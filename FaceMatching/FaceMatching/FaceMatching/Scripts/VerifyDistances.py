import sys
from deepface import DeepFace
import os
from os import path
from datetime import datetime
import numpy as np
import glob
import shutil

encodings_path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching" \
                 "\\FaceMatching\\Encodings"

target_path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching" \
              "\\FaceMatching\\Results\\"

def generate_encoding(img_path, model_name='VGG-Face', enforce_detection=False, detector_backend='opencv'):
    return DeepFace.represent(img_path, model_name=model_name, enforce_detection=enforce_detection,
                              detector_backend=detector_backend)


def open_encodings():
    encoding_dict = dict()
    entries = os.listdir(encodings_path)
    for folder in entries:
        for filename in glob.glob(encodings_path + "\\" + folder + "/*.npy"):
            encoding_dict.setdefault(folder, []).append(np.load(filename))

    return encoding_dict


def find_euclidean_distance(source_representation, test_representation):
    if type(source_representation) == list:
        source_representation = np.array(source_representation)

    if type(test_representation) == list:
        test_representation = np.array(test_representation)

    euclidean_distance = source_representation - test_representation
    euclidean_distance = np.sum(np.multiply(euclidean_distance, euclidean_distance))
    euclidean_distance = np.sqrt(euclidean_distance)
    return euclidean_distance


def l2_normalize(x):
    return x / np.sqrt(np.sum(np.multiply(x, x)))


def call_result(encoding_dict, source_path):
    distances_dict = dict()
    source = generate_encoding(source_path, model_name='Facenet', detector_backend='ssd')

    for name, encodings in encoding_dict.items():
        distance = 0.0
        dist_weight = 0
        for value in encodings:
            tmp = find_euclidean_distance(l2_normalize(source), l2_normalize(value))
            if np.float64(tmp) > 0.8:
                distance += np.float64(tmp)
            elif np.float64(tmp) > 0.5:
                distance += 2 * np.float64(tmp)
                dist_weight += 1
            else:
                distance += 3 * np.float64(tmp)
                dist_weight += 2

        name_source = source_path.split('\\')

        distances_dict[name] = distance / (len(encodings) + dist_weight)

        print('Average between {0} and {1} -> result {2}'.format(name_source[len(name_source) - 1], name,
                                                                 distance / (len(encodings) + dist_weight)))
    save_result(how_is_it(distances_dict), source_path)

def how_is_it(distances_dict):
    result_name = ""
    result_value = sys.float_info.max

    for name, value in distances_dict.items():
        if result_value > value:
            result_name = name
            result_value = value

    if result_value > 1.3:
        result_name = "Unknown"
        print('Person: {0} - distance {1}'.format(result_name, result_value))
    else:
        print('Person: {0} - distance {1}'.format(result_name, result_value))

    return result_name


def save_result(result_name, source_path):
    True if path.exists(target_path + result_name) else os.makedirs(target_path + "\\" + result_name)

    split = source_path.split('\\')
    split[len(split) - 1] = "\\" + result_name + datetime.now().strftime('_%d-%m-%Y-%H-%M-%S') + ".jpg"

    shutil.move(source_path, target_path + result_name + split[len(split) - 1])


def main():
    call_result(open_encodings(), sys.argv[1])


if __name__ == "__main__":
    main()
import sys
from deepface import DeepFace
import os
from os import path
import numpy as np
import glob
from datetime import datetime
import shutil


def verify_new_images():
    path_new_image = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching\\FaceMatching\\tmpImages"
    path_target = "C:C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching\\FaceMatching\\savedImages\\"

    new_images = open_images(path_new_image)

    if new_images:
        save_encodings_from_dir(new_images, "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching\\FaceMatching\\Encodings")

        for image in new_images:
            split = image.split('\\')
            folder = split[len(split) - 2]
            name = split[len(split) - 1]

            True if path.exists(path_target + "\\" + folder) else os.makedirs(path_target + "\\" + folder)

            shutil.move(image, path_target + folder + "\\" + name)


def open_images(path):
    image_list = []
    entries = os.listdir(path)
    for folder in entries:
        for filename in glob.glob(path + "\\" + folder + "/*.jpg"):
            image_list.append(filename)

    return image_list


def open_encodings():
    encoding_dict = dict()
    path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching\\FaceMatching\\Encodings"
    entries = os.listdir(path)
    for folder in entries:
        for filename in glob.glob(path + "\\" + folder + "/*.npy"):
            encoding_dict.setdefault(folder, []).append(np.load(filename))

    return encoding_dict


def generate_encoding(img_path, model_name='VGG-Face', enforce_detection=False, detector_backend='opencv'):
    return DeepFace.represent(img_path, model_name=model_name, enforce_detection=enforce_detection,
                              detector_backend=detector_backend)


def save_encodings_from_dir(images_path, encoding_path):
    for image in images_path:
        split = image.split('\\')
        folder = split[len(split)-2]
        name = split[len(split)-1]

        True if path.exists(encoding_path + "\\" + folder) else os.makedirs(encoding_path + "\\" + folder)

        np.save(encoding_path + "\\" + folder + "\\" + name + datetime.now().strftime("_%d-%m_%S-%f") + '.npy',
               generate_encoding(image, model_name='Facenet', detector_backend='ssd'))


def find_cosine_distance(source_representation, test_representation):
    a = np.matmul(np.transpose(source_representation), test_representation)
    b = np.sum(np.multiply(source_representation, source_representation))
    c = np.sum(np.multiply(test_representation, test_representation))
    return 1 - (a / (np.sqrt(b) * np.sqrt(c)))


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
    source = generate_encoding(source_path, model_name='Facenet', detector_backend='ssd')

    for name, encodings in encoding_dict.items():
        distance = 0.0
        weigth = 0
        for value in encodings:
            tmp = find_euclidean_distance(l2_normalize(source), l2_normalize(value))
            print(np.float64(tmp))

            if np.float64(tmp) > 0.8:
                distance += np.float64(tmp)
            elif np.float64(tmp) > 0.5:
                distance += 2 * np.float64(tmp)
                weigth += 1
            else:
                distance += 3 * np.float64(tmp)
                weigth += 2

        name_source = source_path.split('\\')

        print('Average between {0} and {1} -> result {2}'.format(name_source[len(name_source) - 1], name,
                                                               distance / (len(encodings)+weigth)))


def main():

    #save_encodings_from_dir(open_images(), "C:\\Users\\estagio.sst17\\Documents\\studyPython\\APIDeepFace\\FaceEncoding\\"
    #                                "Encodings")

    #verify_new_images()
    call_result(open_encodings(), sys.argv[1])

    #bad_models = ['Facenet512', 'OpenFace', 'DeepID', 'ArcFace']
    #bad_backends = ['mediapipe']
    #bad_metrics = ['cosine']
    #models = ['VGG-Face', 'Facenet', 'DeepFace']
    #backends = ['opencv', 'ssd', 'mtcnn', 'retinaface']
    #metrics = ['euclidean', 'euclidean_l2']


if __name__ == "__main__":
    main()

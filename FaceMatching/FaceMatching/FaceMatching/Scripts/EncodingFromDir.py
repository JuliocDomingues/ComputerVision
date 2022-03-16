import os
from os import path
import numpy as np
from deepface import DeepFace
from datetime import datetime
import glob
import shutil

target_path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching" \
              "\\FaceMatching\\savedImages\\"

temp_images_path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching" \
                 "\\FaceMatching\\tmpImages"

encodings_path = "C:\\Users\\estagio.sst17\\Documents\\studycsharp\\ComputerVision\\FaceMatching\\FaceMatching" \
                 "\\FaceMatching\\Encodings"


def save_encodings_from_dir(images_list):
    for image in images_list:
        split = image.split('\\')
        folder = split[len(split) - 2]
        name = split[len(split) - 1]
        name = name.split('.')

        True if path.exists(encodings_path + "\\" + folder) else os.makedirs(encodings_path + "\\" + folder)

        np.save(encodings_path + "\\" + folder + "\\" + name[0] + '.npy',
           generate_encoding(image, model_name='Facenet', detector_backend='ssd'))

    move_images(images_list)


def open_images():
    images_list = []
    entries = os.listdir(temp_images_path)
    for folder in entries:

        if folder != 'Unknown':
            for filename in glob.glob(temp_images_path + "\\" + folder + "/*.jpg"):
                images_list.append(filename)

    return images_list


def move_images(images_list):
    for image in images_list:
        split = image.split('\\')
        folder = split[len(split) - 2]
        name = split[len(split) - 1]

        True if path.exists(target_path + "\\" + folder) else os.makedirs(target_path + "\\" + folder)

        shutil.move(image, target_path + folder + "\\" + name)


def generate_encoding(img_path, model_name='VGG-Face', enforce_detection=False, detector_backend='opencv'):
    return DeepFace.represent(img_path, model_name=model_name, enforce_detection=enforce_detection,
                              detector_backend=detector_backend)


def main():
    save_encodings_from_dir(open_images())
    print("All right!!")


if __name__ == "__main__":
    main()

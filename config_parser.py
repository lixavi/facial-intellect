import configparser
import os

class ConfigParser:
    def __init__(self, config_file_path):
        self.config = configparser.ConfigParser()
        self.config.read(config_file_path)

    def get_shape_predictor_path(self):
        return self.config.get('General', 'shape_predictor_path')

    def get_face_detection_model_path(self):
        return self.config.get('General', 'face_detection_model_path')

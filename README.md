# FacialIntellect

FacialIntellect is a Python library that incorporates deep learning models from the dlib and OpenCV libraries for facial recognition tasks. It provides functionalities for face detection, facial landmark detection, and face recognition.

## Features

- Face detection using Haar Cascade classifier or deep learning-based models.
- Facial landmark detection for identifying key points on faces.
- Face recognition using deep learning-based models for recognizing faces and comparing them against a database.

## Usage

```python
from src.detector import FaceDetector
from src.recognizer import FaceRecognizer
from src.config_parser import ConfigParser
```

Initialize the ConfigParser to access configuration parameters:

```
config = ConfigParser('config/config.ini')
shape_predictor_path = config.get_shape_predictor_path()
face_detection_model_path = config.get_face_detection_model_path()
```

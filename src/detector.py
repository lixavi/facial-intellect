import cv2

class FaceDetector:
    def __init__(self, cascade_path):
        self.face_cascade = cv2.CascadeClassifier(cascade_path)

    def detect_faces(self, image):
        gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
        faces = self.face_cascade.detectMultiScale(gray, scaleFactor=1.3, minNeighbors=5)
        return faces

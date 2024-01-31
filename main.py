from src.detector import FaceDetector

def main():
    cascade_path = "data/haarcascade_frontalface_default.xml"
    detector = FaceDetector(cascade_path)

    # Load image
    image = cv2.imread("path_to_image.jpg")

    # Detect faces
    faces = detector.detect_faces(image)

    # Draw rectangles around detected faces
    for (x, y, w, h) in faces:
        cv2.rectangle(image, (x, y), (x + w, y + h), (0, 255, 0), 2)

    # Display the result
    cv2.imshow("Faces Detected", image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

if __name__ == "__main__":
    main()

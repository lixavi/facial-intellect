
import numpy as np
import cv2

def resize_image(image, width=None, height=None, inter=cv2.INTER_AREA):
    """
    Resize the input image while maintaining aspect ratio.
    """
    if width is None and height is None:
        return image
    elif width is None:
        r = height / float(image.shape[0])
        dim = (int(image.shape[1] * r), height)
    else:
        r = width / float(image.shape[1])
        dim = (width, int(image.shape[0] * r))

    resized = cv2.resize(image, dim, interpolation=inter)
    return resized

def load_image(image_path):
    """
    Load an image from disk.
    """
    image = cv2.imread(image_path)
    return image

def show_image(image, title="Image"):
    """
    Display an image.
    """
    cv2.imshow(title, image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()

def save_image(image, output_path):
    """
    Save an image to disk.
    """
    cv2.imwrite(output_path, image)

def draw_text(image, text, position, color=(0, 255, 0), font=cv2.FONT_HERSHEY_SIMPLEX, font_scale=1, thickness=2):
    """
    Draw text on an image.
    """
    cv2.putText(image, text, position, font, font_scale, color, thickness)

def draw_landmarks(image, landmarks, color=(0, 255, 0), radius=2):
    """
    Draw facial landmarks on an image.
    """
    for (x, y) in landmarks:
        cv2.circle(image, (x, y), radius, color, -1)

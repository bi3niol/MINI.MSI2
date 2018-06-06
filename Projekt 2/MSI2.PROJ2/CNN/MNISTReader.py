import keras
from keras.datasets import mnist


class MNISTReader:
    num_classes = 10
    image_rows, image_cols = 28, 28
    input_shape = (image_rows, image_cols, 1)
    X_train = []
    y_train = []
    X_test = []
    y_test = []

    def __init__(self):

        #wczytanie danych...
        (X_train, y_train), (X_test, y_test) = mnist.load_data()
        X_train = X_train.reshape(X_train.shape[0], MNISTReader.image_rows, MNISTReader.image_cols, 1)
        X_test = X_test.reshape(X_test.shape[0], MNISTReader.image_rows, MNISTReader.image_cols, 1)

        #..i normalizacja ([0-255] -> [0-1])
        MNISTReader.X_train = X_train.astype('float32')
        MNISTReader.X_test = X_test.astype('float32')
        MNISTReader.X_train /= 255
        MNISTReader.X_test /= 255
            
        # zamiana reprezentacji kategorii z liczb całkowitych na wektory binarne (one-hot encoding)
        # na przykład: 3 -> [0 0 0 1 0 0 0 0 0 0]

        MNISTReader.y_train = keras.utils.to_categorical(y_train, MNISTReader.num_classes)
        MNISTReader.y_test = keras.utils.to_categorical(y_test, MNISTReader.num_classes)
        return super().__init__()


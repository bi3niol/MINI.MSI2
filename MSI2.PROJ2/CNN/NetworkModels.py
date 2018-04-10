import keras
from keras.datasets import mnist
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPooling2D

#budowa sieci - różne modele
# Conv2D - warstwa konwolucyjna
# MaxPooling2D - redukcja rozmiaru
# Dropout - zapobiega przeuczeniu przez dropowanie części neuronów
# Flatten - "spłaszczenie"
# Dense - warstwa w pełni połączona
# funkcja aktywacji relu - funkcja f(x) = max(x, 0)

def model1(input_shp, num_classes):
    return Sequential([Conv2D(32, kernel_size=(3, 3), activation='relu', input_shape=input_shp),
                    Conv2D(64, (3, 3), activation='relu'),
                    MaxPooling2D(pool_size=(2, 2)),
                    Dropout(0.2),   
                    Flatten(),
                    Dense(128, activation='relu'),
                    #Dropout(0.5),
                    Dense(num_classes, activation='softmax')])

def model2(input_shp, num_classes):
    return Sequential([Conv2D(32, kernel_size=(5, 5), activation='relu', input_shape=input_shp),
                        MaxPooling2D(pool_size=(2, 2)),
                        Dense(128, activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model3(input_shp, num_classes):
    return Sequential([Conv2D(32, kernel_size=(4, 4), activation='relu', input_shape=input_shp),
                        Dense(128, activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model4(input_shp, num_classes):
    return Sequential([Conv2D(32, kernel_size=(2, 2), activation='relu', input_shape=input_shp),
                        Conv2D(64, kernel_size=(3, 3), activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model5(input_shp, num_classes):
    return Sequential([Conv2D(32, kernel_size=(5, 2), activation='relu', input_shape=input_shp),
                    Conv2D(64, (1, 3), activation='relu'),
                    MaxPooling2D(pool_size=(2, 2)),
                    Dropout(0.5),   
                    Flatten(),
                    Dense(128, activation='relu'),
                    Dropout(0.1),
                    Dense(num_classes, activation='softmax')])




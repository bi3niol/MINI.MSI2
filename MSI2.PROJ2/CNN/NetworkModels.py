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

def model1(input_shp, num_classes, kernel, pool, dropout):
    return Sequential([Conv2D(32, kernel_size=kernel, activation='relu', input_shape=input_shp),
                    Conv2D(64, kernel, activation='relu'),
                    MaxPooling2D(pool_size=pool),
                    Dropout(dropout),   
                    Flatten(),
                    Dense(128, activation='relu'),
                    Dense(num_classes, activation='softmax')])

def model2(input_shp, num_classes, kernel, pool ):
    return Sequential([Conv2D(32, kernel_size=kernel, activation='relu', input_shape=input_shp),
                        MaxPooling2D(pool_size=pool),
                        Dense(128, activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model3(input_shp, num_classes, kernel):
    return Sequential([Conv2D(32, kernel_size=kernel, activation='relu', input_shape=input_shp),
                        Dense(128, activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model4(input_shp, num_classes, kernel1, kernel2):
    return Sequential([Conv2D(32, kernel_size=kernel1, activation='relu', input_shape=input_shp),
                        Conv2D(64, kernel_size=kernel2, activation='relu'),
                        Flatten(),
                        Dense(num_classes, activation='softmax')])

def model5(input_shp, num_classes, kernel, pool, dropout ):
    return Sequential([Conv2D(32, kernel_size=kernel, activation='relu', input_shape=input_shp),
                    Conv2D(64, kernel, activation='relu'),
                    MaxPooling2D(pool_size=pool),
                    Conv2D(64, kernel, activation='relu'),
                    Dropout(dropout),   
                    Flatten(),
                    Dense(128, activation='relu'),
                    Dropout(dropout),
                    Dense(num_classes, activation='softmax')])




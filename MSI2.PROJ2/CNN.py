
import keras
from keras.datasets import mnist
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPooling2D

num_classes = 10
image_rows, image_cols = 28, 28
input_shape = (image_rows, image_cols, 1)

#wczytanie danych...
(X_train, y_train), (X_test, y_test) = mnist.load_data()

X_train = X_train.reshape(X_train.shape[0], image_rows, image_cols, 1)
X_test = X_test.reshape(X_test.shape[0], image_rows, image_cols, 1)

#..i normalizacja ([0-255] -> [0-1])
X_train = X_train.astype('float32')
X_test = X_test.astype('float32')
X_train /= 255
X_test /= 255

# zamiana reprezentacji kategorii z liczb całkowitych na wektory binarne (one-hot encoding)
# na przykład: 3 -> [0 0 0 1 0 0 0 0 0 0]

y_train = keras.utils.to_categorical(y_train, num_classes)
y_test = keras.utils.to_categorical(y_test, num_classes)

#budowa sieci
# Conv2D - warstwa konwolucyjna
# MaxPooling2D - redukcja rozmiaru
# Dropout - zapobiega przeuczeniu przez dropowanie części neuronów
# Flatten - "spłaszczenie"
# Dense - warstwa w pełni połączona
# funkcja aktywacji relu - funkcja f(x) = max(x, 0)

model = Sequential([Conv2D(32, kernel_size=(3, 3), activation='relu', input_shape=input_shape),
                    Conv2D(64, (3, 3), activation='relu'),
                    MaxPooling2D(pool_size=(2, 2)),
                    Dropout(0.5),   
                    Flatten(),
                    Dense(128, activation='relu'),
                    Dropout(0.5),
                    Dense(num_classes, activation='softmax')])

# określenie sposobu obliczania błędu (categorical_crossentropy), optymalizatora służącego do aktualizacji wag (Adadelta)
# i metryki oceny sieci (accuracy)

model.compile(loss=keras.losses.categorical_crossentropy,
              optimizer=keras.optimizers.Adadelta(),
              metrics=['accuracy'])
# uczenie sieci:
#   X_train, y_train - dane uczące
#   batch_size - liczba przetwarzanych obrazków na aktualizację
#   epochs - liczba iteracji (w czasie każdej przetwarzane są wszystkie dane uczące)

model.fit(X_train,
          y_train,
          batch_size=128,
          epochs=1,
          verbose=1)

# testowanie

score = model.evaluate(x_test, y_test, verbose=0)
print('loss:', score[0])
print('accuracy:', score[1])

# przewidywanie

#prediction = model.predict_classes(X_test, verbose = 1);
#print(prediction);
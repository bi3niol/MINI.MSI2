
import keras
from keras.models import Sequential
import NetworkModels
import MNISTReader
import time


class CNN:

    def RunCNN(reader: MNISTReader, model: Sequential, iterations: int, optimizerMethod: keras.optimizers=keras.optimizers.Adadelta):
        
        # określenie sposobu obliczania funkcji celu-błędu (categorical_crossentropy), optymalizatora służącego do minimalizacji funkcji celu przez zmianę wag (Adadelta)
        # i metryki oceny sieci (accuracy)
        model.compile(loss=keras.losses.categorical_crossentropy, optimizer=optimizerMethod(), metrics=['accuracy'])
        startTime = time.time()
        # uczenie sieci:
        #   X_train, y_train - dane uczące
        #   batch_size - liczba przetwarzanych obrazków na aktualizację
        #   epochs - liczba iteracji (w czasie każdej przetwarzane są wszystkie dane uczące)
        trainRes = model.fit(reader.X_train[1:60000:10], reader.y_train[1:60000:10], batch_size=128, epochs=iterations, verbose=1, validation_data = (reader.X_test,reader.y_test))
        t = time.time() - startTime

        return trainRes.history, t
   
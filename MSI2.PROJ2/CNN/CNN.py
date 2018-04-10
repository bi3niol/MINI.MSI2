
import keras
from keras.models import Sequential
import NetworkModels
import MNISTReader
import time


class CNN:

    def RunCNN(reader: MNISTReader, model: Sequential, iterations: int, lossFunc: keras.losses=keras.losses.categorical_crossentropy, optimizerMethod: keras.optimizers=keras.optimizers.Adadelta):
        
        # określenie sposobu obliczania błędu (categorical_crossentropy), optymalizatora służącego do aktualizacji wag (Adadelta)
        # i metryki oceny sieci (accuracy)
        model.compile(loss=lossFunc, optimizer=optimizerMethod(), metrics=['accuracy'])
        startTime = time.time()
        # uczenie sieci:
        #   X_train, y_train - dane uczące
        #   batch_size - liczba przetwarzanych obrazków na aktualizację
        #   epochs - liczba iteracji (w czasie każdej przetwarzane są wszystkie dane uczące)
        model.fit(reader.X_train, reader.y_train, batch_size=128, epochs=iterations, verbose=1)
        t = time.time() - startTime
        # testowanie
        score = model.evaluate(reader.X_test, reader.y_test, verbose=0)
        #print('loss:', score[0])
        #print('accuracy:', score[1])
        return score[1], t
   

import keras
from keras.models import Sequential
import NetworkModels
import MNISTReader
import time


class CNN:

    def RunCNN(reader: MNISTReader, model: Sequential, iterations: int, optimizerMethod: keras.optimizers=keras.optimizers.Adadelta):
        
        # określenie sposobu obliczania funkcji celu-błędu
        # (categorical_crossentropy), optymalizatora służącego do minimalizacji
        # funkcji celu przez zmianę wag (Adadelta)
        # i metryki oceny sieci (accuracy)
        model.compile(loss=keras.losses.categorical_crossentropy, optimizer=optimizerMethod(), metrics=['accuracy'])
        _times=[]
        _test_acc = []
        _test_loss=[]
        _val_loss=[]
        _val_acc=[]
        _train_acc = []
        _train_loss = []
        # uczenie sieci:
        #   X_train, y_train - dane uczące
        #   batch_size - liczba przetwarzanych obrazków na aktualizację
        #   epochs - liczba iteracji (w czasie każdej przetwarzane są wszystkie
        #   dane uczące)
        i = 1
        startTime = time.time()
        for i in range (iterations):
            trainRes = model.fit(reader.X_train, reader.y_train, batch_size=128, epochs=1, verbose=1, validation_split = 0.2)
            t = time.time() - startTime
            
            _train_acc.append(trainRes.history["acc"][0])
            _train_loss.append(trainRes.history["loss"][0])

            _val_acc.append(trainRes.history["val_acc"][0])
            _val_loss.append(trainRes.history["val_loss"][0])
            _times.append(t)

            rr = model.evaluate(reader.X_test,reader.y_test)

            _test_loss.append(rr[0])
            _test_acc.append(rr[1])

        return (_test_loss, _test_acc, _val_loss, _val_acc, _train_loss, _train_acc, _times)
   
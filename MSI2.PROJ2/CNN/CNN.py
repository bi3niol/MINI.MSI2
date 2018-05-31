
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
        _acc = []
        _loss=[]
        _val_loss=[]
        _val_acc=[]
        # uczenie sieci:
        #   X_train, y_train - dane uczące
        #   batch_size - liczba przetwarzanych obrazków na aktualizację
        #   epochs - liczba iteracji (w czasie każdej przetwarzane są wszystkie
        #   dane uczące)
        i = 1
        startTime = time.time()
        while i <= iterations:
            trainRes = model.fit(reader.X_train, reader.y_train, batch_size=128, epochs=1, verbose=1,validation_split = 0.2)
            t = time.time() - startTime
            #acc loss - ze zbioru treningowego
            _val_acc.append(trainRes.history["val_acc"][0])
            _val_loss.append(trainRes.history["val_loss"][0])
            _times.append(t)
            rr = model.evaluate(reader.X_test,reader.y_test)
            #acc loss - ze zbiuru testowego
            _loss.append(rr[0])
            _acc.append(rr[1])
            pass

        return (_loss,_acc,_val_loss,_val_acc,_times)
   
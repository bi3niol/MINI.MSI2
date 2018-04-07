import keras
from keras.datasets import mnist
from keras.models import Sequential
from keras.layers import Dense, Dropout, Flatten, Conv2D, MaxPooling2D
import pandas as pd

class CNNTester(object):
    """
    class description
    """
    num_classes = 10
    image_rows, image_cols = 28, 28
    input_shape = (image_rows, image_cols, 1)
    X_train = []
    y_train = []
    X_test = []
    y_test = []

    def __init__(self):
        if(len(CNNTester.X_train) == 0):
            (X_train, y_train), (X_test, y_test) = mnist.load_data()
            X_train = X_train.reshape(X_train.shape[0], CNNTester.image_rows, CNNTester.image_cols, 1)
            X_test = X_test.reshape(X_test.shape[0], CNNTester.image_rows, CNNTester.image_cols, 1)

            CNNTester.X_train = X_train.astype('float32')
            CNNTester.X_test = X_test.astype('float32')
            CNNTester.X_train /= 255
            CNNTester.X_test /= 255
            
            CNNTester.y_train = keras.utils.to_categorical(y_train, CNNTester.num_classes)
            CNNTester.y_test = keras.utils.to_categorical(y_test, CNNTester.num_classes)
        return super().__init__()

    def TestMethod(self):
        colNames = ['efficiency','accuracy',]
        testResults = pd.DataFrame([],columns=colNames)

        layersSet = []
        model = self.GetModelTrained()
        return
    def OneConvOneDense(self):
        data = []
        for x in range(3,28,4):
            print('calculate for ',x)
            model, tt,history = self.GetModelTrained([Conv2D(32, kernel_size=(x, x), activation='relu', input_shape=(28,28,1)),
                        Flatten(),
                        Dense(10, activation='softmax')],step=4,epochsM=6)
            data.append({'time':tt,'itterations':6,'acc':history.history['acc'],'kernelSize':x})
            df = pd.DataFrame(data)
            print('saving result')
            df.to_csv("./OneConvOneDense.csv",';')
            print('saved to OneConvOneDense.csv')
        pass

    def GetModelTrained(self,layers,lossM=keras.losses.categorical_crossentropy,optM=keras.optimizers.Adadelta,metricsM=['accuracy'],epochsM=1,batch_sizeM=128,step=1):
        model = Sequential(layers)

        model.compile(loss=lossM,
              optimizer=optM(),
              metrics=metricsM)
        import time
        ct = time.time()
        history = model.fit(CNNTester.X_train[0:len(CNNTester.X_train):step],
          CNNTester.y_train[0:len(CNNTester.y_train):step],
          batch_size=batch_sizeM,
          epochs=epochsM,
          verbose=1,
          validation_data=(CNNTester.X_test,CNNTester.y_test))
        tt = time.time() - ct
        return model, tt, history

if(__name__ == "__main__"):
    print('sadw')
    train = CNNTester()
    train.OneConvOneDense()
    
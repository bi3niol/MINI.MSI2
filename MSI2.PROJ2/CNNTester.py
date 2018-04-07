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
        if(len(CNNTester.X_train)== 0):
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
        testResults =pd.DataFrame([],columns=colNames)

        layersSet = []
        model = self.GetModelTrained()
        return

    def GetModelTrained(self,layers,lossM=keras.losses.categorical_crossentropy,optM=keras.optimizers.Adadelta,metricsM=['accuracy'],epochsM=1,batch_sizeM=128):
        model = Sequential(layers)

        model.compile(loss=lossM,
              optimizer=optM(),
              metrics=metricsM)

        model.fit(CNNTester.X_train,
          CNNTester.y_train,
          batch_size=batch_sizeM,
          epochs=epochsM,
          verbose=1)

        return model

if(__name__=="__main__"):
    tester = CNNTester()
    model = tester.GetModelTrained([Conv2D(32, kernel_size=(28, 28), activation='relu', input_shape=(28,28,1)),
                    #Conv2D(64, (3, 3), activation='relu'),
                    #MaxPooling2D(pool_size=(2, 2)),
                    #Dropout(0.2),   
                    Flatten(),
                    #Dense(128, activation='relu'),
                    #Dropout(0.5),
                    Dense(10, activation='softmax')])
    score = model.evaluate(CNNTester.X_test,CNNTester.y_test, verbose=0)
    print('loss:', score[0])
    print('accuracy:', score[1])
    print(score)
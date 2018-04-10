import MNISTReader
import CNN
import NetworkModels
import time
import pandas as pd
import keras
from keras import Sequential


class CNNTester:

    def testModel(reader: MNISTReader.MNISTReader, model: keras.Sequential, modelName: str):
        data = []
        file = str.format('{}_{}.csv',modelName, time.time())
        for i in range(1,2):
            print('Calculating for ', i)
            accuracy, duration = CNN.CNN.RunCNN(reader, model, i)
            data.append({'iterations': i, 'time': duration,'accuracy': accuracy})
            df = pd.DataFrame(data)
            print('Saving results...')
            df.to_csv("./"+file,';')
            print('Results saved to ',file)
        pass

   
    #def OneConvMaxPoolTwoDense():
    #    data = []
    #    file = 'OneConvMaxPoolTwoDense' + str.format('{}',time.time()) + '.csv'
    #    for x in [3,7,11,14]:
    #        print('calculate for ',x)
    #        model, tt,history = GetModelTrained([Conv2D(32, kernel_size=(x, x), activation='relu', input_shape=(28,28,1)),
    #                    MaxPooling2D(pool_size=(2, 2)),
    #                    Dense(128, activation='relu'),
    #                    Flatten(),
    #                    Dense(10, activation='softmax')],step=4,epochsM=6)
    #        data.append({'time':tt,'itterations':6,'acc':history.history['acc'],'kernelSize':x})
    #        df = pd.DataFrame(data)
    #        print('saving result')
    #        df.to_csv("./" + file,';')
    #        print('saved to ',file)
    #    pass

    #def OneConvTwoDense(self):
    #    data = []
    #    file = 'OneConvTwoDense' + str.format('{}',time.time()) + '.csv'
    #    for x in [3,7,11,14,20,28]:
    #        print('calculate for ',x)
    #        model, tt,history = self.GetModelTrained([Conv2D(32, kernel_size=(x, x), activation='relu', input_shape=(28,28,1)),
    #                    Dense(128, activation='relu'),
    #                    Flatten(),
    #                    Dense(10, activation='softmax')],step=4,epochsM=6)
    #        data.append({'time':tt,'itterations':6,'acc':history.history['acc'],'kernelSize':x})
    #        df = pd.DataFrame(data)
    #        print('saving result')
    #        df.to_csv("./" + file,';')
    #        print('saved to ',file)
    #    pass
    #def TwoConvOneDense(self):
    #    data = []
    #    file = 'TwoConvOneDense' +str.format('{}',time.time())+ '.csv'
    #    for x in [3,7,11,20,28]:
    #        print('calculate for ',x)
    #        model, tt,history = self.GetModelTrained([Conv2D(32, kernel_size=(x, x), activation='relu', input_shape=(28,28,1)),
    #                    Conv2D(64, (3, 3), activation='relu'),
    #                    Flatten(),
    #                    Dense(10, activation='softmax')],step=4,epochsM=6)
    #        data.append({'time':tt,'itterations':6,'acc':history.history['acc'],'kernelSize':x})
    #        df = pd.DataFrame(data)
    #        print('saving result')
    #        df.to_csv("./" + file,';')
    #        print('saved to ',file)
    #    pass

    if __name__ == '__main__':
        reader = MNISTReader.MNISTReader()
        testModel(reader, NetworkModels.model1(reader.input_shape, reader.num_classes), "model1")

    
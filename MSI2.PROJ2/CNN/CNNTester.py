import MNISTReader
import CNN
import NetworkModels
import time
import pandas as pd


class CNNTester:

    #def TestMethod():
    #    colNames = ['accuracy','train_time',]
    #    testResults = pd.DataFrame([],columns=colNames)

    #    layersSet = []
    #    model = self.GetModelTrained()
    #    return

    def model1(reader: MNISTReader.MNISTReader):
        data = []
        file = 'model1' + str.format('{}',time.time()) + '.csv'
        for x in range(3,28,4):
            print('calculate for ',x)
            accuracy, duration = CNN.CNN.RunCNN(reader, NetworkModels.model1(reader.input_shape, reader.num_classes), 1)
            data.append({'time': duration,'itterations': 1,'acc': accuracy})
            df = pd.DataFrame(data)
            print('saving result')
            df.to_csv("./"+file,';')
            print('saved to ',file)
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
        model1(reader)

    
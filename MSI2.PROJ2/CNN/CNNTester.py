import MNISTReader
import CNN
import NetworkModels
import time
import pandas as pd
import keras
from keras import Sequential


class CNNTester:

    def testModel(reader: MNISTReader.MNISTReader, model: keras.Sequential, modelName: str, data):
        for i in range(1,4):
            print(modelName+ ' - calculating for ', i)
            accuracy, duration = CNN.CNN.RunCNN(reader, model, i)
            data.append({'model': modelName, 'iterations': 5, 'time': duration,'accuracy': accuracy})
        pass

    if __name__ == '__main__':
        file = str.format('test_{}.csv', time.time())
        data = []
        reader = MNISTReader.MNISTReader()
        testModel(reader, NetworkModels.model1(reader.input_shape, reader.num_classes), "model1", data)
        testModel(reader, NetworkModels.model2(reader.input_shape, reader.num_classes), "model2", data)
        testModel(reader, NetworkModels.model3(reader.input_shape, reader.num_classes), "model3", data)
        testModel(reader, NetworkModels.model4(reader.input_shape, reader.num_classes), "model4", data)
        testModel(reader, NetworkModels.model5(reader.input_shape, reader.num_classes), "model5", data)

        df = pd.DataFrame(data)
        print('Saving results...')
        df.to_csv("./"+file,';')
        print('Results saved to ',file)

    
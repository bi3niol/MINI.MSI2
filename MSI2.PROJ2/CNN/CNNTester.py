import MNISTReader
import CNN
import NetworkModels
import time
import pandas as pd
import keras
from keras import Sequential


class CNNTester:
    def testModel(reader: MNISTReader.MNISTReader, model: keras.Sequential, modelName: str, data, FileName="CNN_TestResult.csv"):
        if model == None:
            print("invalid model {}",modelName)
            return
        history, duration = CNN.CNN.RunCNN(reader, model, 5)
        data.append({'model': modelName, 'iterations': 5, 'time': round(duration, 2),'acc': [ round(elem, 4) for elem in history['acc']],
                    'loss': [ round(elem, 4) for elem in history['loss']], 'val_acc': [ round(elem, 4) for elem in history['val_acc']],'val_loss': [ round(elem, 4) for elem in history['val_loss']]})

        df = pd.DataFrame(data)
        print('Saving results...')
        df.to_csv("./" + FileName,';')
        print('Results saved to ',FileName)

    if __name__ == '__main__':
        fileName = str.format('CNN_test_{}.csv', time.time())
        data = []
        reader = MNISTReader.MNISTReader()
        for k in range(2,20,5):
            for p in range(2,3):
                for d in range(1,6):
                    testModel(reader, NetworkModels.model1(reader.input_shape, reader.num_classes, (k, k), (p, p), d / 10), str.format("model1, kernel: ({},{}), pool: ({}, {}), dropout: {} ", k, k, p, p, d / 10), data)
        for k in range(2,20,5):
            for p in range(2,3):
                testModel(reader, NetworkModels.model2(reader.input_shape, reader.num_classes, (k, k), (p, p)), str.format("model2, kernel: ({},{}), pool: ({}, {}) ", k, k, p, p), data)
        
        for k in range(2,20,5):
            testModel(reader, NetworkModels.model3(reader.input_shape, reader.num_classes, (k, k)), str.format("model3, kernel: ({},{})", k, k), data)
        for k1 in range(2,20,5):
            for k2 in range(2,20,5):
                    testModel(reader, NetworkModels.model4(reader.input_shape, reader.num_classes, (k1, k1), (k2, k2)), str.format("model4, kernel1: ({},{}), kernel2:({}, {})", k1, k1, k2, k2), data)
        for k in range(12,20,5):
            for p in range(2,3):
                for d in range (1,6):
                    testModel(reader, NetworkModels.model5(reader.input_shape, reader.num_classes, (k, k), (p, p), d/10  ), str.format("model5, kernel: ({},{}), pool: ({}, {}), dropout: {} ", k, k, p, p, d/10), data)
        df = pd.DataFrame(data)
        print('Saving results...')
        df.to_csv("./" + fileName,';')
        print('Results saved to ',fileName)
    
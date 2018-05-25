#   On the basis of tutorial:
#   https://ksopyla.com/machine-learning/mnist-svm-klasyfikacja-recznie-pisanych-cyfr/#more-37

import matplotlib.pyplot as plt
import numpy as np
import time
import pandas as pd
 
# Import datasets, classifiers and performance metrics
from sklearn import datasets, svm, metrics
 
#fetch original mnist dataset
from sklearn.datasets import fetch_mldata
mnist = fetch_mldata('MNIST original', data_home='./')
 
#data field is 70k x 784 array, each row represents pixels from 28x28=784 image
images = mnist.data
targets = mnist.target

res = []
FileName = str.format('SVM_test_{}.csv', time.time())

def GetClassifiers():
        for c in [1,2,3,4,5,6]:
            for g in [1,4,7,10,14]:
                yield (c/5,g/1000,svm.SVC(C=c/5,gamma=g/1000))

def AccuracyFunc(orgin,predic):
        tmp = orgin == predic
        res = np.sum(tmp) / len(orgin) * 100
        return res    

#sample smaller size for testing
rand_idx = np.random.choice(images.shape[0],1000)
 
#scale data for [0,255] -> [0,1]
X_data =images[rand_idx]/255.0
Y      = targets[rand_idx]
 
#split data to train and test 
from sklearn.cross_validation import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X_data, Y, test_size=0.15, random_state=42)

for (c, g, classifier) in GetClassifiers():
    print(str.format('C = {} G = {} classifier = {} ',c,g,classifier))
    startTime = time.time()
    classifier.fit(X_train, y_train)
    elapsedTime = time.time() - startTime

    predicted = classifier.predict(X_test)
    accuracy = AccuracyFunc(y_test,predicted)
    res.append({"C":c,"G":g,"Accuracy":round(accuracy, 4),"Time": round(elapsedTime, 2)})

    df = pd.DataFrame(res)
    print('Saving results...')
    df.to_csv("./" + FileName,';')
    print('Results saved to ',FileName)
 
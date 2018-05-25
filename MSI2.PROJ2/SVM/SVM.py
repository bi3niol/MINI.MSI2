#   On the basis of tutorial:
#   https://ksopyla.com/machine-learning/mnist-svm-klasyfikacja-recznie-pisanych-cyfr/#more-37

import matplotlib.pyplot as plt
import numpy as np
 
# Import datasets, classifiers and performance metrics
from sklearn import datasets, svm, metrics
 
#fetch original mnist dataset
from sklearn.datasets import fetch_mldata
mnist = fetch_mldata('MNIST original', data_home='./')
 
#minist object contains: data, COL_NAMES, DESCR, target fields
#you can check it by running
#mnist.keys()
 
#data field is 70k x 784 array, each row represents pixels from 28x28=784 image
images = mnist.data
targets = mnist.target

##test wyświetlania
#plt.imshow(images[30000].reshape(28,28), cmap=plt.cm.gray_r, interpolation='nearest')
#plt.axis('off')
#plt.title("Digit: {}".format(targets[30000]))
#plt.show()

#sample smaller size for testing
rand_idx = np.random.choice(images.shape[0],10000)
 
#scale data for [0,255] -> [0,1]
X_data =images[rand_idx]/255.0
Y      = targets[rand_idx]
 
#split data to train and test 
from sklearn.cross_validation import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X_data, Y, test_size=0.15, random_state=42)
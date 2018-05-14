'''
This script performs the basic process for applying a machine learning
algorithm to a dataset using Python libraries.

The four steps are:
   1. Download a dataset (using pandas)
   2. Process the numeric data (using numpy)
   3. Train and evaluate learners (using scikit-learn)
   4. Plot and compare results (using matplotlib)


The data is downloaded from URL, which is defined below. As is normal
for machine learning problems, the nature of the source data affects
the entire solution. When you change URL to refer to your own data, you
will need to review the data processing steps to ensure they remain
correct.

============
Example Data
============
The example is from http://mlr.cs.umass.edu/ml/datasets/Spambase
It contains pre-processed metrics, such as the frequency of certain
words and letters, from a collection of emails. A classification for
each one indicating 'spam' or 'not spam' is in the final column.
See the linked page for full details of the data set.

This script uses three classifiers to predict the class of an email
based on the metrics. These are not representative of modern spam
detection systems.
'''

# Remember to update the script for the new data when you change this URL
URL = "http://mlr.cs.umass.edu/ml/machine-learning-databases/spambase/spambase.data"

# Uncomment this call when using matplotlib to generate images
# rather than displaying interactive UI.
#import matplotlib
#matplotlib.use('Agg')
import pandas as pd
from pandas import read_table
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import keras
from keras.datasets import mnist

try:
    # [OPTIONAL] Seaborn makes plots nicer
    import seaborn
except ImportError:
    pass

# =====================================================================
def download_data_sets():
    (X_train, y_train), (X_test, y_test) = mnist.load_data()
    X_train = X_train.reshape(X_train.shape[0],28 * 28)
    X_test = X_test.reshape(X_test.shape[0],28 * 28)

    X_train = X_train.astype('float32')
    X_test = X_test.astype('float32')
    X_train[X_train > 0.5] = 1
    X_test[X_test > 0.5] = 1
    X_train[X_train <= 0.5] = 0
    X_test[X_test <= 0.5] = 0
    print(np.sum(X_test))

    #y_train = keras.utils.to_categorical(y_train, 10)
    #y_test = keras.utils.to_categorical(y_test, 10)

    return (X_train[1::1], y_train[1::1]), (X_test, y_test)


# =====================================================================
def evaluate_classifier(X_train, X_test, y_train, y_test):
    from sklearn.svm import LinearSVC, NuSVC, SVC
    from sklearn.ensemble import AdaBoostClassifier

    from sklearn.metrics import precision_recall_curve, f1_score
    from sklearn import metrics

    def GetClassifiers():
        for c in [1,2,3,4,5,6]:
            for g in [1,4,7,10,14]:
                yield (c/5,g/1000,SVC(C=c/5,gamma=g/1000))

    def AccuracyFunc(orgin,predic):
        tmp = orgin == predic
        res = np.sum(tmp) / len(orgin) * 100
        return res

    import time

    res = []
    FileName = str.format('SVM_test_{}.csv', time.time())
    for (c, g, classifier) in GetClassifiers():
        # Fit the classifier
        print(str.format('C = {} G = {} classifier = {} ',c,g,classifier))
        startTime = time.time()
        classifier.fit(X_train, y_train)
        tt = time.time() - startTime

        predicted = classifier.predict(X_test)
        accuracy = AccuracyFunc(y_test,predicted)
        res.append({"C":c,"G":g,"Accuracy":accuracy,"Time":tt})

        df = pd.DataFrame(res)
        print('Saving results...')
        df.to_csv("./" + FileName,';')
        print('Results saved to ',FileName)
        # =====================================================================
def plot(results):
    fig = plt.figure(figsize=(6, 6))
    fig.canvas.set_window_title('Classifying data from ' + URL)

    for label, precision, recall in results:
        plt.plot(recall, precision, label=label)

    plt.title('Precision-Recall Curves')
    plt.xlabel('Precision')
    plt.ylabel('Recall')
    plt.legend(loc='lower left')

    # Let matplotlib improve the layout
    plt.tight_layout()

    # ==================================
    # Display the plot in interactive UI
    plt.show()

    # To save the plot to an image file, use savefig()
    #plt.savefig('plot.png')

    # Open the image file with the default image viewer
    #import subprocess
    #subprocess.Popen('plot.png', shell=True)

    # To save the plot to an image in memory, use BytesIO and savefig()
    # This can then be written to any stream-like object, such as a
    # file or HTTP response.
    #from io import BytesIO
    #img_stream = BytesIO()
    #plt.savefig(img_stream, fmt='png')
    #img_bytes = img_stream.getvalue()
    #print('Image is {} bytes - {!r}'.format(len(img_bytes), img_bytes[:8] +
    #b'...'))

    # Closing the figure allows matplotlib to release the memory used.
    plt.close()


# =====================================================================
if __name__ == '__main__':

    (X_train, y_train), (X_test, y_test) = download_data_sets()
    print("Evaluating classifiers")
    evaluate_classifier(X_train, X_test, y_train, y_test)

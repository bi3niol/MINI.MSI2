import pandas as pd

if __name__ == '__main__':
    cnnGeneral = pd.read_csv("CNN_test_1527289066.5262716.csv",sep=";")
    data = []
    for index, row in cnnGeneral.iterrows():
        data.append({"model": row["model"], "time":row["time"],"acc":eval(row["acc"])[4],"loss":eval(row["loss"])[4],
                     "val_acc":eval(row["val_acc"])[4],"val_loss":eval(row["val_loss"])[4]})

    FileName = "CNN_General.csv"
    df = pd.DataFrame(data)
    print('Saving results...')
    df.to_csv("./best-models/" + FileName,';')
    print('Results saved to ',FileName)
    import re
    for file in ["CNN_Model1.csv","CNN_Model4.csv"]:
        cnnGeneral = pd.read_csv(file,sep=";")
        for index, row in cnnGeneral.iterrows():
            data = []
            for i in range((row["iterations"])):
                data.append({"time":eval(row["time"])[i],"test_acc":eval(row["test_acc"])[i],"test_loss":eval(row["test_loss"])[i],
                             "train_acc":eval(row["train_acc"])[i],"train_loss":eval(row["train_loss"])[i],"val_acc":eval(row["val_acc"])[i],"val_loss":eval(row["val_loss"])[i]})
            df = pd.DataFrame(data)
            print('Saving results...')
            fileName =  re.sub("[. ,():]+","-",row["model"])
            print(fileName)
            df.to_csv("./best-models/" + fileName+".csv",';')
            print('Results saved to ',fileName+".csv")


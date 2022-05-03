import os
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import warnings
from minisom import MiniSom
import numpy as np
import math
from sklearn.decomposition import PCA

class DTW:

    def __init__(self, sequence1, sequence2):
        self.s1 = sequence1
        self.s2 = sequence2

    def d(self,x,y):
        return np.sum((x-y)**2)/1000

    def dtw_distance(self, mww=10000000):

        ts_a = self.s1
        ts_b = self.s2
        M, N = np.shape(ts_a)[1], np.shape(ts_b)[1]
        # print('M', M)
        # print("N", N)
        cost = np.ones((M, N))

        # Initialize the first row and column
        cost[0, 0] = self.d(ts_a[:,0], ts_b[:,0])
        for i in range(1, M):
            cost[i, 0] = cost[i-1, 0] + self.d(ts_a[:,i], ts_b[:,0])

        for j in range(1, N):
            cost[0, j] = cost[0, j-1] + self.d(ts_a[:,0], ts_b[:,j])

        # Populate rest of cost matrix within window
        for i in range(1, M):
            for j in range(max(1, i - mww), min(N, i + mww)):
                choices = cost[i-1, j-1], cost[i, j-1], cost[i-1, j]
                cost[i, j] = min(choices) + self.d(ts_a[:,i], ts_b[:,j])

        # Return DTW distance given window
        return cost[-1, -1]

if __name__ == '__main__':

    data1 = pd.read_csv('D:/Whoop_then_Pull_PCA.csv')
    data2 = pd.read_csv('D:/Flying_Around_PCA.csv')
    data3 = pd.read_csv('D:/Flying_Around2_PCA.csv')
    data4 = pd.read_csv('D:/Simply_Whoop_PCA.csv')
    data5 = pd.read_csv('D:/Spin_and_Whoop_then_Pull_PCA.csv')
    data6 = pd.read_csv('D:/Straight_PCA.csv')

    data_for_PCA1 = data1.to_numpy()

    data_for_PCA2 = data2.to_numpy()
    data_for_PCA3 = data3.to_numpy()
    data_for_PCA4 = data4.to_numpy()
    data_for_PCA5 = data5.to_numpy()
    data_for_PCA6 = data6.to_numpy()

    len_1 = len(data_for_PCA1)
    len_2 = len(data_for_PCA2)+len_1
    len_3 = len(data_for_PCA3)+len_2
    len_4 = len(data_for_PCA4)+len_3
    len_5 = len(data_for_PCA5)+len_4
    len_6 = len(data_for_PCA6)+len_5

    data_for_PCA = np.concatenate((data_for_PCA1, data_for_PCA2), axis=0)
    data_for_PCA = np.concatenate((data_for_PCA, data_for_PCA3), axis=0)
    data_for_PCA = np.concatenate((data_for_PCA, data_for_PCA4), axis=0)
    data_for_PCA = np.concatenate((data_for_PCA, data_for_PCA5), axis=0)
    data_for_PCA = np.concatenate((data_for_PCA, data_for_PCA6), axis=0)
    print(len_1)
    print(len(data_for_PCA))

    data_for_PCA = np.delete(data_for_PCA, 0, axis=1)
    data_for_PCA = np.delete(data_for_PCA, 0, axis=1)

    print(data_for_PCA)
    pca = PCA(n_components=2)
    pca.fit(np.array(data_for_PCA))

    result=pca.transform(data_for_PCA)
    print("variance", pca.explained_variance_ratio_)
    w_x,  w_y = zip(*[d for d in result])
    w_x = np.array(w_x)
    w_y = -1 * np.array(w_y)
    data_after_PCA1 = {'Wx':w_x[0:len_1], 'Wy':w_y[0:len_1]}
    Data_PCA1 = pd.DataFrame(data_after_PCA1)
    data_after_PCA2 = {'Wx':w_x[len_1:len_2], 'Wy':w_y[len_1:len_2]}
    Data_PCA2 = pd.DataFrame(data_after_PCA2)
    data_after_PCA3 = {'Wx':w_x[len_2:len_3], 'Wy':w_y[len_2:len_3]}
    Data_PCA3 = pd.DataFrame(data_after_PCA3)
    data_after_PCA4 = {'Wx':w_x[len_3:len_4], 'Wy':w_y[len_3:len_4]}
    Data_PCA4 = pd.DataFrame(data_after_PCA4)
    data_after_PCA5 = {'Wx':w_x[len_4:len_5], 'Wy':w_y[len_4:len_5]}
    Data_PCA5 = pd.DataFrame(data_after_PCA5)
    data_after_PCA6 = {'Wx':w_x[len_5:len_6], 'Wy':w_y[len_5:len_6]}
    Data_PCA6 = pd.DataFrame(data_after_PCA6)
    # print("w_x", w_x)
    # print("w_y", w_y)
    plt.figure(figsize = (8, 6))
    sns.scatterplot(data=Data_PCA1,x='Wx',y='Wy',label='Whoop_then_Pull')
    sns.scatterplot(data=Data_PCA2,x='Wx',y='Wy',label='Flying_Around')
    sns.scatterplot(data=Data_PCA3,x='Wx',y='Wy',label='Flying_Around2')
    sns.scatterplot(data=Data_PCA4,x='Wx',y='Wy',label='Simply_Whoop')
    sns.scatterplot(data=Data_PCA5,x='Wx',y='Wy',label='Spin_and_Whoop_then_Pull')
    sns.scatterplot(data=Data_PCA6,x='Wx',y='Wy',label='Straight')

    #focus_data.to_csv('D:/Flying_Around2_PCA.csv', encoding='utf_8_sig')
    plt.grid()

    plt.show()

    data_DTW_1 = DTW(np.transpose(Data_PCA1.to_numpy()), np.transpose(Data_PCA2.to_numpy()))
    print('1 / 2', data_DTW_1.dtw_distance())

    data_DTW_2 = DTW(np.transpose(Data_PCA1.to_numpy()), np.transpose(Data_PCA3.to_numpy()))
    print('1 / 3', data_DTW_2.dtw_distance())

    data_DTW_3 = DTW(np.transpose(Data_PCA1.to_numpy()), np.transpose(Data_PCA4.to_numpy()))
    print('1 / 4', data_DTW_3.dtw_distance())

    data_DTW_4 = DTW(np.transpose(Data_PCA1.to_numpy()), np.transpose(Data_PCA5.to_numpy()))
    print('1 / 5', data_DTW_4.dtw_distance())

    data_DTW_5 = DTW(np.transpose(Data_PCA1.to_numpy()), np.transpose(Data_PCA6.to_numpy()))
    print('1 / 6', data_DTW_5.dtw_distance())

    data_DTW_6 = DTW(np.transpose(Data_PCA2.to_numpy()), np.transpose(Data_PCA3.to_numpy()))
    print('2 / 3', data_DTW_6.dtw_distance())

    data_DTW_7 = DTW(np.transpose(Data_PCA2.to_numpy()), np.transpose(Data_PCA4.to_numpy()))
    print('2 / 4', data_DTW_7.dtw_distance())

    data_DTW_8 = DTW(np.transpose(Data_PCA2.to_numpy()), np.transpose(Data_PCA5.to_numpy()))
    print('2 / 5', data_DTW_8.dtw_distance())

    data_DTW_9 = DTW(np.transpose(Data_PCA2.to_numpy()), np.transpose(Data_PCA6.to_numpy()))
    print('2 / 6', data_DTW_9.dtw_distance())

    data_DTW_10 = DTW(np.transpose(Data_PCA3.to_numpy()), np.transpose(Data_PCA4.to_numpy()))
    print('3 / 4', data_DTW_10.dtw_distance())

    data_DTW_11 = DTW(np.transpose(Data_PCA3.to_numpy()), np.transpose(Data_PCA5.to_numpy()))
    print('3 / 5', data_DTW_11.dtw_distance())

    data_DTW_12 = DTW(np.transpose(Data_PCA3.to_numpy()), np.transpose(Data_PCA6.to_numpy()))
    print('3 / 6', data_DTW_12.dtw_distance())

    data_DTW_13 = DTW(np.transpose(Data_PCA4.to_numpy()), np.transpose(Data_PCA5.to_numpy()))
    print('4 / 5', data_DTW_13.dtw_distance())

    data_DTW_14 = DTW(np.transpose(Data_PCA4.to_numpy()), np.transpose(Data_PCA6.to_numpy()))
    print('4 / 6', data_DTW_14.dtw_distance())

    data_DTW_15 = DTW(np.transpose(Data_PCA5.to_numpy()), np.transpose(Data_PCA6.to_numpy()))
    print('5 / 6', data_DTW_15.dtw_distance())

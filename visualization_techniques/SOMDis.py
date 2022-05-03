import os
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import warnings
from minisom import MiniSom
import numpy as np
from sklearn.decomposition import PCA
warnings.filterwarnings(action='ignore')
sns.set(style='white', color_codes=True)
plt.style.use('seaborn-whitegrid')

# Press the green button in the gutter to run the script.
if __name__ == '__main__':

    # data = [[ 0.80 , 0.55 , 0.22 , 0.03 ],
    #         [ 0.82 , 0.50 , 0.23 , 0.03 ],
    #         [ 0.80 , 0.54 , 0.22 , 0.03 ],
    #         [ 0.80 , 0.53 , 0.26 , 0.03 ],
    #         [ 0.79 , 0.56 , 0.22 , 0.03 ],
    #         [ 0.75 , 0.60 , 0.25 , 0.03 ],
    #         [ 0.77 , 0.59 , 0.22 , 0.03 ]]
    #
    #
    # som = MiniSom(6, 6, 4, sigma=0.3, learning_rate=0.5) # initialization of 6x6 SOM
    # som.train(data, 100) # trains the SOM with 100 iterations
    # som.winner(data[0])

    # columns=['area', 'perimeter', 'compactness', 'length_kernel', 'width_kernel',
    #          'asymmetry_coefficient', 'length_kernel_groove', 'target']
    # # data = pd.read_csv('https://archive.ics.uci.edu/ml/machine-learning-databases/00236/seeds_dataset.txt',
    # #                    names=columns,
    # #                    sep='\t+', engine='python')
    # target = data['target'].values
    # #label_names = {1:'Kama', 2:'Rosa', 3:'Canadian'}
    # data = data[data.columns[:-1]]
    # # data normalization
    # data = (data - np.mean(data, axis=0)) / np.std(data, axis=0)
    # data = data.values

    dimension = 12
    timeframe = 100
    GreyOut_Num = 4
    GreyOut = 1
    Sample = GreyOut_Num - GreyOut

    PerData = [0] * dimension
    data = np.zeros([timeframe*GreyOut_Num, dimension])
    index = 0
    #for num in range(GreyOut_Num):
    for t in np.linspace(-4, 4, timeframe) / 4: # Greyout
        #print("np.random.rand(1)", np.random.rand(1))
        PerData[0] = t*10 + (np.random.rand(1)[0]-.5) * 0.05
        PerData[1] = - t*t*10 - t*5 + (np.random.rand(1)[0]-.4) * 0.05 -5
        PerData[2] =  t*4 + (np.random.rand(1)[0]+.5) * 0.05
        PerData[3] = (np.random.rand(1)[0]+.5) * 0.5
        PerData[4] = (np.random.rand(1)[0]+.3) * 0.5
        PerData[5] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[6] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[7] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[8] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[9] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[10] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[11] = (np.random.rand(1)[0]-.2) * 0.5
        data[index] = PerData
        index = index + 1

    pca = PCA(n_components=2)
    pca.fit(np.array(data[0:timeframe*GreyOut]))

    for t in np.linspace(-4, 4, timeframe) / 4: # Sample 1
        #print("np.random.rand(1)", np.random.rand(1))
        PerData[0] = t*7 + (np.random.rand(1)[0]-.5) * 0.05
        PerData[1] = (- t*t*10 - t*5 + (np.random.rand(1)[0]-.4) * 0.05) * 0.8 + 10
        PerData[2] =  t*5 + (np.random.rand(1)[0]+.5) * 0.05
        PerData[3] = (np.random.rand(1)[0]+.5) * 0.8
        PerData[4] = (np.random.rand(1)[0]+.3) * 2
        PerData[5] = (np.random.rand(1)[0]-.2) * 1
        PerData[6] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[7] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[8] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[9] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[10] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[11] = (np.random.rand(1)[0]-.2) * 0.5
        data[index] = PerData
        index = index + 1

    for t in np.linspace(-4, 4, timeframe) / 4: # Sample 2
        #print("np.random.rand(1)", np.random.rand(1))
        PerData[0] = t*6 + (np.random.rand(1)[0]-.5) * 0.05
        PerData[1] = - t*t*10 - t*5 + (np.random.rand(1)[0]-.4) * 0.05 + 5
        PerData[2] =  t*3 + (np.random.rand(1)[0]+.5) * 0.05
        PerData[3] = (np.random.rand(1)[0]+.5) * 2
        PerData[4] = (np.random.rand(1)[0]+.3) * 2
        PerData[5] = (np.random.rand(1)[0]-.2) * 1
        PerData[6] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[7] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[8] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[9] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[10] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[11] = (np.random.rand(1)[0]-.2) * 0.5
        data[index] = PerData
        index = index + 1

    for t in np.linspace(-4, 4, timeframe) / 4: # Sample 2
        #print("np.random.rand(1)", np.random.rand(1))
        PerData[0] = t*8 + (np.random.rand(1)[0]-.5) * 0.05
        PerData[1] = - t*t*10 - t*15 + (np.random.rand(1)[0]-.4) * 0.05
        PerData[2] =  t*6 + (np.random.rand(1)[0]+.5) * 0.05
        PerData[3] = (np.random.rand(1)[0]+.5) * 2
        PerData[4] = (np.random.rand(1)[0]+.3) * 2
        PerData[5] = (np.random.rand(1)[0]-.2) * 1
        PerData[6] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[7] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[8] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[9] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[10] = (np.random.rand(1)[0]-.2) * 0.5
        PerData[11] = (np.random.rand(1)[0]-.2) * 0.5
        data[index] = PerData
        index = index + 1

    print("index", index)
    Numpy_Data = np.array(data)
   # o_x, o_y, o_z = zip(*[d for d in data])
    #print("Numpy_Data", Numpy_Data)
    #pca = PCA(n_components=2)
    #result=pca.fit_transform(Numpy_Data)
    result=pca.transform(Numpy_Data)
    print("variance", pca.explained_variance_ratio_)
    w_x,  w_y = zip(*[d for d in result])
    w_x = np.array(w_x)
    w_y = -1 * np.array(w_y)

    # fig = plt.figure()
    # ax = fig.gca(projection='3d')
    # ax.plot(o_x, o_y, o_z)
    # plt.show()


    # # Initialization and training
    # n_neurons = 10
    # m_neurons = 10
    # som = MiniSom(n_neurons, m_neurons, 6, sigma=1.5, learning_rate=.5,
    #               neighborhood_function='gaussian', random_seed=0)
    #
    # som.pca_weights_init(data)
    # som.train(data, 1000, verbose=True)  # random training
    #
    # w_x, w_y = zip(*[som.winner(d) for d in data])
    # w_x = np.array(w_x)
    # w_y = np.array(w_y)
    #
    # plt.figure(figsize=(10, 9))
    # plt.pcolor(som.distance_map().T, cmap='bone_r', alpha=.2)
    # plt.colorbar()
    # markers = ['o', 's', 'D']
    # colors = ['C0', 'C1', 'C2']
    #
    # # print("target", target)
    # # for c in np.unique(target):
    # #     print("c", c)
    # #     idx_target = target==c
    # #     print("np.random.rand(np.sum(idx_target))", np.random.rand(np.sum(idx_target)))
    # #     plt.scatter(w_x[idx_target]+.5+(np.random.rand(np.sum(idx_target))-.5)*.8,
    # #                 w_y[idx_target]+.5+(np.random.rand(np.sum(idx_target))-.5)*.8,
    # #                 s=50, c=colors[c-1], label=label_names[c])


    print("w_x", w_x)
    print("w_y", w_y)
    plt.figure(figsize = (8, 6))
    plt.scatter(w_x[0:timeframe]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8,
                w_y[0:timeframe]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8)
    plt.scatter(w_x[timeframe:timeframe*2]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8,
                w_y[timeframe:timeframe*2]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8)
    plt.scatter(w_x[timeframe*2:timeframe*3]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8,
                w_y[timeframe*2:timeframe*3]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8)
    plt.scatter(w_x[timeframe*2:timeframe*3]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8,
                w_y[timeframe*2:timeframe*3]+.5+(np.random.rand(np.sum(timeframe))-.5)*.8)

    plt.legend(loc='upper right')
    plt.grid()
    plt.savefig('Images_to_Plot/som_seed.png')
    plt.show()



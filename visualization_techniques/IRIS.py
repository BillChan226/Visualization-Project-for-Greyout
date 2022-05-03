import os
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import warnings
warnings.filterwarnings(action='ignore')
sns.set(style='white', color_codes=True)
plt.style.use('seaborn-whitegrid')

# Press the green button in the gutter to run the script.
if __name__ == '__main__':


    a = [1, 2, 3]
    s = sum(i*a[i] for i in range (0, 3))
    print ("s = ", s)
    # load data
    #iris = sns.load_dataset(name='iris', cache=True, data_home='F:/SJTU/Projects/毕业设计/Tryout/visualization techniques/Iris.csv')
    iris = pd.read_csv('D:/Path4Code/Iris.csv')
    # 简单了解一下数据集的结构
    print(iris.head(3))

    # 描述统计
    print("\n", iris.describe())

    print("\n", iris.Species.value_counts()) #iris['species'].value_counts()


    SepalLength_Setosa = iris.SepalLengthCm[iris.Species == 'Iris-setosa']
    SepalLength_versicolor = iris.SepalLengthCm[iris.Species == 'Iris-versicolor']
    SepalLength_virginica = iris.SepalLengthCm[iris.Species == 'Iris-virginica']

    # seaborn模块绘制分组的直方图和核密度图

    sns.distplot(SepalLength_Setosa, bins = 20, kde = False, hist_kws = {'color':'steelblue'}, label = 'Setosa')
    # 绘制女性年龄的直方图
    sns.distplot(SepalLength_versicolor, bins = 20, kde = False, hist_kws = {'color':'purple'}, label = 'Versicolor')
    sns.distplot(SepalLength_versicolor, bins = 20, kde = False, hist_kws = {'color':'red'}, label = 'Virginica')
    plt.title('Histogram of Each Kind w.r.t. Sepal Length')
    plt.xlabel('Sepal Length (cm)')
    plt.ylabel('Frequency')
    # 显示图例
    plt.legend()
    # 显示图形
    plt.show()


    # 利用pandas对象的 .plot() 方法绘制
    plt.figure(figsize=(16, 8), dpi=320)
    colors = ['blue', 'yellow', 'red']
    sns.relplot(data=iris, kind="scatter", x='SepalLengthCm', y='SepalWidthCm', s=15, hue="Species")
    #iris.plot(kind='scatter', x='SepalLengthCm', y='SepalWidthCm', c=colors, s=15)
    plt.title(u'Sepal_Length VS Sepal_Width', fontsize=15)
    plt.show()

    # 利用seaborn库实现带边缘直方图的散点图
    plt.figure(figsize=(100, 5), dpi=420)
    sns.set(palette="Spectral")
    sns.jointplot(x='SepalLengthCm', y='SepalWidthCm', data=iris, color='red')
    plt.show()

    # 箱形图主要用于可视化原始数据分布的特征 可以显示出一组数据的最大值、最小值、中位数、及上下四分位数
    plt.figure(figsize=(5, 5), dpi=420)
    sns.boxplot(x='Species', y='PetalLengthCm', data=iris)
    sns.stripplot(x='Species', y='PetalLengthCm', data=iris, jitter=True,
                  edgecolor='white', size=4)
    plt.show()

    # 矩阵图 pairplot
    plt.figure(figsize=(10,8), dpi= 80)
    sns.pairplot(data=iris, kind="scatter", hue="Species") #矩阵散点图 scatter matrices
    plt.show()

    plt.figure(figsize=(10,8), dpi= 80)
    sns.pairplot(data=iris, kind="reg", hue="Species")# 矩阵回归图 regression matrices
    plt.show()


def pairPlot():
    #iris = sns.load_dataset(name='iris', cache=True, data_home='F:/SJTU/Projects/毕业设计/Tryout/visualization techniques/')
    iris = pd.read_csv('C:/Users/Bill Chan/Desktop/Iris.csv')
    plt.figure(figsize=(10,8), dpi= 80)
    sns.pairplot(data=iris, kind="scatter", hue="Species") #矩阵散点图 scatter matrices
    Path_to_plot = 'F:\\SJTU\\Projects\\Graduation Project\\Visualization-Project-for-Greyout\\visualization_techniques\\Images_to_Plot\\pair.jpg'
    plt.savefig(Path_to_plot, dpi=750, bbox_inches = 'tight')
    return Path_to_plot

def histoPlot():
    iris = pd.read_csv('C:/Users/Bill Chan/Desktop/Iris.csv')
    # 简单了解一下数据集的结构
    print(iris.head(3))

    # 描述统计
    print("\n", iris.describe())

    print("\n", iris.Species.value_counts()) #iris['species'].value_counts()


    SepalLength_Setosa = iris.SepalLengthCm[iris.Species == 'Iris-setosa']
    SepalLength_versicolor = iris.SepalLengthCm[iris.Species == 'Iris-versicolor']
    SepalLength_virginica = iris.SepalLengthCm[iris.Species == 'Iris-virginica']

    # seaborn模块绘制分组的直方图和核密度图

    sns.distplot(SepalLength_Setosa, bins = 20, kde = False, hist_kws = {'color':'steelblue'}, label = 'Setosa')
    # 绘制女性年龄的直方图
    sns.distplot(SepalLength_versicolor, bins = 20, kde = False, hist_kws = {'color':'purple'}, label = 'Versicolor')
    sns.distplot(SepalLength_versicolor, bins = 20, kde = False, hist_kws = {'color':'red'}, label = 'Virginica')
    plt.title('Histogram of Each Kind w.r.t. Sepal Length')
    plt.xlabel('Sepal Length (cm)')
    plt.ylabel('Frequency')
    # 显示图例
    plt.legend()
    # 显示图形
    #plt.show()
    Path_to_plot = 'F:\\SJTU\\Projects\\Graduation Project\\Visualization-Project-for-Greyout\\visualization_techniques\\Images_to_Plot\\histo.jpg'
    plt.savefig(Path_to_plot, dpi=750, bbox_inches = 'tight')
    return Path_to_plot
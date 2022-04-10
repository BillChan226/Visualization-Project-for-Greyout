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

    # load data
    iris = sns.load_dataset(name='iris', cache=True, data_home='F:/SJTU/Projects/毕业设计/Tryout/visualization techniques/')

    # 简单了解一下数据集的结构
    print(iris.head(3))

    # 描述统计
    print("\n", iris.describe())

    print("\n", iris.Species.value_counts()) #iris['species'].value_counts()

    # 利用pandas对象的 .plot() 方法绘制
    plt.figure(figsize=(16, 8), dpi=320)
    colors = ['blue', 'yellow', 'red']
    iris.plot(kind='scatter', x='SepalLengthCm', y='SepalWidthCm', c=colors, s=15)
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



def pairplot():
    iris = sns.load_dataset(name='iris', cache=True, data_home='F:/SJTU/Projects/毕业设计/Tryout/visualization techniques/')
    plt.figure(figsize=(10,8), dpi= 80)
    sns.pairplot(data=iris, kind="scatter", hue="species") #矩阵散点图 scatter matrices
    Path_to_plot = 'F:\\SJTU\\Projects\\Graduation Project\\Visualization-Project-for-Greyout\\visualization_techniques\\Images_to_Plot\\test.jpg'
    plt.savefig(Path_to_plot, dpi=750, bbox_inches = 'tight')
    return Path_to_plot
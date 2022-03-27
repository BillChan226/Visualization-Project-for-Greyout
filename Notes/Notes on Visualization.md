# Visualization Tools

## Seaborn
### Style Manager

Seaborn装载了一些默认主题风格，通过sns.set()方法实现

sns.set()可以设置5种风格的图表背景：darkgrid, whitegrid, dark, white, ticks，通过参数style设置，默认情况下为darkgrid风格：

![img](https://s2.loli.net/2022/03/27/5zoQL49DKdtIhUm.jpg)

Seaborn 调色板palette功能（作图色系）

[Seaborn（三）调色板palette_风度翩翩猪肉王子的博客-CSDN博客_palette参数](https://blog.csdn.net/qq_17249717/article/details/103435739)

[seaborn palette参数各配色方案及显示效果_coolerpan的博客-CSDN博客_palette seaborn](https://blog.csdn.net/panlb1990/article/details/103851983)

### 点、线混合绘图函数 - relplot()

relplot()是seaborn中非常重要的绘图函数，它可以用于绘制散点图和线图，通过参数kind改变绘图类型

- 散点图：relplot(kind='scatter') ## default
- 线图：relplot(kind='line')

添加多个控制行参数：

![img](https://s2.loli.net/2022/03/27/6tYdBCVehngz1Zb.jpg)

lineplot() 和 scatter()也可以分别用于绘制线图和散点图

### 绘制线性回归模型-lmplot()函数

lmplot()函数用以绘制回归模型，描述线性关系

可以使用传递参数ci调整置信区间的大小：

![img](https://s2.loli.net/2022/03/27/tRlXyC81waV6Fdm.jpg)

也可以绘制非参数回归模型（局部加权线性回归），传递参数 lowess=True：

![img](https://s2.loli.net/2022/03/27/o8tSms7z1YwAlin.jpg)

### **分类散点图 - stripplot()函数**

当有一维数据是分类数据时，散点图成了条带形状，这里就用到stripplot()函数

![img](https://s2.loli.net/2022/03/27/BbxTq4YiWRn1guv.jpg)

stripplot()数与catplot类的子函数，也可通过更换父类catplot中的kind参数实现分类散点图。catplot还有子函数如下所示：

- stripplot()，此时(kind="strip"，默认)；
- swarmplot()，此时(kind="swarm")；
- boxplot()，此时(kind="box")；
- violinplot()，此时(kind="violin")；
- boxenplot()，此时(kind="boxen")
- pointplot()，此时(kind="point")；
- barplot()，此时(kind="bar")；
- countplot()，此时(kind="count")

### 工具函数

利用**FacetGrid()函数**可以将多种对数据可视化操作映射到同一数据集上

例如 先画直方图：

```python
# 画不同Species情况下，SepalWidthCm直方图
g = sns.FacetGrid(iris, col="Species")
g = g.map(plt.hist, "SepalWidthCm", bins=20)
```

![img](https://s2.loli.net/2022/03/27/9e86TW7SCJ2HKcz.jpg)

再画KDE图：

```python
# 画不同Species情况下，PetalLengthCm KDE图
sns.FacetGrid(iris, hue="Species", size=6) \
   .map(sns.kdeplot, "PetalLengthCm") \
   .add_legend()
```

![img](https://s2.loli.net/2022/03/27/buhcWAXPj9C3yeo.jpg)

这里通过KDE可以看出，由于Setosa的KDE与其他两种没有交集，直接可以用Petailength线性区分Setosa与其他两个物种



## yellowbrick



## Bubbly

Bubbly is a package for plotting interactive and animated *bubble charts* using *Plotly*. The animated bubble charts can accommodate upto seven variables in total viz. X-axis, Y-axis, Z-axis, time, bubbles, their size and their color in a compact and captivating way. Bubbly is easy to use with plenty of customization, especially suited for use in Jupyter notebooks and is designed to work with `plotly`’s offline mode such as in Kaggle kernels.

[AashitaK/bubbly: A python package for plotting animated and interactive bubble charts using Plotly (github.com)](https://github.com/AashitaK/bubbly)

以Iris数据集为例：

![img](https://s2.loli.net/2022/03/27/kLiPMhnadOEpH3u.jpg)

这个数据集有6列，6个特征，很多时候做可视化就是为了更好的了解数据，比如这里就是想看每个种类的花有什么特点，怎么样根据其他特征把花分为三类。**因此可以首先绘制一张图尽量多的包含数据点，展示数据信息，从中发现规律。**我们可以利用以下代码完全展示全部维度和数据这里用的bubbly：

```python
from bubbly.bubbly import bubbleplot 
from __future__ import division
from plotly.offline import init_notebook_mode, iplot
init_notebook_mode()

#这里设置x,y,z轴，气泡，气泡大小，气泡颜色分别代表6列~在二维平面想展示6个维度，除了x,y,z之外，
#只能用颜色，大小等代表其他维度了，bubbly还可以承受更高维度的数据，可以自己搜索

figure = bubbleplot(dataset=iris, x_column='SepalLengthCm', y_column='PetalLengthCm', z_column='SepalWidthCm',
    bubble_column='Id', size_column='PetalWidthCm', color_column='Species', 
    x_title="SepalLength(Cm)", y_title="PetalLength(Cm)", z_title='SepalWidth(Cm)',
                    title='IRIS Visualization',
    x_logscale=False,scale_bubble=0.1,height=600)

#展示图片

iplot(figure, config={'scrollzoom': True})
```

![img](https://s2.loli.net/2022/03/27/5Gh2LpoTNCnl6HO.jpg)



# Visualization Strategies

## Direct Visualization

### Geometric Methods

#### Visualizing Distrubution 

##### KDE 核密度估计

[核密度估计Kernel Density Estimation(KDE)及python代码 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/360982296)

[ 什么是核密度估计？如何感性认识？ - 知乎 (zhihu.com)](https://www.zhihu.com/question/27301358/answer/105267357?from=profile_answer_card)

[ 核密度估计 Kernel Density Estimation(KDE)_NeverMore_7的博客-CSDN博客_核密度估计](https://blog.csdn.net/unixtch/article/details/78556499)

KDE是对直方图的一个自然拓展 采用非参数的方法估计一个分布的概率密度函数

一般估计概率密度会想到先求分布函数，再对其求导得到。一个最简单而有效的估计分布函数的方法是所谓的`经验分布函数`（empirical distribution function）：

![img](https://s2.loli.net/2022/03/27/Q59qsurURtav2p1.png)

即，F(t)的估计为所有小于t的样本的概率。可以证明，这个估计是almost surely收敛的，有很好的统计性质。如图所示：

![img](https://s2.loli.net/2022/03/27/MicvYNU8lCZ9DEQ.jpg)

可是这个EDF不是可导的，不够光滑，因而不能通过对该EDF直接求导算密度函数。因此可以近似逼近斜率的方法来求导数：

![[公式]](https://www.zhihu.com/equation?tex=f(x)%3D\lim_{h\rightarrow+0}+\frac{F(x%2Bh)-F(x-h)}{2h})

把分布函数用上面的经验分布函数替代，那么上式分子上就是落在[x-h,x+h]区间的点的个数。我们可以把f(x)的估计写成：

![[公式]](https://www.zhihu.com/equation?tex=\hat{f}_h(x)%3D\frac{1}{2h}\frac{\%23x_i\in[x-h%2Cx%2Bh]}{N}%3D\frac{1}{2Nh}\sum_{i%3D1}^{N}1(x-h\leq+x_i\leq+x%2Bh)%3D\frac{1}{Nh}\sum_{i%3D1}^{N}\frac{1}{2}\cdot+1(\frac{|x-x_i|}{h}\leq+1))

h的选择：存在非参数估计里面的bias-variance tradeoff：如果h太大，用于计算的点很多，可以减小方差，但是方法本质要求h→0，bias可能会比较大；如果h太小，bais小了，但是用于计算的点太少，方差又很大。

所以理论上存在一个最小化mean square error的一个h。h的选取应该取决于N，当N越大的时候，我们可以用一个比较小的h，因为较大的N保证了即使比较小的h也足以保证区间内有足够多的点用于计算概率密度。因而，我们通常要求当N→∞，h→0。比如，在这里可以推导出，最优的h应该是N的-1/5次方乘以一个常数，也就是![[公式]](https://www.zhihu.com/equation?tex=h%3Dc%5Ccdot+N%5E%7B-1%2F5%7D)。对于正态分布而言，可以计算出c=1.05×标准差。

另外，我们知道之前的经验分布函数每个点的收敛速度都是√N的，而这里，因为有h的存在（观察估计式，分母上是nh而非n，而nh=O(N^{-4/5})）。所以收敛速度比一般的参数收敛速度要慢很多。

然而，通过上式得到的密度函数不是光滑的，存在阶跃。（可以看作是N张以每个点为中心（均值）的门函数（值为1/(N*2h)，长度为2h) 叠加在一起）

因此，可以将以该点为均值的门函数替换为核函数（常用高斯函数），从而得到一个光滑的密度函数。

**理论推导：**

观察上面的估计式子，如果记 ![[公式]](https://www.zhihu.com/equation?tex=K_0(t)%3D\frac{1}{2}\cdot+1(t<1))，那么估计式可以写为：

![[公式]](https://www.zhihu.com/equation?tex=\hat{f}_h(x)%3D\frac{1}{nh}\sum_{i%3D1}^{N}K_0(\frac{x-x_i}{h}))

密度函数的积分：

![[公式]](https://www.zhihu.com/equation?tex=\int+\hat{f(x)}+dx%3D\frac{1}{Nh}\sum_{i%3D1}^N\int+K_0(\frac{x-x_i}{h})dx%3D\frac{1}{N}\sum_{i%3D1}^N\int+K_0(t)dt%3D\int+K_0(t)dt)

因而只要K的积分等于1，就能保证估计出来的密度函数积分等于1。

例如，用标准正态分布的密度函数作为K，估计就变成了：

![[公式]](https://www.zhihu.com/equation?tex=%5Chat%7Bf%7D_h%28x%29%3D%5Cfrac%7B1%7D%7Bnh%7D%5Csum_%7Bi%3D1%7D%5E%7BN%7D%5Cphi+%28%5Cfrac%7Bx-x_i%7D%7Bh%7D%29)

这个密度函数的估计就变得可导了，而且实数域的积分积起来等于1。直觉上，上式就是一个加权平均，离x越近的x<sub>i</sub>其权重越高。而最开始的利用门函数的估计方式则是在区间内权重相等，区间外权重为0。

将设有N个样本点，对这N个点进行上面的拟合过后，将这N个概率密度函数进行叠加便得到了整个样本集的概率密度函数。例如利用高斯核对X={x1=−2.1,x2=−1.3,x3=−0.4,x4=1.9,x5=5.1,x6=6.2} 六个点的“拟合”结果如下：

![这里写图片描述](https://s2.loli.net/2022/03/27/P6v5jQUETMSyAJh.png)

左边是直方图，bin的大小为2，右边是核密度估计的结果。
可见将以每个点为均值的高斯函数叠加在一起就得到了总概率密度函数

h越小高斯函数越陡峭，h越大越平滑。当h为无穷大时退化为y=0的线性函数。

###### 带宽h的选择

在核函数确定之后，比如上面选择的高斯核，那么高斯核的方差，也就是h（也叫带宽，也叫窗口，我们这里说的邻域）应该选择多大呢？不同的带宽会导致最后的拟合结果差别很大。同时上面也提到过，理论上h->0的，但h太小，邻域中参与拟合的点就会过少。那么借助机器学习的理论，我们当然可以使用交叉验证选择最好的h。另外，也有一个理论的推导给你选择h提供一些信息。
在样本集给定的情况下，我们只能对样本点的概率密度进行计算，那拟合过后的概率密度应该核计算的值更加接近才好，基于这一点，我们定义一个误差函数，然后最小化该误差函数便能为h的选择提供一个大致的方向。选择均平方积分误差函数(mean intergrated squared error)，该函数的定义是：

![image-20220322191240526](https://s2.loli.net/2022/03/27/BP8Yr1RO9e3AGIH.png)

在weak assumptions下， ，其中AMISE为渐进的MISE(这里我没搞懂是怎么推导出来的)。而AMISE有：

![image-20220322191323754](https://s2.loli.net/2022/03/27/jLtNCHY1XPSKsyi.png)

其中：

![image-20220322191342905](https://s2.loli.net/2022/03/27/hFgdo5TjBflYn6p.png)

最小化MISE(h)等价于最小化AMISE(h)，求导，令导数为0有：

![image-20220322191402969](https://s2.loli.net/2022/03/27/q7XWL1y9NVZMlwh.png)

得：

![image-20220322191423641](https://s2.loli.net/2022/03/27/qQBZ6huWv7YSrCx.png)

当核函数确定之后，h公式里的R、m、f” 都可以确定下来，h便存在解析解。如果带宽不是固定的，其变化取决于估计的位置（balloon estimator）或样本点（逐点估计pointwise estimator)，由此可以产生一个非常强大的方法称为自适应或可变带宽核密度估计。

##### KDE相关可视化

##### Pairplot

```python
# Pairplot, 看三个品种在不同的两特征组合中的区分情况，对角线由于X,Y是一个特征，可以用来画KDE
sns.pairplot(iris.drop("Id", axis=1), hue="Species", size=3, diag_kind="kde")
```

![img](https://s2.loli.net/2022/03/27/3LSu1jJnQwiv75B.jpg)

##### 小提琴图

```python
# 小提琴图，箱线图与核密度图的结合体，能代表的信息和上图相似
sns.violinplot(x="Species", y="PetalLengthCm", data=iris, size=6)
```

![img](https://s2.loli.net/2022/03/27/nDvfWY4GXghQKy8.jpg)

#### Visualizing Data Structure

##### Andrews Curves

体现每条数据的各特征的分布情况。

In [data visualization](https://en.wikipedia.org/wiki/Data_visualization), an **Andrews plot** or **Andrews curve** is a way to visualize structure in high-dimensional data. It is basically a rolled-down, non-integer version of the Kent–Kiviat [radar m chart](https://en.wikipedia.org/wiki/Radar_chart), or a smoothed version of a [parallel coordinate plot](https://en.wikipedia.org/wiki/Parallel_coordinates). It is named after the statistician David F. Andrews.

A value **x** is a [high-dimensional datapoint](https://en.wikipedia.org/wiki/Real_coordinate_space) if it is an element of ![{\displaystyle \mathbb {R} ^{d}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/a713426956296f1668fce772df3c60b9dde8a685). We can represent high-dimensional data with a number for each of their dimensions, ![{\displaystyle x=\left\{x_{1},x_{2},\ldots ,x_{d}\right\}}](https://wikimedia.org/api/rest_v1/media/math/render/svg/9dd717321df8f5c29f657c29f4de674a3edfa5de). To visualize them, the Andrews plot defines a finite [Fourier series](https://en.wikipedia.org/wiki/Fourier_series):

![{\displaystyle f_{x}(t)={\frac {x_{1}}{\sqrt {2}}}+x_{2}\sin(t)+x_{3}\cos(t)+x_{4}\sin(2t)+x_{5}\cos(2t)+\cdots }](https://wikimedia.org/api/rest_v1/media/math/render/svg/e4c0dd9477fdfa6166f10d2f335aa6b8e29c5413)

This function is then plotted for ![-\pi <t<\pi ](https://wikimedia.org/api/rest_v1/media/math/render/svg/12d88552ec06804c7440e25f2d4f337491f78dd8). Thus each data point may be viewed as a line between ![-\pi ](https://wikimedia.org/api/rest_v1/media/math/render/svg/f2359073fe90a84a705e02f0c1e63b32df850a60) and ![\pi ](https://wikimedia.org/api/rest_v1/media/math/render/svg/9be4ba0bb8df3af72e90a0535fabcc17431e540a). This formula can be thought of as the projection of the data point onto the vector:

![{\displaystyle \left({\frac {1}{\sqrt {2}}},\sin(t),\cos(t),\sin(2t),\cos(2t),\ldots \right)}](https://wikimedia.org/api/rest_v1/media/math/render/svg/42ebe4f593cd69b2150dead852b09f1c60178637)

`If there is structure in the data, it may be visible in the Andrews curves of the data.`

```python
from pandas.tools.plotting import andrews_curves
andrews_curves(iris.drop("Id", axis=1), "Species")
```

![img](https://s2.loli.net/2022/03/27/iycJBUbpIDV7WRA.jpg)

Andrew Curves将高维数据通过傅里叶级数的方式呈现到二维平面上，可以较为heuristically地呈现大量数据在高维空间的分布情况。个人理解是信号的某一频率如果幅值较大，则该信号会呈现出明显的周期。可是假如调换多维数据中任意两个维度的位置，把特征比较明显的维度分配给频率较小的正弦波，现象还是否明显呢？

##### Parallel Coordinates

体现每条数据的各特征的分布情况。

Parallel coordinates as a way of visualizing multidimensional data are proposed by Inselberg. In this method, coordinate axes are shown as parallel lines that represent features. An n-dimensional point is represented as n − 1 line segments, connected to each of the parallel lines at the appropriate feature value.

```python
# parallel_coordinates 做法是把每个特征放一列，不同物种用不同颜色连起来看看有没有规律
from pandas.tools.plotting import parallel_coordinates
parallel_coordinates(iris.drop("Id", axis=1), "Species")
```

![img](https://s2.loli.net/2022/03/27/lOF4x61craRZyJ9.jpg)

可以较容易地看出哪些特征最能够区分不同种类的数据，如上图的PetalLength和PetalWidth。However，这个方法的缺点是可视化较高维数据的时候coordinates are too dense，想要perceive数据结构比较困难。同样，当数据量较大的时候，interpretation of the results is also very complicated.

###### Hierarchical Parallel Coordinates

HPC是Parallel Coordinates的Variation之一。When visualizing a large data set by the hierarchical parallel coordinates, the number of overlapping lines, obtained by the parallel coordinates, decreases.

+ First, the data are grouped into some clusters by one of clustering methods 

+ Afterwards, the data are represented on the parallel coordinates, the centers of clusters are highlighted; the color intensity of the members of clusters depends on how far they are from the cluster center; different clusters are displayed by

![HPC](https://s2.loli.net/2022/03/27/I9zHuFGK3OQnE2y.png)

##### Radviz

体现每条数据各特征之间的大小（比例）关系。大小比例近似的数据分布在一起。

Radviz可视化原理是将一系列多维空间的点通过非线性方法映射到二维空间的可视化技术，是基于圆形平行坐标系的设计思想而提出的多维可视化方法。圆形的m条半径表示m维空间，使用坐标系中的一点代表多为信息对象，其实现原理参照物理学中物体受力平衡定理。 多维空间的点映射到二维可视空间的位置由弹簧引力分析模型确定。 ([Radviz可视化原理 - CSDN博客](https://link.zhihu.com/?target=https%3A//blog.csdn.net/Haiyang_Duan/article/details/78985225)) ，能展示一些数据的可区分规律。

```python
# radviz
from pandas.tools.plotting import radviz
radviz(iris.drop("Id", axis=1), "Species")
```

![img](https://s2.loli.net/2022/03/27/OD2JBh13ctrijen.jpg)

Modification：PolyViz 和 GridViz

###### PolyViz

将维度锚点（dimensional anchor）替换成线段（segments of lines），以此来减少因为特征之间比例近似而造成的数据点重叠。

![PolyViz](https://s2.loli.net/2022/03/27/sA83kYpNu2WFelr.png)

#### Visualizing Correlations

##### 热力图

用颜色的深浅来表征相关系数矩阵每个数据的大小。基于热力图对目标特征相关性分析见：[相关矩阵 Correlation matrix_zzw小凡的博客-CSDN博客_correlation matrix](https://blog.csdn.net/zzw000000/article/details/81205027)

```python
#特征间相关系数热力图
f = iris.drop("Id", axis=1).corr()
sns.heatmap(f, annot=True)
```

![img](https://s2.loli.net/2022/03/27/FtexinVbTYRPXIO.jpg)

数值是皮尔森相关系数，浅颜色表示相关性高，比如Petal.Length（花瓣长度）与 Petal.Width（花瓣宽度）相关性0.96，也就是花瓣长的花，花瓣宽度也大，也就是个大花。

#### Visualization with ML

#### Iconographic Displays

##### Chernoff Faces

Chernoff faces are designed by Chernoff for visualization of multidimensional data. In Chernoff faces, data features are mapped to facial features, such as the angle of eyes, the width of a nose, etc. 

The Iris visualized by Chernoff faces, are presented below, where sepal length corresponds to the size of face, sepal width corresponds to the shape of forehead, petal length corresponds to the shape of jaw, and petal width corresponds to the length of nose.

![Chernoff Faces](https://s2.loli.net/2022/03/27/vBt6ZkIE5oseJ9q.png)

作图工具：Matlab

**总结：**该方法和Andrews Curves, Parallel Coordinates以及RadViz方法类似，都是想通过把高维的数据的各维度通过一个具有多个特征的二维平面物体呈现出来。Andrews Curves想通过投射到一条曲线上（曲线可被分解成若干个不同频率的正弦波组成）；Parallel Coordinates想通过投射到一条折线上（折现具有若干段）；RadViz想通过投射到一个满足若干弹簧弹力合力为零的物理系统上；Chernoff方法想通过投射到脸部特征上（脸具有多个特征：眼睛的角度、鼻翼宽度等）

**Stars**

Each object is displayed by a stylized star. In the star plot, the features are represented as spokes of a wheel circle, but their lengths correspond to the values of features. The angles between the neighboring spokes are equal. The outer ends of the neighboring spokes are connected by line segments.

![Star Glyphs](https://s2.loli.net/2022/03/27/aIME3Ls4PVU1iCW.png)

比较的是各组数据各特征的大小和比例关系。

#### Hierachical Displays

Hierarchical displays create a structure of an image such that some features are embedded in displays of other features. 

##### Dimensional Stacking

[XmdvTool Home Page: Downloads (wpi.edu)](https://davis.wpi.edu/~xmdv/downloadxmdv.shtml)

+ 选中两个特征，根据每个特征的取值将取值范围分为几个小区间（不超过5）；
+ 选中的两个特征（outer features）将矩阵平面划分成n1*n2个小格子（grid）（n1和n2分别为outer features小区间的数量）；
+ 再选出两个特征（inner features），这两个特征再将outer features划分出的每个较大格子划分成n3*n4个小格子；
+ 不断重复这个过程（选出两个新的特征，进一步划分格子），直到所有的特征都被表示出来
+ 将有数据点的值落在对应小区间范围里的那个grid染色

![Dimensional Stacking](https://s2.loli.net/2022/03/27/3RdaHzhLAeQ4NwW.png)

注意：数据的维数最好不要超过8；个人认为，为了使可视化的结果更容易理解（同类数据成簇），尽量先选择能划分不同种类数据的特征以及不能明显划分同类数据集的特征。

##### Trellis Display

Trellis Display方法与Dimensional Stacking类似，也是通过选取一定的维度将整张图先划分成若干个小块，再利用这些小块呈现剩余特征的分布。与Dimensional Stacking方法不同的是，Trellis Display方法使用散点图刻画最内层的两个特征的分布。因此Outer features可以尽可能选择取值集合变量较少的离散变量，将取值集合较大的特征留在内层呈现。两个方法可以灵活利用subrange的划分方式（遍历特征离散值、划分连续区间等）来混合使用。

![Trellis Display.png](https://s2.loli.net/2022/03/27/RSpL6xWlqFZtVOK.png)



## Dimensionality Reduction

同维度线性变换：变换矩阵A为n行n列

**rotation**

![image-20220327095408167.png](https://s2.loli.net/2022/03/27/JhrmeHsKNkZTPdQ.png)

降维线性变换：变换矩阵A为n行d列，且d<n

非线性变换：The nonlinear transformation is more complicated than the linear one and requires more time-consuming computations. However, such a transformation allows us to preserve the characteristics of multidimensional data better as compared with the linear transformation if d < n.

e.g. 保证相邻两点距离相等（线性变换无法（约束方程n-1个，自由变量2个 --旋转变换的情况））

![image-20220327100418820](https://s2.loli.net/2022/03/27/eLiTAvGtl4ZVIp8.png)

#### Proximity Measures

The aim of projection methods is to transform multidimensional data to a low-dimensional space so that the **proximity of the data was possibly preserved**. So proximity measures should be defined first.

**Minkowski Distance**

![Minkowski Distance.png](https://s2.loli.net/2022/03/27/t5dApZQ4uMqJwGI.png)

即连接两点的向量的各范数

q = 1：Manhattan Distance；

![Manhattan Distance](https://s2.loli.net/2022/03/27/rMQyu1BTtgfaSos.png)

q = 2：Euclidean Distance；

![Euclidean Distance](https://s2.loli.net/2022/03/27/YEPQiWo96gbN12y.png)

q = ∞：Chebyshev Distance；

![Chebyshev Distance](https://s2.loli.net/2022/03/27/NUuD2VdJHrK9IZ8.png)

**Canberra Distance**

Weighted version of manhattan distance

<img src="https://s2.loli.net/2022/03/27/ON9PIryYtLzfUKx.png" alt="img"  />

# Resources

数据项目分析实例：[开发者自述：我是如何从 0 到 1 走进 Kaggle 的 (sohu.com)](https://www.sohu.com/a/143064983_114877)

可视化产品：[SandDance - Demo Vote (microsoft.github.io)](https://microsoft.github.io/SandDance/app/)

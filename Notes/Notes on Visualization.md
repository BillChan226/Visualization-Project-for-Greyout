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

![[公式]](https://www.zhihu.com/equation?tex=\hat{f}_h(x)%3D\frac{1}{2h}\frac{x_i\in[x-h%2Cx%2Bh]}{N}%3D\frac{1}{2Nh}\sum_{i%3D1}^{N}1(x-h\leq+x_i\leq+x%2Bh)%3D\frac{1}{Nh}\sum_{i%3D1}^{N}\frac{1}{2}\cdot+1(\frac{|x-x_i|}{h}\leq+1))

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

![[公式]](https://www.zhihu.com/equation?tex=\hat{f}_h(x)%3D\frac{1}{nh}\sum_{i%3D1}^{N}\phi+(\frac{x-x_i}{h}))

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

<img src="https://s2.loli.net/2022/03/27/ON9PIryYtLzfUKx.png" alt="img" style="zoom:120%;" />

**Bray Curtis Distance**

Bray Curtis距离主要用于生态学和环境科学，计算坐标之间的距离。该距离取值在[0,1]之间。它也可以用来计算样本之间的差异。

![img](https://s2.loli.net/2022/03/27/5QtqCYnLT7deZVR.png)

#### Principal Component Analysis (PCA)

PCA is a way of linear transforming a set X of n-dimensional points X1,X2,...,Xm into another set Y of n-dimensional points Y1,Y2,...,Ym. The property of the set is that the largest part of its information content is stored in the first few coordinates (components) of points Yi , i = 1,...,m.

[PCA：详细解释主成分分析_lanyuelvyun的博客-CSDN博客_主成分分析](https://blog.csdn.net/lanyuelvyun/article/details/82384179)

PCA的目标是通过某种线性投影，将高维的数据映射到低维的空间中，并期望在所投影的维度上数据的信息量最大（**方差最大**），以此使用较少的数据维度，同时保留住较多的原数据点的特性。

Steps：

+ 去除平均值
+ 计算协方差矩阵
+ 计算协方差矩阵的特征值和特征向量
+ 将特征值排序
+ 保留前N个最大的特征值对应的特征向量
+ 将原始特征转换到上面得到的N个特征向量构建的新空间中

**协方差矩阵的特征向量是投影面，相对应的特征值是原始特征投影到这个投影面之后的方差。**

证明：

现在，假设有以下几个样本，特征只有2个维度。做完预处理（减去了均值，这步很重要，之后会解释）之后，分布如下：

![这里写图片描述](https://s2.loli.net/2022/03/27/axpw3jtg6qfH9vT.png)

现在将这些样本往低维空间进行投影，二维特征降维的话就是往一维降，投影直线有很多，比如下面的u1和u2，选哪一条比较好呢？


![这里写图片描述](https://s2.loli.net/2022/03/27/vCJdl4K8B7Digpy.png)

根据方差最大理论，选择投影过去之后，样本方差最大的那条投影直线作为投影维度，对原始特征进行降维。经过计算，u1比较好，因为投影后的样本点之间方差最大。

**那么，投影过去之后样本之间的方差怎么计算？**

以一个样本Xi为例，蓝色点表示该样本，原始特征有2维，绿色点表示样本在u上的投影，u是该投影直线的**单位向量**。那么该样本的原二维特征xi = (x1, x2)* 投影到这个投影直线上就变成了一维特征（从二维坐标系变到了一维坐标系u上），这个一维特征的值 = 投影点到原点的距离：xi*u（根据向量的计算公式得到）。

![这里写图片描述](https://s2.loli.net/2022/03/27/ibECaPdMkqL4r5v.png)

同理，其他的样本投影到该投影直线上，生成的新的一维特征也这么计算。那么，投影之后的`所有样本之间的方差`就等于（根据方差的定义）：

![image-20220328000101040](https://s2.loli.net/2022/03/28/AO2rbnNQoZhvJa6.png)

由于这些样本原特征的每一维特征在最一开始都进行了去均值操作，所以xi每一维特征的均值都为0，因此投影到u上的特征的均值仍然是0（所有xi*的均值=0)。对上式进行变换
![image-20220328000224724](https://s2.loli.net/2022/03/28/upLo6gOPSbMVm2F.png)

那么怎么求这个方差的最大值呢？

我们发现，![image-20220328000300359](https://s2.loli.net/2022/03/28/GUKLkSZFfT7DbVh.png)是一个方形矩阵，我们可以`从矩阵的角度求解`，令方差![image-20220328000348048](https://s2.loli.net/2022/03/28/3xge9KjhRVBnPXJ.png)，上式就变成了

![image-20220328000428591](https://s2.loli.net/2022/03/28/B2JeXyt9Ouv6MzW.png)

**注意：**这步不能直接得到（下式可以推到上式（u*u=1），不能反推）

![image-20220328000514207](https://s2.loli.net/2022/03/28/tVvNWkhrijo5UwZ.png)

正确的做法是对![image-20220328000428591](https://s2.loli.net/2022/03/28/B2JeXyt9Ouv6MzW.png)式求导，代入极值点取得方差的最大值。

引入拉格朗日乘子来保证u为单位向量。得到极值点u应该满足如下条件：

![image-20220328000514207](https://s2.loli.net/2022/03/28/LPwxekjA2ft5Kr7.png)

即矩阵C的各特征向量为λ函数（方差）的极值点。因此，代入C的最大特征值对应的特征向量时，λ函数取得最大值。

而展开矩阵C的表达式，可以发现C就是协方差矩阵：

![image-20220328001810448](https://s2.loli.net/2022/03/28/Lpj8cKUAsq5kfPl.png)

综上所述：协方差矩阵的特征值就是当数据点以其对应的特征向量为投影面时投影得到的点的方差。故PCA选取最大的几个特征值对应的特征向量构成变换矩阵即可。

![image-20220328125053953](https://s2.loli.net/2022/03/28/51GA9etVEg43FJX.png)

由于协方差矩阵是对称且非负定的，因此找到其最大的特征值比较容易。也有一些神经网络的手段被用于找主成分。

PCA的缺点：It is not good for data of **nonlinear structures**, consisting of arbitrarily shaped clusters or curved manifolds.

解决方案：Principal curves/surfaces

#### Linear Discriminant Analysis (LDA)

与PCA不同的是，LDA是一种有监督学习方式（利用数据点所属的类别信息作为监督标签）。LDA transforms multidimensional data to a low-dimensional space, maximizing the linear separability between objects belonging to different classes.

[线性判别分析LDA原理总结 - 刘建平Pinard - 博客园 (cnblogs.com)](https://www.cnblogs.com/pinard/p/6244265.html)

类似于PCA，也是先构造一个待优化的表达式：

LDA的思想可以用一句话概括，就是“**投影后类内方差最小，类间方差最大**”。即要将数据在低维度上进行投影，投影后希望每一种类别数据的投影点尽可能的接近，而不同类别的数据的类别中心之间的距离尽可能的大。

LDA需要让不同类别的数据的类别中心之间的距离尽可能的大，即定义不同类别的数据的类别中心到整体中心的距离之和为Sb：

![LDA_Sb](https://s2.loli.net/2022/03/28/XvqTHLjtmdQeygZ.png)

其中μ为所有样本均值向量

再定义每个类之内的方差之和：

![LDA_Sw](https://s2.loli.net/2022/03/28/SwyAhJFZLBVYij3.png)

得到待优化目标为：

![LDA_Jw](https://s2.loli.net/2022/03/28/S2vxlsq53YjywIX.png)

根据广义瑞利商，上式的最大值是矩阵S−1wSb的最大特征值,最大的d个值的乘积就是矩阵S−1wSb的最大的d个特征值的乘积,此时对应的矩阵**W**为这最大的d个特征值对应的特征向量张成的矩阵。即目标投影面就是矩阵

![image-20220328141141841](https://s2.loli.net/2022/03/28/45bJKFh28Tfa6Qc.png)

的前d个最大特征值对应的特征向量构成的n*d矩阵。

由于**W**是一个利用了样本的类别得到的投影矩阵，因此它的降维到的维度d最大值为k-1，即d<k。为什么最大维度不是类别数k呢？因为Sb中每个μj−μ的秩为1，因此协方差矩阵相加后最大的秩为k（矩阵的秩小于等于各个相加矩阵的秩的和），但是由于如果我们知道前k-1个μj后，最后一个μk可以由前k-1个μj线性表示，因此Sb的秩最大为k-1，即特征向量最多有k-1个。

LDA算法流程：

+ 计算类内散度矩阵Sw
+ 计算类间散度矩阵Sb
+ 计算矩阵S−1wSb
+ 计算S−1wSb最大的d个特征值和对应的d个特征向量(w1,w2,...wd)，得到投影矩阵W
+ 对样本集中的每一个样本特征xi，转化为新的样本zi=WTxi
+ 得到输出样本集D′={(z1,y1),(z2,y2),...,((zm,ym))}

实际上LDA除了可以用于降维以外，还可以用于分类。一个常见的LDA分类基本思想是假设各个类别的样本数据符合高斯分布，这样利用LDA进行投影后，可以利用极大似然估计计算各个类别投影数据的均值和方差，进而得到该类别高斯分布的概率密度函数。当一个新的样本到来后，我们可以将它投影，然后将投影后的样本特征分别带入各个类别的高斯分布概率密度函数，计算它属于这个类别的概率，最大的概率对应的类别即为预测类别。

##### LDA vs PCA

LDA用于降维，和PCA有很多相同，也有很多不同的地方：

**相同点：**

+ 两者均可以对数据进行降维
+ 两者在降维时均使用了矩阵特征分解的思想
+ 两者都假设数据符合高斯分布

**不同点：**

+ LDA是有监督的降维方法，而PCA是无监督的降维方法
+ LDA降维最多降到类别数k-1的维数，而PCA没有这个限制
+ LDA除了可以用于降维，还可以用于分类
+ LDA选择分类性能最好的投影方向，而PCA选择样本点投影具有最大方差的方向

当样本分类信息依赖均值而不是方差的时候，LDA较优：

<img src="https://s2.loli.net/2022/03/28/rAnUlYGQy3x8oja.jpg" alt="img" style="zoom:65%;" />

当样本分类信息依赖方差而不是均值的时候，PCA较优：

![img](https://s2.loli.net/2022/03/28/TrfZLudKvMHAetz.png)

#### Multidimensional Scaling

The goal of multidimensional scaling is to find low-dimensional points Yi = (yi1, yi2,..., yid), such that the distances between the points in the low-dimensional space were as close to the proximities as possible.

**The least-squares objective:**

![image-20220328144626772](https://s2.loli.net/2022/03/28/OwqYN6Us8VTWi3m.png)

wij are non-negative weights

**Normalized:**

![image-20220328145038983](https://s2.loli.net/2022/03/28/Hwadb19oL5kGyc3.png)

**Relative error:**

![image-20220328144807536](https://s2.loli.net/2022/03/28/kDVEdyU6KZpo8vM.png)

The reason for using E(Y) rather than the normalized error σn(Y) is that σn(Y) is almost always very small in practice, so E(Y) values are easier to discriminate.

实际上，存在多种MDS的优化目标函数（多种权值）和对应的优化方法。

##### Local Optimization Strategy

###### SMACOF Algorithm

[sklearn.manifold.smacof-scikit-learn中文社区](https://scikit-learn.org.cn/view/465.html)

[2.降维 - 二、MDS - 《AI算法工程师手册》 - 书栈网 · BookStack](https://www.bookstack.cn/read/huaxiaozhuan-ai/spilt.2.78262ebb86c63967.md)

The multidimensional scaling Stress function(应力方程) can be minimized in the majorization way. The idea of majorization is to replace iteratively the original complicated function f(x) by an auxiliary function g(x,z), where z is some fixed value.

Stress function(objective function to be minimized):

![image-20220328144626772](https://s2.loli.net/2022/03/28/OwqYN6Us8VTWi3m.png)

The set Y = {Y1,Y2,...,Ym} of d-dimensional points may be iteratively calculated by the so-called **Guttman transform formula**(古特曼变换):

![image-20220328164940185](https://s2.loli.net/2022/03/28/QNvDBisw8L4pCc9.png)

where t is the order number of iteration(迭代次数), B(Y(t)) has the elements

![image-20220328164254984](https://s2.loli.net/2022/03/28/zVUsGZxWnvM5SK8.png)

**V** is a matrix of weights with the entries:

![image-20220328164321578](https://s2.loli.net/2022/03/28/PBjsG3dQy2KTmSx.png)

V+是V的Moore-Penrose伪逆，因此Guttman transform formula被简化成：

![image-20220328164527766](https://s2.loli.net/2022/03/28/jt4JekrQlWTLG7I.png)

因此降维算法的SMACOF算法流程：

+ 随机化设置初始启动配置，迭代次数t重置为0
+ 计算变量为Y(t)时的应力σ(Y(t))
+ 根据古特曼变换，计算Y(t+1)
+ 迭代以上两步，直到σ(Y(tn-1)) - σ(Y(tn)) < ε 或 达到最大迭代次数时停止

sklearn中的api:

```python
sklearn.manifold.smacof(dissimilarities, *, metric=True, n_components=2, init=None, n_init=8,n_jobs=None, max_iter=300, verbose=0, eps=0.001, random_state=None, return_n_iter=False)
```

**Diagonal Majorization Algorithm (DMA)**

SMACOF是利用Majorization的方法解目标凸优化函数σ(Y(t))的一种迭代方法（梯度更新是另一种）。SMACOF指定Projection error σ(Y(t))必须定义成如下形式：

![image-20220328144626772](https://s2.loli.net/2022/03/28/OwqYN6Us8VTWi3m.png)

而DMA方法通过定义一个更差的projection error来得到更快的收敛速度，其majorization function为：

![image-20220328170154559](https://s2.loli.net/2022/03/28/Vr6KU2EROBZDqxS.png)

###### Relative Mapping

Relative mapping是一种通过将计算任务（映射后的各objects坐标）分解来加速计算的方法。猜测SMACOF方法的时间复杂度和待求的Y矩阵的object的数量正相关？（迭代次数随object的数量的增加而增加？）因此Relative mapping的idea是先选择一小部分的objects用MDS的通用方法（SMACOF, DMA等）进行映射（mapping），再通过优化下式来保证映射尚未映射的objects的同时已映射的objects被保留下来：

![image-20220328203222933](https://s2.loli.net/2022/03/28/bux5U1QKI24Gtvk.png)

m hat是已经映射过的objects的数量，Yj hat是被映射过的objects在新空间的坐标。可以看出，这个新的projection error表达式仅需要优化（m - m hat）* d 个变量。

Relative mapping对于large data sets比较适用。对于Relative mapping而言，恰当的选择刚开始的小部分objects（basic objects）很重要。The basic objects should be selected so that they were distributed as uniformly as possible all over the data set, which yields better results of the obtained visualization. 

对于高维数据，可以用K-means的方法来选择basic objects。

###### Sammon's mapping

通过令general projection error function中的权值wij取下式：

![image-20220328211420045](https://s2.loli.net/2022/03/28/1MXD6SdCgZt2fxV.png)

可以得到projection error的new form：

![image-20220328211508981](https://s2.loli.net/2022/03/28/9RtmQMerUPnjNCD.png)

Due to the normalization (division by δij), the preservation of small values of proximities is emphasized. 之前的表达式在优化时对于dissimilarity scale本身就较大的两个objects可能效果更明显，而没有强调dissimilarity较小的两个objects的映射。

为了优化上式Es(Y)，Sammon采用了梯度下降的策略：

![image-20220329114621823](https://s2.loli.net/2022/03/29/DFSRKtmbN3Jch8I.png)

where t denotes the order number of iteration, η is an optimization step parameter.

![image-20220329114723582](https://s2.loli.net/2022/03/29/ndrcCJfs6mPN7Mw.png)

由于Es(Y)不一定是一个凸函数，因此其的最终收敛值依赖于步长η和初始值Y(0)的选择。

可以用Gauss-Seidel迭代法来迭代计算y(t)。

![image-20220329120438538](https://s2.loli.net/2022/03/29/5OxvesL3FKANYHB.png)在Jacob迭代法中（最直观的方式），每个yik(t+1)的计算依赖于上一次迭代得到的各yik(t)，因此计算机在计算该公式时需要两组存储单元，来存储yik(t)和yik(t+1)。而Gauss-Seidel迭代法在一次迭代中分别按顺序计算一组数据 i=1,2,...,n 时，假设已经计算到第j行数据了（即已经得到y(j-1)k(t+1)，待计算yik(t+1), i>j)，此时直接利用y(j-1)k(t+1)来替换计算yjk(t+1)所需要的y(j-1)kt。即Gauss-Seidel迭代法仅需要一组存储单元，每次计算出新的yjk(t+1)就可以替换掉本来的yjk(t)。

关于Jacob迭代法和Gauss-Seidel迭代法：

[雅可比迭代和高斯赛德尔迭代 - 加拿大小哥哥 - 博客园 (cnblogs.com)](https://www.cnblogs.com/hxsyl/p/4193868.html)

![image](https://s2.loli.net/2022/03/29/UIVm4jueAyrczgJ.png)

![image](https://s2.loli.net/2022/03/29/2fgdo1CpySj3iuX.png)

![image](https://s2.loli.net/2022/03/29/ibGZI7LWMeFOqE6.png)

![image](https://s2.loli.net/2022/03/29/SNMYWK1fhJceT4V.png)

![image](https://s2.loli.net/2022/03/29/tqDnvobeGJL9ds7.png)

![image](https://s2.loli.net/2022/03/29/juT1qxhyr8mn4vM.png)

![img](https://s2.loli.net/2022/03/29/hHLobdKzZf5QDas.png)

#### Manifold-Based Visualization

[流形学习概述 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/40214106)

Most of real-life data are **multidimensional**, but they are not truly **high-dimensional** (not as high as the vector space). Multidimensional points just lie on a low-dimensional **manifold** embedded into a high-dimensional space. 流形是高维空间中的几何图形（空间）的统称，每一个点的邻近空间都可以被近似成一个欧式空间。

非线性流形学习方法是topology preserving方法，即保持点与点之间在领域的几何关系（欧式空间）。如果在流形空间中位于领域的两点之间距离较近，则将其展开到低维空间以后两点也应该距离较近。

对于所有的流行学习方法而言，都包括以下几步：

+ 衡量样本点的邻居点（认为分布于欧式空间，可以线性近似），构建邻域图
+ 衡量邻居点之间的关系（欧式距离、线性表示等）
+ 根据第二步建立的邻域集关系构造优化问题并求解

实际上，大部分的方法对于上述第一步的操作都是类似的。主要有两种方式来判断一个点i的邻居点：

1. 预先设定一个距离阈值，分别遍历每个点到点i的欧式距离是否小于这个距离阈值，并加入邻域集合（阈值的给出缺乏先验知识有时难以确定）
2. 先算出全体数据点集合N中各点相互之间的欧式距离，再用K近邻法筛选每个点i的K个邻居结点（K的选择）

##### Isometric Feature Mapping (ISOMAP)

ISOMAP is a **global** approach that attempts to preserve geometry at all scales: nearby multidimensional points are projected to nearby points in a low-dimensional space, and faraway multidimensional points to faraway low-dimensional points.

ISOMAP方法计算了N中每个点之间的距离：对于相邻样本点直接采用欧式距离近似；对于不相邻的样本点，采用测地线距离（通常采用Dijkstra算法得出连通图各点之间的最小路径）。将这些距离存储到距离矩阵DG中。

![image-20220330171305018](https://s2.loli.net/2022/03/30/D8Xrputah3TfOYb.png)

如上图所示，a是欧式距离，b是测地线距离。

模仿MDS方法，构造内在d维子空间，最小化下式：

![image-20220330171435661](https://s2.loli.net/2022/03/30/zehQTyD7OSvKs8N.png)

之后再采用MDS章节介绍的几种方法来求解这个优化问题即可。



##### Locally Linear Embedding (LLE)

LLE假设有足够多数据点，且每个数据点和它的邻居点分布在同一个局部线性区域。因此，一个数据点的坐标可以用它的邻居结点的线性组合来（最小二乘意义下）近似。LLE方法即是把这种线性拟合的系数当成这个流形的局部几何性质的描述（ISOMAP方法是用邻居结点之间的欧式距离来吗描述流体的局部几何性质）。The basic idea of LLE is that such a linear combination is invariant under linear transformations (translation, rotation, and scaling) and, therefore, it should remain unchanged after the manifold has been unfolded to a low-dimensional space.

算法步骤：

+ 构建邻域图（通常用K近邻法，因为一个k维的流体（局部欧式空间为k维）可以用k+1个线性不相关向量的线性组合表示）

+ 计算权重。由局部线性假设，样本点xi可用其K 个邻域点 xj 线性表示，即 xi≈∑Wi,jxj，用权重描述出每一样本点与其邻域点之间的关系，权重 Wi,j是使得样本点xi用其K个邻域点 xj重构误差最小的解的系数：

  ![image-20220330200249652](https://s2.loli.net/2022/03/30/TCWOrbonVLyz8Ui.png)

+ 将这种局部线性结构嵌入低维空间。嵌入操作是通过最小化误差来尽可能多的保留原空间的性质：

  ![image-20220330200436925](https://s2.loli.net/2022/03/30/LBIefAbdHmQJho9.png)

  subject to:

  ![image-20220330200508075](https://s2.loli.net/2022/03/30/QpS9OFJ6mgoADRh.png)

  这里的 Wi,j是第二步计算的权重值，yi与 yj是样本点在嵌入空间的投影。

  求解目标d维Y矩阵的最直接方法是找出如下稀疏矩阵的最小的d+1个特征值对应的特征向量：

  ![image-20220330201041698](https://s2.loli.net/2022/03/30/WibLqkx16YAPCvO.png)

  最小的特征值接近0，该特征向量 is the unit vector with all equal components and it is discarded. 剩余的d个特征向量则构成的嵌入局部线性关系后的d维矩阵Y。

Isomap 与LLE的比较：

+ Isomap与LLE从不同的角度出发来实现同一个目标，它们都能从某种程度上发现并在映射的过程中保持流形的几何特征；
+ Isomap希望保持任意两点间的测地线距离；LLE希望保持局部线性关系；
+ 从保持几何角度来看，Isomap保留了更多信息，然而Isomap方法的一个问题是要考虑任意两点之间的关系，这个数量随着数据点的增多而呈现爆炸性增长，从而增加计算负荷，在大数据时代，使用全局方法分析巨型数据结构正在变得越来越困难；
+ 因此，以LLE为开端的局部分析方法的变种和相关理论正在受到越来越多的关注；

LLE可以将距离的衡量方式改为kernel distance（之前是euclidean distance）来在kernel feature space寻找邻居点，从而获得一些generalization (KLLE) 。

LLE的重点在于如何选取邻居结点数量K。K值若太小（下图k=5的情况），则本来的连续流形可能会被错误地划分为一些无法连接的子流形（disjoint sub-manifolds），从而无法充分展现global properties（对流形的维度预估过小，数据点难以用K个点的坐标线性表示）；K值若太大（下图K=100的情况），此时数据如果比较稀疏，则流形中本来存在的一些small-scale structure就可能被smooth or eliminate（退化成PCA和MDS）。K的值因具体情况而不同，通常取决于sampling density和manifold geometry。

![image-20220330202820521](https://s2.loli.net/2022/03/30/DCvi3TpjJ1PmSdU.png)

LLE的一个应用场景是动态物体image analysis。For example, shown below is a set of uncolored pictures, obtained by gradually (by 5◦ ) rotating a duckling around. The number of pictures is m = 72. The pictures consist of 128×128 gray-scale pixels, therefore the dimensionality of data is n = 16384. **Intuitively, one would expect multidimensional data that represent these pictures, to lie on a manifold parameterized by a rotation angle.**

![image-20220330203235811](https://s2.loli.net/2022/03/30/eMXGVKukOUl9Lsx.png)

##### Laplacian Eigenmaps (LE)

和前面两种方式类似，LE希望保持流形中的近邻关系：将原始空间中相近的点映射成目标空间中相近的点。

令样本集 X=(x1,x2...xn)，投影后的样本集为 Y=(y1,y2...yn)

LE的目标是最小化目标函数：

![img](https://s2.loli.net/2022/03/30/bStuIv1f74Tcowj.png)

Wij表示的是原始空间中结点i和j之间的距离权重系数组成的矩阵。若i和j是近邻关系，则

![img](https://s2.loli.net/2022/03/30/UYdrgbcyWGiAsIt.png)

否则Wij等于0。

**物理意义：**

如果ij是近邻关系（现在假设的是降维后的空间和原始空间一样都是满足近邻关系，这里只考虑近邻关系，不考虑全局的信息），比如原始空间中i和j是比较接近的,也就是dist(xij)比较小（如果ij不是k近邻的关系，那么Wij等于零，就不需要进行计算了），那么Wij（是dist(xij)的减函数）就比较大，那么为了满足min，降维后的dist(yij)就应该满足比较小的设定。相反，如果原始空间中i和j是比较远的(也就是dist(xij)比较大)，那么Wij就比较小了，此时允许dist(yij)相对Wji较大的情况不必被映射得很近。

此后根据下式推导：

![img](https://s2.loli.net/2022/03/30/N6eDojyvETQcMFX.png)

构造出一个拉普拉斯矩阵L= D - W，得到目标函数：

![image-20220330204301214](https://s2.loli.net/2022/03/30/eEmQg4FBcniUTRG.png)

转换成一个求广义特征向量问题：

![image-20220330204415373](https://s2.loli.net/2022/03/30/d7vISloJb1QutW5.png)

从而解得使得目标函数最小得映射后d维矩阵Y。

**关于图拉普拉斯矩阵：**

[谱聚类方法推导和对拉普拉斯矩阵的理解 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/81502804)

[散度、旋度与拉普拉斯算子 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/53794607)

拉普拉斯算子（Laplace Operator）是 ![[公式]](https://www.zhihu.com/equation?tex=n) 维欧几里得空间中的一个二阶微分算子，定义为梯度（ ![[公式]](https://www.zhihu.com/equation?tex=\nabla+f) ）的散度（ ![[公式]](https://www.zhihu.com/equation?tex=%5Cnabla++%5Ccdot) )。

笛卡尔坐标系下的表示法（以三维为例）：

![image-20220330204727579](https://s2.loli.net/2022/03/30/8vABbjHwuPgXixo.png)

可以将拉普拉斯算子转化为离散形式（以二维为例）：

![image-20220330204841255](https://s2.loli.net/2022/03/30/clnykZhxg1mTzIo.png)

其矩阵表示形式为：

![[公式]](https://www.zhihu.com/equation?tex=\left(+{\matrix{++++0+%26+1+%26+0++\cr+++++1+%26+{+-+4}+%26+1++\cr+++++0+%26+1+%26+0++\cr++++}+}+\right))

**实际上，拉普拉斯算子计算得到的是对矩阵中某一点进行微小扰动后获得的总增益**

将这个结论推广到图后得到图拉普拉斯矩阵。

假设具有 ![[公式]](https://www.zhihu.com/equation?tex=N) 个节点的图 ![[公式]](https://www.zhihu.com/equation?tex=G) ，此时图中每个节点的自由度至多为 ![[公式]](https://www.zhihu.com/equation?tex=N) ，此时该图为完全图，即任意两个节点之间都有一条边连接，则对其中一个节点进行微扰，它可能变为图中任意一个节点。

此时f可以看作自变量部分相连（结点之间权重为0则不相连）的离散函数，自变量的取值对应图中的各个结点。对 ![[公式]](https://www.zhihu.com/equation?tex=i) 节点进行扰动，它可能变为任意一个与它相邻的节点 ![[公式]](https://www.zhihu.com/equation?tex=j+\in+N_i) , ![[公式]](https://www.zhihu.com/equation?tex=N_i) 表示节点 ![[公式]](https://www.zhihu.com/equation?tex=i) 的一阶邻域节点。则将拉普拉斯算子应用到结点i得到：

![[公式]](https://www.zhihu.com/equation?tex=\Delta+{f_i}+%3D+\sum\limits_{j+\in+{N}}+{{w_{ij}}({f_i}+-+}+{f_j}))

继续推导有：
![[公式]](https://www.zhihu.com/equation?tex=+\begin{array}{l}+\Delta+{f_i}+%3D+\sum\limits_{j+\in+N}+{{w_{ij}}({f_i}+-+{f_j})}+\++\\%3D+\sum\limits_{j+\in+N}+{{w_{ij}}{f_i}+-+\sum\limits_{j+\in+N}+{{w_{ij}}{f_j}}+}+\++\\%3D+{d_i}{f_i}+-+{W_{i%3A}}f+\end{array}+)
对于所有的 ![[公式]](https://www.zhihu.com/equation?tex=N) 个节点有：

![[公式]](https://www.zhihu.com/equation?tex=\eqalign{+++%26+\Delta+{f}+%3D+\left(+{\matrix{++++{\Delta+{f_1}}++\cr++++++\vdots+++\cr+++++{\Delta+{f_N}}++\cr++++}+}+\right)+%3D+\left(+{\matrix{++++{{d_1}{f_1}+-+{W_{1%3A}}f}++\cr++++++\vdots+++\cr+++++{{d_N}{f_N}+-+{W_{N%3A}}f}++\cr++++}+}+\right)++\cr++++%26++%3D++\left(+{\matrix{++++{{d_1}}+%26++\cdots++%26+0++\cr++++++\vdots++%26++\ddots++%26++\vdots+++\cr+++++0+%26++\cdots++%26+{{d_N}}++\cr++++}+}+\right)f++-+\left(+{\matrix{++++{{W_{1%3A}}}++\cr++++++\vdots+++\cr+++++{{W_{N%3A}}}++\cr++++}+}+\right)f+\cr+++++%26++%3D+diag({d_i})f+-+Wf++\cr++++%26++%3D+(D-W)f++\cr++++%26++%3D+Lf+\cr}+)

这里的![[公式]](https://www.zhihu.com/equation?tex=(D-W)) 实际上就是的拉普拉斯矩阵 ![[公式]](https://www.zhihu.com/equation?tex=L)
根据前面所述，拉普拉斯矩阵中的第 ![[公式]](https://www.zhihu.com/equation?tex=i) 行实际上反应了第 ![[公式]](https://www.zhihu.com/equation?tex=i) 个节点在对其他所有节点产生扰动时所产生的增益累积。直观上来讲，图拉普拉斯反映了当我们在节点 ![[公式]](https://www.zhihu.com/equation?tex=i) 上施加一个势，这个势以**哪个**方向能够多**顺畅**地流向其他节点。谱聚类中的拉普拉斯矩阵可以理解为是对图的一种矩阵表示形式。

因此，从拉普拉斯矩阵的角度来理解LE，即最小化对各结点产生扰动时它们邻居结点的增益累计的和。

##### Locality Preserving Projection (LPP)

[局部保留投影算法(LPP)（Locality Preserving Projections）详解_AlanDreamer的博客-CSDN博客_lpp算法](https://blog.csdn.net/qq_39187538/article/details/90402961)

LPP就是在LE方法中，通过Y=X*A来线性近似。在LE方法中，是通过求解广义特征向量问题：

![image-20220330204415373](https://s2.loli.net/2022/03/30/d7vISloJb1QutW5.png)

来直接解得非线性映射后的d维矩阵Y。但是这个方法的缺点是其只能映射原本的训练数据点，不能评估（映射）新的测试数据。而由于LPP方法解得的是一个线性变换矩阵A，因此可以很容易地将新的测试数据点投影映射在低维空间中。

LPP方法在求解目标函数：

![image-20220330204301214](https://s2.loli.net/2022/03/30/eEmQg4FBcniUTRG.png)

时，令 Y=X*A （ *代表转置 ），将优化问题转化成：

![img](https://s2.loli.net/2022/03/30/r1kIVb4Bi5aoGY2.png)

最后转化成求解下面广义特征向量问题：

![image-20220330211843281](https://s2.loli.net/2022/03/30/Oli5ET8WBca2IPk.png)

由于不一定总是存在一个变换矩阵A，使得Y=X*A成立，因此LPP仅仅是LE方法的一个线性近似。但也正由于线性变换的引入，使得LPP方法更容易应用在实际问题中。

##### Conclusion

可以看出，以上四种方法其实都大同小异。第一步都是利用流形的局部线性性质先求得每个结点的邻居结点，再用不同的方式描述这种局部线性关系。这四种方法都是希望在映射之后也能保留原来的这种局部线性关系，从而各自设计了自己的目标优化函数。

ISOMAP希望整个数据集的各结点之间的距离（邻居结点之间为欧式距离，非邻居结点为测地线距离）在映射前后相似：

![image-20220330171435661](https://s2.loli.net/2022/03/30/zehQTyD7OSvKs8N.png)

LE和LPP仅希望保持邻居结点之间距离的比例（用权值来刻画映射前空间邻居结点的距离关系）：

![img](https://s2.loli.net/2022/03/30/bStuIv1f74Tcowj.png)

LLE则希望保持映射前后邻域结点之间的线性组合关系：

![image-20220330200436925](https://s2.loli.net/2022/03/30/sQv2yRteDwTkOLp.png)





# Resources

数据项目分析实例：[开发者自述：我是如何从 0 到 1 走进 Kaggle 的 (sohu.com)](https://www.sohu.com/a/143064983_114877)

可视化产品：[SandDance - Demo Vote (microsoft.github.io)](https://microsoft.github.io/SandDance/app/)

Potential Data sets: **MESA** [Multi-Ethnic Study of Atherosclerosis - Sleep Data - National Sleep Research Resource - NSRR](https://sleepdata.org/datasets/mesa)

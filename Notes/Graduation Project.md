# Graduation Project

### 笔记日志

#### **3月31号会议记录**

工作量的体现基本已经满足（各种可视化策略按照逻辑整理好就已经有可观的工作量了），现在欠缺的是将各种可视化策略通过一些更深层的分析串联在一起（所谓毕业设计）。本课题重在分析，一是要分析灰视和影响变量之间的关系（课题的研究客体）；二是要对可视化方法的特点进行分析（研究方法本身也是研究的客体）。

现在的思路是：

+ 先想清楚本课题中研究灰视到底需要得出怎么一个结论：是灰视与主要影响变量的函数关系吗？是根据各维度影响变量来对是否灰视进行分类或者预测灰视指数吗？
+ 其次是对各种可视化策略的本质进行归纳总结（比如散点图和曲线图都是表征一个变量与另一个变量的关系，但散点图的各轴之间可能没有序列关系；而曲线图的其中一轴往往是时间序列），并将各种可视化方法按照它们主要能用于解决的问题来分类。
+ 接下来将第一点得出的最终研究的关于灰视的目标划分为几个阶段，每个阶段又根据第二点总结出的不同研究目标对应的各功能重点不同的可视化方法来选择恰当的方法进行可视化。这就是一个分析目标，分析方法，再根据目标选择恰当的方法的设计分析过程。

例如，假如最后想要得到灰视指数与某些相关维度变量的函数关系，我认为可以将这个目标分为四个阶段：

+ 分别分析每个变量与灰度指数的关系（散点图、函数关系拟合）
+ 筛选出几个重要的变量（根据第一步得出直观结论，热力图）
+ 进一步研究灰度指数与这几个变量的关系（各种可视化方法）
+ 拟合函数关系（model-based方法，神经网络）

例如，假如在第一步可视化灰度指数和脑血压关于时间的曲线时，发现两者仅在时间位于某一个时间区间内（或在另一个相关变量位于某个范围内时）才呈现正相关，则这几个变量都相互耦合，且不能直接将这些变量的全体数据拿来进行下一步可视化（可能会掩盖数据的intrinsic关联而导出错误的结论）。此时利用human-in-the-loop的优势，用户可以手工选择出一些区间段的数据，形成新的降维降数据量（矩阵的行列均缩小）后的数据集，进行下一步分析。假如这一步已经剥离了时间的维度，就可以采取相关矩阵，parallel coordinate，脸谱图等方法来进一步分析灰视与这些高维度变量的耦合关系了。总之，**Human-in-the-loop的思想应该贯穿整个课题设计！**

#### **4月8号思考**

本课题的名称为：多维**动态**数据可视化分析方法研究。所谓“动态”，就强调对“时间”的考虑在灰视症状的产生发展过程中的重要性。而目前大部分的可视化项目在分析目标变量和多维自变量的关系时，考虑的都是静态数据（即目标变量仅与其余各变量在当前时间点的值有关（马尔可夫事件），时间不是单独的一个维度）。然而灰视现象在飞行员的飞行过程中是由多重因素在一段时间内的动态变化造成的（例如脑血压在短时间内的增加速率），因此在本课题中有必要将“时间”作为单独的维度来考察。目前想了如下几种方法来嵌入对“时间”的考虑：

+ 将“时间”作为与其余各维度平行的一个维度来降维及可视化（先normalization）；
+ 先用简单的可视化策略呈现灰视指数（是否灰视）及选中的某几个变量关于时间的变化关系，人为选中最相关某个较小的时间区间，in which 灰视和这几个变量最相关（人为剥离时间维度）。之后将这个区间内的数据提取出来再做可视化分析（此时可以不再考虑时间问题）；
+ 先不考虑时间因素，用常用的降维方法（MDS, PCA, SOM等）对数据集进行降维，投影到2维平面上。从一个目标（飞行员）上采集的一序列（时间序列）数据，分别采用该投影方式获得对应的二维时间序列数据。用一个高次多项式函数来拟合这些数据，获得飞行员抽象生理状态表征随时间的变化轨迹。最后通过计算任意一条轨迹和出现过灰视现象的轨迹的距离（曲线距离），就可以定性地判断这条轨迹是否也出现过灰视现象，甚至可以自定义两轨迹的距离为”安全/危险指数“；
+ 接上一个方法，不过这里不是用全部时间序列的数据来判断两条曲线的相似程度进而推断灰视程度，而是拟合灰视指数关于降维后的数据点（二维）加上时间维度（一共三维）的函数关系。从而利用这个函数关系，只要输入某一个时刻的生理数据以及该时刻，就可以预测该时刻（以及下一时刻）的灰视指数了（也可以是判别分类模型）。当然，这里也可以不降维，直接利用原维度加上时间维度训练预测模型；



#### 4月10日

UI界面的结构构思：

**主页面**：包含上面一行工具栏，左边一列导航栏，下面一行调试栏。

**工具栏**：数据（导入数据，查看数据，数据统计，数据筛选），用户登录，页面个性化（更换皮肤）

**导航栏**：汇集各种数据操作（降维，可视化）方法。折叠方法分类如下：

+ 数据处理流（对数据流的各分支的处理记录，提示用户对哪些数据采取了怎样的操作，避免混淆）

+ 数据降维（线性、非线性、基于神经网络）
+ 数据直观呈现（散点图、折线图等）
+ 数据结构呈现（Andrews曲线，Parallel Coordinates等）
+ 数据分布呈现（KDE拟合，箱线图，小提琴图，联合概率分布等）
+ 数据关系呈现（函数关系拟合，热力图）
+ 各类别数据的表征维度规律（Radviz，脸谱图，dimensional stacking等）

**调试栏**：打印调试信息

#### 4月12日会议记录

就该课题而言，我的工作涉及面较广。老师再三提醒要抓住毕设的各个节点，首先保证顺利毕业。老师认为SOM方法需要对数据进行建模，潜在工作量可能较大，建议仅将该部分粗浅完成即可，重点应该放在更初级的可视化工作上。老师认为可视化可以分为三个部分：

+ 单变量可视化/数据直观呈现（直方图、KDE、折线图等）
+ 数据相关关系分析（相关矩阵、热力图（局部极值））
+ 深层（隐性）特征提取（降维分析、建立灰视指标的分类器、预测器）

老师说上面三个部分至少各实现一种方法，该项目的重点在于对方法的分析，需要少而精（主要是工作量太大，时间不足）。对于分析，可以给出一套可视化的策略，例如做完单变量可视化之后根据得到的结果下一步应该采取怎样的操作（例如PCA），PCA之后又应该根据情况采取哪些后续操作。对于UI界面的设计，应该有一个指导原则（始终记住这是一个毕业设计课题，不仅仅是工程实践）。UI界面需要考虑页面的层次关系（每个子页面实现相同层次的功能）。

#### 4月19日会议记录

+ 落实文字工作，开始写论文，做Slide，系统性地体现项目结构和工作；
+ 重点在于分析各种可视化策略的优势，即哪些可视化策略擅于展现数据的哪种特征，提取出来一套方法选择的策略，产出一个表格；不要仅仅呈现各种可视化方案，而要去对它们的特点进行抽象总结；



#### 4月23日论文准备工作

研究课题的分析方案、软件的逻辑搭建和论文的撰写都需要有一个总的思维指导目标。对于诸多的可视化方案，需要总结抽象出各种方法的本质，再进行比较和归纳。

**先对可视化方法进行汇总（可视化与降维解耦）**：

+ 概率分布
  + 对于某一维度（变量）的可视化 / 列的可视化
    + 直方图（histogram）
    + 概率密度函数（PDF）/ 核密度估计（KDE）/ 联合概率分布
    + 箱线图 / 小提琴图

+ 数据分布（主要是映射到坐标平面上）

  + 对于某一行数据的可视化 / 行的可视化

    + 散点图 / 折线图（无时间轴）

    + 启发式降维：Andrews曲线 / Parallel Coordinates / Hierarchical Parallel Coordinates / Radviz / Polyviz
    + Hierarchical Display：维度堆叠 / Trellis Display
    + 启发式映射：脸谱图（Chernoff Faces) / 星线图（Stars）

+ 时序分布（映射到坐标平面上，且能体现时间维度）
  + 直接呈现：
    + 折线图 / 拟合曲线图
  + 间接呈现：即将映射到坐标平面上的各方法以分段时间区间为标签分类可视化
    +  散点图（将时间分段后，通过hue的方式呈现为第三维度）：寻找数据之间最具关联的时间区间
    + 启发式降维：寻找不同时间段的数据分布规律；启发式映射：寻找不同时间段的数据特征
    + Trellis Display：最内层用时间轴作为x轴，呈现多维数据下目标变量与时间的关系



**Conclusive Table**:

![image-20220424232039983](https://s2.loli.net/2022/04/26/ipHxyemt5hFcRgI.png)



**模拟数据集：**

+ 筛选数据（有效时间区间）：
  + 折线图：选择与灰视产生相关性大的区间（飞行员灰视感受标记曲线，眼压-血压=眼灌注压曲线，血压（BP，正常60-90/90-140mmHg），心率（HR,正常60-100次/分钟），血氧饱和度（SPO2,正常95%-100%），体温（TEMP,正常35.5-37.5摄氏度），呼吸（呼吸频率RR，正常16-20次/分钟），飞行系统速度/加速度曲线，(正G力曲线)，俯仰角，偏航角，滚转角）
  + 散点图、Radviz、Andrews曲线，发现数据分布整体存在规律的区间
+ 筛选维度（相关性大的维度）：



维度：时间轴、飞行员灰视感受标记曲线、血压、眼压、



#### 4月26日会议记录

总体评价：很好；课题分析上有自己的思考；前面的可视化方法分析表格很不错（有意义，有趣）；数据集的获取方式：极好（Surprise，体现出主观能动性，主动获取仿真数据比直接在网上找数据集好很多）

+ 进一步优化Slide
  + Reconstruction: 将4个Stage作为主线（横轴方向的拓展），再将可视化方法、降维方法等方法的抽象总结作为各个stage的纵轴的拓展；
  + Stage 0：将“从数据中剔除异常数据” 改为预处理，因为预处理包括了去除异常数据、不同通道的同步（根据相同事件）等操作；对每个Stage的讲解要分**目标**(要做什么，为什么要这么做）、需求(怎么做) 和方法三个层次。例如在预处理的Stage，目标是先对整个数据集做预处理（为什么要这么做：可能有和预设分布不同的异常数据存在，传感器的delay可能导致不同通道数据之间没有同步）；怎么做：剔除异常值：确保异常值的出现是不符合常理和预设合理的最极端情况的，而不是一些合理却罕见的场景，**方法**：极端值：箱线图、小提琴图；数据分布：KDE、直方图；**怎么做**：时间轴同步需要先找到相同的事件，然后再根据同一事件时间点调整不同通道的delay关系，**方法**：折线图。
  + Stage 3：尽量维护降维之后数据点的时间关系
  + 采集数据的方式很有新意，可以多用一些笔墨来介绍；这样物理数据仿真得到，生理数据自己构想的方式很好，但在写论文的时候一开始就声明生理数据是自己构想的函数关系（毕竟现在都没有得到明确的函数关系，可以充分发挥想象空间），不要给别人怀疑的机会。对于生理数据的生成，可以考虑人的生理指标会略微延后物理变化（有一个delay），而且人的身体会对外界的扰动有一个补偿机制。
  + 科研课题的进行，都要把握住目的-需求-方法的流程，例如在Stage 1，需要对“有效区间”有明确定义，分析找有效区间的目的，为什么要这样做，以及如何做。如何做需要明确，尽可能细化，能让使用者很清晰明确地知道每一步要做什么，怎么做。例如，筛选有效区间地方法可以是：先找出一个参考量（例如Greyout Indicator），再在这个参考量周围去观察其他变量的变化趋势和规律。这个过程尽可能多一些确定的选择指标，例如量化指标（例如在用散点图筛选有效时间区间的时候，可以对各个时间区间加一个KDE的量化指标评价）。



#### 5月3日会议记录

+ 毕业论文正文内容按照“数据呈现”、“数据关联”和“特征提取”三个Stage来展开论证，不要按照之前的结构（可视化方法综述、灰视案例分析和软件的制作）。绪论部分先讲**为什么要可视化**（可视化做得好的好处，做得不好的坏处），**怎么样可视化**（先呈示可视化在数据分析的三个阶段的作用，再分别引用文献，说明其他人在这三个阶段分别采用了怎么样的方法）；接下来引入灰视视觉症状，说明分析这种类型的数据在三个阶段中分别具有什么样的特征以及会遇到什么样的困难（instance的特殊性），然后再总述论文提出对应的解决方案。总之，整篇文章无论是在绪论还是正文部分，都应该是按照数据分析的三个阶段中，分“为什么以及怎么样应用可视化技术”、“可视化的难点”以及“提出的解决方案”这几点来论述。
+ 软件设计应该是对前面的理论研究的一个实践验证，因此需要和提出的方法论紧密联系。不需要将软件做的很好，重要的是能通过软件体现论文的思想以及分析和实验过程。软件设计放在最后作为单独的一个章节论述。例如，在三个stage中，关于如何选择具体的可视化策略来进行相应的分析肯定有一个较为通用和流程化的方法论（如何选择数据、哪些数据对于现象分析更为重要），因此可以按照这样的方法论来考虑软件层次的搭建和界面的布局。







**本可视化课题主要分两条线索进行：**

+ 可视化策略以及相关算法的实现（基于Python）
+ UI界面的设计（基于C# Winform）

### 可视化策略

由于实际数据集无法得到，我们假设数据集有100个维度以上（包含灰视标签）。因此直接对这100维数据做可视化是不可能的，因此以下提供了两种策略：

+ 基于用户自定义的数据可视化
+ 基于灰视（目标标签变量）的可视化分析

第一种是用户根据自己的先验知识选择较相关的一些维度来进行可视化；第二种是基于一些自动降维算法和变量相关性分析的方法来进行可视化。

#### 基于用户自定义的数据可视化

由于本软件仅为一个可视化工具，不能也不需要嵌入太多与医学相关的先验知识，即采取尽可能general的手段来呈现数据以及分析多维变量与目标标签变量的关系。

当一个有经验的医学工作者在使用这款软件时，我们假设其对灰视的成因以及主要影响因素已经有了相当的了解，因此他可以从本来高维的数据中自由地选择一些他认为与灰视相关的维度（不超过8个）来进行可视化分析。

对于8个维度左右的可视化，参考我的Notes on Visualization里写的笔记，将可视化策略分类成了单变量分布、双变量结构、双变量分布、多变量直观可视化、多变量函数关系、多变量相关性等方法。计划在软件中对上述所有的方法都进行实现，允许用户选择具体的方法对其感兴趣的数据进行可视化。

根据我在Notes on Visualization里的总结，可以将可视化方法（不包含降维部分）分为五种：

+ 数据直观呈现（散点图、折线图等）
+ 数据结构呈现（Andrews曲线，Parallel Coordinates等）
+ 数据分布呈现（KDE拟合，箱线图，小提琴图，联合概率分布等）
+ 数据关系呈现（函数关系拟合，热力图）
+ 各类别数据的表征维度规律（Radviz，脸谱图，dimensional stacking等）



#### 基于目标标签变量的可视化分析

上一节的重点在于对数据本身的呈现，而这一节着重对数据进行分析。对数据的分析首先要降维，降维方法大致可以分为两种：

+ 选择与目标变量相关性最大的几个维度组成新的数据集
+ 利用投影方法来降低维度，主要服务于分类任务

对于第一种方法，目前想到的是先建立一个相关矩阵（热力图）：

![img](https://s2.loli.net/2022/03/31/8mRnfvLe25trKOx.png)

选取与目标变量相关性较大【颜色深】（且相互之间相关性小【颜色浅】）的几个特征来利用general方法可视化。

对于第二种方法，可以采用各种线性的（PCA，LDA），非线性的（MDS，流形学习）方法来降维（投影）。由于这些方法仅仅是在整个降维后的空间中寻找使得目标式子最优化的投影方向，因此这些投影方向很可能是没有实际物理意义的。仅仅基于这些没有实际物理意义的投影方向进行可视化意义不大，因此现在的想法是在本可视化平台上实现一个分类器（预测器），将目标变量（灰视）看作取值为0，1的离散变量来构成一个二分类问题，或将灰视指数看作目标变量，来构成一个连续变量的预测问题。初步想法是先嵌入一些简单的模型（SVM，EM），来学习这个分类任务，后期如果有时间再嵌入一些基于神经网络的方法。



### UI界面的设计

**三层架构：**

1. UI：用户交互层 --由C#实现
   + 供用户操作数据，选择可视化模式和窗口
2. BLL：UI与DAL的桥梁 --由C#和Python实现
   + 包裹一层C#函数 供UI层调用
   + 内核为Python程序 通过Flask服务器方式调用Python程序
   + Python程序实现各种可视化功能
   + 定义C#函数调用DAL层的方法来获取数据库中的数据
3. DAL：数据访问层 --由C#实现
   + 调用MySQL的数据：实现全局表格导入和基本的选中部分属性列导入即可。仅实现查功能，暂时不需要实现增、删、改功能

UI Template：[SunnyUI](https://gitee.com/yhuse/SunnyUI/wikis/pages?sort_id=3025093&doc_id=1022550)

#### BLL层

##### C# <> Python

方法总述：[一 、C#调用Python的使用总结 - 卢大鸽 - 博客园 (cnblogs.com)](https://www.cnblogs.com/ludage/p/12461403.html)

###### 基于Flask的Python和C#交互

[欢迎使用 Flask — Flask 0.10.1 文档 (jinkan.org)](http://docs.jinkan.org/docs/flask/index.html)

**关于Flask：** Flask是一个符合WSGI标准的Framework（[WSGI协议介绍-CSDN博客_wsgi协议](https://blog.csdn.net/j163you/article/details/80919360)）WSGI标准是为Python语言定义的Web服务器和Web应用程序或框架之间的一种简单而通用的接口。

WSGI描述了Server与Framework之间通信的规范，简单来说，WSGI规范了以下几项内容：

+ WSGI协议主要包括server和application两部分，server负责接受客户端请求并进行解析，然后将其传入application，客户端处理请求并将响应头和正文返回服务器（严格说来，还有一个模块叫做中间件middleware，但中间件也同样使用上述两种接口进行通讯）；
+ 从application的角度来说，它应当是一个可调用的对象（实现了__call__ 函数的方法或者类），它接受两个参数：environ和start_response，其主要作用就是根据server传入的environ字典来生成一个“可迭代的”http报文并返回给server；
+ 从server的角度来说，其主要工作是解析http请求，生成一个environ字典并将其传递给可调用的application对象；另外，server还要实现一个start_response函数，其作用是生成响应头，start_response作为参数传入application中并被其调用；

使用实例（套用即可）：[四、基于Flask的Python和C#交互（中篇） - 卢大鸽 - 博客园 (cnblogs.com)](https://www.cnblogs.com/ludage/p/13710687.html)

（客户端）C#只需要添加相应的Url（对应Python Flask路由）和输入参数（传递给Application的参数）即可；

（Application）Python Flask脚本增加对应的路由即可；以此形成客户端-Server-Application（Framework）的交互模式

**Python Flask脚本：**

``` python
# !/usr/bin/python
# -*- coding: UTF-8 -*-
# python服务器如果需要访问静态的文件，都需要放到static这个指定的文件夹。


from flask import Flask, jsonify, request
from flask import render_template
from wtforms import StringField, Form
from wtforms.validators import DataRequired
import AddNum


app = Flask(__name__)
app.logger.info('Finished Start Flask!')


# 开始数据转移
@app.route('/add/', methods=['POST']) # POST是一种HTTP方法（客户端访问URL Server的请求类别）POST：客户端告知服务器：想在URL上发布新信息；GET（默认存在的）：客户端告知服务器：只获取页面上的信息发送给我
def startTransfer(name=None):
    if request.method == 'POST': # 此处使用”POST“方法是因为C#客户端要将待相加的参数传递给Server
        receiveData = request.data.decode('utf-8')    # 为了兼容中文输入
        para = str(receiveData)
        print(para)        #输出接收到的信息
        array = str(para).split('#')
        sum = AddNum.Add(array[1], array[2])
        return str(sum)


if __name__ == '__main__':
    app.run(host='127.0.0.1', port=8000, debug=False, threaded=True)
    # debug=True 时设置的多线程无效
    # 多线程和多进程功能只能开一个     1.processes=True      2.threaded=True
```

**C#客户端：**

```c#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlaskClient
{
    public partial class FlaskClient : Form
    {
        public FlaskClient()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string log = "";//错误信息
            string Url = this.textBoxUrl.Text;//功能网址
            string add1 = this.textBoxAdd1.Text;
            string add2 = this.textBoxAdd2.Text;
            string jsonParams = "#" + add1 + "#" + add2 + "#";
            string result = RequestsPost(Url, jsonParams);
            if (result == null)
            {
                log = "Failed to Connect Flask Server!";
            }
            else
            {
                if (result.Contains("default"))
                {
                    log = "There is an error running the algorithm." + "\r\n" + result;
                }
                else
                {
                    this.textBoxSum.Text = result;
                    log = "Test Successed!";
                }
            }
            MessageBox.Show(log);
        }

        /// <summary>
        /// 通过网络地址和端口访问数据
        /// </summary>
        /// <param name="Url">网络地址</param>
        /// <param name="jsonParas">json参数</param>
        /// <returns></returns>
        public string RequestsPost(string Url, string jsonParas)
        {
            string postContent = "";
            string strURL = Url;
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 

            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength 
            request.ContentLength = payload.Length;

            //发送请求，获得请求流 
            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                MessageBox.Show("连接服务器失败!");
                return null;
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                postContent = "default: The response is null." + "\r\n" + "Exception: " + ex.Message;
            }
            if (response != null)
            {
                try
                {
                    Stream s = response.GetResponseStream();
                    StreamReader sRead = new StreamReader(s);
                    postContent = sRead.ReadToEnd();
                    sRead.Close();
                }
                catch (Exception e)
                {
                    postContent = "default: The data stream is not readable." + "\r\n" + e.Message;
                }
            }
            return postContent;//返回Json数据
        }
    }
}
```



#### DAL层

##### C# <> MySQL

[MySQL :: MySQL Connector/NET Developer Guide :: 6 Connector/NET Tutorials](https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html)

[C# - MySQL数据库编程 简明教程 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/28401873)



#### 交互策略

具体C#和Python指令/数据交互流程：

+ 将Flask的HTTP请求设置为Post（因为Python脚本需要接收来自C#的指令）；
+ C#根据用户在UI界面触发的特定事件（button等）向Python脚本通过Flask服务器发送对应的指令；
+ Python脚本接收C#指令后对数据集进行相关操作，生成可视化后的图像，并保存到指定路径，将路径字符串返回给C#程序
+ C#程序通过pictureBox控件在对应的位置显示该图片

C#交互代码：

```c#
private void uiButton1_Click(object sender, EventArgs e)
        {
            string log = "";//错误信息
            string Url = "http://127.0.0.1:8000/plot/";//功能网址
            string command = "pairplot";
            string jsonParams = "#" + command + "#";
            string result = RequestsPost(Url, jsonParams);
            if (result == null)
            {
                log = "Failed to Connect Flask Server!";
            }
            else
            {
                if (result.Contains("default"))
                {
                    log = "There is an error running the algorithm." + "\r\n" + result;
                }
                else
                {
                    Bitmap plot = new Bitmap(result);
                    pictureBox1.Image = plot;
                    log = "Test Successed!";
                }
            }
            MessageBox.Show(log);
        }

        /// <summary>
        /// 通过网络地址和端口访问数据
        /// </summary>
        /// <param name="Url">网络地址</param>
        /// <param name="jsonParas">json参数</param>
        /// <returns></returns>
        public string RequestsPost(string Url, string jsonParas)
        {
            string postContent = "";
            string strURL = Url;
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 

            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength 
            request.ContentLength = payload.Length;

            //发送请求，获得请求流 
            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                MessageBox.Show("连接服务器失败!");
                return null;
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                postContent = "default: The response is null." + "\r\n" + "Exception: " + ex.Message;
            }
            if (response != null)
            {
                try
                {
                    Stream s = response.GetResponseStream();
                    StreamReader sRead = new StreamReader(s);
                    postContent = sRead.ReadToEnd();
                    sRead.Close();
                }
                catch (Exception e)
                {
                    postContent = "default: The data stream is not readable." + "\r\n" + e.Message;
                }
            }
            return postContent;//返回Json数据
        }
```





### 数据集的选择

Potential data sets: [Multi-Ethnic Study of Atherosclerosis - Sleep Data - National Sleep Research Resource - NSRR](https://sleepdata.org/datasets/mesa)

# Graduation Project

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

### BLL层

#### C# <> Python

方法总述：[一 、C#调用Python的使用总结 - 卢大鸽 - 博客园 (cnblogs.com)](https://www.cnblogs.com/ludage/p/12461403.html)

##### 基于Flask的Python和C#交互

[欢迎使用 Flask — Flask 0.10.1 文档 (jinkan.org)](http://docs.jinkan.org/docs/flask/index.html)

**关于Flask：** Flask是一个符合WSGI标准的Framework（[WSGI协议介绍-CSDN博客_wsgi协议](https://blog.csdn.net/j163you/article/details/80919360)）WSGI标准是为Python语言定义的Web服务器和Web应用程序或框架之间的一种简单而通用的接口。

WSGI描述了Server与Framework之间通信的规范，简单来说，WSGI规范了以下几项内容：

+ WSGI协议主要包括server和application两部分，server负责接受客户端请求并进行解析，然后将其传入application，客户端处理请求并将响应头和正文返回服务器（严格说来，还有一个模块叫做中间件middleware，但中间件也同样使用上述两种接口进行通讯）；
+ 从application的角度来说，它应当是一个可调用的对象（实现了__call__ 函数的方法或者类），它接受两个参数：environ和start_response，其主要作用就是根据server传入的environ字典来生成一个“可迭代的”http报文并返回给server；
+ 从server的角度来说，其主要工作是解析http请求，生成一个environ字典并将其传递给可调用的application对象；另外，server还要实现一个start_response函数，其作用是生成响应头，start_response作为参数传入application中并被其调用；

使用实例（套用即可）：[四、基于Flask的Python和C#交互（中篇） - 卢大鸽 - 博客园 (cnblogs.com)](https://www.cnblogs.com/ludage/p/13710687.html)

（客户端）C#只需要添加相应的Url（对应Python Flask路由）和输入参数（传递给Application的参数）即可；

（Application）Python Flask脚本增加对应的路由即可；以此形成客户端-Server-Application（Framework）的交互模式

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



### DAL层

#### C# <> MySQL

[MySQL :: MySQL Connector/NET Developer Guide :: 6 Connector/NET Tutorials](https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html)





#### 


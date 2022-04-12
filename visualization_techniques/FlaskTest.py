# !/usr/bin/python
# -*- coding: UTF-8 -*-
# python服务器如果需要访问静态的文件，都需要放到static这个指定的文件夹。


from flask import Flask, jsonify, request
from flask import render_template
#from wtforms import StringField, Form
#from wtforms.validators import DataRequired
import IRIS


app = Flask(__name__)
app.logger.info('Finished Start Flask!')


# 开始数据转移
@app.route('/plot/', methods=['POST'])
def startTransfer(name=None):
    path_to_plot = ''
    if request.method == 'POST':
        receiveData = request.data.decode('utf-8')    # 为了兼容中文输入
        para = str(receiveData)
        print(para)        #输出接收到的信息
        array = str(para).split('#')
        print(array)
        if(str(array[1]) == 'pairPlot'):
            path_to_plot = IRIS.pairPlot()
        if(str(array[1]) == 'histoPlot'):
            path_to_plot = IRIS.histoPlot()
        return str(path_to_plot)


if __name__ == '__main__':
    app.run(host='127.0.0.1', port=8000, debug=False, threaded=True)
    # debug=True 时设置的多线程无效
    # 多线程和多进程功能只能开一个     1.processes=True      2.threaded=True
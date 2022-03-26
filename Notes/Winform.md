## 项目实例

Winform+MySql实例: [（2021年最新C#Winform｜零基础到精通实战教程全集（.Net Core/WPF/桌面开发/UI/界面/窗体）B0503_哔哩哔哩_bilibili](https://www.bilibili.com/video/BV1FL411s7Fc?p=93)

将数据库各表之间的关系用Winform代码进行逻辑控制，而不使用MySQL设置关系表，以保证数据逻辑的一致性

[（2021年最新C#Winform｜零基础到精通实战教程全集（.Net Core/WPF/桌面开发/UI/界面/窗体）B0503_哔哩哔哩_bilibili](https://www.bilibili.com/video/BV1FL411s7Fc?p=94)

三层架构：（建立分层引用关系）

UI：用户交互层---Winform应用程序/WPF/Web

BLL：业务逻辑层---业务逻辑处理：连接UI与DAL的桥梁

DAL：数据访问层---处理数据（数据库）

1. 功能
   + 增添
   + 修改
   + 查询
   + 删除

DbUtility数据库通用类库

Models 实体模型层（与MySql表有映射关系）

Common 辅助工具层

- 用户自定义特性：用于在运行时传递程序中的各种元素（例如类、方法、结构、枚举、组件等）的行为信息的声明性标签
  - TableAttribute：映射表名
  - ColumnAttribute：映射列名
  - PrimaryKeyAttribute：标注主键列名

Communicate 通信类库

### Models层搭建

实体模型层（类：一系列的属性 --表中的列名）

**<u>DModels</u>** --数据表对应的实体类

例：仓库管理系统用户实体类对应MySql用户表：

![image-20220324143029181](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220324143029181.png)

**<u>UIModels</u>** -- UI层，BLL层的实体类

**<u>VModels</u>** -- 视图对应的实体类（用视图来简化查询）

### Common 辅助工具层

**特性**（Attribute）：特性是一种允许我们向程序集增加元数据的语言结构，它是用于保存程序结构信息的某种特殊类型的类。[C# 自定义特性 - JohnYang819 - 博客园 (cnblogs.com)](https://www.cnblogs.com/johnyang/p/15228269.html)

可以通过使用特性向程序添加声明性信息。一个声明性标签是通过放置在它所应用的元素前面的方括号（[ ]）来描述的。

根据惯例，特性名使用Pascal命名法并且以`Attribute`后缀结尾。当为目标应用特性时，我们可以不使用后缀。例如对于`SerializableAttribute`和`MyAttributeAttribute`这两个特性，我们在把他们应用到结构时可以使用`Serializable`和`MyAttribute`短名称。

所有特性类都派生自`System.Attribute`，用户自定义的特殊类叫做自定义特性。

#### 声明自定义特性

- 派生自`System.Attribute`
- 起一个以后缀为`Attribute`结尾的名字

为安全起见，建议声明一个`sealed`的特性类

- 由于特性持有目标的信息，所以特性类的公共成员只能是：字段，属性，构造函数。

#### 使用特性的构造函数

和其他类一样，都有构造函数，每一个特性至少必须有一个公共构造函数，如果不声明构造函数，编译器会为我们产生一个隐式，公共且无参的构造函数，也可以被重载，**声明构造函数时，必须使用类全名（即包括后缀）**。在应用时，才可以使用**短名称（不包括后缀）**。

```c#
[MyAttribute("Holds a value")] //使用了一个字符串的构造函数，它只是声明语句，只有特性的消费者访问特性时候才能调用构造函数，它不会决定什么时候构造特性类的对象。
public int MyField;
```

#### 限制特性

特性本身就是类，有一个很重要的**预定义特性**可以应用到自定义特性上，那就是`AttributeUsage`特性，可以用它来限制特性使用在某个目标类型上。

例如，如果我们希望自定义特性`MyAttribute`只应用到方法上，那么可以以如下方式使用`AttributeUsage`：

```c#
[AttributeUsage(AttributeTarget.Method)]
public sealed class MyAttributeAttribute:System.Attribute{...}
```

`AttributeTarget`的枚举值成员：

| `All`              | `Assembly`  | `Class`       | `Constructor` |
| :----------------- | ----------- | ------------- | ------------- |
| `Delegate`         | `Enum`      | `Event`       | `Field`       |
| `GenericParameter` | `Interface` | `Method`      | `Module`      |
| `Parameter`        | `Property`  | `ReturnValue` | `Struct`      |

### AttributeHelper --静态类

**扩展方法**：必须是静态类中的静态类。扩展方法是C# 3.0 中新增特性，可在不修改源类代码情况，通过ADD File 模式对源代码功能扩展。其要求如下:

a.扩展方法需包含在 static 修饰类中.

b.扩展实现需是静态形式。

c.扩展方法第一个参数 前缀为 this , 表示需要扩展类对象，从第二个参数开始，为扩展方法参数列表。

在仓库温控系统项目中，利用AttributeHelper向Type类添加（从Attribute找到MySql数据库中数据表的名称的）方法，来完成Models实体模型与MySql数据表名的映射。

### PropertyHelper

通过反射方法获取指定类名的指定列名的属性数组

在该项目中：

作用的类型：实体类 服务于后面的Insert Update Select等函数

任务：解析以”，“分隔的字符串，并返回这些字符串指定的部分列的属性数组。

### DAL层

C#操作MySql：

[MySQL :: MySQL Connector/NET Developer Guide :: 6 Connector/NET Tutorials](https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials.html)

[C# - MySQL数据库编程 简明教程 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/28401873)

## Form

### 初始化顺序

先执行Form的构造函数（包括InitializeComponent()及事件的注册），再执行Load事件

![image-20220322113041060](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220322113041060.png)

### Form控件布局

* UI设计页面直接拖控件到窗体上（属性页注册事件）
* Load事件写代码添加控件
  1. 实例化
  2. 属性设置
  3. 注册事件
  4. 把控件添加到当前窗体的Controls集合中

### 事件注册

注册方式：

1. 双击控件，可默认注册单击或其他事件（默认事件有区分）
   1. Label和Button：Click事件
   2. Form：Load事件
   3. Textbox：TextChanged事件（Text属性值改变时触发）
2. 先写好事件处理函数，再在属性页中给要注册事件的控件中绑定

### Form常用的事件

1. Load()
2. FormClosing() //关闭窗口时

### Form常用的方法

1. Show() //非模态窗口方式(可以跟其他界面自由切换，而且不阻塞代码)
2. ShowDialog() //模态窗口(必须关闭了该窗口，后面的代码才会执行，并且不能跟其他界面自由切换)

## Label

Label 一般显示不能编辑的文本或图像

### 常用的属性

1. Name：对象名 lblUsername
2. Text：显示的文本信息
3. Image：显示图像
4. ImageList：图片集控件
5. Tag：与控件相关的自定义数据
6. Enabled：是否启用

### 常用的事件

1. Click()
2. TextChanged()

## TextBox

可编辑的文本框

### 常用的属性

1. Name：对象名 txtUsername
2. Text：文本信息
3. MultiLine：是否多行
4. WordWrap：是否可以自动换行
5. PasswordChar：将字符隐藏为***
6. MaxLength：可输入的最大字符数

### 常用的方法

1. AppendText()：指定文本追加到文本框的末尾
2. Clear()：清楚
3. Focus()：获取焦点
4. Select()/SelectAll()：选择文本

### 常用的事件

1. TextChanged()
2. Clicked()

## Button

按钮控件 最常用的主动触发事件的控件

继承于ButtonBase：Control

### 常用的属性

1. Name：对象名 btnUsername
2. Text：控件显示的文本
3. BackgroundImage/Image：背景图片（不会覆盖Text）
4. BackColor：背景色
5. ForeColor：文字颜色
6. DialogResult：返回模态窗口中点击的按钮
7. Visible：是否显示

## RadioButton

单选按钮：一组单选按钮互斥（同一容器中）

![image-20220323165813714](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220323165813714.png)

### 常用的属性

1. Name：对象名 rbUsername
2. Text：文本
3. Checked：是否被选中
4. Appearance：外观
5. AutoCheck：检查互斥关系是否满足，否则自动更改
6. CheckAlign：文字与按钮的对齐方式

### 常用的事件

1. CheckedChanged()：按钮选中状态改变时触发

## Checkbox

复选框：一组复选框中，可以选择多项

![image-20220323165826534](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220323165826534.png)

### 常用的属性

1. Name：对象名 ckUsername
2. Text：文本
3. Checked：选中状态
4. CheckAlign：文字与按钮的对齐方式
5. ThreeState：三种选中状态（选中状态由CheckState显示）

### 常用的事件

1. CheckedChanged()：Checked属性发生改变时
2. CheckStateChanged()：CheckState属性发生改变时

如果ThreeState属性被启用，则选中复选框**先**触发CheckedChanged()，**再**触发CheckStateChanged()事件；通常注册CheckedChanged()事件即可

## ListBox

列表框：从中选择一项或多项 **建议使用Items方法添加数据**

![image-20220323165854595](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220323165854595.png)

### 常用的属性

1. Name：对象名 lbList
2. DataSource：要显示的数据源（包含Id和Name的对象的集合）
3. DisplayMember：要显示的数据源的列名
4. ValueMember：要显示的数据对应的实际值
5. Items：手动在集合中添加字符串以供显示（对象为字符串）
6. SelectionModel：单选/多选

### 常用的事件

1. SelectedIndexChanged()：选择项发生改变时触发

### 常用的方法

a. 通过Items添加数据

1. Items.Clear()：清除所有项
2. Items.Add()：添加项
3. Items.AddRange()：添加数组
4. Items.Insert()：在制定索引位置插入新项
5. Items.IndexOf()：获取索引
6. Items.Contains()：判断某项是否存在

加载大量项时在程序体前后加入lbUsername.BeginUpdate()/EndUpdate()：来避免闪烁问题

b. 通过数据源添加（绑定对象）

使用DataSource方法不能直接用Items方法来修改数据源项

Dictionary的类型作为DataSource需要用BindingSource

可以将DataSource指定为BindingSource，利用BindingSource控件的方法来操作数据。BindingSource组件是数据源和控件间的一座桥,同时提供了大量的API和Event供我们使用。

BindingSource控件与数据源建立连接，简化数据绑定的过程。BindingSource支持向后台数据库发送命令来检索数据，又支持直接通过BindingSource控件对数据进行访问、排序、筛选和更新操作。BindingSource控件能够自动管理许多绑定问题。BindingSource控件没有运行时界面，无法在用户界面上看到该控件。

```c#
DataTable myTable = myTableAdapter.GetData();//创建Table
BindingSource myBindingSource= new BindingSource();//创建BindingSource
DataGridView myGrid = new DataGridView();//创建GridView
myGrid.DataSource = myBindingSource；//将BindingSource绑定到GridView 
myBindingSource.DataSource = myTable;//绑定数据到BindingSource
```

## ComboBox

下拉框（由TextBox和ListBox组合而成） 只能选择一项 常用属性，事件和方法基本都和ListBox相同 **建议使用DataSource方法绑定数据源**

![image-20220323165942852](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220323165942852.png)

### 常用的属性

1. Name：对象名 cboUsername
2. DropDownStyle：外观（三种样式）
3. DataSource：同上
4. DropDownHeight：下拉高度

Items和DataSource方法均可以添加对象作为项，如果是非内置类型，都需要设置DisplayMember和ValueMember。

SelectedIndexChanged()事件可以用于级联下拉框（根据上一级确定下一级可供选择的内容）

## CheckedListBox

复选框列表：提供一个列表框，且每项前面有复选框（类似ListBox）

![image-20220323170011206](C:\Users\Bill Chan\AppData\Roaming\Typora\typora-user-images\image-20220323170011206.png)

### 常用的属性

1. Name：对象名 cklUsername
2. MultiColumn：是否多列显示
3. Items：同上 `属性页没有DataSources但实际上存在相关属性`
4. SelectionMode：MultiExtended：按住Shift/Ctrl以选择多项
5. CheckonClick：Select某项时就进行Check
6. SelectedItems/SelectedIndices：被选中的项/索引
7. CheckedItems/CheckedIndices：被勾选的项/索引
8. SelectedIndex：被单选的项的索引

注意Select（选中）和Check（勾选）的区别



方法和事件与ListBox类似 

ItemCheck()事件：具体某一项被Check时
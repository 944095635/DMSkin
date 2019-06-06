## 与源码无关内容
#### 1.如果你有XAML相关的外包需求，可以通过QQ或微信与我取得联系。(QQ:"944095635" 微信号:"qq944095635")
#### 2.我正在找工作，成都软件园附近，WPF偏XAML前端的。


## 基于DMSkin开发的PC项目，现在运营中你可以前往Steam下载体验。
[Wallpaper Maker](https://store.steampowered.com/app/1010800)
<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/wall.jpg" align="center">


# DMSkin
## 目前可以使用,但是内容较少,持续更新中
#### 介绍
#### 这是一个全新的项目，快速开发WPF客户端的框架。
#### 内容：MVVM 框架模块 + DesignLibrary 控件样式库
#### 开发PC客户端 一套搞定

<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/Demo1.png" align="center">
<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/Demo2.png" align="center">

## 1.开发&编译&环境&问题

<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/VS.png" width="310" height="101" align="center">

````xml
开发环境：Windows 10  +  Visual Studio 2019 Professional  +  .Net Framework 4.5

项目基于Visual Studio 2019 Professional .Net Framework 4.5，源码包括一些C#新语法。

如果你在旧版本Visual Studio版本上编译不通过的话，请自行修改中源码不兼容的部分。
````
````xml
支持环境：Windows 7/10 +  .Net Framework 4.5
````
````xml
1.目前绝对放弃Windows XP
2.WPF多数是企业软件,如果要适配windows 7,单独装.Net Framework 4.5的库
3.UI库的初衷就是为了制作更精美的界面,精美的效果在旧系统中并不能正常的显示,
  为了适配旧版本的系统而放弃语言新特性,得不偿失。

目前Windows 10 占有率已经超过Windows 7
````
````xml
注意：系统阴影(如果用户关闭了窗口阴影,界面边界无法分辨，可以考虑使用Border增加窗口边框)
我的电脑->此电脑->高级系统设置->性能->设置->√ 在窗口下显示阴影
````
````xml
Windows XP 请自行测试,
旧版本已经被我转移到[DMSkin-for-WPF](https://github.com/944095635/DMSkin-for-WPF)(备份学习之用)
````
## 2.项目模块&使用说明

| 项目               |   DMSkin.dll 和 DMSkin.Core.dll 可以独立存在   | 最新版本            | Nuget  |
| :----:            |   :----:                                     |   :----:           |:----:  | 
| DMSkin            | DMSkin 窗口&样式 基础控件 基础色 滚动条样式      | 3.0.0.1000         |        |
| DMSkin.Core       | MVVM,Broadcast,DelegateCommand,ViewModelBase | 3.0.0.1000         |        |

| DesignLibrary样式库| Library样式库都依赖于DMSkin.dll  | 最新版本        | Nuget |
| :----:            |   :----:                       |   :----:       |:----:  | 
| DMSkin.CyanDesign | CyanDesign 青 "轻"              | 1.0.0.1000     |        |
| DMSkin.AduDesign  | Adu为DMSkin设计的样式库          | 1.0.0.1000     |        |

#### 2.1 新手使用说明
<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/Framework1.png" align="center">

````xml
使用DMSkin.dll 和 DMSkin.Core.dll,窗口继承自DMSkinWindow
从DesignLibrary样式库中选择一个来作为软件的样式库。
非常推荐刚接触WPF,不会自己写样式和模板的开发者使用这种方式。

这种模式,你只需要使用原生组件,通过设置Style Key就可以切换风格。
通过重写覆盖样式库中的颜色Key实现整体换色(如果目标库有主题色)
````

#### 2.2 进阶使用说明
<img src="https://raw.githubusercontent.com/944095635/DMSkin/master/Docs/Image/Framework2.png" align="center">

````xml
仅用DMSkin.dll 和 DMSkin.Core.dll
非常推荐会写样式模板的开发者使用这种方式。

这种模式,只会使用到DMSkin的窗口和组件(无外观) 和 Core中的核心辅助类.
你可以自己为内置组件设计外观。
非常的轻,不会有多余的代码和样式。
````


#### 2.3 DMSkin.Core模块(DMSkin.Core.dll)
> UIExecute(跨线程UI调度器) [[使用文档]](https://github.com/944095635/DMSkin/wiki/Execute%E8%B7%A8%E7%BA%BF%E7%A8%8BUI%E8%B0%83%E5%BA%A6%E5%99%A8)

> Broadcast(广播器) [[使用文档]](https://github.com/944095635/DMSkin/wiki/Broadcast%E5%B9%BF%E6%92%AD%E5%99%A8)

> TaskManager(Task管理器)

> Storage(内容存储器)

> DelegateCommand(ICommand实现)

> ViewModelBase(ViewModel基类)

#### 2.4 DMSkin模块(DMSkin.dll)
> DMSkinWindow[[使用文档]](https://github.com/944095635/DMSkin/wiki/DMSkinWindow%E7%AA%97%E5%8F%A3)

> [[学习WPF的窗口跳转和内容切换]](https://github.com/944095635/DMSkin/wiki/%E9%A1%B5%E9%9D%A2%E5%8A%A0%E8%BD%BD&%E7%AA%97%E5%8F%A3%E8%B7%B3%E8%BD%AC)

> SystemButton(系统按钮)

> Icon(附加属性类)


## 3.下载&引用
> 3.1 可以直接通过   `https://github.com/944095635/DMSkin.git`

克隆代码到本地，通过引用项目的方式导入DMSkin到你的解决方案中

> 3.2 你可以通过Nuget 搜索DMSkin安装到自己的项目中

## 4.代码段
项目中一般会使用到Visual Studio的智能提示(双tab代码段),

我在项目中提供了3个代码段（在当前项目的Docs文件夹中可以找到）。

VS->工具->代码片段管理器->语言（Csharp）->Visual C#

我的VS安装在C盘路径是:
````xml
C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\VC#\Snippets\2052\Visual C#
````

| Dos文件夹                | 描述   |使用率   |
| :----:              | :---:          | :---:          |
| propfull  |  刷新属性       |⭐⭐⭐|
| propob  |  刷新集合属性       |⭐⭐⭐|
| command   | 命令        |⭐⭐|
| propdp    | 依赖属性    |⭐|
| propa    | 附加属性    |⭐|

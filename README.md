# DMSkin-for-WPF

<<<<<<< HEAD
![](https://img.shields.io/badge/.NET-%3E%3D3.5-brightgreen.svg)
![](https://img.shields.io/badge/version-2.5.0.1-blue.svg)
![](https://img.shields.io/badge/license-MIT-green.svg)

A WPF UI framework to create borderless window faster and easier.
[中文文档](./docs/README-CN.md)

## Preface 
DMSkin-for-WPF (aka DFW) is a WPF UI framework that aims to help WPF developers create a borderless window faster and easier. It supports .NET framework from 3.5 to 4.7, and runs well from Windows XP to Windows 10.

DFW offers 2 plans for window borderless:
#### 1. ComplexWindow Plan
Use Windows 32 API to redraw non-client area and create a separate shadow window for shadow's presentation.
#### 2. SimpleWindow Plan
Delay Window message to prevent flickering corruption bug.

The follwing chart can show you the differences between `DMSkinComplexWindow` and `DMSkinSimlpeWindow`


| Plan                | Transparency   |Animation   |
| :----:              | :---:          | :----:     |
| DMSkinComplexWindow | Not Support    |  Support   |
| DMSkinSimpleWindow  |  Support       |Not Support |

## Notice
#### 1. DFW was developed on VS 2017 Community, .NET 4.0 Environment, contains some c# 6.0+ grammar codes.If you cannot compile it through VS 2015 and others previous VS versions, please modify the source code youself.
#### 2. The plan still has drawback, Non-client area system button blocking operation on Windows 7 system.

## Installation
You can get the **`DMSkin.WPF.dll`** through 2 two different ways.

#### 1. [Download DMSkin.WPF.dll](https://github.com/944095635/DMSkin-for-WPF/releases/download/2.5.0.1/Release.zip)

The drawback of this way is the **dll** you downloaded is not always up to date.

#### 2. [Download the source code](https://github.com/944095635/DMSkin-for-WPF/archive/master.zip) and compile it yourself
Click `DMSkin-for-WPF.sln` to open the project, right click DMSkin.WPF in the solution resource manager window and click build button to complile. And then open the project folder with `file explorer`, you will find the DMSkin.WPF.dll is in `bin\Debug` folder.

There are some other ways to fetch `DMSkin.WPF.dll` and source code.

- Nuget  `PM> Install-Package DMSkin.WPF -Version 2.5.0.1`
- Git  `git clone git@github.com:944095635/DMSkin-for-WPF.git`

## Usage & Configration
#### 1. Create a new WPF project
#### 2. [Add DMSkin.WPF.dll reference](http://p40kjburh.bkt.clouddn.com/18-6-13/50043356.jpg)
#### 3. Modify `MainWindow.cs`
![](http://p40kjburh.bkt.clouddn.com/1.png)

#### 4. Modify `MainWindow.xaml`
![](http://p40kjburh.bkt.clouddn.com/2.png)

#### 5. Make DFW transparent (optional)
Set DMSkinSimpleWindow `Background` property `transparent`.

#### 6. Add System Buttons (optional)
````xml
<!-- Add below codes into MainWindow.xaml -->
<!-- System button properties:
  -- DMSystemButtonSize // System button size
  -- DMSystemButtonForeground // System button foreground color
  -- DMSystemButtonHoverColor // System button background color when mouse is over
  -- DMSystemButtonHoverForeground // System button foreground color when mouse is over
  -- DMSystemButtonCloseHoverColor // System close button background color
  -->
<WrapPanel Height="{Binding DMSystemButtonSize}" Orientation="Horizontal" VerticalAlignment="Top" HorizontalAlignment="Right">
  <controls:DMSystemMinButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#383838" DMSystemButtonForeground="#383838"></controls:DMSystemMinButton>
  <controls:DMSystemMaxButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#FFFFFF" DMSystemButtonForeground="#383838"></controls:DMSystemMaxButton>
  <controls:DMSystemCloseButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#FFFFFF" DMSystemButtonForeground="#383838"></controls:DMSystemCloseButton>
</WrapPanel>
````

#### 7. Config your DFW properties (optional)
````xml
Foreground="White"                    // window foreground color
Background="White"                    // window background color 
DMWindowShadowSize="10"               // window shadow size
DMWindowShadowColor="#FFC8C8C8"       // window shadow color
DMWindowShadowDragVisibility="False"  // whether show shadow when window is being dragged
DMWindowShadowVisibility="False"      // whether show window shadow
DMWindowShadowBackColor="#FF323CAD"   // shadow background color (only for DMSkinComplexWindow)
ResizeMode="CanResize"                // window resize mode (CanResiz or CanResizeWithGrip)
WindowStartupLocation="CenterScreen"  // window startup location
````

#### 8. [Make Rounded window (optional)](./demos/Rounded-Window.xaml)

## Communication
We appreciate it a lot if you can join us:

- **[C# .NET (2000 members) QQ Group](http://qm.qq.com/cgi-bin/qm/qr?k=reTIeglEELMIW267mOO7amouFFwhJwwP)**

- **DMSkin QQ Group: 194684812**

- **WPF Course Group (Charges) QQ Group: 611509631**
- **{%raw%}<a href="tencent://message/?uin=944095635">Contact Author</a>{%endraw%}**
- **[DMSkin Website](http://www.dmskin.com)**

If you can not communicate with us in Chinese.You can communicate with us by giving your issues on issues page and we will reply soon.Any issues and PRs are welcomed!

## Donation
If this framework really helps you a lot, you can donate me to support my work, which can encourage me to do better.

<img src="http://p40kjburh.bkt.clouddn.com/18-6-13/9034578.jpg" width="500">

## Change Log
### 2.5.0 (2018-06-07)
1. Merge DMSkinComplexWindow and DMSkinSimpleWindow project
2. Add some common calss for WPF, for example ViewModelBase, UI Scheduler, Converter and so on.
3. Add Watermark Input and some controls, refactoring and release DFW to Nuget, developers can install and update it through Nuget from now on.

### 2.1.0 (2018-04-17)
1. Modify framework's logic, now DFW supports MVVM.
2. Fix a bug that shadow layers when window loads.
3. System buttons have been Separated from DFW template, developers could choose whether to add system buttons according to their needs.

### 2.0.1 (2018-01-30)
1. Add a new demo.

### 2.0.0 (2017-10-15)
1. Remove window mode.
2. Find that there is a small defect when framework runs on Windows 7.

### 1.3.0 (2017-09-21)
1. Apply ComplexWindow on Windows XP and Windows 7.
2. Apply SimpleWindow on Windows 8 and Windows 10.

### 1.2.4 (2017-09-21)
1. Support resizing Window feature.
2. Shadow restore speed changed to 200ms.

### 1.1.3 (2017-09-20)
1. Fix ALT+TAB show 2 windows bug.
2. Recommand shadow layer's drag and resize color being similar to MainWindow's color, which may create a more friendly UI.

### 1.1.2 (2017-09-20)
1. Fix muti-Windows cannot be and focused actived bug.
2. Support display shadow layer when MainWindow is being dragged.
3. Fix shadow layer delayed display bug.

### 1.1.1 (2017-09-19)
1. Optimize minimizing restore shadow order, not like Netease Music that displays 2 layers.
2. Remove Window cropping code.(previous clipping operation is redundant)
3. Optimize hide shadow's efficiency when window is being dragged.

### 1.0.0 (2017-09-13)
1. Completely fix minimize animation.(the first WPF borderless minimize animation plan in the world)

**Note:** Before version 1.0.0, We use WindowStyle.None and Transparency property to realize window borderless and transparency.But its drawback is window minimize animation does not work at the plan.After version 1.0.0, we use double windows and Windows 32 API to realize borderless window.This version do not support rounded window and window transparency, but it obtains the most wonderful minimize animation.

### 0.8.0 (2017-08-26)
1. Fix minimize animation and restore animation(ready to be optimized).

### 0.7.0 (2017-08-25)
1. Upload source code to github.
2. Add demo: Jay Music Player.
3. Add demo: default template window.

### 0.6.0 (2017-03-06)
1. Add `DMSystemButtonHoverColor` system button mouse hover background color(for rounded window, please set it to transparent, may get a more good display effect).
2. Add window mode: Metro mode and Shadow mode.


## MIT License
Copyright © 2018 <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
=======
 
<h1>﻿# DMSkin-for-WPF 2.5.0.1</h1>
<h2>升级到2.5,全新改版,支持MVVM,支持单双层</h2>

<h2>安装</h2>
Nuget安装 <code>PM> Install-Package DMSkin.WPF -Version 2.5.0.1</code>
<br/><br/>
HTTP下载 https://codeload.github.com/944095635/DMSkin-for-WPF/zip/master
<br/><br/>
Git获取 https://github.com/944095635/DMSkin-for-WPF.git
<br/><br/>
Dll下载https://github.com/944095635/DMSkin-for-WPF/releases
 
<hr/>
<h1>前言</h1>
<h3>2.5+版本 将 单双层合为一个项目,便于升级与维护</h3>
<h4>基于WPF的UI框架</h4>
<h4>支持：.NET Framework 3.5 - 4.7</h4>
<h4>支持：Windows XP - Windows 7 - Windows 10</h4>

<h4>A:双层方案思路:Win32 重绘非客户区+阴影层窗口     - 继承DMSkinComplexWindow</h4>
<h4>B:单层方案思路:延迟窗口Window消息防止闪烁花屏BUG - 继承DMSkinSimpleWindow</h4>

<h2>WPF 疑问&解决方案</h2>

<h4>是否还有其他阴影方案?</h4>
<h5>WPF .NET Framework 4.5+ 推出了原生组件<a href='https://github.com/944095635/WindowChrome-Demo'>WindowChrome无边框方案</a></h5>
<h5>WPF .NET Framework 3.5+ 可以调用 System.Windows.Shell  实现无边框方案</h5>

<h5><a href='https://github.com/944095635/DMSkin-for-WPF/wiki/%E6%95%B0%E6%8D%AE%E7%BB%91%E5%AE%9A%E5%88%B7%E6%96%B0%E9%80%9A%E7%9F%A5'>数据绑定&刷新通知</a></h5>
<h5><a href='https://github.com/944095635/DMSkin-for-WPF/wiki/%E8%B7%A8%E7%BA%BF%E7%A8%8BUI%E8%B0%83%E5%BA%A6%E5%99%A8'>跨线程UI调度器</a></h5>
<h5><a href=''>WPF 开启透明之后嵌入GDI+组件无法显示,Microsoft.DwayneNeed</a></h5>



<h1>注意事项</h1>
<h3>本源码采用VS2017 个人版 开发,.NET FrameWork4.0,部分C# 6.0+语法 vs2015 vs2013 vs2012 请自行修改源码中不支持的部分。</h3>
<h3>本方案缺点:---遗留BUG:WIN7 系统上非客户区系统按钮阻挡操作(目前WIN7有点小瑕疵)---.</h3>



<img  src="https://raw.githubusercontent.com/944095635/Image/master/NEW.jpg" />


DMSkin-for-WPF是一个基于WPF的.Net WPF开源界面库,实现了无边框的WPF开发方案,内置部分控件模板.
你可以参照模板自行修改完善。（以下简称DFW）。

<h1>核心</h1>
DFW实现了比较完美的无边框窗体方案，并且拖拽全部采用WIN32消息实现。拖拽依靠桌面边缘完美,高DPI支持,窗体不会变形或异常

最新版本已经支持MVVM架构。



<h1>版本更新</h1>
<blockquote>
 <h3>2.5.0.0 (2018-06-07)</h3>
<p>1.将2个项目合二为一。</p>
<p>2.添加一些WPF 常用的class 如ViewModelBase,UI调度器,转换器。</p>
<p>3.加入了水印输入框等,代码重构,准备发布到Nuget,以后可以通过Nuget安装 和 更新。</p>
 
 <h3>2.1.0.0 (2018-04-17)</h3>
<p>1.修改逻辑,目前窗口支持MVVM。</p>
<p>2.修复一个启动时阴影分层的BUG。</p>
<p>3.系统按钮被分离出窗口模板,具体查看本文底部使用方法。</p>
 
 
 <h3>2.0.0.1 (2018-01-30)</h3>
<p>1.新增一个窗口Demo。</p>
 
<h3>2.0.0.0 (2017-10-15)</h3>
<p>1.移除WindowMode。</p>
<p>2.目前WIN7有点小瑕疵。</p>

<h3>3.0 (2017-9-21)</h3>
<p>1.WIN7以及以下采用单层。</p>
<p>2.WIN8、WIN10采用双层。</p>
 
<h3>2.4 (2017-9-21)</h3>
<p>1.窗口边缘拉伸(右,右下,下)。</p>
<p>2.阴影恢复速度调为200ms</p>
<p>3.阴影可以完全关闭(高效率,配合窗口虚线使用)</p>
 
<h3>2.3 (2017-9-20)</h3>
<p>1.修复ALT+TAB 出现2个窗体的BUG。</p>
<p>2.阴影层背景色,拉伸 拖拽时 出现的颜色。选择跟主窗体 接近的颜色 用户体验更好</p>
 
<h3>2.2 (2017-9-20)</h3>
<p>1.修复多个窗口无法激活聚焦的BUG。</p>
<p>2.拖动窗口支持显示阴影层</p>
<p>3.阴影层延迟显示的BUG修复</p> 
   
<h3>2.1 (2017-9-19)</h3>
<p>1.优化最小化恢复阴影顺序,不会像网易云音乐一样出现双层了。</p>
<p>2.去除窗口裁剪代码(之前的裁剪操作多此一举)</p>
<p>3.拖动窗口位置时隐藏阴影提高效率</p>
<p>【2.0版本】采用双层窗体+Win32实现无边框,2.0版本不支持圆角窗体,不支持窗体透明,但是拥有完美最小化的动画。如果采用虚线边框,则可以去除双层窗体。</p>
<p>【<a href='https://github.com/944095635/DMSkin-for-WPF-1.0' target="_blank">1.0版本</a>】采用WindowStyle.None + 透明实现无边框,版本缺陷是无边框通病，窗体最小化 动画失效了。但是我用xaml实现了动画(动画流畅程度取决于显卡),需要这个版本的源码请点击我的头像进到另外一个1.0项目中获取</p>


<h3>2.0 (2017-9-13)</h3><p>1.版本升级到2.0,最小化动画终于解决,此方案可以移植到winform无边框中,这是我所知道的世界第一例WPF/winfrom无边框最小化动画方案。</p>
            
<h3>0.8 (2017-8-26)</h3><p>1.修复最小化动画以及恢复动画(尚可优化)</p>
<h3>0.7 (2017-8-25)</h3>   
<p>1.代码托管到GITHUB</p>
<p>2.新增Demo:周杰伦音乐播放器</p>
<p>3.新增Demo:默认模板窗体</p>
<h3>0.6 (2017-3-6)</h3>
<p>1.新增DMSystemButtonHoverColor 系统按钮鼠标悬浮的背景色(圆角窗体请设为透明,效果更好)</p>
<p>2.新增窗体模式：扁平化Metro+阴影Shadow 2种风格窗体</p>
</blockquote>


<h1>相关</h1>

加入讨论

<h3>C#.NET 2000人 QQ群： 76566523</h3>
<h3>DMSkin QQ群： 194684812</h3>
<h2>WPF课程群(收费) QQ群： 611509631</h2>

<h2>我的QQ:944095635</h2>
官网：http://www.dmskin.com

<h1>帮助改进</h1>
非常欢迎参与DFW的改进。有钱出钱有力出力，如果你觉得DFW很棒，请支持我。
如果你需要相关的资源或者学习资料也请联系我。
<img style="width:200px;" src="https://github.com/944095635/Image/blob/master/JZ.jpg" />


<h1>使用说明</h1>
<pre>
<code>
1.引用DMSkin.WPF.DLL
2.Window继承修改为:MainWindow:DMSkinSimpleWindow
   单层方案思路:继承DMSkinSimpleWindow
   双层方案思路:继承DMSkinComplexWindow
3.添加引用:xmlns:DMSkin="clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF"
4.XAML继承修改为: DMSkin:DMSkinWindow x:Class="MainWindow"
</code>
</pre>


<h1>窗体属性</h1>
<pre>
<code>     
Foreground="White"                    //前景色 
Background="White"                    //背景色 

DMWindowShadowSize="10"               //窗体边框阴影大小
DMWindowShadowColor="#FFC8C8C8"       //窗体边框阴影颜色
DMWindowShadowDragVisibility="False"  //窗体拖动时是否显示阴影层
DMWindowShadowVisibility="False"      //窗体是否有阴影层[关闭阴影层]
DMWindowShadowBackColor="#FF323CAD"   //阴影背景色,选择跟主窗体相近的颜色 拉伸跟拖动 用户体验更好|#FF323CAD 为蓝色

ResizeMode="CanResize"                //边框拉伸方案CanResiz和CanResizeWithGrip
Height="700" Width="1000"             //窗体大小
MinHeight="268" MinWidth="360"        //窗体最大以及最小属性
WindowStartupLocation="CenterScreen"  //窗体初始位置
</code>
</pre>


<h1>系统按钮</h1>
<pre>
<code>     

&lt;WrapPanel Height=&quot;{Binding DMSystemButtonSize}&quot; Orientation=&quot;Horizontal&quot; VerticalAlignment=&quot;Top&quot; HorizontalAlignment=&quot;Right&quot;&gt;
            &lt;controls:DMSystemMinButton DMSystemButtonSize=&quot;50&quot; DMSystemButtonHoverForeground=&quot;#383838&quot; DMSystemButtonForeground=&quot;#383838&quot;&gt;&lt;/controls:DMSystemMinButton&gt;
            &lt;controls:DMSystemMaxButton DMSystemButtonSize=&quot;50&quot; DMSystemButtonHoverForeground=&quot;#FFFFFF&quot; DMSystemButtonForeground=&quot;#383838&quot;&gt;&lt;/controls:DMSystemMaxButton&gt;
            &lt;controls:DMSystemCloseButton DMSystemButtonSize=&quot;50&quot; DMSystemButtonHoverForeground=&quot;#FFFFFF&quot; DMSystemButtonForeground=&quot;#383838&quot;&gt;&lt;/controls:DMSystemCloseButton&gt;
        &lt;/WrapPanel&gt;


DMSystemButtonSize="50"               //系统按钮大小
DMSystemButtonForeground="#FF666666"  //系统按钮[文字]颜色
DMSystemButtonHoverColor="#33000000"  //系统按钮的鼠标悬浮[背景]色
DMSystemButtonHoverForeground="White" //系统按钮的鼠标悬浮[文字]颜色
DMSystemButtonCloseHoverColor="Red"   //系统【关闭】按钮的鼠标悬浮[背景]色-默认为红色

</code>
</pre>


<h1>资源引用</h1>
<pre>
<code>
App.xaml文件
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>

                <!--  DMSKin内置配色  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Styles/DMColor.xaml" />

                <!--  DMSKin内置滚动容器  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Styles/DMScrollViewer.xaml" />

                <!--  DMSKin内置SVG图标  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMIcon.xaml" />

                <!--  DMSKin自定义控件 样式  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMControls.xaml" />

                <!--  DMSKin内置按钮 样式  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMButton.xaml" />

                <!--  DMSKin其他样式  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMTabControl.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMRadioButton.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMTreeView.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMDataGrid.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMListBox.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMSlider.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMCheckBox.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMContextMenu.xaml" />

                <!--  自己项目的样式  -->
                <ResourceDictionary Source="/Styles/DMSkin.xaml" />
                <ResourceDictionary Source="/Styles/Dictionary1.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</code>
</pre>

<h1>通用模板</h1>
<pre>
<code>
&lt;Grid&gt;
        &lt;Grid Background="White"&gt;
            &lt;Border Grid.Column="0" BorderThickness="0,0,0,2" BorderBrush="{StaticResource LineColor}" VerticalAlignment="Top"&gt;
                &lt;Grid&gt;
                    &lt;TextBlock Foreground="{StaticResource MainColor}" Text="DMSkin"  FontSize="20"
                           HorizontalAlignment="Left" VerticalAlignment="Center" Margin="10,0,0,0"/&gt;
                    &lt;Button  Name="ButtonSkin"
                                ToolTip="主题"
                                Focusable="False"
                                Style="{DynamicResource CaptionButtonStyle}"
                                Padding="0" HorizontalContentAlignment="Center" HorizontalAlignment="Right" Margin="0,0,150,0" Width="50" Height="50" 
                                &gt;
                        &lt;Label Foreground="#FF555555" 
                                       Content="X" FontSize="22" 
                                       HorizontalContentAlignment="Center" FontWeight="Bold"  &gt;&lt;/Label&gt;
                    &lt;/Button&gt;
                &lt;/Grid&gt;
            &lt;/Border&gt;
        &lt;/Grid&gt;
        &lt;ResizeGrip  HorizontalContentAlignment="Stretch" VerticalContentAlignment="Stretch" VerticalAlignment="Bottom" HorizontalAlignment="Right"&gt;&lt;/ResizeGrip&gt;
&lt;/Grid&gt;
</code>
</pre>

<h1>圆角窗体</h1>
<pre>
<code>
&lt;Border Background="White" CornerRadius="5"  BorderThickness="1"&gt;
        &lt;Border.Effect&gt;
            &lt;DropShadowEffect BlurRadius="12" ShadowDepth="0" Color="#88000000"/&gt;
        &lt;/Border.Effect&gt;
        &lt;Grid Margin="0,0,0,0"&gt;
            &lt;Grid Background="Transparent"&gt;
                &lt;Grid.RowDefinitions&gt;
                    &lt;RowDefinition Height="30"&gt;&lt;/RowDefinition&gt;
                    &lt;RowDefinition Height="*"&gt;&lt;/RowDefinition&gt;
                    &lt;RowDefinition Height="30"&gt;&lt;/RowDefinition&gt;
                &lt;/Grid.RowDefinitions&gt;
                &lt;Grid Grid.Row="0" Name="DMTitle"&gt;
                &lt;/Grid&gt;
            &lt;/Grid&gt;
            &lt;ResizeGrip VerticalContentAlignment="Bottom" HorizontalContentAlignment="Right" HorizontalAlignment="Right" VerticalAlignment="Bottom"&gt;&lt;/ResizeGrip&gt;
        &lt;/Grid&gt;
&lt;/Border&gt;
</code>
</pre>

<h1>更多效果图:</1>
<br/>
<img  src="https://raw.githubusercontent.com/944095635/Image/master/GI (2).png" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/A (1).gif" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/A (2).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/B.png" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/A (3).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/A (4).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/JSQ.jpg" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/GIF3.gif" />
<img  src="https://raw.githubusercontent.com/944095635/Image/master/双层.gif" />
>>>>>>> master

# DMSkin-for-WPF 2.1.0.0
<hr/>
<h1>前言</h1>
<h3>WPF无边框方案(双层窗体)</h3>
<h4>基于WPF的UI框架</h4>
<h4>方案思路:Win32 重绘非客户区+阴影层窗口</h4>
<h4>支持：.NET Framework 3.5 - 4.7</h4>
<h4>支持：Windows XP - Windows 7 - Windows 10</h4>


WPF borderless scheme (double form)

UI framework based on WPF

Plan idea: Win32 redraws non customer zone + shadow layer window

Support:.NET Framework 3.5 - 4.7

Support: Windows XP - Windows 7 - Windows 10


<h1>注意事项</h1>
<h3>本源码采用VS2017 个人版 开发,.NET FrameWork4.0,部分C# 6.0+语法 vs2015 vs2013 vs2012 请自行修改源码中不支持的部分。</h3>
<h3>---遗留BUG:WIN7 系统上非客户区系统按钮阻挡操作(目前WIN7有点小瑕疵)---</h3>


<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/NEW.jpg" />

<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/双层.gif" />



DMSkin-for-WPF是一个基于WPF的.Net WPF开源界面库,实现了无边框的WPF开发方案,内置部分控件模板.
你可以参照模板自行修改完善。（以下简称DFW）。

<h1>核心</h1>
DFW实现了比较完美的无边框窗体方案，并且拖拽全部采用WIN32消息实现。拖拽依靠桌面边缘完美,高DPI支持,窗体不会变形或异常

最新版本已经支持MVVM架构。



<h1>版本更新</h1>
<blockquote>
 
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
<img style="width:200px;" src="https://github.com/944095635/DMSkin-for-WPF/blob/master/%E5%9B%BE%E7%89%87/JZ.jpg" />


<h1>使用说明</h1>
<pre>
<code>
1.引用DMSkin.WPF.DLL
2.Window继承修改为:MainWindow : DMSkinWindow
3.添加引用:xmlns:DMSkin="clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF"
4.XAML继承修改为: DMSkin:DMSkinWindow x:Class="DMSkin.WPF.Test.MainWindow"
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

<WrapPanel Height="{Binding DMSystemButtonSize}" Orientation="Horizontal" VerticalAlignment="Top" HorizontalAlignment="Right">
            <controls:DMSystemMinButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#383838" DMSystemButtonForeground="#383838"></controls:DMSystemMinButton>
            <controls:DMSystemMaxButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#FFFFFF" DMSystemButtonForeground="#383838"></controls:DMSystemMaxButton>
            <controls:DMSystemCloseButton DMSystemButtonSize="50" DMSystemButtonHoverForeground="#FFFFFF" DMSystemButtonForeground="#383838"></controls:DMSystemCloseButton>
        </WrapPanel>


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
&lt;Application.Resources&gt;
            &lt;ResourceDictionary&gt;
                &lt;ResourceDictionary.MergedDictionaries&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Themes/DMColor.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Themes/DMScrollViewer.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMButton.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMTabControl.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMRadioButton.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMTreeView.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMDataGrid.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMListBox.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMSlider.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMCheckBox.xaml" /&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.Wpf;component/Themes/DMContextMenu.xaml" /&gt;
                &lt;/ResourceDictionary.MergedDictionaries&gt;
            &lt;/ResourceDictionary&gt;
&lt;/Application.Resources&gt;
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

<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (1).gif" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (2).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/B.png" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (3).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (4).jpg" />

<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/JSQ.jpg" />

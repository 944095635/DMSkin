# DMSkin-for-WPF 2.0
<h3>全中国第一款WPF无边框完美方案</h3>
<p>基于WPF的UI框架</p>

<p>【2.0版本】 双层窗体+Win32 不支持窗体透明,不支持窗体圆角,特点：完美的最小化动画(完美移植winform无边框方案)</p>
<p>如果采用虚线边框,则可以去除双层窗体。</p>
<br/>
<p>【<a href='https://github.com/944095635/DMSkin-for-WPF-1.0' target="_blank">1.0版本</a>】 WindowStyle.None + 透明 最小化动画采用xaml实现,特点：支持窗体透明,支持窗体圆角,缺点:最小化动画流畅程度不够。</p>



<h1>前言</h1>

<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A.png" />


DMSkin-for-WPF是一个基于WPF的.Net WPF开源界面库,实现了无边框的WPF开发方案,内置部分控件模板.
你可以参照模板自行修改完善。（以下简称DFW）。

<h1>核心</h1>
DFW实现了比较完美的无边框窗体方案，并且拖拽全部采用WIN32消息实现。拖拽依靠桌面边缘完美,高DPI支持,窗体不会变形或异常

另外,由于我对MVVM不擅长，所以DEMO并不是采用MVVM框架。


<h1>注意事项</h1>
本源码采用VS2017 个人版 开发,部分C# 6.0+语法 vs2015 vs2013 vs2012 请自行修改源码中不支持的部分。


<h1>版本更新 - 2.0版本</h1>
<blockquote>
   
<h2>2.0版本,采用WIN32实现无边框,2.0版本不支持圆角窗体,不支持窗体透明,但是拥有完美最小化的动画。如果采用虚线边框,则可以去除双层窗体。</h2>
<h2>1.0版本,采用WindowsNone实现无边框,版本缺陷是无边框通病，窗体最小化 动画失效了。但是我用xaml实现了动画(动画流畅程度取决于显卡),需要这个版本的源码请点击我的头像进到另外一个1.0项目中获取</h2>

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
<h2>WPF课程直播(收费) QQ群： 669046923</h2>

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
Foreground="White"      //前景色 
Background="White"      //背景色   
----DMWindow="Shadow"     //Shadow-阴影模式  Metro-线条扁平化模式   --2.0中移除
DMShowMin="True"        //显示系统按钮-最小化
DMShowMax="True"        //显示系统按钮-最大化
DMShowClose="True"      //显示系统按钮-Close
DMWindowShadowSize="10" //窗体边框阴影颜色-仅Shadow有效
DMWindowShadowColor="#FFC8C8C8" 
DMSystemButtonSize="50" //系统按钮大小
DMSystemButtonForeground="#FF666666" //系统按钮颜色
DMSystemButtonHoverColor="#33000000" //系统按钮的鼠标悬浮色
DMSystemButtonShadowEffect="0"  //系统按钮的阴影大小
----DMMetroBorderColor="#FFC8C8C8"  //窗体边框颜色-仅Metro有效   --2.0中移除
----DMMetroBorderSize="1"  //边框大小-仅Metro有效   --2.0中移除
ResizeMode="CanResizeWithGrip" //边框拉伸方案
Height="700" Width="1000"   //窗体大小
MinHeight="268" MinWidth="360"  //窗体最大以及最小属性
WindowStartupLocation="CenterScreen"   //窗体初始位置
</code>
</pre>


<h1>资源引用</h1>
<pre>
<code>
&lt;Application.Resources&gt;
            &lt;ResourceDictionary&gt;
                &lt;ResourceDictionary.MergedDictionaries&gt;
                &lt;ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Themes/DMSkin.xaml" /&gt;
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

<h1>更多效果图</1>
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (1).gif" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (2).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/B.png" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (3).jpg" />
<img  src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/图片/A (4).jpg" />

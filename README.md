# DMSkin-for-WPF
基于WPF的UI框架


<h1>前言</h1>

<image src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/Images/A.png"></image>



DMSkin-for-WPF是一个基于WPF开源项目的.Net WPF界面库,实现了无边框的WPF开发方案,内置部分控件模板.
你可以参照模板自行修改完善。（以下简称DFW）。

<h1>核心</h1>
DFW实现了比较完美的无边框窗体方案，并且拖拽全部采用WIN32消息实现。拖拽依靠桌面边缘完美,高DPI支持,窗体不会变形或异常
目前唯一的缺陷是无边框通病，窗体最小化 动画失效了（如果你有解决方案 请联系我）。
另外,由于我对MVVM不擅长，所以DEMO并不是采用MVVM框架。


<h1>相关</h1>
加入讨论

QQ群： 76566523

我的QQ： 944095635

官网： http://www.dmskin.com



<h1>使用说明</h1>
<pre><code>
1.引用DMSkin.WPF.DLL
2.Window继承修改为:MainWindow : DMSkinWindow
3.添加引用:xmlns:DMSkin="clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF"
4.XAML继承修改为: DMSkin:DMSkinWindow x:Class="DMSkin.WPF.Test.MainWindow"
</code></pre>
<h1>窗体属性</h1>
<pre><code>
Foreground="White"  //前景色        
Background="White"  //背景色   
DMWindow="Shadow"   //Shadow-阴影模式  Metro-线条扁平化模式
DMShowMin="True"//显示系统按钮-最小化
DMShowMax="True"//显示系统按钮-最大化
DMShadowSize="10"//窗体阴影大小
DMTitleSize="50"//系统按钮大小
DMTitleColor="#FF666666"//系统按钮颜色
DMTitleHoverColor="#33000000"//系统按钮的鼠标悬浮色
DMDropShadowEffect="0" //系统按钮的阴影大小
DMShadowColor="#FFC8C8C8" //窗体边框阴影颜色-仅Shadow有效
DMBorderColor="#FFC8C8C8" //窗体边框颜色-仅Metro有效
DMBorderSize="1" //边框大小-仅Metro有效
ResizeMode="CanResizeWithGrip" //边框拉伸方案
Height="700" Width="1000"  //窗体大小
WindowStartupLocation="CenterScreen"  //窗体初始位置
MinHeight="268" MinWidth="360"   //窗体最大以及最小属性
</code></pre>


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
<image src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/Images/A (1).gif"></image>
<image src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/Images/A.png"></image>
<image src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/Images/A.png"></image>

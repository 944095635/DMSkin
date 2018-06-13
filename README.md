# DMSkin-for-WPF
![](https://img.shields.io/badge/.NET-%3E%3D3.5-brightgreen.svg)
![](https://img.shields.io/badge/version-2.5.0.1-blue.svg)
![](https://img.shields.io/badge/license-MIT-green.svg)

A WPF UI framework to create borderless window faster and easier.

## Preface
DMSkin-for-WPF (aka DFW) is a WPF UI framework that aims to help WPF developers create a borderless window faster and easier. It supports .NET framework from 3.5 to 4.7, and runs well from `Windows XP` to `Windows 10`.

DFW offers 2 plans for window borderless:
#### 1. ComplexWindow Plan
Use Windows 32 API to redraw non-client area and create a separate shadow window to for shadow's presentation.
#### 2. SimpleWindow Plan
Delay Window message to prevent flickering corruption bug.

The follwing chart can show you the differences between `DMSkinComplexWindow` and `DMSkinSimlpeWindow`


| Plan       | Transparency   |  Animation |

| :----: | :---:  | :----:  | :---: |

| DMSkinComplexWindow     | Not Support |  Support |

| DMSkinSimpleWindow      |  Support   |   Not Support |

## Installation
You can get the **`DMSkin.WPF.dll`** through 2 two different ways.

#### 1. [Download DMSkin.WPF.dll directly](https://github.com/944095635/DMSkin-for-WPF/releases/download/2.5.0.1/Release.zip)

The drawback of this way is the `dll` you downloaded is not always up to date.

#### 2. [Download the source code](https://github.com/944095635/DMSkin-for-WPF/archive/master.zip) and compile it yourself
Click `DMSkin-for-WPF.sln` to open the project, right click DMSkin.WPF in the solution resource manager window and click build button to complile. And then open the project folder with `file explorer`, you will find the DMSkin.WPF.dll is in `bin\Debug` folder.

There are some other ways to fetch `DMSkin.WPF.dll` and source code.

- Nuget  `PM> Install-Package DMSkin.WPF -Version 2.5.0.1`
- Git  `git clone git@github.com:944095635/DMSkin-for-WPF.git`

## Usage & Configration
#### 1. Create a new WPF project
#### 2. [Add DMSkin.WPF.dll reference](http://p40kjburh.bkt.clouddn.com/18-6-13/50043356.jpg)
#### 3. Modify `MainWindow.cs`
<p style="background:rgba(230, 255, 237,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">+ </span>using DMSkin.WPF;</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">+  </span>	using System.Windows;</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span></p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>namespace DMSkinDemo</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>{</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp/// &ltsummary&gt</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp/// MainWindow.xaml 的交互逻辑</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp/// &lt/summary&gt</p>
<p style="background:rgba(255, 238, 240,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">- </span>&nbsp&nbsppublic partial class MainWindow : Window</p>
<p style="background:rgba(230, 255, 237,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">+ </span>&nbsp&nbsppublic partial class MainWindow : DMSkinSimpleWindow</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp{</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp&nbsp&nbsppublic MainWindow()</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp&nbsp&nbsp{</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbspInitializeComponent();</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp&nbsp&nbsp}</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&nbsp&nbsp}</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>}</p>

#### 4. Modify `MainWindow.xaml`
<p style="background:rgba(255, 238, 240,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">- </span>&ltWindow x:Class="DMSkinTest.MainWindow"</p>
<p style="background:rgba(230, 255, 237,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">+ </span>&ltWindow x:Class="DMSkinTest.MainWindow"&ltDMSkin:DMSkinSimpleWindow x:Class="DMSkinDemo.MainWindow"</p>
<p style="background:rgba(230, 255, 237,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">+ </span>xmlns:DMSkin="clr-namespace:DMSkin.WPF;assembly=DMSkin.WPF"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">+  </span>	xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>		xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>		xmlns:d="http://schemas.microsoft.com/expression/blend/2008"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>		xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>	xmlns:local="clr-namespace:DMSkinTest"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>	mc:Ignorable="d"</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>	Title="MainWindow" Height="450" Width="800"&gt</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&ltGrid&gt</p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span></p>
<p style="background:rgba(241, 248, 255,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(241, 248, 255,1);margin-left:2px">&nbsp  </span>&ltGrid&gt</p>
<p style="background:rgba(255, 238, 240,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">- </span>&lt/Window&gt</p>
<p style="background:rgba(230, 255, 237,1);width:auto;margin:0;font-family:consolas"><span class="codepre" style="color:rgba(32, 32, 32,1);margin-left:2px">+ </span>&ltWindow x:Class="DMSkinTest.MainWindow"&ltDMSkin:DMSkinSimpleWindow x:Class="DMSkinDemo.MainWindow"</p>

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
DMWindowShadowDragVisibility="False"  // whether show shadow when window is dragging
DMWindowShadowVisibility="False"      // whether show window shadow
DMWindowShadowBackColor="#FF323CAD"   // shadow background color (only for DMSkinComplexWindow)
ResizeMode="CanResize"                // window resize mode (CanResiz or CanResizeWithGrip)
WindowStartupLocation="CenterScreen"  // window startup location
````

#### 8. [Make Rounded window (optional)](./demos/Rounded-Window.xaml)


<style>
.codepre{
    -webkit-user-select:none;
    -moz-user-select:none;
    -ms-user-select:none;
    user-select:none;
}
</style>
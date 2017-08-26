using DMSkin.WPF.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static DMSkin.WPF.DMSkinWindow;

namespace DMSkin.WPF
{
    /// <summary>
    /// 主窗体基类
    /// </summary>
    public partial class DMSkinWindow:Window,INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 初始化
        public DMSkinWindow()
        {
            AllowsTransparency = true;
            WindowStyle = WindowStyle.None;
            InitializeStyle();
            DataContext = this;
            BindFunc();
            Loaded += new RoutedEventHandler(DMLoad);
        }

        
        private void DMLoad(object sender, RoutedEventArgs e)
        {
            WindowBorder = (Grid)Template.FindName("WindowBorder", this);

            Button btnClose = (Button)Template.FindName("PART_Close", this);
            btnClose.Click += delegate
            {
                Close();
            };
            Button btnMax = (Button)Template.FindName("PART_Max", this);
            btnMax.Click += delegate
            {
                WindowState = WindowState.Maximized;
            };
            Button btnRestore = (Button)Template.FindName("PART_Restore", this);
            btnRestore.Click += delegate
            {
                WindowState = WindowState.Normal;
            };
            Button btnMin = (Button)Template.FindName("PART_Min", this);
            btnMin.Click += delegate
            {
                WindowMini();
            };
        }

    
        Style MainWindowShadow;
        Style MainWindowMetro;
        /// <summary>
        /// 慢慢显示的动画
        /// </summary>
        Storyboard StoryboardSlowShow;
        /// <summary>
        /// 慢慢隐藏的动画
        /// </summary>
        Storyboard StoryboardSlowHide;

        private void InitializeStyle()
        {
            string packUri = @"/DMSkin.WPF;component/Themes/DMSkin.xaml";
            ResourceDictionary dic = new ResourceDictionary { Source = new Uri(packUri, UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(dic);

            string packUriAnimation = @"/DMSkin.WPF;component/Themes/Animation.xaml";
            ResourceDictionary dicAnimation = new ResourceDictionary { Source = new Uri(packUriAnimation, UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(dicAnimation);

            MainWindowShadow = this.Style = (Style)dic["MainWindow"];
            MainWindowMetro = (Style)dic["MainWindowMetro"];

            StoryboardSlowShow = (Storyboard)this.FindResource("SlowShow");
            StoryboardSlowHide = (Storyboard)this.FindResource("SlowHide");
        }
        #endregion

        #region 窗体操作函数
        //绑定
        private void BindFunc()
        {
            //绑定窗体操作函数
            this.SourceInitialized += MainWindow_SourceInitialized;
            this.StateChanged += MainWindow_StateChanged;
            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }

        //边框
        private Grid WindowBorder;

        //WIN32 互操作
        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            if (source == null)
            { throw new Exception("Cannot get HwndSource instance."); }
            source.AddHook(new HwndSourceHook(this.WndProc));
        }

        //消息
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case Win32.WM_GETMINMAXINFO: // WM_GETMINMAXINFO message  
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
                case Win32.WM_SYSCOMMAND:
                    if (wParam.ToInt32() == Win32.SC_MINIMIZE)//最小化消息
                    {
                        WindowMini();
                        handled = true;
                    }
                    if (wParam.ToInt32() == Win32.SC_RESTORE)//恢复消息
                    {
                        StoryboardSlowShow.Begin(this);
                    }
                    break;
            }
            return IntPtr.Zero;
        }


        private void WindowMini()
        {
            //启动最小化动画
            StoryboardSlowHide.Begin(this);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(300);
                Dispatcher.Invoke(new Action(() =>
                {
                    WindowState = WindowState.Minimized;
                }));
            });
        }

        //最大最小化信息
        void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            // MINMAXINFO structure  
            Win32.MINMAXINFO mmi = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));

            // Get handle for nearest monitor to this window  
            WindowInteropHelper wih = new WindowInteropHelper(this);
            IntPtr hMonitor = Win32.MonitorFromWindow(wih.Handle, Win32.MONITOR_DEFAULTTONEAREST);

            // Get monitor info   显示屏
            Win32.MONITORINFOEX monitorInfo = new Win32.MONITORINFOEX();

            monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);
            Win32.GetMonitorInfo(new HandleRef(this, hMonitor), monitorInfo);
            
            // Convert working area  
            Win32.RECT workingArea = monitorInfo.rcWork;

            // Set the maximized size of the window  
            //ptMaxSize：  设置窗口最大化时的宽度、高度
            //mmi.ptMaxSize.x = (int)dpiIndependentSize.X;
            //mmi.ptMaxSize.y = (int)dpiIndependentSize.Y;

            // Set the position of the maximized window  
            mmi.ptMaxPosition.x = workingArea.Left;
            mmi.ptMaxPosition.y = workingArea.Top;

            // Get HwndSource  
            HwndSource source = HwndSource.FromHwnd(wih.Handle);
            if (source == null)
                // Should never be null  
                throw new Exception("Cannot get HwndSource instance.");
            if (source.CompositionTarget == null)
                // Should never be null  
                throw new Exception("Cannot get HwndTarget instance.");

            Matrix matrix = source.CompositionTarget.TransformToDevice;

            Point dpiIndenpendentTrackingSize = matrix.Transform(new Point(
               this.MinWidth,
               this.MinHeight
               ));

            if (DMFullScreen)
            {
                Point dpiSize = matrix.Transform(new Point(
              SystemParameters.PrimaryScreenWidth,
              SystemParameters.PrimaryScreenHeight
              ));

                mmi.ptMaxSize.x = (int)dpiSize.X;
                mmi.ptMaxSize.y = (int)dpiSize.Y;
            }
            else
            {
                mmi.ptMaxSize.x = workingArea.Right;
                mmi.ptMaxSize.y = workingArea.Bottom;
            }

            // Set the minimum tracking size ptMinTrackSize： 设置窗口最小宽度、高度 
            mmi.ptMinTrackSize.x = (int)dpiIndenpendentTrackingSize.X;
            mmi.ptMinTrackSize.y = (int)dpiIndenpendentTrackingSize.Y;

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        //窗体最大化 隐藏阴影
        void MainWindow_StateChanged(object sender, EventArgs e)
        {
            //WindowBorder 窗体边框
            if (WindowState == WindowState.Maximized)
            {
                if (DMShowMax)
                {
                    BtnMaxVisibility = Visibility.Collapsed;
                    BtnRestoreVisibility = Visibility.Visible;
                }
                WindowBorder.Margin = new Thickness(0);
            }
            if (WindowState == WindowState.Normal)
            {
                if (DMShowMax)
                {
                    BtnMaxVisibility = Visibility.Visible;
                    BtnRestoreVisibility = Visibility.Collapsed;
                }
                WindowBorder.Margin = new Thickness(DMWindowShadowSize);
            }
        }

        //窗体移动
        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Grid g)
            {
                if (g.Tag is string s && s == "NoMove")
                {
                    return;
                }
            }
            if (e.OriginalSource is Border b)
            {
                if (b.Tag is string s && s== "NoMove")
                {
                    return;
                }
            }
            if (e.OriginalSource is Grid || e.OriginalSource is Window|| e.OriginalSource is Border)
            {
                WindowInteropHelper wih = new WindowInteropHelper(this);
                Win32.SendMessage(wih.Handle, Win32.WM_NCLBUTTONDOWN, (int)Win32.HitTest.HTCAPTION, 0);
                return;
            }
        }

        public class Win32
        {
            // Sent to a window when the size or position of the window is about to change
            //发送到一个窗口时，窗口的大小和位置变化有关
            public const int WM_GETMINMAXINFO = 0x0024;
            /// <summary>
            /// 系统操作
            /// </summary>
            public const int WM_SYSCOMMAND = 0x112;
            /// <summary>
            /// 最小化
            /// </summary>
            public const int SC_MINIMIZE = 0xF020;
            /// <summary>
            /// 恢复
            /// </summary>
            public const int SC_RESTORE = 0xF120;

            // Retrieves a handle to the display monitor that is nearest to the window  
            //检索到靠近窗口的显示监视器的处理
            public const int MONITOR_DEFAULTTONEAREST = 2;

            // Retrieves a handle to the display monitor  
            [DllImport("user32.dll")]
            public static extern IntPtr MonitorFromWindow(IntPtr hwnd, int dwFlags);

            // RECT structure, Rectangle used by MONITORINFOEX  
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            // MONITORINFOEX structure, Monitor information used by GetMonitorInfo function  
            [StructLayout(LayoutKind.Sequential)]
            public class MONITORINFOEX
            {
                public int cbSize;
                public RECT rcMonitor; // The display monitor rectangle  
                public RECT rcWork; // The working area rectangle  
                public int dwFlags;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x20)]
                public char[] szDevice;
            }

            // Point structure, Point information used by MINMAXINFO structure  
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int x;
                public int y;

                public POINT(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            // MINMAXINFO structure, Window's maximum size and position information  
            [StructLayout(LayoutKind.Sequential)]
            public struct MINMAXINFO
            {
                public POINT ptReserved;
                public POINT ptMaxSize; // The maximized size of the window  
                public POINT ptMaxPosition; // The position of the maximized window  
                public POINT ptMinTrackSize;
                public POINT ptMaxTrackSize;
            }

            // Get the working area of the specified monitor  
            [DllImport("user32.dll")]
            public static extern bool GetMonitorInfo(HandleRef hmonitor, [In, Out] MONITORINFOEX monitorInfo);

            // Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate  
            public const int WM_NCHITTEST = 0x0084;

            /// <summary>  
            /// Indicates the position of the cursor hot spot.  
            /// </summary>  
            public enum HitTest : int
            {
                /// <summary>  
                /// On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function produces a system beep to indicate an error).  
                /// </summary>  
                HTERROR = -2,

                /// <summary>  
                /// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).  
                /// </summary>  
                HTTRANSPARENT = -1,

                /// <summary>  
                /// On the screen background or on a dividing line between windows.  
                /// </summary>  
                HTNOWHERE = 0,

                /// <summary>  
                /// In a client area.  
                /// </summary>  
                HTCLIENT = 1,

                /// <summary>  
                /// In a title bar.  
                /// </summary>  
                HTCAPTION = 2,

                /// <summary>  
                /// In a window menu or in a Close button in a child window.  
                /// </summary>  
                HTSYSMENU = 3,

                /// <summary>  
                /// In a size box (same as HTSIZE).  
                /// </summary>  
                HTGROWBOX = 4,

                /// <summary>  
                /// In a size box (same as HTGROWBOX).  
                /// </summary>  
                HTSIZE = 4,

                /// <summary>  
                /// In a menu.  
                /// </summary>  
                HTMENU = 5,

                /// <summary>  
                /// In a horizontal scroll bar.  
                /// </summary>  
                HTHSCROLL = 6,

                /// <summary>  
                /// In the vertical scroll bar.  
                /// </summary>  
                HTVSCROLL = 7,

                /// <summary>  
                /// In a Minimize button.  
                /// </summary>  
                HTMINBUTTON = 8,

                /// <summary>  
                /// In a Minimize button.  
                /// </summary>  
                HTREDUCE = 8,

                /// <summary>  
                /// In a Maximize button.  
                /// </summary>  
                HTMAXBUTTON = 9,

                /// <summary>  
                /// In a Maximize button.  
                /// </summary>  
                HTZOOM = 9,

                /// <summary>  
                /// In the left border of a resizable window (the user can click the mouse to resize the window horizontally).  
                /// </summary>  
                HTLEFT = 10,

                /// <summary>  
                /// In the right border of a resizable window (the user can click the mouse to resize the window horizontally).  
                /// </summary>  
                HTRIGHT = 11,

                /// <summary>  
                /// In the upper-horizontal border of a window.  
                /// </summary>  
                HTTOP = 12,

                /// <summary>  
                /// In the upper-left corner of a window border.  
                /// </summary>  
                HTTOPLEFT = 13,

                /// <summary>  
                /// In the upper-right corner of a window border.  
                /// </summary>  
                HTTOPRIGHT = 14,

                /// <summary>  
                /// In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).  
                /// </summary>  
                HTBOTTOM = 15,

                /// <summary>  
                /// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).  
                /// </summary>  
                HTBOTTOMLEFT = 16,

                /// <summary>  
                /// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).  
                /// </summary>  
                HTBOTTOMRIGHT = 17,

                /// <summary>  
                /// In the border of a window that does not have a sizing border.  
                /// </summary>  
                HTBORDER = 18,

                /// <summary>  
                /// In a Close button.  
                /// </summary>  
                HTCLOSE = 20,

                /// <summary>  
                /// In a Help button.  
                /// </summary>  
                HTHELP = 21,
            };

            // Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window  
            public const int WM_NCLBUTTONDOWN = 0x00A1;

            // Sends the specified message to a window or windows  
            [DllImport("user32.dll", EntryPoint = "SendMessage")]
            public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        }
        #endregion

        #region 窗体属性


        private bool _DMFullscreen = false;
        [Description("全屏是否保留任务栏显示"), Category("DMSkin")]
        public bool DMFullScreen
        {
            get
            {
                return _DMFullscreen;
            }

            set
            {
                _DMFullscreen = value;
                OnPropertyChanged("DMFull");
            }
        }


        private DMWindow dmDMWindow = DMWindow.Shadow;
        [Description("窗体类型"), Category("DMSkin")]
        public DMWindow DMWindow
        {
            get
            {
                return dmDMWindow;
            }

            set
            {
                dmDMWindow = value;
                if (dmDMWindow == DMWindow.Shadow)//阴影
                {
                    this.Style = MainWindowShadow;
                }
                else
                {
                    this.Style = MainWindowMetro;
                }
                OnPropertyChanged("DMWindow");
            }
        }

        private int _DMWindowShadowSize = 10;
        [Description("窗体阴影大小"), Category("DMSkin")]
        public int DMWindowShadowSize
        {
            get
            {
                return _DMWindowShadowSize;
            }

            set
            {
                _DMWindowShadowSize = value;
                OnPropertyChanged("DMWindowShadowSize");
            }
        }

        private Color _DMWindowShadowColor = Color.FromArgb(255, 151, 151, 151);

        [Description("窗体阴影颜色"), Category("DMSkin")]
        public Color DMWindowShadowColor
        {
            get
            {
                return _DMWindowShadowColor;
            }

            set
            {
                _DMWindowShadowColor = value;
                OnPropertyChanged("DMWindowShadowColor");
            }
        }


        #region 系统按钮
        private int _DMSystemButtonSize = 30;

        [Description("窗体标题高度(关系到系统按钮)"), Category("DMSkin")]
        public int DMSystemButtonSize
        {
            get
            {
                return _DMSystemButtonSize;
            }

            set
            {
                _DMSystemButtonSize = value;
                OnPropertyChanged("DMSystemButtonSize");
            }
        }

        private Brush _DMSystemButtonHoverColor = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));

        [Description("窗体系统按钮鼠标悬浮背景颜色"), Category("DMSkin")]
        public Brush DMSystemButtonHoverColor
        {
            get
            {
                return _DMSystemButtonHoverColor;
            }

            set
            {
                _DMSystemButtonHoverColor = value;
                OnPropertyChanged("DMSystemButtonHoverColor");
            }
        }

        private double _DMSystemButtonShadowEffect = 1;
        [Description("窗体控制按钮阴影大小"), Category("DMSkin")]
        public double DMSystemButtonShadowEffect
        {
            get
            {
                return _DMSystemButtonShadowEffect;
            }

            set
            {
                _DMSystemButtonShadowEffect = value;
                OnPropertyChanged("DMSystemButtonShadowEffect");
            }
        }

        private Brush _DMSystemButtonForeground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        [Description("窗体系统按钮颜色"), Category("DMSkin")]
        public Brush DMSystemButtonForeground
        {
            get
            {
                return _DMSystemButtonForeground;
            }

            set
            {
                _DMSystemButtonForeground = value;
                OnPropertyChanged("DMSystemButtonForeground");
            }
        }



        private bool dmShowMax = true;
        [Description("显示最大化按钮"), Category("DMSkin")]
        public bool DMShowMax
        {
            get
            {
                return dmShowMax;
            }

            set
            {
                dmShowMax = value;
                if (dmShowMax)
                {
                    ResizeMode = ResizeMode.CanResize;
                    BtnMaxVisibility = Visibility.Visible;
                    BtnRestoreVisibility = Visibility.Collapsed;
                }
                else
                {
                    ResizeMode = ResizeMode.CanMinimize;
                    BtnMaxVisibility = Visibility.Collapsed;
                    BtnRestoreVisibility = Visibility.Collapsed;
                }

                OnPropertyChanged("DMShowMax");
            }
        }

        private bool dmShowMin = true;
        [Description("显示最小化按钮"), Category("DMSkin")]
        public bool DMShowMin
        {
            get
            {
                return dmShowMin;
            }

            set
            {
                dmShowMin = value;
                if (dmShowMin)
                {
                    ResizeMode = ResizeMode.CanResize;
                    BtnMinVisibility = Visibility.Visible;
                }
                else
                {
                    ResizeMode = ResizeMode.CanMinimize;
                    BtnMinVisibility = Visibility.Collapsed;
                }
                OnPropertyChanged("DMShowMin");
            }
        }


        private bool dmShowClose = true;
        [Description("显示关闭按钮"), Category("DMSkin")]
        public bool DMShowClose
        {
            get
            {
                return dmShowClose;
            }

            set
            {
                dmShowClose = value;
                if (dmShowClose)
                {
                    BtnCloseVisibility = Visibility.Visible;
                }
                else
                {
                    BtnCloseVisibility = Visibility.Collapsed;
                }
                OnPropertyChanged("DMShowClose");
            }
        }
        #endregion

        #region Metro 属性
        private int _DMMetroBorderSize = 1;

        [Description("Metro窗体边框宽度"), Category("DMSkin")]
        public int DMMetroBorderSize
        {
            get
            {
                return _DMMetroBorderSize;
            }

            set
            {
                _DMMetroBorderSize = value;
                OnPropertyChanged("DMMetroBorderSize");
            }
        }


        private Brush _DMMetroBorderColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        [Description("Metro窗体边框颜色"), Category("DMSkin")]
        public Brush DMMetroBorderColor
        {
            get
            {
                return _DMMetroBorderColor;
            }

            set
            {
                _DMMetroBorderColor = value;
                OnPropertyChanged("DMMetroBorderColor");
            }
        }
        #endregion

   

        private Visibility btnMinVisibility = Visibility.Visible;
        //最小化按钮显示
        public Visibility BtnMinVisibility
        {
            get
            {
                return btnMinVisibility;
            }

            set
            {
                btnMinVisibility = value;
                OnPropertyChanged("BtnMinVisibility");
            }
        }

        private Visibility btnCloseVisibility = Visibility.Visible;
        //关闭按钮显示
        public Visibility BtnCloseVisibility
        {
            get
            {
                return btnCloseVisibility;
            }

            set
            {
                btnCloseVisibility = value;
                OnPropertyChanged("BtnCloseVisibility");
            }
        }

        private Visibility btnMaxVisibility = Visibility.Visible;
        //最大化按钮显示
        public Visibility BtnMaxVisibility
        {
            get
            {
                return btnMaxVisibility;
            }

            set
            {
                btnMaxVisibility = value;
                OnPropertyChanged("BtnMaxVisibility");
            }
        }

        private Visibility btnRestoreVisibility = Visibility.Collapsed;
        //最大化按钮显示
        public Visibility BtnRestoreVisibility
        {
            get
            {
                return btnRestoreVisibility;
            }

            set
            {
                btnRestoreVisibility = value;
                OnPropertyChanged("BtnRestoreVisibility");
            }
        }

        #endregion
    }
}

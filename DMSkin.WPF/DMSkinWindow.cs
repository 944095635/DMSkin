using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace DMSkin.WPF
{
    public partial class DMSkinWindow : Window, INotifyPropertyChanged
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
            InitializeStyle();
            DataContext = this;
            //绑定窗体操作函数
            SourceInitialized += MainWindow_SourceInitialized;
            StateChanged += MainWindow_StateChanged;
            MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            LocationChanged += MainWindow_LocationChanged;
            SizeChanged += MainWindow_SizeChanged;
            Closing += MainWindow_Closing;
            Loaded += Load;

            ShadowWindowVisibility(true);
        }



        private void Load(object sender, RoutedEventArgs e)
        {
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
                WindowState = WindowState.Minimized;
            };

            //绑定阴影窗体
            if (DMWindowShadowVisibility)
            {
                Owner = _shadowWindow;
            }

            //Debug.WriteLine("DMSkinLoad");
        }



        /// <summary>
        /// 初始化样式
        /// </summary>
        private void InitializeStyle()
        {
            string packUri = @"/DMSkin.WPF;component/Themes/DMSkin.xaml";
            ResourceDictionary dic = new ResourceDictionary { Source = new Uri(packUri, UriKind.Relative) };
            Resources.MergedDictionaries.Add(dic);
            Style = (Style)dic["MainWindow"];
        }

        #endregion

        #region 阴影窗体

        private void ShadowWindowVisibility(bool show)
        {
            if (_shadowWindow == null)
            {
                return;
            }
            if (!DMWindowShadowVisibility)
            {
                Owner = null;
                _shadowWindow.Close();
                _shadowWindow = null;
                return;
            }
            if (show)
            {
                _shadowWindow.Show();
            }
            else
            {
                _shadowWindow.Hide();
            }
        }


        //创建阴影窗体
        ShadowWindow _shadowWindow = new ShadowWindow();
        /// <summary>
        /// 窗体关闭时 关闭阴影窗口
        /// </summary>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (_shadowWindow!=null)
            {
                _shadowWindow.Close();
            }
        }

        /// <summary>
        /// 主窗体修改尺寸时 更新阴影窗口
        /// </summary>
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (DMWindowShadowVisibility)
            {
                _shadowWindow.Width = Width + 60;
                _shadowWindow.Height = Height + 60;
            }
        }

        /// <summary>
        /// 窗体移动
        /// </summary>
        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            if (DMWindowShadowVisibility)
            {
                _shadowWindow.Left = Left - 30;
                _shadowWindow.Top = Top - 30;
            }
        }
        #endregion

        #region 系统函数

        IntPtr Handle = IntPtr.Zero;
        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            Handle = new WindowInteropHelper(this).Handle;
            HwndSource source = HwndSource.FromHwnd(Handle);
            if (source == null)
            { throw new Exception("Cannot get HwndSource instance."); }
            source.AddHook(new HwndSourceHook(this.WndProc));
        }
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case Win32.WM_GETMINMAXINFO: // WM_GETMINMAXINFO message  
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
                case Win32.WM_NCHITTEST:
                    return WmNCHitTest(lParam, ref handled);
                //case Win32.WM_SYSCOMMAND:
                //    if (wParam.ToInt32() == Win32.SC_MINIMIZE)//最小化消息
                //    {
                //        Debug.WriteLine("最小化消息");
                //    }
                //    if (wParam.ToInt32() == Win32.SC_RESTORE)//恢复消息
                //    {
                //        Debug.WriteLine("恢复消息");
                //    }
                //    break;
                case Win32.WM_NCPAINT:
                    break;
                case Win32.WM_NCCALCSIZE:
                    handled = true;
                    break;
                case Win32.WM_NCUAHDRAWCAPTION:
                case Win32.WM_NCUAHDRAWFRAME:
                    handled = true;
                    break;
                    //case Win32.WM_NCACTIVATE:
                    //    if (wParam == (IntPtr)Win32.WM_FALSE)
                    //    {
                    //        handled = true;
                    //    }
                    //    //handled = true;
                    //    break;
            }
            return IntPtr.Zero;
        }

        /// <summary>  
        /// 圆角拖动大小 
        /// </summary>  
        private readonly int cornerWidth = 8;

        /// <summary>  
        /// 拉伸鼠标坐标 
        /// </summary>  
        private Point mousePoint = new Point();
        private IntPtr WmNCHitTest(IntPtr lParam, ref bool handled)
        {
            this.mousePoint.X = (int)(short)(lParam.ToInt32() & 0xFFFF);
            this.mousePoint.Y = (int)(short)(lParam.ToInt32() >> 16);
            if (ResizeMode == ResizeMode.CanResize||ResizeMode==ResizeMode.CanResizeWithGrip)
            {
                handled = true;
                //if (Math.Abs(this.mousePoint.Y - this.Top) <= this.cornerWidth
                //    && Math.Abs(this.mousePoint.X - this.Left) <= this.cornerWidth)
                //{ // 左上 
                //    return new IntPtr((int)Win32.HitTest.HTTOPLEFT);
                //}
                //else if (Math.Abs(this.ActualHeight + this.Top - this.mousePoint.Y) <= this.cornerWidth
                //    && Math.Abs(this.mousePoint.X - this.Left) <= this.cornerWidth)
                //{ // 左下  
                //    return new IntPtr((int)Win32.HitTest.HTBOTTOMLEFT);
                //}
                //else if (Math.Abs(this.mousePoint.Y - this.Top) <= this.cornerWidth
                //    && Math.Abs(this.ActualWidth + this.Left - this.mousePoint.X) <= this.cornerWidth)
                //{ //右上
                //    return new IntPtr((int)Win32.HitTest.HTTOPRIGHT);
                //}
                //else if (Math.Abs(this.mousePoint.X - this.Left) <= 30)
                //{ // 左侧边框
                //    return new IntPtr((int)Win32.HitTest.HTLEFT);
                //}
                //else if (Math.Abs(this.mousePoint.Y - this.Top) <= 30)
                //{ // 顶部  
                //    return new IntPtr((int)Win32.HitTest.HTTOP);
                //}
                if (Math.Abs(this.ActualWidth + this.Left - this.mousePoint.X) <= this.cornerWidth
                    && Math.Abs(this.ActualHeight + this.Top - this.mousePoint.Y) <= this.cornerWidth)
                { // 右下 
                    return new IntPtr((int)Win32.HitTest.HTBOTTOMRIGHT);
                }
                else if (Math.Abs(this.ActualWidth + this.Left - this.mousePoint.X) <= 2 && Math.Abs(this.mousePoint.Y - this.Top)>DMSystemButtonSize)
                { // 右  
                    return new IntPtr((int)Win32.HitTest.HTRIGHT);
                }
                else if (Math.Abs(this.ActualHeight + this.Top - this.mousePoint.Y) <= 2)
                { // 底部  
                    return new IntPtr((int)Win32.HitTest.HTBOTTOM);
                }
            }
            handled = false;
            return IntPtr.Zero;
        }

        //最大最小化信息
        void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            // MINMAXINFO structure  
            Win32.MINMAXINFO mmi = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));

            // Get handle for nearest monitor to this window  
            IntPtr hMonitor = Win32.MonitorFromWindow(Handle, Win32.MONITOR_DEFAULTTONEAREST);

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
            HwndSource source = HwndSource.FromHwnd(Handle);
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

        //阴影加载状态
        bool shadowWindowState = false;
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
                ShadowWindowVisibility(false);
            }
            if (WindowState == WindowState.Normal)
            {
                if (DMShowMax)
                {
                    BtnMaxVisibility = Visibility.Visible;
                    BtnRestoreVisibility = Visibility.Collapsed;
                }
                if (shadowWindowState)
                {
                    return;
                }
                shadowWindowState = true;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(200);
                    Dispatcher.Invoke(new Action(() =>
                    {
                        ShadowWindowVisibility(true);
                        shadowWindowState = false;
                        Activate();//激活当前窗口
                        //Debug.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    }));
                });
            }
            if (WindowState == WindowState.Minimized)
            {
                ShadowWindowVisibility(false);
            }
        }
        //窗体移动
        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Grid || e.OriginalSource is Window || e.OriginalSource is Border)
            {
                //是否隐藏阴影
                if (!DMWindowShadowDragVisibility)
                {
                    ShadowWindowVisibility(false);
                }
                Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, (int)Win32.HitTest.HTCAPTION, 0);
                if (!DMWindowShadowDragVisibility)
                {
                    ShadowWindowVisibility(true);
                }
                return;
            }
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


        #region 系统按钮
        private int _DMSystemButtonSize = 30;

        [Description("窗体系统按钮大小"), Category("DMSkin")]
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

        private Brush _DMSystemButtonCloseHoverColor = new SolidColorBrush(Color.FromArgb(255,255,0,0));

        [Description("窗体系统关闭按钮鼠标悬浮背景颜色"), Category("DMSkin")]
        public Brush DMSystemButtonCloseHoverColor
        {
            get
            {
                return _DMSystemButtonCloseHoverColor;
            }

            set
            {
                _DMSystemButtonCloseHoverColor = value;
                OnPropertyChanged("DMSystemButtonCloseHoverColor");
            }
        }
        

        private double _DMSystemButtonShadowEffect = 1.0;
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

        private Brush _DMSystemButtonHoverForeground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

        [Description("窗体系统按钮鼠标悬按钮颜色"), Category("DMSkin")]
        public Brush DMSystemButtonHoverForeground
        {
            get
            {
                return _DMSystemButtonHoverForeground;
            }

            set
            {
                _DMSystemButtonHoverForeground = value;
                OnPropertyChanged("DMSystemButtonHoverForeground");
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

        private bool dMWindowShadowDragVisibility = true;
        [Description("窗体拖动是否显示阴影"), Category("DMSkin")]
        public bool DMWindowShadowDragVisibility
        {
            get
            {
                return dMWindowShadowDragVisibility;
            }

            set
            {
                dMWindowShadowDragVisibility = value;
            }
        }

        [Description("窗体阴影大小"), Category("DMSkin")]
        public int DMWindowShadowSize
        {
            get
            {
                return _shadowWindow.DMWindowShadowSize;
            }

            set
            {
                _shadowWindow.DMWindowShadowSize = value;
            }
        }

        [Description("窗体阴影颜色"), Category("DMSkin")]
        public Color DMWindowShadowColor
        {
            get
            {
                return _shadowWindow.DMWindowShadowColor;
            }

            set
            {
                _shadowWindow.DMWindowShadowColor = value;
            }
        }


        [Description("窗体阴影背景颜色"), Category("DMSkin")]
        public Brush DMWindowShadowBackColor
        {
            get
            {
                return _shadowWindow.DMWindowShadowBackColor;
            }

            set
            {
                _shadowWindow.DMWindowShadowBackColor = value;
            }
        }

        private bool _DMWindowShadowVisibility = true;
        [Description("窗体是否有阴影"), Category("DMSkin")]
        public bool DMWindowShadowVisibility
        {
            get
            {
                return _DMWindowShadowVisibility;
            }

            set
            {
                _DMWindowShadowVisibility = value;
                OnPropertyChanged("DMWindowShadowVisibility");
            }
        }
        #endregion
    }
}


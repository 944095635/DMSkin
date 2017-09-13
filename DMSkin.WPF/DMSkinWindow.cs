using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static DMSkin.WPF.Win32;

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




        //创建阴影窗体
        ShadowWindow shadowWindow = new ShadowWindow();
        public DMSkinWindow()
        {
            InitializeStyle();
            DataContext = this;

            shadowWindow.Width = 0;
            shadowWindow.Height = 0;
            shadowWindow.WindowStyle = WindowStyle.None;
            shadowWindow.AllowsTransparency = true;
            shadowWindow.ShowInTaskbar = false;
            shadowWindow.Show();
            //绑定阴影窗体
            Owner = shadowWindow;


            //绑定窗体操作函数
            SourceInitialized += MainWindow_SourceInitialized;
            StateChanged += MainWindow_StateChanged;
            MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            LocationChanged += MainWindow_LocationChanged;
            SizeChanged += MainWindow_SizeChanged;
            Closing += MainWindow_Closing;

            Loaded += new RoutedEventHandler(Load);


        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            shadowWindow.Close();
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReShadowWindow();
        }

        Style MainWindowShadow;
        private void InitializeStyle()
        {
            string packUri = @"/DMSkin.WPF;component/Themes/DMSkin.xaml";
            ResourceDictionary dic = new ResourceDictionary { Source = new Uri(packUri, UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(dic);

            string packUriAnimation = @"/DMSkin.WPF;component/Themes/Animation.xaml";
            ResourceDictionary dicAnimation = new ResourceDictionary { Source = new Uri(packUriAnimation, UriKind.Relative) };
            this.Resources.MergedDictionaries.Add(dicAnimation);

            MainWindowShadow = this.Style = (Style)dic["MainWindow"];
        }


        public void ReShadowWindow()
        {
            shadowWindow.Left = Left - 30;
            shadowWindow.Top = Top - 30;
            shadowWindow.Width = Width + 60;
            shadowWindow.Height = Height + 60;

            if (WindowState != WindowState.Maximized)
            {
                //让窗体不被裁剪
                POINTAPI[] poin;
                poin = new POINTAPI[4];
                poin[0].x = 0;
                poin[0].y = 0;
                poin[3].x = (int)Width;
                poin[3].y = 0;
                poin[1].x = 0;
                poin[1].y = (int)Height;
                poin[2].x = (int)Width;
                poin[2].y = (int)Height;
                Boolean flag = true;
                IntPtr hRgn = CreatePolygonRgn(ref poin[0], 4, 0);
                SetWindowRgn(new WindowInteropHelper(this).Handle, hRgn, flag);
            }
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            ReShadowWindow();
        }

        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
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
                case Win32.WM_SYSCOMMAND:
                    if (wParam.ToInt32() == Win32.SC_MINIMIZE)//最小化消息
                    {
                         shadowWindow.Hide();//执行最小化动画
                    }
                    if (wParam.ToInt32() == Win32.SC_RESTORE)//恢复消息
                    {
                        Task.Factory.StartNew(() => {
                            Thread.Sleep(100);
                            Dispatcher.Invoke(new Action(() => {
                                shadowWindow.Show();//执行恢复动画
                            }));
                        });
                    }
                    break;
                case Win32.WM_NCPAINT:
                    handled = true;
                    break;
                case Win32.WM_NCCALCSIZE:
                    handled = true;
                    break;
                case Win32.WM_NCACTIVATE:
                    handled = true;
                    break;

                
            }
            return IntPtr.Zero;
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
                shadowWindow.Hide();
            }
            if (WindowState == WindowState.Normal)
            {
                if (DMShowMax)
                {
                    BtnMaxVisibility = Visibility.Visible;
                    BtnRestoreVisibility = Visibility.Collapsed;
                }
            }
            if (WindowState == WindowState.Minimized)
            {
                shadowWindow.Hide();
            }
            ReShadowWindow();
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
                if (b.Tag is string s && s == "NoMove")
                {
                    return;
                }
            }
            if (e.OriginalSource is Grid || e.OriginalSource is Window || e.OriginalSource is Border)
            {
                WindowInteropHelper wih = new WindowInteropHelper(this);
                Win32.SendMessage(wih.Handle, Win32.WM_NCLBUTTONDOWN, (int)Win32.HitTest.HTCAPTION, 0);
                return;
            }
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


            Task.Factory.StartNew(() => {
                Thread.Sleep(800);
                Dispatcher.Invoke(new Action(()=> {
                    ReShadowWindow();
                }));
            });
        }

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



        [Description("窗体阴影大小"), Category("DMSkin")]
        public int DMWindowShadowSize
        {
            get
            {
                return shadowWindow.DMWindowShadowSize;
            }

            set
            {
                shadowWindow.DMWindowShadowSize = value;
            }
        }

        [Description("窗体阴影颜色"), Category("DMSkin")]
        public Color DMWindowShadowColor
        {
            get
            {
                return shadowWindow.DMWindowShadowColor;
            }

            set
            {
                shadowWindow.DMWindowShadowColor = value;
            }
        }
        #endregion
    }
}


using System;
using System.ComponentModel;
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
    /// <summary>
    /// 单层窗体
    /// </summary>
    public partial class DMSkinSimpleWindow:Window
    {
        #region 初始化
        public DMSkinSimpleWindow()
        {
            InitializeWindowStyle();

            //绑定窗体操作函数
            SourceInitialized += MainWindow_SourceInitialized;
            StateChanged += MainWindow_StateChanged;
            MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
        }
        #endregion

        #region 窗口模式
        /// <summary>
        /// 慢慢显示的动画
        /// </summary>
        ///Storyboard StoryboardSlowShow;
        /// <summary>
        /// 慢慢隐藏的动画
        /// </summary>
        //Storyboard StoryboardSlowHide;

        /// <summary>
        /// 加载双层窗口的样式
        /// </summary>
        private void InitializeWindowStyle()
        {
            ResourceDictionary dic = new ResourceDictionary { Source = new Uri(@"/DMSkin.WPF;component/Styles/DMSkinSimpleWindow.xaml", UriKind.Relative) };
            Resources.MergedDictionaries.Add(dic);
            Style = (Style)dic["MainWindow"];

            //string packUriAnimation = @"/DMSkin.WPF;component/Themes/Animation.xaml";
            //ResourceDictionary dicAnimation = new ResourceDictionary { Source = new Uri(packUriAnimation, UriKind.Relative) };
            //Resources.MergedDictionaries.Add(dicAnimation);

            //StoryboardSlowShow = (Storyboard)FindResource("SlowShow");
            //StoryboardSlowHide = (Storyboard)FindResource("SlowHide");
        }
        #endregion

        #region XAML动画
        /// <summary>
        /// 执行最小化窗体
        /// </summary>
        private void StoryboardHide()
        {
            //启动最小化动画
            //StoryboardSlowHide.Begin(this);
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(300);
                Dispatcher.Invoke(new Action(() =>
                {
                    WindowState = WindowState.Minimized;
                }));
            });
        }

        /// <summary>
        /// 恢复窗体
        /// </summary>
        private void WindowRestore()
        {
            Opacity = 0;
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(50);
                Dispatcher.Invoke(new Action(() =>
                {
                    WindowState = WindowState.Normal;
                    Opacity = 1;
                }));
            });
        }
        #endregion

        #region 系统函数
        IntPtr Handle = IntPtr.Zero;
        HwndSource source;
        void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            Handle = new WindowInteropHelper(this).Handle;
            source = HwndSource.FromHwnd(Handle);
            if (source == null)
            { throw new Exception("Cannot get HwndSource instance."); }
            source.AddHook(new HwndSourceHook(this.WndProc));
        }
        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                //获取窗口的最大化最小化信息
                case (int)WindowMessages.WM_GETMINMAXINFO:
                        WmGetMinMaxInfo(hwnd, lParam);
                        handled = true;
                    break;
                //case Win32.WM_NCHITTEST:
                //     return WmNCHitTest(lParam, ref handled);
                case (int)WindowMessages.WM_SYSCOMMAND:
                    //if (wParam.ToInt32() == Win32.SC_MINIMIZE)//最小化消息
                    //{
                        //StoryboardHide();//执行最小化动画
                        //handled = true;
                    //}
                    if (wParam.ToInt32() == (int)SystemCommands.SC_RESTORE)//恢复消息
                    {
                        WindowRestore();//执行恢复动画
                        handled = true;
                    }
                    break;
                    //case Win32.WM_NCPAINT:
                    //    break;
                    //case Win32.WM_NCCALCSIZE:
                    //    handled = true;
                    //    break;
                    //case Win32.WM_NCUAHDRAWCAPTION:
                    //case Win32.WM_NCUAHDRAWFRAME:
                    //    handled = true;
                    //    break;
                    //case Win32.WM_NCACTIVATE:
                    //    if (wParam == (IntPtr)Win32.WM_TRUE)
                    //    {
                    //        handled = true;
                    //    }
                    //    break;
            }
            return IntPtr.Zero;
        }

        void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            // MINMAXINFO structure  
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Get handle for nearest monitor to this window  
            IntPtr hMonitor = NativeMethods.MonitorFromWindow(Handle, NativeConstants.MONITOR_DEFAULTTONEAREST);

            // Get monitor info   显示屏
            MONITORINFOEX monitorInfo = new MONITORINFOEX();

            monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);
            NativeMethods.GetMonitorInfo(new HandleRef(this, hMonitor), monitorInfo);

            // Convert working area  
            RECT workingArea = monitorInfo.rcWork;

            // Set the maximized size of the window  
            //ptMaxSize：  设置窗口最大化时的宽度、高度
            //mmi.ptMaxSize.x = (int)dpiIndependentSize.X;
            //mmi.ptMaxSize.y = (int)dpiIndependentSize.Y;

            // Set the position of the maximized window  
            mmi.ptMaxPosition.x = workingArea.left;
            mmi.ptMaxPosition.y = workingArea.top;

            // Get HwndSource  
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
                mmi.ptMaxSize.x = workingArea.right;
                mmi.ptMaxSize.y = workingArea.bottom;
            }

            // Set the minimum tracking size ptMinTrackSize： 设置窗口最小宽度、高度 
            mmi.ptMinTrackSize.x = (int)dpiIndenpendentTrackingSize.X;
            mmi.ptMinTrackSize.y = (int)dpiIndenpendentTrackingSize.Y;

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        Thickness MaxThickness = new Thickness(0);
        Thickness NormalThickness = new Thickness(20);
        
        //窗体最大化 隐藏阴影
        void MainWindow_StateChanged(object sender, EventArgs e)
        {
            //最大化
            if (WindowState == WindowState.Maximized)
            {
                BorderThickness = MaxThickness;
            }
            //默认大小
            if (WindowState == WindowState.Normal)
            {
                BorderThickness = NormalThickness;
            }
            //最小化-隐藏阴影
            if (WindowState == WindowState.Minimized)
            {
               
            }
        }
        //窗体移动
        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Grid || e.OriginalSource is Window || e.OriginalSource is Border)
            {
                NativeMethods.SendMessage(Handle,(int)WindowMessages.WM_NCLBUTTONDOWN, (int)HitTest.HTCAPTION, 0);
                return;
            }
        }

        #endregion

        #region 窗体属性
        [Description("全屏是否保留任务栏显示"), Category("DMSkin")]
        public bool DMFullScreen
        {
            get { return (bool)GetValue(DMFullScreenProperty); }
            set { SetValue(DMFullScreenProperty, value); }
        }
        public static readonly DependencyProperty DMFullScreenProperty =
            DependencyProperty.Register("DMFullScreen", typeof(bool), typeof(DMSkinSimpleWindow), new PropertyMetadata(false));

        [Description("窗体阴影大小"), Category("DMSkin")]
        public int DMWindowShadowSize
        {
            get { return (int)GetValue(DMWindowShadowSizeProperty); }
            set { SetValue(DMWindowShadowSizeProperty, value); }
        }
        public static readonly DependencyProperty DMWindowShadowSizeProperty =
            DependencyProperty.Register("DMWindowShadowSize", typeof(int), typeof(DMSkinSimpleWindow), new PropertyMetadata(10));

        [Description("窗体阴影颜色"), Category("DMSkin")]
        public Color DMWindowShadowColor
        {
            get { return (Color)GetValue(DMWindowShadowColorProperty); }
            set { SetValue(DMWindowShadowColorProperty, value); }
        }
        public static readonly DependencyProperty DMWindowShadowColorProperty =
            DependencyProperty.Register("DMWindowShadowColor", typeof(Color), typeof(DMSkinSimpleWindow), new PropertyMetadata(Color.FromArgb(255, 200, 200, 200)));

        [Description("窗体阴影透明度"), Category("DMSkin")]
        public double DMWindowShadowOpacity
        {
            get { return (double)GetValue(DMWindowShadowOpacityProperty); }
            set { SetValue(DMWindowShadowOpacityProperty, value); }
        }
        public static readonly DependencyProperty DMWindowShadowOpacityProperty =
            DependencyProperty.Register("DMWindowShadowOpacity", typeof(double), typeof(DMSkinSimpleWindow), new PropertyMetadata(1.0));
        #endregion
    }
}


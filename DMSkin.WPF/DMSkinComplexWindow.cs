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
using System.Windows.Threading;

namespace DMSkin.WPF
{
    /// <summary>
    /// 双层双体
    /// </summary>
    public partial class DMSkinComplexWindow : Window
    {
        #region 初始化
        public DMSkinComplexWindow()
        {
            InitializeWindowStyle();
            //绑定窗体操作函数
            SourceInitialized += MainWindow_SourceInitialized;
            StateChanged += MainWindow_StateChanged;
            IsVisibleChanged += MainWindow_IsVisibleChanged;
            MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            Closed += MainWindow_Closed;
            SizeChanged += MainWindow_SizeChanged;
            LocationChanged += MainWindow_LocationChanged;
        }
        #endregion

        #region 切换单双窗口模式
        /// <summary>
        /// 加载双层窗口的样式
        /// </summary>
        private void InitializeWindowStyle()
        {
            _shadowWindow = new ShadowWindow();
            Dispatcher.BeginInvoke(new Action<UIElement>(x =>
            {
                Thread.Sleep(70);
                _shadowWindow.Left = this.Left - 30;
                _shadowWindow.Top = this.Top - 30;
                ShadowWindowVisibility(true);//初始化
                Owner = _shadowWindow;//绑定阴影窗体
                Activate();
            }), DispatcherPriority.ApplicationIdle, this);
        }
        #endregion

        #region 阴影窗体
        /// <summary>
        /// 显示或者隐藏阴影
        /// </summary>
        private void ShadowWindowVisibility(bool show)
        {
            if (show)
            {
                _shadowWindow.Show();
            }
            else
            {
                _shadowWindow.Hide();
            }
        }

        /// <summary>
        /// 阴影窗体
        /// </summary>
        ShadowWindow _shadowWindow = null;
        /// <summary>
        /// 窗体关闭时 关闭阴影窗口
        /// </summary>
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if (_shadowWindow != null)
            {
                _shadowWindow.Close();
            }
        }

        /// <summary>
        /// 主窗体修改尺寸时 更新阴影窗口尺寸
        /// </summary>
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_shadowWindow != null)
            {
                _shadowWindow.Width = Width + 60;
                _shadowWindow.Height = Height + 60;
            }
        }

        /// <summary>
        /// 窗体移动坐标时 更新阴影窗口坐标
        /// </summary>
        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            if (_shadowWindow != null)
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

        private void WmNCCalcSize(IntPtr LParam)
        {
            // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/windows/windowreference/windowmessages/wm_nccalcsize.asp
            // http://groups.google.pl/groups?selm=OnRNaGfDEHA.1600%40tk2msftngp13.phx.gbl

            var r = (RECT)Marshal.PtrToStructure(LParam, typeof(RECT));
            //var max = MinMaxState == FormWindowState.Maximized;

            if (WindowState == WindowState.Maximized)
            {
                var x = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXSIZEFRAME);
                var y = NativeMethods.GetSystemMetrics(NativeConstants.SM_CYSIZEFRAME);
                var p = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXPADDEDBORDER);
                var w = x + p;
                var h = y + p;

                r.left += w;
                r.top += h;
                r.right -= w;
                r.bottom -= h;

                var appBarData = new APPBARDATA();
                appBarData.cbSize = Marshal.SizeOf(typeof(APPBARDATA));
                var autohide = (NativeMethods.SHAppBarMessage(NativeConstants.ABM_GETSTATE, ref appBarData) & NativeConstants.ABS_AUTOHIDE) != 0;
                if (autohide) r.bottom -= 1;

                Marshal.StructureToPtr(r, LParam, true);
            }
        }

        //四个坐标
        POINTAPI[] poin = new POINTAPI[4];
        //是否正在绘制边角
        bool ReWindowState = false;
        //重设主窗口裁剪区域
        public void ReWindow()
        {
            if (ReWindowState)//已经在绘制过程
            {
                return;
            }
            ReWindowState = true;
            Task.Factory.StartNew(() =>
            {
                //150毫秒延迟,并且150毫秒内不会重复触发多次
                Thread.Sleep(150);
                //让窗体不被裁剪
                poin[3].x = (int)ActualWidth;
                poin[1].y = (int)ActualHeight;
                poin[2].x = (int)ActualWidth;
                poin[2].y = (int)ActualHeight;
                IntPtr hRgn = NativeMethods.CreatePolygonRgn(ref poin[0], 4, 0);
                NativeMethods.SetWindowRgn(Handle, hRgn, true);
                ReWindowState = false;
                //Debug.WriteLine("触发时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            });
        }

        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                //WM_NCCALCSIZE
                case (int)WindowMessages.WM_NCCALCSIZE:
                    //WmNCCalcSize(lParam);
                    ReWindow();
                    handled = true;
                    break;
                ///重绘 非客户区
                case (int)WindowMessages.WM_NCPAINT:
                    // Here should all our painting occur, but...
                    handled = true;
                    return NativeConstants.TRUE;

                case (int)WindowMessages.WM_NCACTIVATE:
                    // ... WM_NCACTIVATE does some painting directly 
                    // without bothering with WM_NCPAINT ...
                    bool active = (wParam == NativeConstants.TRUE);
                    if (WindowState != WindowState.Minimized)
                    {
                        handled = true;
                        return NativeConstants.TRUE;
                    }
                    break;
                //------------------
                //if (wParam == (IntPtr)Win32.WM_TRUE)
                //{
                //    handled = true;
                //}

                case (int)WindowMessages.WM_NCLBUTTONDOWN:
                    if (wParam.ToInt32() == (int)HitTest.HTCLOSE ||
                        wParam.ToInt32() == (int)HitTest.HTMAXBUTTON ||
                        wParam.ToInt32() == (int)HitTest.HTMINBUTTON ||
                        wParam.ToInt32() == (int)HitTest.HTHELP)
                    {
                        NativeMethods.SendMessage(Handle, (int)WindowMessages.WM_NCPAINT, 0, 0);
                        handled = true;
                    }
                    break;
                case (int)WindowMessages.WM_NCUAHDRAWCAPTION:
                case (int)WindowMessages.WM_NCUAHDRAWFRAME:
                    handled = true;
                    break;
                    //获取窗口的最大化最小化信息
                    //case (int)WindowMessages.WM_GETMINMAXINFO:
                    //    WmGetMinMaxInfo(hwnd, lParam);
                    //    handled = true;
                    //    break;
                    //窗口拉伸 还有DPI BUG 
                    //case (int)WindowMessages.WM_NCHITTEST:
                    //    return WmNCHitTest(lParam, ref handled);
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
            if (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip)
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
                    return new IntPtr((int)HitTest.HTBOTTOMRIGHT);
                }
                else if (Math.Abs(this.ActualWidth + this.Left - this.mousePoint.X) <= 4 && Math.Abs(this.mousePoint.Y - this.Top) > 50)
                { // 右  
                    return new IntPtr((int)HitTest.HTRIGHT);
                }
                else if (Math.Abs(this.ActualHeight + this.Top - this.mousePoint.Y) <= 4)
                { // 底部  
                    return new IntPtr((int)HitTest.HTBOTTOM);
                }
            }
            handled = false;
            return IntPtr.Zero;
        }

        //最大最小化信息
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

            //if (DMFullScreen)
            //{
            //    Point dpiSize = matrix.Transform(new Point(
            //  SystemParameters.PrimaryScreenWidth,
            //  SystemParameters.PrimaryScreenHeight
            //  ));

            //    mmi.ptMaxSize.x = (int)dpiSize.X;
            //    mmi.ptMaxSize.y = (int)dpiSize.Y;
            //}
            //else
            //{
            //    mmi.ptMaxSize.x = workingArea.right;
            //    mmi.ptMaxSize.y = workingArea.bottom;
            //}

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
            //最大化
            if (WindowState == WindowState.Maximized)
            {
                ShadowWindowVisibility(false);
            }
            //默认大小
            if (WindowState == WindowState.Normal)
            {
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
                        //恢复-显示阴影
                        ShadowWindowVisibility(true);
                        shadowWindowState = false;
                        //激活当前窗口
                        Activate();
                        //Debug.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    }));
                });
            }
            //最小化-隐藏阴影
            if (WindowState == WindowState.Minimized)
            {
                ShadowWindowVisibility(false);
            }
        }

        /// <summary>
        /// 窗口第一次加载
        /// </summary>
        bool _theFirstTime = true;
        //窗体显示和隐藏
        void MainWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == false)
            {
                //最小化-隐藏阴影
                ShadowWindowVisibility(false);
            }
            else
            {
                //窗口初始化的时候 不显示 阴影 因为需要异步 激活 主窗口
                if (!_theFirstTime)
                {
                    ShadowWindowVisibility(true);
                }
                _theFirstTime = false;
            }
        }

        //窗体移动
        void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Grid || e.OriginalSource is Window || e.OriginalSource is Border)
            {
                NativeMethods.SendMessage(Handle, NativeConstants.WM_NCLBUTTONDOWN, (int)HitTest.HTCAPTION, 0);
                return;
            }
        }

        #endregion

        #region 窗体属性

        private int _DMWindowShadowSize = 10;
        [Description("窗体阴影大小"), Category("DMSkin")]
        public int DMWindowShadowSize
        {
            get
            {
                if (_shadowWindow != null)
                {
                    return _shadowWindow.DMWindowShadowSize;
                }
                else
                {
                    return _DMWindowShadowSize;
                }
            }

            set
            {
                if (_shadowWindow != null)
                {
                    _shadowWindow.DMWindowShadowSize = value;
                }
                else
                {
                    _DMWindowShadowSize = value;
                }
            }
        }

        private Color _DMWindowShadowColor = Color.FromArgb(255, 200, 200, 200);
        [Description("窗体阴影颜色"), Category("DMSkin")]
        public Color DMWindowShadowColor
        {
            get
            {
                if (_shadowWindow != null)
                {
                    return _shadowWindow.DMWindowShadowColor;
                }
                else
                {
                    return _DMWindowShadowColor;
                }
            }

            set
            {
                if (_shadowWindow != null)
                {
                    _shadowWindow.DMWindowShadowColor = value;
                }
                else
                {
                    _DMWindowShadowColor = value;
                }
            }
        }

        private Brush _DMWindowShadowBackColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        [Description("窗体阴影背景颜色"), Category("DMSkin")]
        public Brush DMWindowShadowBackColor
        {
            get
            {
                if (_shadowWindow != null)
                {
                    return _shadowWindow.DMWindowShadowBackColor;
                }
                else
                {
                    return _DMWindowShadowBackColor;
                }
            }

            set
            {
                if (_shadowWindow != null)
                {
                    _shadowWindow.DMWindowShadowBackColor = value;
                }
                else
                {
                    _DMWindowShadowBackColor = value;
                }
            }
        }
        #endregion
    }
}


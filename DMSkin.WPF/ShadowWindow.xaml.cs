using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace DMSkin.WPF
{
    public partial class ShadowWindow : Window, INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

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

        private Color _DMWindowShadowColor = Color.FromArgb(255, 200, 200, 200);
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


        private Brush _DMWindowShadowBackColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        [Description("窗体阴影背景颜色"), Category("DMSkin")]
        public Brush DMWindowShadowBackColor
        {
            get
            {
                return _DMWindowShadowBackColor;
            }

            set
            {
                _DMWindowShadowBackColor = value;
                OnPropertyChanged("DMWindowShadowBackColor");
            }
        }

        public ShadowWindow()
        {
            InitializeComponent();
            DataContext = this;
            SourceInitialized += MainWindow_SourceInitialized;
        }

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr Handle = new WindowInteropHelper(this).Handle;
            int exStyle = (int)NativeMethods.GetWindowLong(Handle, -20);
            exStyle = NativeConstants.WS_EX_TOOLWINDOW;
            NativeMethods.SetWindowLong(Handle, -20, (IntPtr)exStyle);
        }
    }
}

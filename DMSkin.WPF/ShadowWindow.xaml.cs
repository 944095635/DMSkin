using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DMSkin.WPF
{
    /// <summary>
    /// ShadowWindow.xaml 的交互逻辑
    /// </summary>
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


        private Brush _DMWindowShadowBackColor = new SolidColorBrush(Color.FromArgb(255,255,255,255));
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
            int exStyle = (int)Win32.GetWindowLong(Handle, -20);
            exStyle |= Win32.WS_EX_TOOLWINDOW;
            Win32.SetWindowLong(Handle, -20, (IntPtr)exStyle);
        }
    }
}

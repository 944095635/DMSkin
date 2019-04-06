using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace DMSkin
{
    public class DMSkinWindow : Window
    {
        #region 初始化
        public DMSkinWindow()
        {
            var chrome = new WindowChrome
            {
                GlassFrameThickness = new Thickness(1),
                ResizeBorderThickness = new Thickness(1)
            };
            WindowChrome.SetWindowChrome(this, chrome);

            //将标题栏高度绑定给Chrome
            BindingOperations.SetBinding(chrome, WindowChrome.CaptionHeightProperty,
                new Binding(CaptionHeightProperty.Name) { Source = this });

            #region 绑定系统Command
            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, (sender, e) =>
            {
                WindowState = WindowState.Minimized;
            }));

            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, (sender, e) =>
             {
                 WindowState = WindowState.Maximized;
             }));

            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, (sender, e) =>
            {
                WindowState = WindowState.Normal;
            }));

            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, (sender, e) =>
            {
                Close();
            }));
            #endregion
        } 
        #endregion

        #region 属性

        #region 系统按钮
        /// <summary>
        /// 系统按钮背景色
        /// </summary>
        public Brush SystemButtonBackground
        {
            get { return (Brush)GetValue(SystemButtonBackgroundProperty); }
            set { SetValue(SystemButtonBackgroundProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonBackgroundProperty =
            DependencyProperty.Register("SystemButtonBackground", typeof(Brush), typeof(DMSkinWindow), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))));
        /// <summary>
        /// 系统按钮大小
        /// </summary>
        public double SystemButtonSize
        {
            get { return (double)GetValue(SystemButtonSizeProperty); }
            set { SetValue(SystemButtonSizeProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonSizeProperty =
            DependencyProperty.Register("SystemButtonSize", typeof(double), typeof(DMSkinWindow), new PropertyMetadata(30.0));
        /// <summary>
        /// 标题栏前景色
        /// </summary>
        public Brush SystemButtonForeground
        {
            get { return (Brush)GetValue(SystemButtonForegroundProperty); }
            set { SetValue(SystemButtonForegroundProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonForegroundProperty =
            DependencyProperty.Register("SystemButtonForeground", typeof(Brush), typeof(DMSkinWindow), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(88, 88, 88))));

        /// <summary>
        /// 系统按钮悬浮背景色
        /// </summary>
        public Brush SystemButtonBackgroundHover
        {
            get { return (Brush)GetValue(SystemButtonBackgroundHoverProperty); }
            set { SetValue(SystemButtonBackgroundHoverProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonBackgroundHoverProperty =
            DependencyProperty.Register("SystemButtonBackgroundHover", typeof(Brush), typeof(DMSkinWindow), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(40, 255, 255, 255))));

        /// <summary>
        /// 关闭按钮悬浮背景色
        /// </summary>
        public Brush SystemCloseButtonBackgroundHover
        {
            get { return (Brush)GetValue(SystemCloseButtonBackgroundHoverProperty); }
            set { SetValue(SystemCloseButtonBackgroundHoverProperty, value); }
        }
        public static readonly DependencyProperty SystemCloseButtonBackgroundHoverProperty =
            DependencyProperty.Register("SystemCloseButtonBackgroundHover", typeof(Brush), typeof(DMSkinWindow), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 0, 0))));

        #endregion

        #region 窗口属性
        /// <summary>
        /// 标题栏高度
        /// </summary>
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }
        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(DMSkinWindow), new PropertyMetadata(30.0));

        /// <summary>
        /// 标题栏背景色
        /// </summary>
        public Brush CaptionBackground
        {
            get { return (Brush)GetValue(CaptionBackgroundProperty); }
            set { SetValue(CaptionBackgroundProperty, value); }
        }
        public static readonly DependencyProperty CaptionBackgroundProperty =
            DependencyProperty.Register("CaptionBackground", typeof(Brush), typeof(DMSkinWindow), new PropertyMetadata(default(Brush)));

        /// <summary>
        /// 标题栏的内容
        /// </summary>
        public UIElement TitleContent
        {
            get { return (UIElement)GetValue(TitleContentProperty); }
            set { SetValue(TitleContentProperty, value); }
        }
        public static readonly DependencyProperty TitleContentProperty =
            DependencyProperty.Register("TitleContent", typeof(UIElement), typeof(DMSkinWindow), new PropertyMetadata(default(UIElement)));

        /// <summary>
        /// 系统区域的内容
        /// </summary>
        public UIElement SystemContent
        {
            get { return (UIElement)GetValue(SystemContentProperty); }
            set { SetValue(SystemContentProperty, value); }
        }
        public static readonly DependencyProperty SystemContentProperty =
            DependencyProperty.Register("SystemContent", typeof(UIElement), typeof(DMSkinWindow), new PropertyMetadata(default(UIElement))); 
        #endregion

        #endregion
    }
}

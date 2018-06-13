using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace DMSkin.WPF.Controls
{
    public class DMSystemMaxButton : Button
    {
        Window targetWindow;
        public DMSystemMaxButton()
        {
            Click += delegate
            {
                if (targetWindow == null)
                {
                    targetWindow = Window.GetWindow(this);
                    targetWindow.StateChanged += delegate
                    {
                        if (targetWindow.WindowState == WindowState.Normal)
                        {
                            IsMax = false;
                        }
                        else if (targetWindow.WindowState == WindowState.Maximized)
                        {
                            IsMax = true;
                        }
                    };
                }
                if (targetWindow.WindowState == WindowState.Normal)
                {
                    targetWindow.WindowState = WindowState.Maximized;
                }
                else if (targetWindow.WindowState == WindowState.Maximized)
                {
                    targetWindow.WindowState = WindowState.Normal;
                }
            };
        }


        public bool IsMax
{
            get { return (bool)GetValue(IsMaxProperty); }
            set { SetValue(IsMaxProperty, value);
            }
        }

        public static readonly DependencyProperty IsMaxProperty =
            DependencyProperty.Register("IsMax", typeof(bool), typeof(DMSystemMaxButton), new PropertyMetadata(false));





        static DMSystemMaxButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMSystemMaxButton), new FrameworkPropertyMetadata(typeof(DMSystemMaxButton)));
        }

        private int _DMSystemButtonSize = 30;

        public int DMSystemButtonSize
        {
            get { return _DMSystemButtonSize; }
            set { _DMSystemButtonSize = value; }
        }

        private Brush _DMSystemButtonHoverColor = new SolidColorBrush(Color.FromArgb(50, 50, 50, 50));
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
            }
        }
    }
}

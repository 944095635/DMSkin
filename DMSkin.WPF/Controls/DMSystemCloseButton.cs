using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace DMSkin.WPF.Controls
{
    public class DMSystemCloseButton : Button
    {
        Window targetWindow;
        public DMSystemCloseButton()
        {
            Click += delegate{
                if (targetWindow==null)
                {
                    targetWindow = Window.GetWindow(this);
                }
                targetWindow.Close();
            };
        }

        static DMSystemCloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMSystemCloseButton), new FrameworkPropertyMetadata(typeof(DMSystemCloseButton)));
        }

        private int _DMSystemButtonSize = 30;
        [Description("窗体系统按钮大小"), Category("DMSkin")]
        public  int DMSystemButtonSize
        {
            get { return _DMSystemButtonSize; }
            set { _DMSystemButtonSize = value; }
        }


        private Brush _DMSystemButtonHoverColor = new SolidColorBrush(Color.FromArgb(255,255,0,0));

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

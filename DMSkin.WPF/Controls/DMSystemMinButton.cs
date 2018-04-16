using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMSystemMinButton : Button
    {

        Window targetWindow;
        public DMSystemMinButton()
        {
            Click += delegate
            {
                if (targetWindow == null)
                {
                    targetWindow = Window.GetWindow(this);
                }
                targetWindow.WindowState = WindowState.Minimized;
            };
        }


        static DMSystemMinButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMSystemMinButton), new FrameworkPropertyMetadata(typeof(DMSystemMinButton)));
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

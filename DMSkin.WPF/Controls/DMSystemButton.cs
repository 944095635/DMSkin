using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMSystemButton : Button
    {
        public DMSystemButton()
        {
        }

        [Description("窗体系统按钮大小"), Category("DMSkin")]
        public int DMSystemButtonSize
        {
            get { return (int)GetValue(DMSystemButtonSizeProperty); }
            set { SetValue(DMSystemButtonSizeProperty, value); }
        }
        public static readonly DependencyProperty DMSystemButtonSizeProperty =
            DependencyProperty.Register("DMSystemButtonSize", typeof(int), typeof(DMSystemButton), new PropertyMetadata(30));

        [Description("窗体系统按钮鼠标悬浮背景颜色"), Category("DMSkin")]
        public SolidColorBrush DMSystemButtonHoverColor
        {
            get { return (SolidColorBrush)GetValue(DMSystemButtonHoverColorProperty); }
            set { SetValue(DMSystemButtonHoverColorProperty, value); }
        }
        public static readonly DependencyProperty DMSystemButtonHoverColorProperty =
            DependencyProperty.Register("DMSystemButtonHoverColor", typeof(SolidColorBrush), typeof(DMSystemButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(50, 50, 50, 50))));



        [Description("窗体系统按钮颜色"), Category("DMSkin")]
        public SolidColorBrush DMSystemButtonForeground
        {
            get { return (SolidColorBrush)GetValue(DMSystemButtonForegroundProperty); }
            set { SetValue(DMSystemButtonForegroundProperty, value); }
        }
        public static readonly DependencyProperty DMSystemButtonForegroundProperty =
            DependencyProperty.Register("DMSystemButtonForeground", typeof(SolidColorBrush), typeof(DMSystemButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));



        [Description("窗体系统按钮鼠标悬按钮颜色"), Category("DMSkin")]
        public SolidColorBrush DMSystemButtonHoverForeground
        {
            get { return (SolidColorBrush)GetValue(DMSystemButtonHoverForegroundProperty); }
            set { SetValue(DMSystemButtonHoverForegroundProperty, value); }
        }
        public static readonly DependencyProperty DMSystemButtonHoverForegroundProperty =
            DependencyProperty.Register("DMSystemButtonHoverForeground", typeof(SolidColorBrush), typeof(DMSystemButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));


        /// <summary>
        /// 图标
        /// </summary>
        [Description("图标"), Category("DMSkin")]
        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(DMSystemButton), new PropertyMetadata(null));




        /// <summary>
        /// 图标宽度
        /// </summary>
        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }
        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(DMSystemButton), new PropertyMetadata(15.0));



        /// <summary>
        /// 图标高度
        /// </summary>
        public double IconHeight
        {
            get { return (double)GetValue(IconHeightProperty); }
            set { SetValue(IconHeightProperty, value); }
        }
        public static readonly DependencyProperty IconHeightProperty =
            DependencyProperty.Register("IconHeight", typeof(double), typeof(DMSystemButton), new PropertyMetadata(15.0));



    }
}

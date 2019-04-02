using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.Controls
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public class SystemButton : Button
    {
        public Brush SystemButtonBackgroundHover
        {
            get { return (Brush)GetValue(SystemButtonBackgroundHoverProperty); }
            set { SetValue(SystemButtonBackgroundHoverProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonBackgroundHoverProperty =
            DependencyProperty.Register("SystemButtonBackgroundHover", typeof(Brush), typeof(SystemButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(40, 255, 255, 255))));

    }
}

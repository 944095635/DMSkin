using System.Windows;
using System.Windows.Media;

namespace DMSkin.Controls
{
    /// <summary>
    /// 系统按钮
    /// </summary>
    public class Button : System.Windows.Controls.Button
    {
        /// <summary>
        /// 鼠标移上去的背景色
        /// </summary>
        public Brush SystemButtonBackgroundHover
        {
            get { return (Brush)GetValue(SystemButtonBackgroundHoverProperty); }
            set { SetValue(SystemButtonBackgroundHoverProperty, value); }
        }
        public static readonly DependencyProperty SystemButtonBackgroundHoverProperty =
            DependencyProperty.Register("SystemButtonBackgroundHover", typeof(Brush), typeof(Button), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(40, 255, 255, 255))));
    }
}

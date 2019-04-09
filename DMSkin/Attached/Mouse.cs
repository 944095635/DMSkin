using System.Windows;
using System.Windows.Media;

namespace DMSkin.Attached
{
    /// <summary>
    /// 鼠标的附加属性
    /// </summary>
    public class Mouse
    {
        #region 鼠标悬浮背景色
        public static Brush GetMouseOverBackColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverBackColorProperty);
        }

        public static void SetMouseOverBackColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverBackColorProperty, value);
        }

        /// <summary>
        /// 鼠标悬浮背景色
        /// </summary>
        public static readonly DependencyProperty MouseOverBackColorProperty =
            DependencyProperty.RegisterAttached("MouseOverBackColor", typeof(Brush), typeof(Mouse), new PropertyMetadata(default));
        #endregion

        #region 鼠标悬浮前景色
        public static Brush GetMouseOverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(MouseOverForegroundProperty);
        }

        public static void SetMouseOverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(MouseOverForegroundProperty, value);
        }

        /// <summary>
        /// 鼠标悬浮前景色
        /// </summary>
        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(Mouse), new PropertyMetadata(default)); 
        #endregion
    }
}

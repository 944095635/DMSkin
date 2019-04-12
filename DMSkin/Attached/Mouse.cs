using System.Windows;
using System.Windows.Media;

namespace DMSkin.Attached
{
    /// <summary>
    /// 鼠标的附加属性
    /// </summary>
    public class Mouse
    {
        #region 默认背景色
        public static Brush GetBackColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackColorProperty);
        }
        public static void SetBackColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackColorProperty, value);
        }
        /// <summary>
        /// 默认背景色
        /// </summary>
        public static readonly DependencyProperty BackColorProperty =
            DependencyProperty.RegisterAttached("BackColor", typeof(Brush), typeof(Mouse), new PropertyMetadata(default));
        #endregion

        #region 鼠标按下去背景色
        public static Brush GetPressedColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PressedColorProperty);
        }

        public static void SetPressedColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(PressedColorProperty, value);
        }

        /// <summary>
        /// 按下去的背景色
        /// </summary>
        public static readonly DependencyProperty PressedColorProperty =
            DependencyProperty.RegisterAttached("PressedColor", typeof(Brush), typeof(Mouse), new PropertyMetadata(default));
        #endregion

        #region 鼠标悬浮背景色
        public static Brush GetOverBackColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(OverBackColorProperty);
        }

        public static void SetOverBackColor(DependencyObject obj, Brush value)
        {
            obj.SetValue(OverBackColorProperty, value);
        }

        /// <summary>
        /// 鼠标悬浮背景色
        /// </summary>
        public static readonly DependencyProperty OverBackColorProperty =
            DependencyProperty.RegisterAttached("OverBackColor", typeof(Brush), typeof(Mouse), new PropertyMetadata(default));
        #endregion

        #region 鼠标悬浮前景色
        public static Brush GetOverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(OverForegroundProperty);
        }

        public static void SetOverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(OverForegroundProperty, value);
        }

        /// <summary>
        /// 鼠标悬浮前景色
        /// </summary>
        public static readonly DependencyProperty OverForegroundProperty =
            DependencyProperty.RegisterAttached("OverForeground", typeof(Brush), typeof(Mouse), new PropertyMetadata(default)); 
        #endregion
    }
}

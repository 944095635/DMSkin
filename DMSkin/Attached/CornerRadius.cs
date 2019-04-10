using System.Windows;

namespace DMSkin.Attached
{
    /// <summary>
    /// 附加属性 圆角值
    /// </summary>
    public class Corner
    {
        public static CornerRadius GetValue(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(CornerRadius), typeof(Corner), new PropertyMetadata(default));
    }
}

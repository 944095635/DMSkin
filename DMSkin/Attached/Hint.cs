using System.Windows;
using System.Windows.Media;

namespace DMSkin.Attached
{
    /// <summary>
    /// 水印
    /// </summary>
    public class Hint
    {
        #region 水印文字
        public static string GetHintText(DependencyObject obj)
        {
            return (string)obj.GetValue(HintTextProperty);
        }

        public static void SetHintText(DependencyObject obj, string value)
        {
            obj.SetValue(HintTextProperty, value);
        }

        //水印文字
        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.RegisterAttached("HintText", typeof(string), typeof(Hint), new PropertyMetadata(default));
        #endregion

        #region 水印颜色
        public static SolidColorBrush GetHintColor(DependencyObject obj)
        {
            return (SolidColorBrush)obj.GetValue(HintColorProperty);
        }

        public static void SetHintColor(DependencyObject obj, SolidColorBrush value)
        {
            obj.SetValue(HintColorProperty, value);
        }

        //水印颜色
        public static readonly DependencyProperty HintColorProperty =
            DependencyProperty.RegisterAttached("HintColor", typeof(SolidColorBrush), typeof(Hint), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 88, 88, 88)))); 
        #endregion
    }
}

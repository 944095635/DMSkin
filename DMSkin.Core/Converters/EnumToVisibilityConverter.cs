using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DMSkin.Core.Converters
{
    /// <summary>
    /// 将枚举值 转换为 是否显示
    /// </summary>
    public class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null||value.ToString()!=parameter.ToString())
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}

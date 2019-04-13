using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Converts = System.Convert;

namespace DMSkin.Core.Converters
{
    /// <summary>
    /// 比较数字大小 返回是否显示的转换器
    /// 例：当界面尺寸大于某个值的时候显示某些东西。
    /// </summary>
    public class CompareToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 转换函数
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double v1 = Converts.ToDouble(value);
                double v2 = Converts.ToDouble(parameter);
                if (v1 > v2)
                {
                    return Visibility.Visible;
                }
            }
            catch (Exception)
            {

            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}

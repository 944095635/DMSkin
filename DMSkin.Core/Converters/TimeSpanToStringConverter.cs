using System;
using System.Globalization;
using System.Windows.Data;

namespace DMSkin.Core.Converters
{
    /// <summary>
    /// 将TimeSpan 转换为 00:00
    /// </summary>
    [ValueConversion(typeof(DateTime?), typeof(string))]
    public class TimeSpanToStringConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (TimeSpan)value;
            return date.ToString(@"mm\:ss\ ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
}

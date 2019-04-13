using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DMSkin.Core.Converters
{
    /// <summary>
    /// 将秒数 转换 为时间显示 00:10:00
    /// </summary>
    public class SecondToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int offset)
            {
                var absOffset = Math.Abs(offset);
                var hour = ((absOffset / 3600)).ToString();
                var minute = ((absOffset - ((absOffset / 3600) * 3600)) / 60).ToString();
                var second = ((absOffset - ((absOffset / 3600) * 3600)) % 60).ToString();
                return $"{(offset >= 0 ? "" : "-")}{hour.PadLeft(2, '0')}:{minute.PadLeft(2, '0')}:{second.PadLeft(2, '0')}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var arr = (value as string)?.Split(':');
            if (arr?.Length == 2)
            {
                long hour, minute;
                if (Int64.TryParse(arr[0], out hour) && Int64.TryParse(arr[1], out minute))
                {
                    return hour * 3600 + minute * 60;
                }
            }
            return value;
        }
    }
}

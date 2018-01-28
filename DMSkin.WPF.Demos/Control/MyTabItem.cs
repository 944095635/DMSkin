using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DM_Studio.Control
{
    public class MyTabItem:TabItem
    {
        /// <summary>
        /// 密码提示符号依赖属性
        /// </summary>
        public static readonly DependencyProperty ThemeColorProperty = DependencyProperty.Register("ThemeColor", typeof(SolidColorBrush), typeof(MyTabItem), new PropertyMetadata());

        public SolidColorBrush ThemeColor
        {
            get { return (SolidColorBrush)GetValue(ThemeColorProperty); }
            set { SetValue(ThemeColorProperty, value); }
        }

    }
}

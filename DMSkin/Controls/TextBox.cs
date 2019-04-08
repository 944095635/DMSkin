using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.Controls
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        /// <summary>
        /// 水印
        /// </summary>
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(TextBox), new PropertyMetadata(default));

        /// <summary>
        /// 水印颜色
        /// </summary>
        public SolidColorBrush HintColor
        {
            get { return (SolidColorBrush)GetValue(HintColorProperty); }
            set { SetValue(HintColorProperty, value); }
        }
        public static readonly DependencyProperty HintColorProperty =
            DependencyProperty.Register("HintColor", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 88, 88, 88))));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMCheckBox : CheckBox
    {
        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }
        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(DMCheckBox), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255,255,255))));
    }
}

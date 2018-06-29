using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMRadioButton : RadioButton
    {
        public SolidColorBrush IconColor
        {
            get { return (SolidColorBrush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }
        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(SolidColorBrush), typeof(DMRadioButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255,255,255))));
    }
}

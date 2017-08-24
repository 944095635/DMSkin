using DMSkin.WPF.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    [ToolboxItem(true)]
    [Description("扁平化按钮"), Category("DMSkin")]
    public class DMButtonFlat : System.Windows.Controls.Button
    {

        public static readonly DependencyProperty DMButtonFlatBackgroundProperty =
        DependencyProperty.Register("DMButtonFlatBackground", typeof(SolidColorBrush), typeof(DMButtonFlat), new PropertyMetadata(DMColor.RedPrimary));
        [Browsable(true)]
        [Description("静止状态背景色"), Category("DMSkin")]
        public SolidColorBrush DMButtonFlatBackground
        {
            get { return (SolidColorBrush)GetValue(DMButtonFlatBackgroundProperty); }
            set { SetValue(DMButtonFlatBackgroundProperty, value); }
        }



        public static readonly DependencyProperty DMButtonFlatHoverForegroundProperty =
        DependencyProperty.Register("DMButtonFlatHoverForeground", typeof(SolidColorBrush), typeof(DMButtonFlat), new PropertyMetadata(DMColor.RedPrimary_Hover));
        [Browsable(true)]
        [Description("鼠标悬浮文字颜色"), Category("DMSkin")]
        public SolidColorBrush DMButtonFlatHoverForeground
        {
            get { return (SolidColorBrush)GetValue(DMButtonFlatHoverForegroundProperty); }
            set { SetValue(DMButtonFlatHoverForegroundProperty, value); }
        }



        public static readonly DependencyProperty DMButtonFlatHoverBackgroundProperty =
        DependencyProperty.Register("DMButtonFlatHoverBackground", typeof(SolidColorBrush), typeof(DMButtonFlat), new PropertyMetadata(DMColor.RedPrimary_Hover));
        [Browsable(true)]
        [Description("鼠标悬浮背景色"), Category("DMSkin")]
        public SolidColorBrush DMButtonFlatHoverBackground
        {
            get { return (SolidColorBrush)GetValue(DMButtonFlatHoverBackgroundProperty); }
            set { SetValue(DMButtonFlatHoverBackgroundProperty, value); }
        }


        public static readonly DependencyProperty DMButtonFlatPressedBackgroundProperty =
        DependencyProperty.Register("DMButtonFlatPressedBackground", typeof(SolidColorBrush), typeof(DMButtonFlat), new PropertyMetadata(DMColor.RedPrimary_Pressed));
        [Browsable(true)]
        [Description("鼠标按下背景色"), Category("DMSkin")]
        public SolidColorBrush DMButtonFlatPressedBackground
        {
            get { return (SolidColorBrush)GetValue(DMButtonFlatPressedBackgroundProperty); }
            set { SetValue(DMButtonFlatPressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty DMButtonFlatFontFamilyProperty =
        DependencyProperty.Register("DMButtonFlatFontFamily", typeof(FontFamily), typeof(DMButtonFlat), new PropertyMetadata(new FontFamily("微软雅黑")));
        [Browsable(true)]
        [Description("图标字体文件"), Category("DMSkin")]
        public FontFamily DMButtonFlatFontFamily
        {
            get { return (FontFamily)GetValue(DMButtonFlatFontFamilyProperty); }
            set { SetValue(DMButtonFlatFontFamilyProperty, value); }
        }


        public static readonly DependencyProperty DMButtonFontIconProperty =
        DependencyProperty.Register("DMButtonFontIcon", typeof(string), typeof(DMButtonFlat), new PropertyMetadata("ICON"));
        [Browsable(true)]
        [Description("图标字"), Category("DMSkin")]
        public string DMButtonFontIcon
        {
            get { return (string)GetValue(DMButtonFontIconProperty); }
            set { SetValue(DMButtonFontIconProperty, value); }
        }

        public static readonly DependencyProperty DMButtonFontIconSizeProperty =
        DependencyProperty.Register("DMButtonFontIconSize", typeof(int), typeof(DMButtonFlat), new PropertyMetadata(20));
        [Browsable(true)]
        [Description("图标字大小"), Category("DMSkin")]
        public int DMButtonFontIconSize
        {
            get { return (int)GetValue(DMButtonFontIconSizeProperty); }
            set { SetValue(DMButtonFontIconSizeProperty, value); }
        }

        public static readonly DependencyProperty DMButtonShowFontIconProperty =
        DependencyProperty.Register("DMButtonShowFontIcon", typeof(Visibility), typeof(DMButtonFlat), new PropertyMetadata(Visibility.Collapsed));
        [Browsable(true)]
        [Description("是否显示图标"), Category("DMSkin")]
        public Visibility DMButtonShowFontIcon
        {
            get { return (Visibility)GetValue(DMButtonShowFontIconProperty); }
            set { SetValue(DMButtonShowFontIconProperty, value); }
        }


        static DMButtonFlat()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMButtonFlat), new FrameworkPropertyMetadata(typeof(DMButtonFlat)));
        }
    }
}

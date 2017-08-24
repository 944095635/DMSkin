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
    [Description("下划线按钮"), Category("DMSkin")]
    public class DMButtonUnderline : System.Windows.Controls.Button
    {

        public static readonly DependencyProperty DMButtonUnderlineColorProperty =
        DependencyProperty.Register("DMButtonUnderlineColor", typeof(SolidColorBrush), typeof(DMButtonUnderline), new PropertyMetadata(DMColor.Primary));
        [Browsable(true)]
        [Description("下划线颜色"), Category("DMSkin")]
        public SolidColorBrush DMButtonUnderlineColor
        {
            get { return (SolidColorBrush)GetValue(DMButtonUnderlineColorProperty); }
            set { SetValue(DMButtonUnderlineColorProperty, value); }
        }

        public static readonly DependencyProperty DMButtonUnderlineHoverColorProperty =
        DependencyProperty.Register("DMButtonUnderlineHoverColor", typeof(SolidColorBrush), typeof(DMButtonUnderline), new PropertyMetadata(DMColor.Primary));
        [Browsable(true)]
        [Description("下划线鼠标悬浮颜色"), Category("DMSkin")]
        public SolidColorBrush DMButtonUnderlineHoverColor
        {
            get { return (SolidColorBrush)GetValue(DMButtonUnderlineHoverColorProperty); }
            set { SetValue(DMButtonUnderlineHoverColorProperty, value); }
        }

        public static readonly DependencyProperty DMButtonUnderlineWidthProperty =
        DependencyProperty.Register("DMButtonUnderlineWidth", typeof(double), typeof(DMButtonUnderline), new PropertyMetadata(100.0));
        [Browsable(true)]
        [Description("下划线宽度"), Category("DMSkin")]
        public double DMButtonUnderlineWidth
        {
            get { return (double)GetValue(DMButtonUnderlineWidthProperty); }
            set { SetValue(DMButtonUnderlineWidthProperty, value); }
        }


        public static readonly DependencyProperty DMButtonUnderlineHoverBackgroundProperty =
        DependencyProperty.Register("DMButtonUnderlineHoverBackground", typeof(SolidColorBrush), typeof(DMButtonUnderline), new PropertyMetadata(DMColor.Primary_Hover));
        [Browsable(true)]
        [Description("鼠标悬浮背景色"), Category("DMSkin")]
        public SolidColorBrush DMButtonUnderlineHoverBackground
        {
            get { return (SolidColorBrush)GetValue(DMButtonUnderlineHoverBackgroundProperty); }
            set { SetValue(DMButtonUnderlineHoverBackgroundProperty, value); }
        }


        public static readonly DependencyProperty DMButtonUnderlinePressedBackgroundProperty =
        DependencyProperty.Register("DMButtonUnderlinePressedBackground", typeof(SolidColorBrush), typeof(DMButtonUnderline), new PropertyMetadata(DMColor.Primary_Pressed));
        [Browsable(true)]
        [Description("鼠标按下背景色"), Category("DMSkin")]
        public SolidColorBrush DMButtonUnderlinePressedBackground
        {
            get { return (SolidColorBrush)GetValue(DMButtonUnderlinePressedBackgroundProperty); }
            set { SetValue(DMButtonUnderlinePressedBackgroundProperty, value); }
        }


        

        public static readonly DependencyProperty DMButtonUnderlineVisibilityProperty =
        DependencyProperty.Register("DMButtonUnderlineVisibility", typeof(Visibility), typeof(DMButtonUnderline), new PropertyMetadata(Visibility.Visible));
        [Browsable(true)]
        [Description("下划线的显示状态"), Category("DMSkin")]
        public Visibility DMButtonUnderlineVisibility
        {
            get { return (Visibility)GetValue(DMButtonUnderlineVisibilityProperty); }
            set { SetValue(DMButtonUnderlineVisibilityProperty, value); }
        }




        static DMButtonUnderline()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMButtonUnderline), new FrameworkPropertyMetadata(typeof(DMButtonUnderline)));
        }
    }
}

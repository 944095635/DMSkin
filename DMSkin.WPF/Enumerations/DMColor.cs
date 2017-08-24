using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace DMSkin.WPF.Enumerations
{
    public class DMColor
    {
        /// <summary>
        /// 主色调
        /// </summary>
        public static SolidColorBrush Primary =new SolidColorBrush(Color.FromRgb(33, 150, 243));//#2196F3

        public static SolidColorBrush RedPrimary = new SolidColorBrush(Color.FromRgb(241, 83, 82));//#FFF15352
        public static SolidColorBrush RedPrimary_Hover = new SolidColorBrush(Color.FromRgb(214, 75, 74));//#FFF15352
        public static SolidColorBrush RedPrimary_Pressed = new SolidColorBrush(Color.FromArgb(200, 214, 75, 74));//#FFF15352

        //public static SolidColorBrush Primary_Hover = new SolidColorBrush(Color.FromRgb(187, 222, 251));//#BBDEFB
        //public static SolidColorBrush Primary_Pressed =  new SolidColorBrush(Color.FromArgb(100,187, 222, 251));//#BBDEFB

        public static SolidColorBrush Primary_Hover = new SolidColorBrush(Color.FromArgb(100, 187, 222, 251));//#BBDEFB
        public static SolidColorBrush Primary_Pressed = new SolidColorBrush(Color.FromRgb(187, 222, 251));//#BBDEFB

        public Color Accent = Color.FromRgb(3, 169, 244);//#03A9F4

        /// <summary>
        /// 主要文字颜色
        /// </summary>
        public Color Primary_text = Color.FromRgb(33, 33, 33);//默认文字颜色

        public Color Secondary_text = Color.FromRgb(117, 117, 117);//#2196F3

        public Color Icons = Color.FromRgb(0, 0, 0);//黑色
        /// <summary>
        /// 分隔线
        /// </summary>
        public Color Divider = Color.FromRgb(189, 189, 189);//#BDBDBD
    }
}

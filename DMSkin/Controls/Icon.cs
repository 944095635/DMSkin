using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DMSkin.Controls
{
    public class Icon
    {
        #region 图标
        public static Geometry GetGeometry(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(GeometryProperty);
        }
        public static void SetGeometry(DependencyObject obj, Geometry value)
        {
            obj.SetValue(GeometryProperty, value);
        }
        public static readonly DependencyProperty GeometryProperty =
            DependencyProperty.RegisterAttached("Geometry", typeof(Geometry), typeof(Icon), new PropertyMetadata(default(Geometry)));
        #endregion



        #region 宽度
        public static double GetWidth(DependencyObject obj)
        {
            return (int)obj.GetValue(WidthProperty);
        }
        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached("Width", typeof(double), typeof(Icon), new PropertyMetadata(12.0));
        #endregion




        #region 高度
        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }
        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached("Height", typeof(double), typeof(Icon), new PropertyMetadata(12.0)); 
        #endregion


    }
}

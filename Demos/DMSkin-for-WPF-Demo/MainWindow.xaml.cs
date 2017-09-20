using DMSkin.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMSkin_for_WPF_Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow :DMSkinWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow2 l = new MainWindow2();
            l.Show();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            DMWindowShadowDragVisibility = (bool)cb1.IsChecked;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DMWindowShadowSize = (int)va.Value;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow2 w = new MainWindow2();
            w.Show();
        }
    }
}

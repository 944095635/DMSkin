using DMSkin.WPF.DEMO.Window;
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

namespace DMSkin.WPF.DEMO.Pages
{
    /// <summary>
    /// PageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PageWindow : UserControl
    {
        public PageWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow w = new ImageWindow();
            w.Show();
        }
    }
}

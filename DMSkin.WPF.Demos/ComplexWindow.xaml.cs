using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DMSkin.WPF.Demos
{
    public partial class ComplexWindow
    {
        public ComplexWindow()
        {
            InitializeComponent();
        }

        private void ButtonSkin_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Task.Factory.StartNew(()=> {
                Thread.Sleep(2000);
                Execute.OnUIThread(()=> 
                {
                    this.Show();
                });
            });
        }
    }
}

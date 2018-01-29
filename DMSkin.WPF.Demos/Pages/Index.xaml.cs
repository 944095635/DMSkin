using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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

namespace DM_Studio.Pages
{
    /// <summary>
    /// DashBoard.xaml 的交互逻辑
    /// </summary>
    public partial class Index : UserControl,INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        string _cpuUsage;
        public string CpuUsage
        {
            get { return _cpuUsage;
            }
            set {
                _cpuUsage = value;
                OnPropertyChanged("CpuUsage");
            }
        }


        public Index()
        {
            InitializeComponent();

            Values = new ChartValues<double> { 150, 375, 420, 500, 160, 140 };

            DataContext = this;
        }

        public ChartValues<double> Values { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/DMSkin.WPF.Demos/Moive/%E6%8B%A9%E5%A4%A9%E8%AE%B0%E6%89%8B%E6%B8%B8CG.mp4


            //Media.Source = new Uri("http://www.dmskin.com/a.mp4", UriKind.Absolute);

            if (File.Exists("a.mp4"))
            {
                Media.Source = new Uri("a.mp4", UriKind.Relative);
            }
            else
            {
               
                Task.Factory.StartNew(new Action(()=> {
                    using (WebClient wb = new WebClient())
                    {
                        wb.DownloadFile("http://www.dmskin.com/a.mp4", "a.mp4");
                    }
                    Dispatcher.Invoke(new Action(()=> 
                    {
                        Media.Source = new Uri("a.mp4", UriKind.Relative);
                    }));
                }));
            }
        }
    }
}

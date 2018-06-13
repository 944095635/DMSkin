using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace DMSkin.WPF.Demos.Pages
{
    /// <summary>
    /// DashBoard.xaml 的交互逻辑
    /// </summary>
    public partial class DashBoard : UserControl,INotifyPropertyChanged
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


        public DashBoard()
        {
            InitializeComponent();

            Values = new ChartValues<double> { 150, 375, 420, 500, 160, 140 };

            DataContext = this;
        }

        public ChartValues<double> Values { get; set; }

    }
}

using DMSkin.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace DMSKIN.WPF.DEMO1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : DMSkinWindow, INotifyPropertyChanged
    {

        #region 集合

        ObservableCollection<Video> _VideoList;
        public ObservableCollection<Video> VideoList
        {
            get
            {
                if (_VideoList == null)
                {
                    _VideoList = new ObservableCollection<Video>();
                }
                return _VideoList;
            }
            set
            {
                _VideoList = value;
                base.OnPropertyChanged("VideoList");
            }
        }

        #endregion

        public class Video
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Time { get; set; }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void DMSkinWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VideoList.Add(new Video() { Name = "发如雪"  ,Id="1",Time="3:45"  });
            VideoList.Add(new Video() { Name = "青花瓷", Id = "2", Time = "4:32" });
            VideoList.Add(new Video() { Name = "霍元甲", Id = "3", Time = "1:50" });
            VideoList.Add(new Video() { Name = "头文字D", Id = "4", Time = "2:11" });
            VideoList.Add(new Video() { Name = "爱情废材", Id = "5", Time = "3:20" });

            dgvAddList.ItemsSource = VideoList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

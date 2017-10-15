using DM_Studio.Models;
using DMSkin.WPF.Small;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
    /// Gallery.xaml 的交互逻辑
    /// </summary>
    public partial class Gallery : UserControl, INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Gallery()
        {
            InitializeComponent();
            DataContext = this;
            GalleryItemsControl.ItemsSource = ShowList;

            Loaded += UserControl_Loaded;
        }
        ObservableCollection<GalleryModel> _showList;
        public ObservableCollection<GalleryModel> ShowList
        {
            get
            {
                if (_showList == null)
                {
                    _showList = new ObservableCollection<GalleryModel>();
                }
                return _showList;
            }
            set
            {
                _showList = value;
                OnPropertyChanged("ShowList");
            }
        }
        int loadtimes = 0;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (loadtimes == 0)
            {
                HTTP.Get(ServicePath.GalleryAshx, new Action<string>((str) =>
                {
                    ObservableCollection<GalleryModel> list = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<GalleryModel>>(str);
                    Dispatcher.Invoke(new Action(() => {
                        foreach (var item in list)
                        {
                            HTTP.DownImage(item.Name, item.Image, new Action<string>((path) =>
                            {
                                item.Image = path;
                            }));
                            item.Image = "";
                            ShowList.Add(item);
                        }
                    }));
                }), new Action<Exception>((ex) => { }));
            }
            loadtimes++;
        }

       

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border b)
            {
                if (b.Tag is GalleryModel g)
                {
                    Process.Start(g.Image);
                }
            }
        }
    }
}


using DMSkin.WPF.Demos.Models;
using System;
using System.Collections.Generic;
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

namespace DMSkin.WPF.Demos.Pages
{
    /// <summary>
    /// Translate.xaml 的交互逻辑
    /// </summary>
    public partial class Translate : UserControl, INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        Dictionary<string, string> LanguageList = new Dictionary<string, string>();
        public Translate()
        {
            InitializeComponent();
            base.DataContext = this;
            FromLanguage = new LanguageModel()
            {
                Short = "zh",
                Text = "中文"
            };
            ToLanguage =new LanguageModel()
                {
                    Short = "en",
                    Text = "英语"
                };

            foreach (UIElement element in LanguageMainBox.Children)
            {
                if (element is RadioButton radio)
                {
                    radio.Click += RadioButtonClick;
                    LanguageList.Add(radio.Tag.ToString(), radio.Content.ToString());
                }
            }
            foreach (UIElement element in LanguageBox.Children)
            {
                if (element is RadioButton radio)
                {
                    radio.Click += RadioButtonClick;
                    LanguageList.Add(radio.Tag.ToString(),radio.Content.ToString());
                }
            }
        }

        private void RadioButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radio)
            {
                if (PopupLanguage.PlacementTarget == BtnFromLanguage)
                {
                    FromLanguage.Short = radio.Tag.ToString();
                    FromLanguage.Text = radio.Content.ToString();
                }
                else
                {
                    ToLanguage.Short = radio.Tag.ToString();
                    ToLanguage.Text = radio.Content.ToString();
                }
                PopupLanguage.IsOpen = false;
            }
        }

        LanguageModel _fromLanguage;
        /// <summary>
        /// 从语言
        /// </summary>
        public LanguageModel FromLanguage
        {
            get
            {
                return _fromLanguage;
            }
            set
            {
                _fromLanguage = value;
                OnPropertyChanged("FromLanguage");
            }
        }

        LanguageModel _toLanguage;
        /// <summary>
        /// 到语言
        /// </summary>
        public LanguageModel ToLanguage
        {
            get
            {
                return _toLanguage;
            }
            set
            {
                _toLanguage = value;
                OnPropertyChanged("ToLanguage");
            }
        }

        private void BtnFromLanguage_Click(object sender, RoutedEventArgs e)
        {
            PopupLanguage.PlacementTarget = BtnFromLanguage;
            BtnFromLanguage.IsChecked = true;
            BtnToLanguage.IsChecked = false;
            PopupLanguage.IsOpen = true;
            CheckLanguage.IsEnabled = true;
        }

        private void BtnToLanguage_Click(object sender, RoutedEventArgs e)
        {
            PopupLanguage.PlacementTarget = BtnToLanguage;
            BtnToLanguage.IsChecked = true;
            BtnFromLanguage.IsChecked = false;
            PopupLanguage.IsOpen = true;
            CheckLanguage.IsEnabled = false;
        }

        private void PopupFromLanguage_Closed(object sender, EventArgs e)
        {
            BtnFromLanguage.IsChecked = false;
            BtnToLanguage.IsChecked = false;
        }

        TranslateModel _TranslateModel;
        /// <summary>
        /// 到语言
        /// </summary>
        public TranslateModel TranslateModels
        {
            get
            {
                if (_TranslateModel == null)
                {
                    _TranslateModel = new TranslateModel();
                }
                return _TranslateModel;
            }
            set
            {
                _TranslateModel = value;
                OnPropertyChanged("TranslateModels");
            }
        }
        

        private void BtnTranslate_Click(object sender, RoutedEventArgs e)
        {
            API api = API.Init();
            api.Translate(TbKey.Text,FromLanguage.Short,ToLanguage.Short, new Action<TranslateModel>((mod) =>
             {
                 if (mod == null)
                 {
                     MessageBox.Show("翻译失败!");
                 }
                 base.Dispatcher.Invoke(new Action(() =>
                 {
                     TranslateModels = mod;
                     if (mod.Word_Name!=null)
                     {
                         Word_Panel.Visibility = Visibility.Visible;
                     }
                     else
                     {
                         Word_Panel.Visibility = Visibility.Collapsed;
                     }
                 }));
             }));
        }

        private void ButtonTurnLanguage_Click(object sender, RoutedEventArgs e)
        {
            LanguageModel temp = FromLanguage;
            FromLanguage  = ToLanguage;
            ToLanguage = temp;
        }

        private void TbKey_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbKey.Text=="")
            {
                TranslateModels = null;
                Word_Panel.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 播放当前的声音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReadFromText_Click(object sender, RoutedEventArgs e)
        {
            if (TbKey.Text!="")
            {
                ReadMediaElement.Source = new Uri("http://fanyi.baidu.com/gettts?lan="+ FromLanguage.Short + "&text="+TbKey.Text+"&spd=3&source=web", UriKind.Absolute);
                ReadMediaElement.Play();
            }
        }

        private void BtnReadToText_Click(object sender, RoutedEventArgs e)
        {
            if (TbResult.Text != "")
            {
                ReadMediaElement.Source = new Uri("http://fanyi.baidu.com/gettts?lan=" + ToLanguage.Short + "&text=" + TbResult.Text + "&spd=3&source=web", UriKind.Absolute);
                ReadMediaElement.Play();
            }
        }


        private void CheckLanguage_Click(object sender, RoutedEventArgs e)
        {
            API api = API.Init();
            api.Langdetect(TbKey.Text, new Action<LanguageModel>((mod) =>
            {
                FromLanguage = mod;
                
                foreach (var element in LanguageList)
                {
                    if (element.Key== FromLanguage.Short)
                    {
                        FromLanguage.Text = element.Value;
                    }
                }
            }));
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ReadMediaElement.Close();
        }
    }
}

using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace DMSkin.WPF.Demos.ViewModels
{
    public class StartWindowViewModel:ViewModelBase
    {
        public ICommand ComplexWindowCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    //UI线程执行
                    Execute.OnUIThread(() =>
                    {
                        new ComplexWindow().Show();
                    });
                });
            }
        }

        public ICommand SimpleWindowCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    new SimpleWindow().Show();
                });
            }
        }

        public ICommand Demo1WindowCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    new DemoWindow().Show();
                });
            }
        }


        private Color _DMWindowShadowColor;

        /// <summary>
        /// 窗体阴影颜色
        /// </summary>
        public Color DMWindowShadowColor
        {
            get { return _DMWindowShadowColor; }
            set
            {
                _DMWindowShadowColor = value;
                OnPropertyChanged("DMWindowShadowColor");
            }
        }

        public ICommand ChangeWindowCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    DMWindowShadowColor = (Color)ColorConverter.ConvertFromString(obj.ToString());
                });
            }
        }

        

    }
}

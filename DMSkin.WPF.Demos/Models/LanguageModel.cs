using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DM_Studio.Models
{
    public class LanguageModel : INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _text;

        /// <summary>
        /// 文字
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private string _short;

        /// <summary>
        /// 文字 简称
        /// </summary>
        public string Short
        {
            get
            {
                return _short;
            }
            set
            {
                _short = value;
                OnPropertyChanged("Short");
            }
        }
    }
}

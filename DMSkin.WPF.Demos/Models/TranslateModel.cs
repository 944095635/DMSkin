using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DM_Studio.Models
{
    public class TranslateModel : INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private List<Result> _data;

        private string _dataString { get; set; }
        public string DataString {
            get
            {
                return _dataString;
            }
            set
            {
                _dataString = value;
                OnPropertyChanged("DataString");
            }
        }
        /// <summary>
        /// 翻译结果
        /// </summary>
        public List<Result> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        private List<string> _word_means;
        public List<string> Word_Means
        {
            get
            {
                return _word_means;
            }
            set
            {
                _word_means = value;
                OnPropertyChanged("Word_Means");
            }
        }

        public string Symbol_Mp3 { get; internal set; }
        public string Word_Symbol { get; internal set; }
        public string Word_Name { get; internal set; }
    }

    public class Result
    {
        public string SRC;
        public string DST;
    }
}

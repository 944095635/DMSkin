using System.ComponentModel;

namespace DMSkin.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region 是否选中
        private bool isChecked;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        #endregion

        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region 是否正在加载
        private bool isLoad;

        /// <summary>
        /// 是否加载
        /// </summary>
        public bool IsLoad
        {
            get { return isLoad; }
            set
            {
                isLoad = value;
                OnPropertyChanged(nameof(IsLoad));
            }
        }
        #endregion

        #region 是否需要刷新
        private bool update;
        /// <summary>
        /// 刷新
        /// </summary>
        public bool Update
        {
            get { return update; }
            set
            {
                update = value;
                OnPropertyChanged(nameof(Update));
            }
        }
        #endregion
    }
}

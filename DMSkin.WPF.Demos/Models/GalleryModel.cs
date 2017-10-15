using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DM_Studio.Models
{
    public class GalleryModel : INotifyPropertyChanged
    {
        #region UI更新接口
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string _image;

        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _size;

        public string Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }
    }
}

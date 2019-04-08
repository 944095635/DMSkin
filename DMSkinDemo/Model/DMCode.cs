using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSkinDemo.Model
{
    public class DMCode:ViewModelBase
    {
        private int _CodeID;
        /// <summary>
        /// CodeID
        /// </summary>
        public int CodeID
        {
            get { return _CodeID; }
            set
            {
                _CodeID = value;
                OnPropertyChanged(nameof(CodeID));
            }
        }
        private string _CodeName;
        /// <summary>
        /// CodeName
        /// </summary>
        public string CodeName
        {
            get { return _CodeName; }
            set
            {
                _CodeName = value;
                OnPropertyChanged(nameof(CodeName));
            }
        }


    }
}

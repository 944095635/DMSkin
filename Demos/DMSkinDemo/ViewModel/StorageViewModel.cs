using DMSkin.Core;
using System.Windows.Input;

namespace DMSkinDemo.ViewModel
{
    public class StorageViewModel:ViewModelBase
    {
        private string saveText;
        /// <summary>
        /// 保存的文字
        /// </summary>
        public string SaveText
        {
            get
            {
                return saveText;
            }
            set
            {
                saveText = value;
                OnPropertyChanged(nameof(SaveText));
            }
        }


        /// <summary>
        /// 保存
        /// </summary>    
        public ICommand SaveCommand => new DelegateCommand(obj =>
        {
            Storage.SaveData("save",SaveText);
        });


        /// <summary>
        /// 清除
        /// </summary>    
        public ICommand ClearCommand => new DelegateCommand(obj =>
        {
            SaveText = "";
        });


        /// <summary>
        /// 读取
        /// </summary>    
        public ICommand ReadCommand => new DelegateCommand(obj =>
        {
            SaveText = Storage.GetData<string>("save");
        });

    }
}

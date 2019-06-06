using AduDesignDemo.Model;
using DMSkin.Core;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace AduDesignDemo.ViewModel
{
    public class AduDesignViewModel:ViewModelBase
    {
        #region 初始化
        public AduDesignViewModel()
        {
            UIExecute.Run(() =>
            {
                CodeList = new ObservableCollection<DMCode> {
                    new DMCode() {  CodeID=1,CodeName="DMSkin"}
                    ,new DMCode() {  CodeID=1,CodeName="AduSkin"}
                };
            });
        }
        #endregion

        #region 属性
        private ObservableCollection<DMCode> _CodeList;
        /// <summary>
        /// CodeList
        /// </summary>
        public ObservableCollection<DMCode> CodeList
        {
            get { return _CodeList; }
            set
            {
                _CodeList = value;
                OnPropertyChanged(nameof(CodeList));
            }
        }

        #endregion

        #region 命令
        /// <summary>
        /// 测试按钮
        /// </summary>    
        public ICommand TestCommand => new DelegateCommand(obj =>
        {
            MessageBox.Show("DMSkin");
        });


        /// <summary>
        /// XXX
        /// </summary>    
        public ICommand WinDemoCommand => new DelegateCommand(obj =>
        {
            //new WinDemo_Adu().Show();
        });

        #endregion
    }
}

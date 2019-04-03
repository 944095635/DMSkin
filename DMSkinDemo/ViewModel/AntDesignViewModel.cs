using DMSkin.Core.Common;
using DMSkin.Core.MVVM;
using System.Windows;
using System.Windows.Input;

namespace DMSkinDemo.ViewModel
{
    public class AntDesignViewModel
    {
        #region 初始化
        public AntDesignViewModel()
        {
            Execute.OnUIThread(() =>
            {

            }, false);
        } 
        #endregion

        #region 属性

        #endregion

        #region 命令
        /// <summary>
        /// 测试按钮
        /// </summary>    
        public ICommand TestCommand => new DelegateCommand(obj =>
        {
            MessageBox.Show("DMSkin");
        });
        #endregion
    }
}

using DMSkin.Core;
using DMSkinDemo.Model;
using DMSkinDemo.View;

namespace DMSkinDemo.ViewModel
{
    class MainViewModel:ViewModelBase
    {
        #region 属性
        private Menu selectMenu;
        /// <summary>
        /// 菜单-包含页面跳转逻辑
        /// </summary>
        public Menu SelectMenu
        {
            get
            {
                return selectMenu;
            }
            set
            {
                selectMenu = value;
                switch (value)
                {
                    case Menu.Broadcast:
                        Broadcast.PushBroadcast("Navigation", new PageBroadcast());
                        break;
                    case Menu.Colors:
                        Broadcast.PushBroadcast("Navigation", new PageColors());
                        break;
                    default:
                        break;
                }
                OnPropertyChanged(nameof(SelectMenu));
            }
        }
        #endregion
    }
}

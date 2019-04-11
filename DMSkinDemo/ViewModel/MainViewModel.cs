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
        /// 菜单
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
                    case Menu.AntDesign:
                        Broadcast.PushBroadcast("Navigation", new PageAntDesign());
                        break;
                    case Menu.AduDesign:
                        Broadcast.PushBroadcast("Navigation", new PageAduDesign());
                        break;
                    case Menu.CyanDesign:
                        Broadcast.PushBroadcast("Navigation", new PageCyanDesign());
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

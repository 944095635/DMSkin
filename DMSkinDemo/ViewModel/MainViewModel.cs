using DMSkin.Core;
using DMSkin.Core.MVVM;
using DMSkinDemo.Model;
using DMSkinDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
                    case Menu.AntDesign:
                        Broadcast.PushBroadcast(BroadcastType.Navigation, new PageAntDesign());
                        break;
                    case Menu.AduDesign:
                        Broadcast.PushBroadcast(BroadcastType.Navigation, new PageAduDesign());
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

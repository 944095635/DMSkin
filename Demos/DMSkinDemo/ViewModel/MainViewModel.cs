using DMSkin.Core;
using DMSkinDemo.Model;
using DMSkinDemo.View;
using System.Threading;
using System.Threading.Tasks;

namespace DMSkinDemo.ViewModel
{
    class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Task task = Task.Run(async ()=> 
            {
                while (tokenSource.IsCancellationRequested)
                {
                    await Task.Delay(1000);
                    System.Console.WriteLine("");
                }
            });

            //立即取消
            tokenSource.Cancel();

            //3秒之后取消
            tokenSource.CancelAfter(3000);
        }

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

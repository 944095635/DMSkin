using DMSkin.Core;
using DMSkinDemo.Model;
using DMSkinDemo.View;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkinDemo.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //CancellationTokenSource tokenSource = new CancellationTokenSource();

            //Task task = Task.Run(async () =>
            //{
            //    while (tokenSource.IsCancellationRequested)
            //    {
            //        await Task.Delay(1000);
            //        System.Console.WriteLine("");
            //    }
            //});

            ////立即取消
            //tokenSource.Cancel();

            ////3秒之后取消
            //tokenSource.CancelAfter(3000);
        }

        #region 命令
        /// <summary>
        /// 导航命令
        /// </summary>    
        public ICommand NavigationCommand => new DelegateCommand(obj =>
        {
            Menu menu = (Menu)Enum.Parse(typeof(Menu), obj.ToString());
            switch (menu)
            {
                case Menu.Null:
                    break;
                case Menu.Colors:
                    Broadcast.PushBroadcast("Navigation", new PageColors());
                    break;
                case Menu.Broadcast:
                    Broadcast.PushBroadcast("Navigation", new PageBroadcast());
                    break;
                case Menu.Storage:
                    Broadcast.PushBroadcast("Navigation", new PageStorage());
                    break;
            }
        });
        #endregion
    }
}

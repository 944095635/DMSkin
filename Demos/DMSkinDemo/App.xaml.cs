using DMSkin.Core;
using System.Windows;

namespace DMSkinDemo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //初始化UI调度器
            UIExecute.Initialize();

            //初始化广播器
            Broadcast.Initialize();

            //数据存储器
            Storage.Initialize();
        }
    }
}

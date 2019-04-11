using DMSkin.Core;
using System.Windows;

namespace DMSkinDemo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Execute.InitializeWithDispatcher();

            //初始化广播器
            Broadcast.Initialize();
        }
    }
}

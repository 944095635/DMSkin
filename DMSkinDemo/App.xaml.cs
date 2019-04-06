using DMSkin.Core;
using DMSkin.Core.Common;
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

            //注册广播通知
            Broadcast.RegisterBroadcast<string>(BroadcastType.Data,(data)=> 
            {
                System.Console.WriteLine($"收到广播:{data}");
            });

            //推送广播
            Broadcast.PushBroadcast(BroadcastType.Data, "Hello world");

            //卸载广播接收器
            Broadcast.UninstallBroadcast(BroadcastType.Data);
        }
}
}

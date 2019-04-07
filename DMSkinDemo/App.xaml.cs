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


            //#单项通知广播
            //注册广播通知
            Broadcast.RegisterBroadcast<string>(BroadcastType.Data,(data)=> 
            {
                System.Console.WriteLine($"收到广播:{data}");
            });

            //推送广播
            Broadcast.PushBroadcast(BroadcastType.Data, "Hello world");

            //卸载广播接收器
            Broadcast.UninstallBroadcast(BroadcastType.Data);


            //#发布广播 并且回收消息
            //注册广播接收器A，当前接收器的ID为10000
            Broadcast.RegisterBroadcast<string, int>(BroadcastType.Data, (data, callBack) =>
            {
                System.Console.WriteLine($"收到广播:{data}");
                //回发消息,数据类型为int
                callBack(10000);
            });

            //推送广播
            Broadcast.PushBroadcast<string,int>(BroadcastType.Data, "给我你们的ID?",(value)=> 
            {
                System.Console.WriteLine($"收到订阅者消息:{value}");
            });


            Broadcast.RegisterBroadcast<string, int>(BroadcastType.Data, (data) =>
            {
                System.Console.WriteLine($"收到广播:{data}");
                //回发消息,数据类型为int
                return 10001;
            });

            //推送广播
            int backId = Broadcast.PushBroadcast<string, int>(BroadcastType.Data, "给我你们的ID?");


            //卸载广播接收器
            Broadcast.UninstallBroadcast(BroadcastType.Data);
        }
    }
}

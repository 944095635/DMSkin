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

            MethodRegister.Initialize();
        }
}
}

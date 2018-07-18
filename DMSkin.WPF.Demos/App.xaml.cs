using DMSkin.WPF.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DMSkin.WPF.Demos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //初始化UI Dispatcher
            Execute.InitializeWithDispatcher();

            ShutdownMode = ShutdownMode.OnLastWindowClose;

            //启动窗口
            StartWindow st= new StartWindow();
            st.Show();

            //ComplexWindow c = new ComplexWindow();
            //c.Show();

            //SimpleMainWindow s = new SimpleMainWindow();
            //s.Show();

            //DemoWindow d = new DemoWindow();
            //d.Show();
        }
    }
}

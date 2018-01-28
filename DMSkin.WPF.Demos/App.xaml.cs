using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DM_Studio
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            DM_Studio.MainWindow m = new DM_Studio.MainWindow();
            DM_Studio.MainWindow2 m2 = new DM_Studio.MainWindow2();
            MainWindow = m2;
            m.Show();
            m2.Show();
        }
    }
}

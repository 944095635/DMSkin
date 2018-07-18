using System;
using System.Windows.Threading;

namespace DMSkin.WPF.API
{
    public static class Execute
    {
        private static Action<Action> executor = action => action();
        /// <summary>
        /// 初始化UI调度器
        /// </summary>
        public static void InitializeWithDispatcher()
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            executor = action =>
            {
                if (dispatcher.CheckAccess())
                    action();
                else dispatcher.BeginInvoke(action);
            };
        }
        /// <summary>
        /// UI线程中执行方法
        /// </summary>
        public static void OnUIThread(this Action action)
        {
            executor(action);
        }
    }
}
using System;
using System.Windows.Threading;

namespace DMSkin.Core
{
    /// <summary>
    /// UI执行器
    /// </summary>
    public static class UIExecute
    {
        /// <summary>
        /// UI线程中执行方法
        /// </summary>
        /// <param name="action">执行的方法</param>
        public static void Run(this Action action)
        {
            executor(action , false);
        }

        /// <summary>
        /// UI线程中异步执行方法
        /// </summary>
        /// <param name="action">执行的方法</param>
        public static void RunAsync(this Action action)
        {
            executor(action, true);
        }

        private static Action<Action, bool> executor = (action, async) => action();
        /// <summary>
        /// 初始化UI调度器
        /// </summary>
        public static void Initialize()
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            executor = (action, async) =>
            {
                //确认是当前的线程
                if (dispatcher.CheckAccess())
                {
                    action();
                }
                else
                {
                    //异步执行
                    if (async)
                    {
                        dispatcher.BeginInvoke(action);
                    }
                    else
                    {
                        dispatcher.Invoke(action);
                    }
                }
            };
        }
    }
}

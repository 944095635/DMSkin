using System;
using System.Windows.Threading;
namespace DMSkin.Core.Common
{
    public static class Execute
    {
        private static Action<Action, bool> executor = (action, async) => action();
        /// <summary>
        /// 初始化UI调度器
        /// </summary>
        public static void InitializeWithDispatcher()
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
        /// <summary>
        /// UI线程中执行方法
        /// </summary>
        /// <param name="action">执行的方法</param>
        /// <param name="async">是否异步执行</param>
        public static void OnUIThread(this Action action, bool async = false)
        {
            executor(action, async);
        }
    }
}

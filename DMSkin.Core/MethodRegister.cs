using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSkin.Core
{
    /// <summary>
    /// 函数-注册器
    /// </summary>
    public class MethodRegister
    {
        private static Dictionary<string, object> actions;

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            actions = new Dictionary<string, object>();
        }

        #region 注册方法
        /// <summary>
        /// 注册
        /// </summary>
        public static void Register<T>(string name, Action<T> action)
        {
            RegisterAction(name, action);
        }
        /// <summary>
        /// 注册
        /// </summary>
        public static void Register<T>(MethodType type, Action<T> action)
        {
            RegisterAction(type.ToString(), action);
        }

        private static void RegisterAction<T>(string name, Action<T> action)
        {
            if (!actions.ContainsKey(name))
            {
                actions.Add(name.ToString(), action);
            }
        }
        #endregion

        #region 执行方法
        /// <summary>
        /// 执行
        /// </summary>
        public static void Execute<T>(string name, T parameter = default)
        {
            ExecuteAction(name, parameter);
        }
        /// <summary>
        /// 执行
        /// </summary>
        public static void Execute<T>(MethodType type, T parameter = default)
        {
            ExecuteAction(type.ToString(), parameter);
        }
        private static void ExecuteAction<T>(string name, T parameter = default)
        {
            if (actions[name] is Action<T> action)
            {
                action.Invoke(parameter);
            }
        } 
        #endregion
    }

    public enum MethodType
    {
        /// <summary>
        /// 导航
        /// </summary>
        Navigation,
        /// <summary>
        /// 数据传递
        /// </summary>
        Data,
    }
}

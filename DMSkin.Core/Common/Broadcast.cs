using System;
using System.Collections.Generic;

namespace DMSkin.Core
{
    /// <summary>
    /// 广播器
    /// </summary>
    public class Broadcast
    {
        #region 初始化
        private static Dictionary<string, List<object>> Broadcasts;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            Broadcasts = new Dictionary<string, List<object>>();
        }

        /// <summary>
        /// 查找广播
        /// </summary>
        /// <param name="name">广播名</param>
        /// <returns>广播</returns>
        private static List<object> FindBroadcast(string name)
        {
            if (Broadcasts.ContainsKey(name))
            {
                return Broadcasts[name];
            }
            return default;
        }

        /// <summary>
        /// 注册广播
        /// </summary>
        private static bool Register(string name,object action)
        {
            var broadcast = FindBroadcast(name);
            if (broadcast != null)
            {
                if (!broadcast.Contains(action))//防止重复注册
                {
                    broadcast.Add(action);
                    return true;
                }
            }
            else//新增广播
            {
                Broadcasts.Add(name, new List<object>() { action });
                return true;
            }
            return false;
        }
        #endregion

        #region 注册广播
        /// <summary>
        /// 注册广播接收器-单向广播-无参
        /// </summary>
        /// <param name="name">广播名称</param>
        /// <param name="action">广播回调函数</param>
        public static bool RegisterBroadcast(string name, Action action)
        {
            return Register(name, action);
        }

        /// <summary>
        /// 注册广播接收器-单向广播
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="action">广播回调函数</param>
        public static bool RegisterBroadcast<T>(string name, Action<T> action)
        {
           return Register(name, action);
        }

        /// <summary>
        /// 注册广播接收器-广播回调
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">广播回调的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="action">广播的回调函数</param>
        public static bool RegisterBroadcast<T, T1>(string name, Action<T, Action<T1>> action)
        {
            return Register(name, action);
        }
        #endregion

        #region 推送广播
        /// <summary>
        /// 推送广播
        /// </summary>
        /// <param name="name">广播名称</param>
        public static void PushBroadcast(string name)
        {
            var broadcast = FindBroadcast(name);
            if (broadcast != null)
            {
                foreach (var item in broadcast)
                {
                    if (item is Action action)
                    {
                        action.Invoke();
                    }
                }
            }
        }

        /// <summary>
        /// 推送广播
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="parameter">广播传递的数据</param>
        public static void PushBroadcast<T>(string name, T parameter = default)
        {
            var broadcast = FindBroadcast(name);
            if (broadcast != null)
            {
                foreach (var item in broadcast)
                {
                    if (item is Action<T> action)
                    {
                        action.Invoke(parameter);
                    }
                }
            }
        }

        /// <summary>
        /// 推送广播-并执行回调
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">广播回调消息的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="parameter">广播传递的数据</param>
        /// <param name="callBack">广播订阅者的回传信息</param>
        public static void PushBroadcast<T, T1>(string name, T parameter = default, Action<T1> callBack = default)
        {
            var broadcast = FindBroadcast(name);
            if (broadcast != null)
            {
                foreach (var item in broadcast)
                {
                    if (item is Action<T, Action<T1>> action)
                    {
                        action.Invoke(parameter, callBack);
                    }
                }
            }
        }
        #endregion

        #region 卸载广播
        /// <summary>
        /// 卸载广播
        /// </summary>
        /// <param name="name">卸载的广播名称</param>
        public static void UninstallBroadcast(string name)
        {
            Broadcasts.Remove(name);
        }
        #endregion
    }
}

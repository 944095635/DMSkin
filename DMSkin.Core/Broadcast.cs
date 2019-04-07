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
        private static Dictionary<string, List<object>> broadcasts;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            broadcasts = new Dictionary<string, List<object>>();
        }
        #endregion

        #region 注册广播
        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T>(string name, Action<T> action)
        {
            if (broadcasts.ContainsKey(name))//已经被注册过的广播
            {
                if (!broadcasts[name].Contains(action))
                {
                    broadcasts[name].Add(action);
                }
            }
            else//新增一个广播
            {
                broadcasts.Add(name, new List<object>() { action });
            }
        }

        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <param name="name">广播类型</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T>(BroadcastType type, Action<T> action)
        {
            RegisterBroadcast(type.ToString(), action);
        }
        #endregion

        #region 注册广播-附带回调广播
        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册，并且对方可以呼叫你
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">回调传播的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T, T1>(string name, Action<T, Action<T1>> action)
        {
            if (broadcasts.ContainsKey(name))//已经被注册过的广播
            {
                if (!broadcasts[name].Contains(action))
                {
                    broadcasts[name].Add(action);
                }
            }
            else//新增一个广播
            {
                broadcasts.Add(name, new List<object>() { action });
            }
        }

        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册，并且对方可以呼叫你
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">回调传播的数据类型</typeparam>
        /// <param name="name">广播类型</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T, T1>(BroadcastType type, Action<T, Action<T1>> action)
        {
            RegisterBroadcast(type.ToString(), action);
        }
        #endregion

        #region 注册广播-附带返回值
        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册，并且对方可以呼叫你
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">回调传播的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T, T1>(string name, Func<T, T1> action)
        {
            if (broadcasts.ContainsKey(name))//已经被注册过的广播
            {
                if (!broadcasts[name].Contains(action))
                {
                    broadcasts[name].Add(action);
                }
            }
            else//新增一个广播
            {
                broadcasts.Add(name, new List<object>() { action });
            }
        }

        /// <summary>
        /// 注册一个广播接收器，你可以在多个地方注册，并且对方可以呼叫你
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">回调传播的数据类型</typeparam>
        /// <param name="name">广播类型</param>
        /// <param name="action">收到广播之后执行的函数</param>
        public static void RegisterBroadcast<T, T1>(BroadcastType type, Func<T,T1> action)
        {
            RegisterBroadcast(type.ToString(), action);
        }
        #endregion

        #region 推送广播
        /// <summary>
        /// 推送广播
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="parameter">广播传递的数据</param>
        public static void PushBroadcast<T>(string name, T parameter = default)
        {
            if (broadcasts.ContainsKey(name))
            {
                foreach (var item in broadcasts[name])
                {
                    if (item is Action<T> action)
                    {
                        action.Invoke(parameter);
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
        public static void PushBroadcast<T>(BroadcastType type, T parameter = default)
        {
            PushBroadcast(type.ToString(), parameter);
        }
        #endregion

        #region 推送广播-并执行回调
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
            if (broadcasts.ContainsKey(name))
            {
                foreach (var item in broadcasts[name])
                {
                    if (item is Action<T, Action<T1>> action)
                    {
                        action.Invoke(parameter, callBack);
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
        public static void PushBroadcast<T, T1>(BroadcastType type, T parameter = default, Action<T1> callBack = default)
        {
            PushBroadcast(type.ToString(), parameter, callBack);
        }
        #endregion

        #region 推送广播-并执行返回值
        /// <summary>
        /// 推送广播-并执行回调
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">广播回调消息的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="parameter">广播传递的数据</param>
        /// <param name="callBack">广播订阅者的回传信息</param>
        public static T1 PushBroadcast<T, T1>(string name, T parameter = default)
        {
            if (broadcasts.ContainsKey(name))
            {
                foreach (var item in broadcasts[name])
                {
                    if (item is Func<T, T1> action)
                    {
                       return action.Invoke(parameter);
                    }
                }
            }
            return default;
        }

        /// <summary>
        /// 推送广播-并执行回调
        /// </summary>
        /// <typeparam name="T">广播传递的数据类型</typeparam>
        /// <typeparam name="T1">广播回调消息的数据类型</typeparam>
        /// <param name="name">广播名称</param>
        /// <param name="parameter">广播传递的数据</param>
        public static T1 PushBroadcast<T, T1>(BroadcastType type, T parameter = default)
        {
            return PushBroadcast<T, T1>(type.ToString(), parameter);
        }
        #endregion

        #region 卸载广播
        /// <summary>
        /// 卸载广播
        /// </summary>
        /// <param name="name">卸载的广播名称</param>
        public static void UninstallBroadcast(string name)
        {
            broadcasts.Remove(name);
        }

        /// <summary>
        /// 卸载广播
        /// </summary>
        /// <param name="name">卸载的广播名称</param>
        public static void UninstallBroadcast(BroadcastType type)
        {
            broadcasts.Remove(type.ToString());
        }
        #endregion
    }

    /// <summary>
    /// 广播消息类型（内置几个基础的广播）
    /// </summary>
    public enum BroadcastType
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

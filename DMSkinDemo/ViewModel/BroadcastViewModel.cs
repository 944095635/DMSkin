using DMSkin.Core;
using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkinDemo.ViewModel
{
    public class BroadcastViewModel : ViewModelBase
    {
        public BroadcastViewModel()
        {

        }

        #region 属性
        private ObservableCollection<string> message;
        /// <summary>
        /// 消息列表
        /// </summary>
        public ObservableCollection<string> Message
        {
            get
            {
                if (message == null)
                {
                    message = new ObservableCollection<string>();
                }
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        #endregion

        #region 命令

        /// <summary>
        /// 注册单向广播接收器
        /// </summary>    
        public ICommand RegisterBroadcast1 => new DelegateCommand(obj =>
        {
            bool state = Broadcast.RegisterBroadcast<string>("test1", (e) =>
             {
                 Message.Add($"我是注册1号,接收到来单向广播的消息:{e}");
             });
            Message.Add($"注册单向广播接收器1:{state}");
        });

        /// <summary>
        /// 注册单向广播接收器
        /// </summary>    
        public ICommand RegisterBroadcast1_1 => new DelegateCommand(obj =>
        {
            bool state = Broadcast.RegisterBroadcast<string>("test1", (e) =>
            {
                Message.Add($"我是注册2号,接收到来单向广播的消息:{e}");
            });
            Message.Add($"注册单向广播接收器2:{state}");
        });

        /// <summary>
        /// 推送单向广播接收器
        /// </summary>    
        public ICommand PushBroadcast1 => new DelegateCommand(obj =>
        {
            Broadcast.PushBroadcast("test1", "你好，这是一条单向通知广播。");
        });


        /// <summary>
        /// 注册回调广播
        /// </summary>    
        public ICommand RegisterBroadcast2 => new DelegateCommand(obj =>
        {
            Broadcast.RegisterBroadcast<string,string>("test1", (e,s) =>
            {
                Message.Add($"接收到来回调广播的消息:{e}");
                s.Invoke("我是1号注册,我收到广播了。");
            });
            Message.Add("注册回调广播接收器成功！");
        });

        /// <summary>
        /// 注册回调广播
        /// </summary>    
        public ICommand RegisterBroadcast2_1 => new DelegateCommand(obj =>
        {
            Broadcast.RegisterBroadcast<string, string>("test1", (e, s) =>
            {
                Message.Add($"接收到来回调广播的消息:{e}");
                s.Invoke("我是2号注册,我收到广播了。");
            });
            Message.Add("注册回调广播接收器成功！");
        });
        

        /// <summary>
        /// 推送广播回调
        /// </summary>    
        public ICommand PushBroadcast2 => new DelegateCommand(obj =>
        {
            Broadcast.PushBroadcast<string,string>("test1", "你好，这是一条回调通知广播。",(e)=>
            {
                Message.Add($"接收到回调信息:{e}");
            });
        });

        /// <summary>
        /// 注册返回广播
        /// </summary>    
        public ICommand RegisterBroadcast3 => new DelegateCommand(obj =>
        {
            Broadcast.RegisterBroadcast<string, string>("test1", (e) =>
            {
                Message.Add($"接收到来直连广播的消息:{e}");
                return "我收到广播了.";
            });
            Message.Add("注册直连广播接收器成功！");
        });

        /// <summary>
        /// 推送返回回调
        /// </summary>    
        public ICommand PushBroadcast3 => new DelegateCommand(obj =>
        {
            Message.Add($"推送广播并接受返回消息:{Broadcast.PushBroadcast<string, string>("test1", "你好，这是一条直连通知广播。")}");
        });



        /// <summary>
        /// 卸载广播
        /// </summary>    
        public ICommand UninstallBroadcast => new DelegateCommand(obj =>
        {
            Broadcast.UninstallBroadcast("test1");
            Message.Add("卸载全部广播！");
        });

        #endregion
    }
}

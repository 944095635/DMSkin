using System;

namespace DMSkin.Core.WIN32
{
    public class DesktopAPI
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialization(IntPtr Handle)
        {
            //获取所有屏幕
            //Screen[] allScreens = Screen.AllScreens;
            //所有屏幕
            //int count = allScreens.Length;
            //拿到程序管理器句柄
            IntPtr progman = NativeMethods.FindWindow("Progman", null);
            NativeMethods.SendMessageTimeout(progman, (uint)0x052C, new UIntPtr(0), IntPtr.Zero, SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out UIntPtr result);
            NativeMethods.SetParent(Handle, FindWorkerWPtr());
        }

        /// <summary>
        /// 查找工作区域
        /// </summary>
        public static IntPtr FindWorkerWPtr()
        {
            IntPtr workerw = IntPtr.Zero;
            IntPtr def = IntPtr.Zero;
            IntPtr intPtr = NativeMethods.FindWindow("Progman", null);
            //http://blog.csdn.net/whatday/article/details/8714573
            IntPtr zeroResult = IntPtr.Zero;
            //遍历窗体
            NativeMethods.EnumWindows(delegate (IntPtr handle, IntPtr param)
            {
                //TODO 双屏问题
                //参考：http://blog.csdn.net/zhoufoxcn/article/details/2515753，获取墙纸的窗体下面的一个窗体句柄
                if ((def = NativeMethods.FindWindowEx(handle, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero)) != IntPtr.Zero)
                {
                    workerw = NativeMethods.FindWindowEx(IntPtr.Zero, handle, "WorkerW", IntPtr.Zero);
                    //得到
                    Console.Write("workerw:" + workerw + "\n");
                    NativeMethods.ShowWindow(workerw, 0);
                }
                return true;
            }, IntPtr.Zero);

            return intPtr;
        }
    }
}

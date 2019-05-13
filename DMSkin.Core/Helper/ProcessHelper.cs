using System.Diagnostics;

namespace DMSkin.Core.Helper
{
    public class ProcessHelper
    {
        #region 判断程序是否在运行
        /// <summary>
        /// 判断程序是否在运行
        /// </summary>
        public static bool GetRunStateByName(string AppName)
        {
            Process[] process = Process.GetProcessesByName(AppName);
            if (process.Length > 1)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

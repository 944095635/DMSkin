using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DMSkin.Core.Helper
{
    /// <summary>
    /// INI文件读写类
    /// </summary>
    public class INIHelper
    {
        #region 初始化
        private static string Path;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize(string path)
        {
            Path = path;
        }
        #endregion

        #region DLL申明
        //声明API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region 写入
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public static void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
        #endregion

        #region 读取
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public static string Read(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(Section, Key, "", temp, 500, Path);
            return temp.ToString();
        }
        #endregion

        #region 读取泛型
        /// <summary>
        /// 读取泛型INI数据
        /// </summary>
        public static T Read<T>(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, "", temp, 1024, Path);
            try
            {
                string tempstr = temp.ToString();
                if (!string.IsNullOrWhiteSpace(tempstr))
                {
                    return (T)Convert.ChangeType(tempstr, typeof(T));
                }
            }
            catch (Exception)
            {
            }
            return default;
        } 
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSkin.WPF
{
    public enum WindowMode
    {
        /// <summary>
        /// 自动
        /// </summary>
        Auto,
        /// <summary>
        /// 单窗口不支持GDI+
        /// </summary>
        OneWindow,
        /// <summary>
        /// 双窗口不支持WIN7
        /// </summary>
        TwoWindow
    }
}

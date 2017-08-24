using DMSkin.WPF.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    [ToolboxItem(true)]
    [Description("阴影边框"), Category("DMSkin")]
    public class DMShadowBorder : System.Windows.Controls.UserControl
    {

        
        static DMShadowBorder()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DMShadowBorder), new FrameworkPropertyMetadata(typeof(DMShadowBorder)));
        }
    }
}

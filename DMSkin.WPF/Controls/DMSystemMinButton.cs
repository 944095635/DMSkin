using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMSystemMinButton : DMSystemButton
    {
        Window targetWindow;
        public DMSystemMinButton()
        {
            Click += delegate
            {
                if (targetWindow == null)
                {
                    targetWindow = Window.GetWindow(this);
                }
                targetWindow.WindowState = WindowState.Minimized;
            };
        }
    }
}

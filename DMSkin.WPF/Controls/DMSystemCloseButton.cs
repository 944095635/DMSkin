using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DMSkin.WPF.Controls
{
    public class DMSystemCloseButton : DMSystemButton
    {
        Window targetWindow;
        public DMSystemCloseButton()
        {
            DMSystemButtonHoverColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

            Click += delegate{
                if (targetWindow==null)
                {
                    targetWindow = Window.GetWindow(this);
                }
                targetWindow.Close();
            };
        }
    }
}

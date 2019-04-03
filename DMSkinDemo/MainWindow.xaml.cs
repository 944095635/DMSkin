using DMSkin.Core;
using System.Windows.Controls;

namespace DMSkinDemo
{
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            //注册导航事件-在需要导航页面的时候可以调用
            MethodRegister.Register<Page>(MethodType.Navigation, (obj)=> 
            {
                Frame.Navigate(obj);
            });
        }
    }
}

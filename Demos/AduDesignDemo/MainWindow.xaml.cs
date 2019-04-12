using AduDesignDemo.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace AduDesignDemo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DMSkinWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DMCode> CodeList = new ObservableCollection<DMCode> {
                    new DMCode() {  CodeID=1,CodeName="AduSkin",Phone="1870921****",Email="1840921****@qq.com",Info="追求极致，永臻完美"}
                    ,new DMCode() {  CodeID=1,CodeName="DMSkin",Phone="1840921****",Email="1840921****@qq.com",Info="梦机器"}
                    ,new DMCode() {  CodeID=1,CodeName="AduSkin",Phone="1870921****",Email="1840921****@qq.com",Info="追求极致，永臻完美"}
                    ,new DMCode() {  CodeID=1,CodeName="DMSkin",Phone="1840921****",Email="1840921****@qq.com",Info="梦机器"}
                     ,new DMCode() {  CodeID=1,CodeName="AduSkin",Phone="1870921****",Email="1840921****@qq.com",Info="追求极致，永臻完美"}
                    ,new DMCode() {  CodeID=1,CodeName="DMSkin",Phone="1840921****",Email="1840921****@qq.com",Info="梦机器"}
                    ,new DMCode() {  CodeID=1,CodeName="AduSkin",Phone="1870921****",Email="1840921****@qq.com",Info="追求极致，永臻完美"}
                    ,new DMCode() {  CodeID=1,CodeName="AduSkin",Phone="1870921****",Email="1840921****@qq.com",Info="追求极致，永臻完美"}
                };
            AduDataGrids.ItemsSource = CodeList;
        }
    }
}

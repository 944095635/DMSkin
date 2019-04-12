using DMSkin.Core;

namespace AduDesignDemo.Model
{
    public class DMCode:ViewModelBase
    {
        public bool IsChecked { get; set; }
        public string CodeType { get; set; }
        public int CodeID { get; set; }
        public string CodeName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
    }
}

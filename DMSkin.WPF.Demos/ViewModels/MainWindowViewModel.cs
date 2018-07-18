using DMSkin.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DM_Studio.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand F1Command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    MessageBox.Show("Test");
                });
            }
        }

    }
}

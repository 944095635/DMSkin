using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DMSkin.WPF.Demos.ViewModels
{
    public class PageAboutViewModel
    {
        public ICommand OpenLinkCommand
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    if (obj is string url)
                    {
                        Process.Start(url);
                    }
                });
            }
        }
    }
}

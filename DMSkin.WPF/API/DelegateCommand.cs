using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DMSkin.WPF
{
    public class DelegateCommand : ICommand
    {
        private Action<object> executeAction;
        private Func<object, bool> canExecuteFunc;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        { }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
            {
                return;
            }
            executeAction = execute;
            canExecuteFunc = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteFunc == null)
            {
                return true;
            }
            return canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (executeAction == null)
            {
                return;
            }
            executeAction(parameter);
        }
    }
}

using System;
using System.Windows.Input;

namespace DMSkin.Core.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> executeAction;
        private readonly Func<object, bool> canExecuteFunc;
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
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace UserBot.Controllers
{
    public class CommandController : ICommand
    {
        public Action<object> execute;
        public Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged 
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public CommandController(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}

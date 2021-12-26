using System;
using System.Windows.Input;

namespace DashboardMVVM
{
    /// <summary>
    /// RelayCommand allows you to inject the command's logic via delegates passed into its constructor. 
    /// This method enables VeiwModel classes to implement commands in a concise manner.
    /// </summary>


    public class RelayCommands : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommands(Action<object> execute)
        {
            _execute = execute;
            _canExecute = null;
        }

        public RelayCommands(Action<object> execute, Func<object,bool> canExecute)
        {
            _execute=execute;
            _canExecute = canExecute;

        }


        /// <summary>
        /// CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the WPF commanding infrastructure asks all RelayCommands objects if they can execute
        /// whenever it asks the built-in commands.
        /// </summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested+=value; }
            remove { CommandManager.RequerySuggested-=value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute ==null || CanExecute(parameter);
            //_canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

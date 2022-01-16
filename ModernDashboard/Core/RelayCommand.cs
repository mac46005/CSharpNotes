using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernDashboard.Core
{
    /// <summary>
    /// RelayCommand allows you to inject the commands logic via delegates passed into its contructor.
    /// This method enables the ViewModel class to implement commands in a concise manner.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;


        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public RelayCommand(Action<object> execute,Func<object,bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        /// CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the WPF commanding infrastructure asks all RelayObjects if they can be executed whenever
        /// it asks the builtin commands.
        /// </summary>

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            Execute(parameter);
        }
    }
}

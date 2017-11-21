using System;
using System.Windows.Input;

namespace Poke
{
    public class DelegateCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Func<object, bool> _canExecute;
        
        public DelegateCommand(Action<object> OnExecute, Func<object, bool> OnCanExecute)
        {
            _execute = OnExecute;
            _canExecute = OnCanExecute;
        }

        public bool CanExecute(object Parameter) => _canExecute?.Invoke(Parameter) ?? true;

        public void Execute(object Parameter) => _execute?.Invoke(Parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
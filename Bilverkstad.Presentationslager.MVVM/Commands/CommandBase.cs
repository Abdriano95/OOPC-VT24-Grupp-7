using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.Commands
{
    public abstract class CommandBase : ICommand
    {      
            public abstract bool CanExecute(object? parameter);
            public abstract void Execute(object? parameter);

            private event EventHandler? canExecuteChangedInternal;

            public event EventHandler? CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                    this.canExecuteChangedInternal += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                    this.canExecuteChangedInternal -= value;
                }
            }

            public void RaiseCanExecuteChanged()
            {
                canExecuteChangedInternal?.Invoke(this, EventArgs.Empty);
            }       
    }
}

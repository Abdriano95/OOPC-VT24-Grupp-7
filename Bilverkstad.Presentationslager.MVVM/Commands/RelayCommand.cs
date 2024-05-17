namespace Bilverkstad.Presentationslager.MVVM.Commands
{
    public class RelayCommand : CommandBase
    {
        private readonly Action _execute = null!;
        private readonly Func<bool> _canExecute = null!;
        public RelayCommand() { }
        public RelayCommand(Action execute) : this(execute, null!) { }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public override void Execute(object? parameter) { _execute(); }
        public override bool CanExecute(object? parameter) =>
        _canExecute == null || _canExecute();
    }

    public class RelayCommand<T> : RelayCommand
    {
        private readonly Action<T?> _execute;
        private readonly Func<T?, bool> _canExecute;

        public RelayCommand(Action<T?> execute, Func<T?, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public override void Execute(object? parameter)
        {
            //Safe cast
            T? typedParameter = default(T);
            if (parameter is T)
            {
                typedParameter = (T)parameter;
            }
            _execute(typedParameter);
        }

        public override bool CanExecute(object? parameter)
        {
            // Safe cast
            T? typedParameter = default(T);
            if (parameter is T)
            {
                typedParameter = (T)parameter;
            }
            return _canExecute == null || _canExecute(typedParameter);
        }
    }
}

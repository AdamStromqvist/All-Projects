using System;
using System.Windows.Input;


public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

//Initializes a new instance of the relaycommand class that can always execute
    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
        CommandManager.RequerySuggested += OnRequerySuggested;
    }
//Handles the internal logic whenever CommandManager suggests that the command rethinks its availability.
    private void OnRequerySuggested(object sender, EventArgs e)
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
//Occurs when changes happens that affect whether or not the command shouldbe executed
    public event EventHandler CanExecuteChanged;
//Determines whether the command can execute in its current state.
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute();
    }

    public void Execute(object parameter)
    {
        _execute();
    }

}

public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool> _canExecute;

    public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute ?? ((_) => true); // Always return true if no custom logic is provided
        CommandManager.RequerySuggested += OnRequerySuggested;
    }
//Handles the internal logic whenever CommandManager suggests that the command reevaluates whether it can execute.
    private void OnRequerySuggested(object sender, EventArgs e)
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler CanExecuteChanged;
//Determines whether the command can execute with the given parameter in its current state.
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

}

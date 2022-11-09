using System;

namespace InsurgencyServerManager.Core;

public class BaseCommand : BaseCommand<object>
{
    public BaseCommand(Func<bool> canExecute, Action execute) : base(_ => canExecute(), _ => execute()) { }
}

public class BaseCommand<TParam> : IBaseCommand
    where TParam : class?
{
    public BaseCommand(Func<TParam?, bool> canExecute, Action<TParam?> execute)
    {
        this._canExecute = canExecute;
        this._execute = execute;
    }

    private Func<TParam?, bool> _canExecute;

    private Action<TParam?> _execute;

    public bool CanExecute(object? parameter)
    {
        var param = parameter as TParam;
        return this._canExecute(param);
    }

    public void Execute(object? parameter)
    {
        var param = parameter as TParam;
        this._execute(param);
    }

    public void RaiseCanExecuteChanged()
    {
        this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? CanExecuteChanged;
}

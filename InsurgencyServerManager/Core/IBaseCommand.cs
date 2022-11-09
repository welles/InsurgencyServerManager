using System.Windows.Input;

namespace InsurgencyServerManager.Core;

public interface IBaseCommand : ICommand
{
    void RaiseCanExecuteChanged();
}

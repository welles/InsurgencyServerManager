using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InsurgencyServerManager.Core;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged([CallerMemberName] string caller = "")
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}

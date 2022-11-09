using InsurgencyServerManager.Core;

namespace InsurgencyServerManager.ViewModels;

public class ModEntryViewModel : ViewModelBase
{
    private bool _active;

    private long? _id;

    private string? _name;

    private string? _link;

    public bool Active
    {
        get => this._active;
        set
        {
            this._active = value;
            this.RaisePropertyChanged();
        }
    }

    public string? Name
    {
        get => this._name;
        set
        {
            this._name = value;
            this.RaisePropertyChanged();
        }
    }

    public string? Link
    {
        get => this._link;
        set
        {
            this._link = value;
            this.RaisePropertyChanged();
        }
    }

    public long? Id
    {
        get => this._id;
        set
        {
            this._id = value;
            this.RaisePropertyChanged();
        }
    }
}

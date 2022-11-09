using System;

namespace InsurgencyServerManager.Core;

public abstract class CommittableViewModelBase : ViewModelBase
{
    public event EventHandler? OnCommit;

    public event EventHandler? OnCancel;

    protected void Commit()
    {
        this.OnCommit?.Invoke(this, EventArgs.Empty);
    }

    protected void Cancel()
    {
        this.OnCancel?.Invoke(this, EventArgs.Empty);
    }
}

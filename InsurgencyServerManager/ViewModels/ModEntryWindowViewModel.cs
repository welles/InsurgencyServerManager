using System.Collections.Generic;
using InsurgencyServerManager.Core;
using InsurgencyServerManager.Data;

namespace InsurgencyServerManager.ViewModels;

public class ModEntryWindowViewModel : CommittableViewModelBase
{
    private bool _active;

    private string? _name;

    private long? _id;

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

    public long? Id
    {
        get => this._id;
        set
        {
            this._id = value;
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

    public IBaseCommand SaveCommand { get; }

    public List<ComboBoxSelectionViewModel<ModType>> ModTypes => ComboBoxSelectionViewModel.FromEnum<ModType>();

    public ModEntryWindowViewModel()
    {
        this.PropertyChanged += (_, _) =>
        {
            this.SaveCommand?.RaiseCanExecuteChanged();
        };

        this.SaveCommand = new BaseCommand<ModEntryWindowViewModel>(
            model => !string.IsNullOrWhiteSpace(model?.Name) && !string.IsNullOrWhiteSpace(model?.Link) &&
                     model?.Id != null,
            model =>
            {
                App.DataManager.AddModEntry(Mapper.Map<ModEntry>(model));

                this.Commit();
            });
    }
}

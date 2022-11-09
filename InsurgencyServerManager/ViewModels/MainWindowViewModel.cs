using System.Collections.ObjectModel;
using System.Linq;
using InsurgencyServerManager.Core;
using InsurgencyServerManager.Windows;

namespace InsurgencyServerManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<ModEntryViewModel> ModEntries => new(App.DataManager.GetModEntries().Select(Mapper.Map<ModEntryViewModel>));

    private ModEntryViewModel? _selectedItem;

    public ModEntryViewModel? SelectedItem
    {
        get => this._selectedItem;
        set
        {
            this._selectedItem = value;
            this.RaisePropertyChanged();

            this.DeleteCommand.RaiseCanExecuteChanged();
        }
    }

    public IBaseCommand DeleteCommand { get; }

    public IBaseCommand AddCommand { get; }

    public MainWindowViewModel()
    {
        this.DeleteCommand = new BaseCommand<ModEntryViewModel?>(
            model => this.SelectedItem != null,
            model =>
            {

            });

        this.AddCommand = new BaseCommand(() => true, () =>
        {
            var window = new ModEntryWindow();
            var viewModel = new ModEntryWindowViewModel();
            viewModel.OnCommit += (_, _) =>
            {
                this.RaisePropertyChanged(nameof(this.ModEntries));
                window.Close();
            };
            viewModel.OnCancel += (_, _) => window.Close();
            window.DataContext = viewModel;
            window.ShowDialog();
        });
    }
}

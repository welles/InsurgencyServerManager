using System;
using InsurgencyServerManager.Data;
using InsurgencyServerManager.ViewModels;
using InsurgencyServerManager.Windows;

namespace InsurgencyServerManager;

public static class App
{
    public static DataManager DataManager { get; }

    static App()
    {
        App.DataManager = new DataManager();
    }

    [STAThread]
    private static void Main()
    {
        var viewModel = new MainWindowViewModel();

        var mainWindow = new MainWindow
        {
            DataContext = viewModel
        };

        mainWindow.ShowDialog();
    }
}

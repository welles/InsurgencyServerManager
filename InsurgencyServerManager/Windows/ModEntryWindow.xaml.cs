using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace InsurgencyServerManager.Windows;

public partial class ModEntryWindow : Window
{
    public ModEntryWindow()
    {
        this.InitializeComponent();
    }

    private void ValidateModId(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }
}

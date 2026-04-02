using System.Windows;

namespace ColourPicker;

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        MainWindow = new MainWindow(new MainWindowViewModel());
        MainWindow.Show();
    }
}

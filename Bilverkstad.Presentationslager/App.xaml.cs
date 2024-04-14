using Bilverkstad.Presentationslager.Data;
using Bilverkstad.Presentationslager.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(
                new MainViewModel(
                    new KundDataService()));
            mainWindow.Show();
        }
    }

}

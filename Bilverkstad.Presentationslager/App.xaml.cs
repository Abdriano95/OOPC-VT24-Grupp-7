using Autofac;
using Bilverkstad.Presentationslager.Data;
using Bilverkstad.Presentationslager.Startup;
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
            var bootstraper = new Bootstraper();
            var container = bootstraper.Bootstrap();
            var mainWindow = container.Resolve<MainWindow>();   
            mainWindow.Show();
        }
    }

}

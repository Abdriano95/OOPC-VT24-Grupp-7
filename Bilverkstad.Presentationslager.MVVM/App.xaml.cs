using Bilverkstad.Affärslager;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Bilverkstad.Presentationslager.MVVM.Views;

namespace Bilverkstad.Presentationslager.MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            loginWindow.IsVisibleChanged += (s, e) =>
            {
                if (!loginWindow.IsVisible && loginWindow.IsLoaded && AnvändarSession.InloggadAnvändare != null)
                {
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    loginWindow.Close();
                }
            };
        }

    }

}

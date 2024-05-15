using Bilverkstad.Affärslager;
using Bilverkstad.Presentationslager.MVVM.Services;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Bilverkstad.Presentationslager.MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            try
            {
                ShowInitialWindow(Get_serviceProvider());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while starting the application: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IWindowService, WindowService>();
            services.AddSingleton<IUserMessageService, UserMessageService>();
            services.AddSingleton<AnställdController>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainWindow>();
        }

        private IServiceProvider? Get_serviceProvider()
        {
            return _serviceProvider;
        }

        private void ShowInitialWindow(IServiceProvider? _serviceProvider)
        {
            var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow.Show();
        }
    }

}

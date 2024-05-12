using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows;

namespace Bilverkstad.Presentationslager.MVVM.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
    {
        InitializeComponent();
        //this.DataContext = new LoginViewModel(windowService);
    }
       

        private void GlömtLösenord_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lösenord återställningsfunktion!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void RegistreraDig_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Registreringsfunktion!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            // Open registration functionality
        }

        

        private void MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}

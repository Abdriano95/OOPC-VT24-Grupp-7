using Bilverkstad.Presentationslager.Services;
using Bilverkstad.Presentationslager.Views.UserControls;
using System.Windows;

namespace Bilverkstad.Presentationslager.Views.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window,ICloseable
    {
        public LoginWindow()
        {
            InitializeComponent();
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

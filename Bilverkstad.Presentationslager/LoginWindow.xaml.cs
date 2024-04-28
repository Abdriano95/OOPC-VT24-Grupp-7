using Bilverkstad.Affärslager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private AnställdController _anställdController;
        public LoginWindow()
        {
            InitializeComponent();
            _anställdController = new AnställdController();
        }

        private void LoggaIn_Click(object sender, RoutedEventArgs e)
        {
            int användarid = int.Parse(txtAnvändarid.Text);
            string lösenord = txtLösenord.Password;

            if (_anställdController.ValideraInlogg(användarid, lösenord))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                MessageBox.Show("Välkommen!");
            }
            else
            {
                MessageBox.Show("Fel användarnamn eller lösenord");
            }
        }
    }
}

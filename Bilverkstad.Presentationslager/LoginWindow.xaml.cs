using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

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
            Anställd anställd = _anställdController.GetSubTypeAnställd(användarid);

            if (_anställdController.ValideraInlogg(användarid, lösenord))
            {
                AnvändarSession.InloggadAnvändare = new Användare { AnvändarNamn = anställd.Förnamn + " " + anställd.Efternamn, AnställningsNummer = anställd.AnställningsNummer };

                MainWindow mainWindow = new MainWindow(anställd);
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

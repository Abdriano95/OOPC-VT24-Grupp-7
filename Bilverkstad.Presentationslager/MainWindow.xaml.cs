using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public Anställd _nuvarandeAnvändare;
        public MainWindow(Anställd nuvarandeAnvändare)
        {
            InitializeComponent();
            UpdateraAnvändarInfo();

            _nuvarandeAnvändare = nuvarandeAnvändare;
            
        }


        private void UpdateraAnvändarInfo()
        {
            if (AnvändarSession.InloggadAnvändare != null)
            {
                användarNamn.Text = AnvändarSession.InloggadAnvändare.AnvändarNamn;
                AnställningsID.Text = AnvändarSession.InloggadAnvändare.AnställningsNummer.ToString();


            }
        }

        private void KonfigureraTabbarBaseradPåRoll()
        {
         
        }

        private void LoggaUt_Click(object sender, RoutedEventArgs e)
        {
            AnvändarSession.Logout();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }   
        

   

    }


}


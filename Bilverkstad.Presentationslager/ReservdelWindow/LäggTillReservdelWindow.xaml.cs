using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillReservdelWindow.xaml
    /// </summary>
    public partial class LäggTillReservdelWindow : Window
    {
        ReservdelController controller = new ReservdelController();
        public LäggTillReservdelWindow()
        {
            InitializeComponent();
        }
        public void AddReservdel_Click(object sender, RoutedEventArgs e)
        {

            if (FindName("txtPris") is TextBox txtPris)
            {
                // Försök att konvertera texten till float
                if (float.TryParse(txtPris.Text, out float pris))
                {
                    var reservdel = new Reservdel
                    {
                        Namn = txtNamn.Text,
                        Pris = pris
                    };

                    controller.AddReservdel(reservdel);
                }
                else
                {

                    MessageBox.Show("Felaktigt prisformat. Vänligen ange ett giltigt tal.");
                }
            }
            else
            {
                // Hantera om txtPris inte hittas
                MessageBox.Show("Kunde inte hitta txtPris.");
            }
        }

    }
}

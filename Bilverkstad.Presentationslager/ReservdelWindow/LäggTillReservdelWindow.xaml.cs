using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
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
            // Försök att hitta txtPris från fönstrets träd
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
                    // Om konverteringen misslyckas, hantera felaktigt format
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

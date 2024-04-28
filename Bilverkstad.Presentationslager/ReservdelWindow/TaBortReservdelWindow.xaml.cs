using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortReservdelWindow.xaml
    /// </summary>
    public partial class TaBortReservdelWindow : Window
    {
        ReservdelController controller = new ReservdelController();
        public TaBortReservdelWindow()
        {
            InitializeComponent();
            Reservdel.ItemsSource = controller.GetReservdel();
        }
        public void TaBortReservdel_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Reservdel befintligReservdel = new Reservdel();
            befintligReservdel.Artikelnummer = int.Parse(inmatning);
            controller.DeleteReservdel(befintligReservdel);
        }
    }
}

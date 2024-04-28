using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for ReservdelFormulär.xaml
    /// </summary>
    public partial class ReservdelFormulär : Window
    {
        int inmatning;
        ReservdelController controller = new ReservdelController();
        Reservdel reservdel = new Reservdel();
        public ReservdelFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            reservdel = controller.GetOneReservdel(inmatning);
            txtNamn.Text = reservdel.Namn.ToString();
            txtPris.Text = reservdel.Pris.ToString();
        }
        public void UpdateReservdel_Click(object sender, RoutedEventArgs e)
        {
            reservdel = controller.GetOneReservdel(inmatning);
            reservdel.Namn = txtNamn.Text;
            reservdel.Pris = float.Parse(txtPris.Text.ToString());
            controller.UpdateReservdel(reservdel);
        }
    }
}

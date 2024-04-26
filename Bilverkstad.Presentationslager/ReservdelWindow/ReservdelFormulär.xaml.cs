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

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

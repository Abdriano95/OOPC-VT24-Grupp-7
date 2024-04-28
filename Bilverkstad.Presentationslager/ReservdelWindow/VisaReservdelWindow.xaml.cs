using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaReservdelWindow.xaml
    /// </summary>
    public partial class VisaReservdelWindow : Window
    {
        public VisaReservdelWindow()
        {
            InitializeComponent();
            ReservdelController reservdelController = new ReservdelController();
            Reservdel.ItemsSource = reservdelController.GetReservdel();
        }
    }
}

using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for UppdateraReservdelWindow.xaml
    /// </summary>
    public partial class UppdateraReservdelWindow : Window
    {
        ReservdelController controller = new ReservdelController();
        public UppdateraReservdelWindow()
        {
            InitializeComponent();
            Reservdel.ItemsSource = controller.GetReservdel();
        }
        public void UppdateraReservdel_Click(object sender, RoutedEventArgs e)
        {

            ReservdelFormulär reservdelFormulär = new ReservdelFormulär(inputtxt.Text);
            reservdelFormulär.Show();
        }
    }
}

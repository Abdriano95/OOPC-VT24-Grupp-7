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

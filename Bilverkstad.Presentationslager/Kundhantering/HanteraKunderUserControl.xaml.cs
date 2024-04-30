using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.HanteraBokningWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bilverkstad.Presentationslager.Kundhantering
{
    /// <summary>
    /// Interaction logic for HanteraKunderUserControl.xaml
    /// </summary>
    public partial class HanteraKunderUserControl : UserControl
    {
        KundController _kundController;
        public HanteraKunderUserControl()
        {
            InitializeComponent();
            _kundController = new KundController();
            Kunder.ItemsSource = _kundController.GetKundWithFordon();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Kunder.ItemsSource = _kundController.GetKundWithFordon();  // Your method to fetch bookings
        }

        public void SkapaKund_Click(object sender, RoutedEventArgs e)
        {
            SkapaKundWindow skapaKundWindow = new SkapaKundWindow();
            skapaKundWindow.Show();
            ReloadData();
        }

        private void ÄndraKund_Click(object sender, RoutedEventArgs e)
        {
            Kund selectedBooking = Kunder.SelectedItem as Kund;  
            if (selectedBooking != null)
            {
                 
                //editWindow.ShowDialog();  
                ReloadData();  
            }
            else
            {
                MessageBox.Show("Var god och välj en kund att ändra.");
            }

        }


        private void ReloadData()
        {
            _kundController = new KundController();
            Kunder.ItemsSource = _kundController.GetKundWithFordon();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSök_TextChanged(object sender, TextChangedEventArgs e)
        {
            SökOchUppdateraGrid();
        }

        private void SökOchUppdateraGrid()
        {
            var sökTerm = txtSök.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(sökTerm))
            {
                var resultat = _kundController.SökKunder(sökTerm);
                Kunder.ItemsSource = resultat;

                if (resultat.Count == 0)
                {
                    MessageBox.Show("Inga kunder hittades med söktermen: " + sökTerm);
                }
            }
            else 
            {
                var allaKunder = _kundController.GetKundWithFordon();
                Kunder.ItemsSource = allaKunder;
            }

        }
    }
}

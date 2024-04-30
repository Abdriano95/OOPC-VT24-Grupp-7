using Bilverkstad.Affärslager;
using Bilverkstad.Presentationslager.HanteraBokningWindow;
using System.Windows;
using Bilverkstad.Entitetlagret;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraBokningWindow.xaml
    /// </summary>
    public partial class HanteraBokningarWindow : Window
    {
        BokningsController _bokningController;
        public HanteraBokningarWindow()
        {
            InitializeComponent();
            _bokningController = new BokningsController();
            Window_Loaded(this, null);
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Bokningar.ItemsSource = _bokningController.GetBokning();  // För att hämta bokningar
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SkapaBokningWindow skapaBokningWindow = new SkapaBokningWindow();
            skapaBokningWindow.Show();
            ReloadData();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bokning selectedBooking = Bokningar.SelectedItem as Bokning;  
            if (selectedBooking != null)
            {
                ÄndraBokningWindow editWindow = new ÄndraBokningWindow(selectedBooking);  
                editWindow.ShowDialog();  
                ReloadData();  // refresh 
            }
            else
            {
                MessageBox.Show("Please select a booking to edit.");
            }

        }

        private void ReloadData()
        {
            _bokningController = new BokningsController();
            Bokningar.ItemsSource = _bokningController.GetBokning();
        }

        private void SökButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = txtSök.Text.Trim();
            try
            {
                var results = _bokningController.SökBokningar(searchTerm);
                Bokningar.ItemsSource = results;

                if (results.Count == 0)
                {
                    MessageBox.Show("No bookings found.");  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching bookings: " + ex.Message);
            }
        }

        private void txtSök_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchAndUpdateGrid();

        }
        private void SearchAndUpdateGrid()
        {
            var searchTerm = txtSök.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var results = _bokningController.SökBokningar(searchTerm);
                Bokningar.ItemsSource = results;

                if (results.Count == 0)
                {
                    MessageBox.Show("No bookings found matching your criteria.");
                }
            }
            else
            {
                
                var allBookings = _bokningController.GetBokning();
                Bokningar.ItemsSource = allBookings;
            }

        }
    }
}

using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraBokningMekanikerWindow.xaml
    /// </summary>
    public partial class HanteraBokningMekanikerWindow : Window
    {
        BokningsController _bokningController;

        public HanteraBokningMekanikerWindow()
        {
            InitializeComponent();
            _bokningController = new BokningsController();
            Bokningar.ItemsSource = _bokningController.GetBokning();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Bokningar.ItemsSource = _bokningController.GetBokning();  // Hämta bokningar
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bokning selectedBooking = Bokningar.SelectedItem as Bokning;
            if (selectedBooking != null)
            {
                ÄndraBokningMekanikerWindow editWindow = new ÄndraBokningMekanikerWindow(selectedBooking);
                editWindow.ShowDialog();
                ReloadData();
            }
            else
            {
                MessageBox.Show("Please select a booking to edit.");
            }

        }

        public void ReloadData()
        {
            Bokningar.ItemsSource = _bokningController.GetBokning();
        }

        private void SökButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = txtSök.Text.Trim();
            if (!string.IsNullOrEmpty(searchTerm))
            {
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
            else
            {
                MessageBox.Show("Please enter a search term.");
            }
        }




    }
}

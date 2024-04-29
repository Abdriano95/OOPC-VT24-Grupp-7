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
            Bokningar.ItemsSource = _bokningController.GetBokning();

        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Bokningar.ItemsSource = _bokningController.GetBokning();  // Your method to fetch bookings
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SkapaBokningWindow skapaBokningWindow = new SkapaBokningWindow();
            skapaBokningWindow.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bokning selectedBooking = Bokningar.SelectedItem as Bokning;  // Assuming your data type is Bokning
            if (selectedBooking != null)
            {
                ÄndraBokningWindow editWindow = new ÄndraBokningWindow(selectedBooking);  // Assuming you have a window or dialog for editing
                editWindow.ShowDialog();  // Show the edit window as a modal dialog
                ReloadData();  // Refresh the data after editing
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
            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    var results = _bokningController.SearchBookings(searchTerm);
                    // Assuming you have a DataGrid or some UI element to display bookings:
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

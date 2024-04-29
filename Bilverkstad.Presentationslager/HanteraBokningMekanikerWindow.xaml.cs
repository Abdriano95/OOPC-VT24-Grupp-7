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
using System.Windows.Shapes;

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
            Bokningar.ItemsSource = _bokningController.GetBokning();  // Your method to fetch bookings
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bokning selectedBooking = Bokningar.SelectedItem as Bokning;  // Assuming your data type is Bokning
            if (selectedBooking != null)
            {
                ÄndraBokningMekanikerWindow editWindow = new ÄndraBokningMekanikerWindow(selectedBooking);  // Assuming you have a window or dialog for editing
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

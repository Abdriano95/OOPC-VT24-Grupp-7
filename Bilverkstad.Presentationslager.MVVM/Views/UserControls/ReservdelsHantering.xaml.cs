using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ReservdelsHantering.xaml
    /// </summary>
    public partial class ReservdelsHantering : UserControl
    {
        private List<Reservdel> _allReservdelar;
        public ReservdelsHantering()
        {
            InitializeComponent();
        }

        private void LoadSampleData()
        {
            _allReservdelar = new List<Reservdel>
            {
                new Reservdel { Artikelnummer = 1, Namn = "Oil Filter", Pris = 50.0f },
                new Reservdel { Artikelnummer = 2, Namn = "Air Filter", Pris = 30.0f },
                new Reservdel { Artikelnummer = 3, Namn = "Brake Pads", Pris = 100.0f },
                new Reservdel { Artikelnummer = 4, Namn = "Wiper Blades", Pris = 25.0f }
            };

            ReservdelarDataGrid.ItemsSource = _allReservdelar;
        }

        private void AddReservdel_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ArtikelnummerTextBox.Text, out int artikelnummer) && float.TryParse(PrisTextBox.Text, out float pris))
            {
                _allReservdelar.Add(new Reservdel
                {
                    Artikelnummer = artikelnummer,
                    Namn = NamnTextBox.Text,
                    Pris = pris
                });
                RefreshDataGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please enter valid values.");
            }
        }

        private void EditReservdel_Click(object sender, RoutedEventArgs e)
        {
            if (ReservdelarDataGrid.SelectedItem is Reservdel selectedReservdel)
            {
                if (int.TryParse(ArtikelnummerTextBox.Text, out int artikelnummer) && float.TryParse(PrisTextBox.Text, out float pris))
                {
                    selectedReservdel.Artikelnummer = artikelnummer;
                    selectedReservdel.Namn = NamnTextBox.Text;
                    selectedReservdel.Pris = pris;
                    RefreshDataGrid();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Please enter valid values.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Reservdel to edit.");
            }
        }

        private void DeleteReservdel_Click(object sender, RoutedEventArgs e)
        {
            if (ReservdelarDataGrid.SelectedItem is Reservdel selectedReservdel)
            {
                _allReservdelar.Remove(selectedReservdel);
                RefreshDataGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a Reservdel to delete.");
            }
        }

        private void RefreshDataGrid()
        {
            ReservdelarDataGrid.ItemsSource = null;
            ReservdelarDataGrid.ItemsSource = _allReservdelar;
        }

        private void ClearInputFields()
        {
            ArtikelnummerTextBox.Clear();
            NamnTextBox.Clear();
            PrisTextBox.Clear();
        }


    }
}

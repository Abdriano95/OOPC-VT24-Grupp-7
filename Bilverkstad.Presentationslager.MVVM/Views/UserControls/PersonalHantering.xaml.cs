using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PersonalHantering.xaml
    /// </summary>
    public partial class PersonalHantering : UserControl
    {
        private List<Anställd> _allPersonal;
        private int _nextAnstallningsNummer = 1;

        public PersonalHantering()
        {
            InitializeComponent();
            LoadSampleData();
            TypComboBox.SelectionChanged += TypComboBox_SelectionChanged;
        }

        private void LoadSampleData()
        {
            _allPersonal = new List<Anställd>
            {
                new Mekaniker { AnställningsNummer = 1, Förnamn = "John", Efternamn = "Doe", Lösenord = "password1", Specialiseringar = Specialiseringar.Dackbyte },
                new Mekaniker { AnställningsNummer = 2, Förnamn = "Alice", Efternamn = "Smith", Lösenord = "password2", Specialiseringar = Specialiseringar.Motor },
                new Receptionist { AnställningsNummer = 3, Förnamn = "Bob", Efternamn = "Johnson", Lösenord = "password3", Auktoritet = Auktoritet.Admin },
                new Receptionist { AnställningsNummer = 4, Förnamn = "Jane", Efternamn = "Doe", Lösenord = "password4", Auktoritet = Auktoritet.NotAdmin }
            };

            _nextAnstallningsNummer = _allPersonal.Max(a => a.AnställningsNummer) + 1;

            PersonalDataGrid.ItemsSource = _allPersonal;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string förnamn = FörnamnTextBox.Text;
            string efternamn = EfternamnTextBox.Text;
            string lösenord = LosenordPasswordBox.Password;
            string typ = (TypComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (typ == "Mekaniker" && SpecializationComboBox.SelectedItem != null)
            {
                Specialiseringar specialisering = (Specialiseringar)Enum.Parse(typeof(Specialiseringar), (SpecializationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                _allPersonal.Add(new Mekaniker
                {
                    AnställningsNummer = _nextAnstallningsNummer++,
                    Förnamn = förnamn,
                    Efternamn = efternamn,
                    Lösenord = lösenord,
                    Specialiseringar = specialisering
                });
            }
            else if (typ == "Receptionist" && AuthorityComboBox.SelectedItem != null)
            {
                Auktoritet auktoritet = (Auktoritet)Enum.Parse(typeof(Auktoritet), (AuthorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                _allPersonal.Add(new Receptionist
                {
                    AnställningsNummer = _nextAnstallningsNummer++,
                    Förnamn = förnamn,
                    Efternamn = efternamn,
                    Lösenord = lösenord,
                    Auktoritet = auktoritet
                });
            }

            RefreshDataGrid();
            ClearInputFields();
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (PersonalDataGrid.SelectedItem is Anställd selectedPersonal)
            {
                string förnamn = FörnamnTextBox.Text;
                string efternamn = EfternamnTextBox.Text;
                string lösenord = LosenordPasswordBox.Password;
                string typ = (TypComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                selectedPersonal.Förnamn = förnamn;
                selectedPersonal.Efternamn = efternamn;
                selectedPersonal.Lösenord = lösenord;

                if (selectedPersonal is Mekaniker mekaniker && typ == "Mekaniker")
                {
                    mekaniker.Specialiseringar = (Specialiseringar)Enum.Parse(typeof(Specialiseringar), (SpecializationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                }
                else if (selectedPersonal is Receptionist receptionist && typ == "Receptionist")
                {
                    receptionist.Auktoritet = (Auktoritet)Enum.Parse(typeof(Auktoritet), (AuthorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                }

                RefreshDataGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (PersonalDataGrid.SelectedItem is Anställd selectedPersonal)
            {
                _allPersonal.Remove(selectedPersonal);
                RefreshDataGrid();
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }

        private void RefreshDataGrid()
        {
            PersonalDataGrid.ItemsSource = null;
            PersonalDataGrid.ItemsSource = _allPersonal;
        }

        private void ClearInputFields()
        {
            FörnamnTextBox.Clear();
            EfternamnTextBox.Clear();
            LosenordPasswordBox.Clear();
            TypComboBox.SelectedIndex = -1;
            SpecializationComboBox.Visibility = Visibility.Collapsed;
            SpecializationLabel.Visibility = Visibility.Collapsed;
            AuthorityComboBox.Visibility = Visibility.Collapsed;
            AuthorityLabel.Visibility = Visibility.Collapsed;
        }

        private void TypComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedType = (TypComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedType == "Mekaniker")
            {
                SpecializationLabel.Visibility = Visibility.Visible;
                SpecializationComboBox.Visibility = Visibility.Visible;
                AuthorityLabel.Visibility = Visibility.Collapsed;
                AuthorityComboBox.Visibility = Visibility.Collapsed;
            }
            else if (selectedType == "Receptionist")
            {
                AuthorityLabel.Visibility = Visibility.Visible;
                AuthorityComboBox.Visibility = Visibility.Visible;
                SpecializationLabel.Visibility = Visibility.Collapsed;
                SpecializationComboBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                SpecializationLabel.Visibility = Visibility.Collapsed;
                SpecializationComboBox.Visibility = Visibility.Collapsed;
                AuthorityLabel.Visibility = Visibility.Collapsed;
                AuthorityComboBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}

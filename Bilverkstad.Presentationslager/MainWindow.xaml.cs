using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public Anställd _nuvarandeAnvändare;
        public MainWindow(Anställd nuvarandeAnvändare)
        {
            InitializeComponent();
            _nuvarandeAnvändare = nuvarandeAnvändare;
            ConfigureMainMenuBasedOnRole();
        }
        private void NavigationComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)navigationComboBox.SelectedItem;
            if (selectedItem != null)
            {
                string option = selectedItem.Content.ToString();
                switch (option)
                {
                    case "Hantera Kunder":
                        OpenWindow1();
                        break;
                    case "Hantera Anställda":
                        OpenWindow2();
                        break;
                    case "Hantera Reservdelar":
                        OpenWindow3();
                        break;
                    case "Hantera Reparationer":
                        OpenWindow4();
                        break;
                    default:
                        break;
                    case "Hantera Bokning":
                        OpenWindow5();
                        break;

                }
            }
        }

        private void ConfigureMainMenuBasedOnRole()
        {
            // Clear existing items
            navigationComboBox.Items.Clear();

            // Based on the type of _currentUser, add the appropriate items to the ComboBox
            if (_nuvarandeAnvändare is Receptionist receptionist)
            {
                // If receptionist is an admin, they can access everything
                if (receptionist.Auktoritet == Auktoritet.Admin)
                {
                    AddAllMenuItems();
                }
                else // If not an admin, add only receptionist-specific items
                {
                    navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Kunder" });
                    navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning" });
                }
            }
            else if (_nuvarandeAnvändare is Mekaniker)
            {
                navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning" });
                navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reservdelar" });
                navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reparationer" });
            }

        }

        private void AddAllMenuItems()
        {
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Kunder" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Anställda" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reservdelar" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reparationer" });
        }



        private void OpenWindow1()
        {
            HanteraKunderWindow hanteraKunder = new HanteraKunderWindow();
            hanteraKunder.Show();
        }

        private void OpenWindow2()
        {
            HanteraAnställdaWindow hanteraAnställda = new HanteraAnställdaWindow();
            hanteraAnställda.Show();
        }
        private void OpenWindow3()
        {
            HanteraReservdelarWindow hanteraReservdelar = new HanteraReservdelarWindow();
            hanteraReservdelar.Show();
        }
        private void OpenWindow4()
        {
            HanteraReparationerWindow hanteraReparationer = new HanteraReparationerWindow();
            hanteraReparationer.Show();
        }
        private void OpenWindow5()
        {
            HanteraBokningarWindow hanteraBokningar = new HanteraBokningarWindow();
            hanteraBokningar.Show();
        }


    }


}


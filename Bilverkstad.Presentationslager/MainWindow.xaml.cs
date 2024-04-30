using Bilverkstad.Affärslager;
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
            UpdateraAnvändarInfo();

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
                    case "Hantera Bokning":
                        OpenWindow5();
                        break;
                    case "Hantera Bokning (Mekaniker)":
                        OpenWindow6();
                        break;
                    default:
                        break;

                }
            }
        }

        private void UpdateraAnvändarInfo()
        {
            if (AnvändarSession.InloggadAnvändare != null)
            {
                användarNamn.Text = AnvändarSession.InloggadAnvändare.AnvändarNamn;
                AnställningsID.Text = AnvändarSession.InloggadAnvändare.AnställningsNummer.ToString();
            }
        }


        private void LoggaUt_Click(object sender, RoutedEventArgs e)
        {
            AnvändarSession.Logout();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }   
        private void ConfigureMainMenuBasedOnRole()
        {
            navigationComboBox.Items.Clear();

            
            if (_nuvarandeAnvändare is Receptionist receptionist)
            {
                // om receptionist är admin har de åtkomst till allt
                if (receptionist.Auktoritet == Auktoritet.Admin)
                {
                    AddAllMenuItems();
                }
                else // Om inte admin, bara vissa grejer
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
                navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning (Mekaniker)" });
            }

        }

        private void AddAllMenuItems()
        {
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Kunder" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Anställda" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reservdelar" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Reparationer" });
            navigationComboBox.Items.Add(new ComboBoxItem { Content = "Hantera Bokning (Mekaniker)" });
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
        private void OpenWindow6()
        {
            HanteraBokningMekanikerWindow hanteraBokningMekaniker = new HanteraBokningMekanikerWindow();
            hanteraBokningMekaniker.Show();
        }

    }


}


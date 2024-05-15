using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager.HanteraBokningWindow
{
    /// <summary>
    /// Interaction logic for SkapaBokningWindow.xaml
    /// </summary>
    public partial class SkapaBokningWindow : Window
    {
        KundController kundController = new KundController();
        BokningsController bokningsController = new BokningsController();

        Kund kund = new Kund();
        Receptionist receptionist = new Receptionist();
        string kundID;
        string receptionistID;
        public SkapaBokningWindow()
        {
            InitializeComponent();
            cmbSpecialiseringar.ItemsSource = Enum.GetValues(typeof(Specialiseringar));
            cmbSpecialiseringar.Items.Refresh();
            cmbSpecialiseringar.DisplayMemberPath = null;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbSpecialiseringar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSpecialiseringar.SelectedItem != null)
            {
                var selectedSpecialisering = (Specialiseringar)cmbSpecialiseringar.SelectedItem;
                var mechanics = bokningsController.GetMekanikerBySpecialisering(selectedSpecialisering);
                cmbMekaniker.ItemsSource = mechanics;
                cmbMekaniker.DisplayMemberPath = "FullständigtNamn";
                cmbMekaniker.SelectedValuePath = "AnställningsNummer";
                cmbMekaniker.IsEnabled = mechanics.Any();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            kundID = txtKundID.Text;
            if (!string.IsNullOrWhiteSpace(kundID))
            {
                try
                {
                    int id = int.Parse(kundID);
                    var customerInfo = await Task.Run(() => kundController.GetOneKund(id));
                    if (customerInfo != null && customerInfo.Fordon != null && customerInfo.Fordon.Any())
                    {

                        cmbFordon.ItemsSource = customerInfo.Fordon;  // Bind fordon till comboboxen
                        cmbFordon.DisplayMemberPath = "RegNr";
                        cmbFordon.SelectedValuePath = "RegNr";

                    }
                    else
                    {
                        MessageBox.Show("Inga fordon hittade för kunden");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ogiltig KundID. Var god och ange ett heltal");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ett fel har inträffat: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Har god och ange ett giltigt KundID.");
            }
        }

        private void SkapaBokning_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string kundID = txtKundID.Text;
                string receptionistID = txtReceptionistID.Text;
                if (!string.IsNullOrWhiteSpace(kundID) && !string.IsNullOrWhiteSpace(receptionistID))
                {
                    int _kundId = int.Parse(kundID);
                    int recId = int.Parse(receptionistID);
                    Fordon selectedFordon = cmbFordon.SelectedItem as Fordon;
                    var selectedMekanikerID = cmbMekaniker.SelectedValue as int?;
                    var selectedSpecialisering = (Specialiseringar)cmbSpecialiseringar.SelectedItem; ;

                    if (selectedFordon != null && selectedMekanikerID.HasValue)
                    {
                        DateTime startDate = datePickerStartDate.SelectedDate ?? DateTime.Now;
                        DateTime? endDate = datePickerEndDate.SelectedDate;
                        string purpose = txtPurpose.Text;
                        Status initialStatus = Status.Inlämnad;

                        Bokning nyBokning = new Bokning
                        {
                            InlämningsDatum = startDate,
                            UtlämningsDatum = endDate,
                            SyfteMedBesök = purpose,
                            BokningStatus = initialStatus
                        };

                        bokningsController.CreateOrUpdateBokning(_kundId, selectedFordon.RegNr, recId, selectedMekanikerID.Value, selectedSpecialisering, nyBokning);
                        MessageBox.Show("Booking Created Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Please make sure all entries are valid and a vehicle is selected.");
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure all fields are filled correctly.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid ID(s). Please enter valid integer ID(s).");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
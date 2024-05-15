using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager.HanteraBokningWindow
{
    public partial class ÄndraBokningWindow : Window
    {
        private BokningsController bokningsController = new BokningsController();
        private MekanikerController mekan = new MekanikerController();

        private Bokning _selectedBokning;

        public ÄndraBokningWindow(Bokning selectedBokning)
        {
            InitializeComponent();
            _selectedBokning = selectedBokning;
            this.DataContext = _selectedBokning;
            HämtaBokningData(_selectedBokning);
            FyllSpecBox();
            HämtaMekanikerTillBokningen(selectedBokning.Mekaniker.Specialiseringar);
        }

        private void HämtaBokningData(Bokning bokning)
        {
            txtBokningsID.Text = bokning.Id.ToString();
            datePickerInlämningsdatum.SelectedDate = bokning.InlämningsDatum;
            datePickerUtlämningsdatum.SelectedDate = bokning.UtlämningsDatum;
            txtSyfteMedBesok.Text = bokning.SyfteMedBesök;

            // Hämta mekaniker
            cmbMekaniker.ItemsSource = mekan.GetMekaniker();
            cmbMekaniker.DisplayMemberPath = "FullständigtNamn";
            cmbMekaniker.SelectedValuePath = "AnställningsNummer";


            if (bokning.MekanikerId != null)
            {
                var mekaniker = mekan.GetOneMekaniker(bokning.MekanikerId.Value);
                bokning.Mekaniker = mekaniker;
                cmbMekaniker.SelectedValue = bokning.MekanikerId;
            }
        }

        private void HämtaMekanikerTillBokningen(Specialiseringar specialization)
        {
            var mechanics = bokningsController.GetMekanikerBySpecialisering(specialization);
            cmbMekaniker.ItemsSource = mechanics;
            cmbMekaniker.DisplayMemberPath = "FullständigtNamn";
            cmbMekaniker.SelectedValuePath = "AnställningsNummer";
            cmbMekaniker.SelectedValue = _selectedBokning.MekanikerId;
            cmbMekaniker.IsEnabled = false;
        }

        private void ÄndraBokningButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                _selectedBokning.SyfteMedBesök = txtSyfteMedBesok.Text;
                _selectedBokning.InlämningsDatum = datePickerInlämningsdatum.SelectedDate.GetValueOrDefault();
                _selectedBokning.UtlämningsDatum = datePickerUtlämningsdatum.SelectedDate.GetValueOrDefault();
                _selectedBokning.MekanikerId = (int?)cmbMekaniker.SelectedValue;
                bokningsController.UpdateBokning(_selectedBokning);
                MessageBox.Show("Booking updated successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update booking: " + ex.Message);
            }
        }

        private void FyllSpecBox()
        {
            cmbSpecialiseringar.ItemsSource = Enum.GetValues(typeof(Specialiseringar));
            cmbSpecialiseringar.SelectedItem = _selectedBokning.Mekaniker?.Specialiseringar;
        }

        private void TaBortBokningButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBokning != null)
            {
                MessageBoxResult result = MessageBox.Show("Är du säker att du vill ta bort bokningen?", "Confirm Deletion", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        bokningsController.DeleteBokning(_selectedBokning.Id);
                        MessageBox.Show("Bokningen är borttagen.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Borttagning av bokning misslyckas!: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No booking is selected to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

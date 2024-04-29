using System;
using System.Collections.ObjectModel;
using System.Windows;
using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret; // Assuming your entities are defined here

namespace Bilverkstad.Presentationslager.HanteraBokningWindow
{
    public partial class ÄndraBokningWindow : Window
    {
        private BokningsController bokningsController = new BokningsController();
        private MekanikerController mekan = new MekanikerController();  

        private Bokning _selectedBokning; // Stores the retrieved booking object
 
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

            // Load mechanics
            cmbMekaniker.ItemsSource = mekan.GetMekaniker(); // Implement this method to fetch mechanics
            cmbMekaniker.DisplayMemberPath = "FullName"; // Assuming the mechanic has a FullName property
            cmbMekaniker.SelectedValuePath = "AnställningsNummer"; // Make sure this is the key property in Mekaniker

            // Fetch and set the Mekaniker property of the bokning object
            if (bokning.MekanikerId != null)
            {
                var mekaniker = mekan.GetOneMekaniker(bokning.MekanikerId.Value);
                bokning.Mekaniker = mekaniker;
                cmbMekaniker.SelectedValue = bokning.MekanikerId;
            }
        }

        private void HämtaMekanikerTillBokningen(Specialiseringar specialization)
        {
            var mechanics = bokningsController.GetMechanicsBySpecialisering(specialization);
            cmbMekaniker.ItemsSource = mechanics;
            cmbMekaniker.DisplayMemberPath = "FullName";
            cmbMekaniker.SelectedValuePath = "AnställningsNummer";
            cmbMekaniker.SelectedValue = _selectedBokning.MekanikerId; // Ensure the originally assigned mechanic is selected
            cmbMekaniker.IsEnabled = false; // Optional: Disable changes if required
        }



        // Implement event handlers for modifying UI elements and managing selected repairs
        // ... (e.g., handling changes in TextBoxes, Calendars, ComboBox, adding/removing items from ListBoxes)

        private void ÄndraBokningButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                // Manually update properties if necessary
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
            cmbSpecialiseringar.SelectedItem = _selectedBokning.Mekaniker?.Specialiseringar;  // Assuming Specialiseringar is an enum on Mekaniker
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
                        this.Close(); // Optionally close the window or refresh data if it's a part of a larger interface
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

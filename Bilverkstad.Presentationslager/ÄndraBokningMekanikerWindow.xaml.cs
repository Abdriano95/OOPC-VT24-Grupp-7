using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
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
    public partial class ÄndraBokningMekanikerWindow : Window
    {
        private BokningsController bokningsController = new BokningsController();
        private MekanikerController mekan = new MekanikerController();

        private Bokning _selectedBokning; // Stores the retrieved booking object

        public ÄndraBokningMekanikerWindow(Bokning valdbokning)
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
                _selectedBokning.MekanikerId = (int?)cmbMekaniker.SelectedValue;
                bokningsController.UpdateBokning(_selectedBokning);
                MessageBox.Show("Booking updated successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update booking: " + ex.Message);
            }
        }
    }
}   


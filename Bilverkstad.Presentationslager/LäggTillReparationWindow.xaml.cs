using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillReparationWindow.xaml
    /// </summary>
    public partial class LäggTillReparationWindow : Window
    {
        ReparationController reparationcontroller = new ReparationController();
        ReservdelController reservdelcontroller = new ReservdelController();
        Reservdel reservdel = new Reservdel();
        Reparation nyReparation = new Reparation();
        string input;
        List<int> artikelnummerList;
        public LäggTillReparationWindow()
        {
            InitializeComponent();
            FillComboBoxWithEnums();
            LoadArtikelnummer();
            ReservdelController reservdelController = new ReservdelController();
            Reservdel.ItemsSource = reservdelController.GetReservdel();
        }
        public void AddReparation_Click(object sender, RoutedEventArgs e)
        {
            Reservdel selectedReservdel = cbArtikelnummer.SelectedItem as Reservdel;

            int id = selectedReservdel.Artikelnummer;

            var reparation = new Reparation
            {
                Åtgärd = txtÅtgärd.Text,
                Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem,
            };
            reparationcontroller.CreateOrUpdateReparation(reparation, id);

            //reparationcontroller.AddReparation(reparation);
            //reparation.Reservdelar.Add(reservdel);
            //reparationcontroller.UpdateReparation(reparation);


            ResetForm();
        }
        private void LoadArtikelnummer()
        {
            // Hämta alla artikelnummer för reservdelarna
            artikelnummerList = new List<int>(reservdelcontroller.GetArtikelnummer());

            // Fyll ComboBoxen med artikelnummer
            foreach (int artikelnummer in artikelnummerList)
            {
                cbArtikelnummer.Items.Add(artikelnummer);
            }
        }
        private void ResetForm()
        {
            // Återställ alla inmatningsfält och ComboBoxen
            txtÅtgärd.Text = "";
            cbReparationsstatus.SelectedIndex = -1;
            cbArtikelnummer.SelectedIndex = -1;
        }
        private void cbArtikelnummer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbReparationsstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbReparationsstatus.SelectedItem != null)
            {
                var selectedSpecialisering = (Reparationsstatus)cbReparationsstatus.SelectedItem;
            }
        }
        private void FillComboBoxWithEnums()
        {
            cbReparationsstatus.ItemsSource = Enum.GetValues(typeof(Reparationsstatus));
        }
    }
}

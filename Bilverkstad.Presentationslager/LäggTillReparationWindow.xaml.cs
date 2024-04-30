using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Diagnostics;
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
        BokningsController bokningscontroller = new BokningsController();
        Reservdel reservdel = new Reservdel();
        private Bokning _selectedBokning;
        public int bokningsID;
        //Bokning updatedBokning = new Bokning();


        public LäggTillReparationWindow(Bokning bokning)
        {
            InitializeComponent();
            bokningsID = bokning.Id;
            _selectedBokning = bokning;
            this.DataContext = _selectedBokning;

            FillComboBoxWithEnums();
            LoadArtikelnummer();
            Reservdel.ItemsSource = reservdelcontroller.GetReservdel();
        }

        public void AddReparation_Click(object sender, RoutedEventArgs e)
        {

            ReservdelController ctrl = new ReservdelController();
            var reservdelen = ctrl.GetOneReservdel(cbArtikelnummer.SelectedIndex +1); // +1 för att index börjar på 0
            _selectedBokning = bokningscontroller.GetOneBokning(bokningsID);

            if (_selectedBokning != null)
            {
                var reparation = new Reparation
                {
                    Åtgärd = txtÅtgärd.Text,
                    Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem,
                    ReservdelId = reservdelen.Artikelnummer,
                    BokningsId = _selectedBokning.Id,                   
                };
                reparationcontroller.AddReparation(reparation);
                _selectedBokning.Reparation.Add(reparation);
                bokningscontroller.UpdateBokning(_selectedBokning);
                var hanterabokningWindow = Application.Current.Windows.OfType<HanteraBokningMekanikerWindow>().FirstOrDefault();
                if (hanterabokningWindow != null)
                {
                    hanterabokningWindow.ReloadData();
                }


            }
            else
            {                
                MessageBox.Show("Vänligen välj en reservdelen.");
            }

        }


        private void LoadArtikelnummer()
        {
            // Hämta alla reservdelar
            var reservdelar = reservdelcontroller.GetReservdel();

            // Fyll ComboBoxen med artikelnummer 
            foreach (var reservdel in reservdelar)
            {
                cbArtikelnummer.Items.Add(reservdel.Artikelnummer);
            }
        }

        private void cbArtikelnummer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbArtikelnummer.SelectedIndex != null) 
            {
                ReservdelController test = new ReservdelController();
                var selectedReservdel2 = test.GetOneReservdel(cbArtikelnummer.SelectedIndex +1);
                
                //Ändrade SelectedItem till SelectedIndex för att enkelt komma åt int enklare
                if (selectedReservdel2 != null)
                {                   
                    reservdel = selectedReservdel2;
                }
                else
                {
                    throw new InvalidOperationException("Det valda objektet är inte en instans av Reservdel.");
                }
            }
            else
            {
                throw new InvalidOperationException("Inget objekt är valt i comboboxen.");
            }

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

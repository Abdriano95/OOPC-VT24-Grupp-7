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
        
        
        
        public LäggTillReparationWindow()
        {
            InitializeComponent();
            FillComboBoxWithEnums();
            LoadArtikelnummer();
            Reservdel.ItemsSource = reservdelcontroller.GetReservdel();
        }
        //public void AddReparation_Click(object sender, RoutedEventArgs e)
        //{
        //    var reparation = new Reparation
        //    {
        //        Åtgärd = txtÅtgärd.Text,
        //        Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem,
        //        //Reservdel = (Reservdel)cbArtikelnummer.SelectedItem,
        //        Reservdel = (Reservdel)cbArtikelnummer.SelectedItem
        //        // Reservdelar
        //        // Mekaniker ID och kopplad till åtgärd
        //        //Bokning ID
        //    };

        //    //reparation.Reservdelar.Add(reservdel);
        //    //reparationcontroller.UpdateReparation(reparation);
        //    reparationcontroller.AddReparation(reparation);

        //    ResetForm();
        //}
        public void AddReparation_Click(object sender, RoutedEventArgs e)
        {
            ReservdelController test = new ReservdelController();
            var reservdelen = test.GetOneReservdel(cbArtikelnummer.SelectedIndex +1);
            //Reservdel reservdelen = new Reservdel();
            /*reservdelen = cbArtikelnummer.SelectedItem as Reservdel;*/ // Här är något knas

            if (reservdelen != null)
            {
                var reparation = new Reparation
                {
                    Åtgärd = txtÅtgärd.Text,
                    Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem,
                    ReservdelId = reservdelen.Artikelnummer,

                    // Fyll i övriga egenskaper för reparationen här, t.ex. Mekaniker ID och kopplad till åtgärd
                };
                reparationcontroller.AddReparation(reparation);
                
            }
            else
            {
                // Om ingen reservdel är vald, visa ett meddelande eller vidta annan lämplig åtgärd
                MessageBox.Show("Vänligen välj en reservdelen.");
            }
        }

        private void LoadArtikelnummer()
        {
            // Hämta alla reservdelar
            var reservdelar = reservdelcontroller.GetReservdel();

            // Fyll ComboBoxen med artikelnummer från de tillgängliga reservdelarna
            foreach (var reservdel in reservdelar)
            {
                cbArtikelnummer.Items.Add(reservdel.Artikelnummer);
            }
        }
        //private void LoadArtikelnummer()
        //{
        //    var reservdelar = reservdelcontroller.GetReservdel();
        //    cbArtikelnummer.ItemsSource = reservdelar;
        //    cbArtikelnummer.DisplayMemberPath = "Artikelnummer"; // Ange egenskapen som ska visas i comboboxen
        //}


                
       
        private void cbArtikelnummer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbArtikelnummer.SelectedIndex != null)
            {
                ReservdelController test = new ReservdelController();
                var selectedReservdel2 = test.GetOneReservdel(cbArtikelnummer.SelectedIndex);
                
                //Reservdel selectedReservdel2 = cbArtikelnummer.SelectedItem as Reservdel;
                //Ändrade SelectedItem till SelectedIndex
                if (selectedReservdel2 != null)
                {
                    // Gör något med den valda reservdelen
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

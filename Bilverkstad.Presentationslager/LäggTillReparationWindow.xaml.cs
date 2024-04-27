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
            
            
            var reparation = new Reparation
            {
                Åtgärd = txtÅtgärd.Text,
                Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem,
                
                // Reservdelar
                // Mekaniker ID och kopplad till åtgärd
                //Bokning ID
            };
            reparationcontroller.AddReparation(reparation);
            reparation.Reservdelar.Add(reservdel);
            reparationcontroller.UpdateReparation(reparation);
           
            
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
            input = cbArtikelnummer.Text;
            reservdel = reservdelcontroller.GetOneReservdel(input);
            if (reservdel1!= null)
            {
               reservdel = reservdel1;
                // Använd den valda artikelnumret här, till exempel spara det i en variabel eller använd det på annat sätt
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

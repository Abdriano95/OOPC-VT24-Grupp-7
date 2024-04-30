using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for KundFormulär.xaml
    /// </summary>
    public partial class KundFormulär : Window
    {
        
        private KundController kundContoller = new KundController();
        private Kund _selectedKund;

        public KundFormulär(Kund selectedKund)
        {
            InitializeComponent();
            _selectedKund = selectedKund;
            this.DataContext = _selectedKund;
            HämtaKundData(_selectedKund);
            
        }

        private void HämtaKundData(Kund selectedKund)
        {
            txtFörnamn.Text = selectedKund.Förnamn;
            txtEfternamn.Text = selectedKund.Efternamn;
            txtPersonnummer.Text = selectedKund.Personnummer;
            txtGatuadress.Text = selectedKund.Gatuadress;
            txtPostnummer.Text = selectedKund.Postnummer;
            txtOrt.Text = selectedKund.Ort;
            txtTelefonnummer.Text = selectedKund.Telefonnummer;
            txtEpost.Text = selectedKund.Epost;
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                kundContoller.UpdateKund(_selectedKund); 
                MessageBox.Show("Kund uppgifter är uppdaterade");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update booking: " + ex.Message);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LäggTillFordonWindow läggTillFordonWindow = new LäggTillFordonWindow(_selectedKund);
            läggTillFordonWindow.Show();
        }
    }
}

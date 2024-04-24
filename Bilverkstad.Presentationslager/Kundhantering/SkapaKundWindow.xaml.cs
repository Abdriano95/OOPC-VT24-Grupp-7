using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for SkapaKundWindow.xaml
    /// </summary>
    public partial class SkapaKundWindow : Window
    {
        KundController kundContoller = new KundController();
        Kund kund = new Kund();
        Kund nyskapadkund = new Kund();
        int lastAddedId;

        public SkapaKundWindow()
        {
            InitializeComponent();

        }

        public void AddKund_Click(object sender, RoutedEventArgs e)
        {
            kund = new Kund
            {
                Personnummer = txtPersonnummer.Text,
                Förnamn = txtFörnamn.Text,
                Efternamn = txtEfternamn.Text,
                Gatuadress = txtGatuadress.Text,
                Postnummer = txtPostnummer.Text,
                Ort = txtOrt.Text,
                Telefonnummer = txtTelefonnummer.Text,
                Epost = txtEpost.Text
            };

            kundContoller.AddKund(kund);
            nyskapadkund = kundContoller.GetOneKund(kund.Id);

            LäggTillFordonWindow läggTillFordonWindow = new LäggTillFordonWindow(nyskapadkund);
            läggTillFordonWindow.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //kund = kundContoller.GetOneKund(lastAddedId);
            LäggTillFordonWindow läggTillFordonWindow = new LäggTillFordonWindow(kund);
            läggTillFordonWindow.Show();


        }
    }
}

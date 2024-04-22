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
        KundContoller kundContoller = new KundContoller();
        public SkapaKundWindow()
        {
            InitializeComponent();

        }

        public void AddKund_Click(object sender, RoutedEventArgs e)
        {
            var kund = new Kund
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

        }
    }
}

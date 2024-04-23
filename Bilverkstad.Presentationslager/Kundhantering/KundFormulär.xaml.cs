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
        int inmatning;
        KundController contoller = new KundController();
        Kund kund = new Kund();
        public KundFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            kund = contoller.GetOneKund(inmatning);
            txtPersonnummer.Text = kund.Personnummer.ToString();
            txtFörnamn.Text = kund.Förnamn.ToString();
            txtEfternamn.Text = kund.Efternamn.ToString();
            txtGatuadress.Text = kund.Gatuadress.ToString();
            txtPostnummer.Text = kund.Postnummer.ToString();
            txtOrt.Text = kund.Ort.ToString();
            txtTelefonnummer.Text = kund.Telefonnummer.ToString();
            txtEpost.Text = kund.Epost.ToString();
        }
        public void Update_Click(object sender, RoutedEventArgs e)
        {
            kund = contoller.GetOneKund(inmatning);
            kund.Förnamn = txtFörnamn.Text;
            kund.Efternamn = txtEfternamn.Text;
            kund.Personnummer = txtPersonnummer.Text;
            kund.Gatuadress = txtGatuadress.Text;
            kund.Postnummer = txtPostnummer.Text;
            kund.Ort = txtOrt.Text;
            kund.Telefonnummer = txtTelefonnummer.Text;
            kund.Epost = txtEpost.Text;
            contoller.UpdateKund(kund);
        }

    }
}

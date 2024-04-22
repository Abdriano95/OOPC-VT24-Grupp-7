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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for KundFormulär.xaml
    /// </summary>
    public partial class KundFormulär : Window
    {
        int inmatning;
        KundContoller contoller = new KundContoller();
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

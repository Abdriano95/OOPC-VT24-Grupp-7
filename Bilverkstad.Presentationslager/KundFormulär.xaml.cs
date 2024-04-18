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
        public KundFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
        }
        public void Update_Click(object sender, RoutedEventArgs e)
        {
            KundContoller contoller = new KundContoller();    
            Kund kund = new Kund();  
            kund.Id = inmatning;
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

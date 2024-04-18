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
            var kund = new Kund {
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

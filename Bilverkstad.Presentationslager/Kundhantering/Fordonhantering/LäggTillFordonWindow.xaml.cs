using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;


namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillFordonWindow.xaml
    /// </summary>
    public partial class LäggTillFordonWindow : Window
    {
        KundController kundController = new KundController();
        FordonController fordController = new FordonController();
        Kund nySkapadKund = new Kund();
        int kundID;
        public LäggTillFordonWindow(Kund kund)
        {
            InitializeComponent();
            nySkapadKund = kundController.GetOneKund(kund.Id);
            kundID = nySkapadKund.Id;

        }

        private void LäggtillFordon_Click(object sender, RoutedEventArgs e)
        {
            // Hämta den korrekta kunden från databasen baserat på det angivna ID:t
            nySkapadKund = kundController.GetOneKund(kundID);

            if (nySkapadKund != null) // Kontrollera att kunden finns
            {
                // Skapa ett nytt fordon
                var fordon = new Fordon
                {
                    RegNr = txtRegNr.Text,
                    Bilmärke = txtBilmärke.Text,
                    Modell = txtModell.Text,
                    KundId = nySkapadKund.Id // Ange kundens ID för att upprätthålla referensintegritet
                };

                // Lägg till fordonet i databasen
                fordController.AddFordon(fordon);

                // Uppdatera kundens fordonslista
                nySkapadKund.Fordon.Add(fordon);
                kundController.UpdateKund(nySkapadKund);
            }
            else
            {
                MessageBox.Show("Kunden med angivet ID hittades inte i databasen.", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

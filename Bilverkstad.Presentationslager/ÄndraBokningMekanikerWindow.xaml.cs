using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraBokningMekanikerWindow.xaml
    /// </summary>
    public partial class ÄndraBokningMekanikerWindow : Window
    {
        private BokningsController bokningsController = new BokningsController();
        private MekanikerController mekan = new MekanikerController();

        private Bokning _selectedBokning;

        public ÄndraBokningMekanikerWindow(Bokning selectedBokning)
        {
            InitializeComponent();
            _selectedBokning = selectedBokning;
            this.DataContext = _selectedBokning;
            HämtaBokningData(_selectedBokning);
        }

        private void HämtaBokningData(Bokning bokning)
        {
            bokningsListBox.ItemsSource = new List<Bokning> { bokning };
        }

        private void HämtaReparationsData(Reparation reparation)
        {
            reparationsListBox.ItemsSource = new List<Reparation> { reparation };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            LäggTillReparationWindow window = new LäggTillReparationWindow(_selectedBokning); // Skicka med bokning och i konstruktorn.
            window.Show();
        }

    }
}


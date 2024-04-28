using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillReceptionistWindow.xaml
    /// </summary>
    public partial class LäggTillReceptionistWindow : Window
    {
        ReceptionistController controller = new ReceptionistController();
        Receptionist receptionist = new Receptionist();
        public LäggTillReceptionistWindow()
        {
            InitializeComponent();
            FillComboBoxWithEnums();
        }
        public void AddReceptionist_Click(object sender, RoutedEventArgs e)
        {
            var receptionist = new Receptionist
            {
                Förnamn = txtFörnamn.Text,
                Efternamn = txtEfternamn.Text,
                Lösenord = txtLösenord.Text,
                Auktoritet = (Auktoritet)cbAdmin.SelectedItem

            };
            controller.AddReceptionist(receptionist);
        }
        private void cbAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAdmin.SelectedItem != null)
            {
                var selectedSpecialisering = (Auktoritet)cbAdmin.SelectedItem;
            }
        }
        private void FillComboBoxWithEnums()
        {
            cbAdmin.ItemsSource = Enum.GetValues(typeof(Auktoritet));
        }
    }
}

using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillMekanikerWindow.xaml
    /// </summary>
    public partial class LäggTillMekanikerWindow : Window
    {
        MekanikerController controller = new MekanikerController();
        public LäggTillMekanikerWindow()
        {
            InitializeComponent();
            FillComboBoxWithEnums();
        }
        public void AddMekaniker_Click(object sender, RoutedEventArgs e)
        {
            var mekaniker = new Mekaniker
            {
                Förnamn = txtFörnamn.Text,
                Efternamn = txtEfternamn.Text,
                Lösenord = txtLösenord.Text,
                Specialiseringar = (Specialiseringar)cbSpecialiseringar.SelectedItem
            };
            controller.AddMekaniker(mekaniker);
        }
        private void cbSpecialiseringar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSpecialiseringar.SelectedItem != null)
            {
                var selectedSpecialisering = (Specialiseringar)cbSpecialiseringar.SelectedItem;
            }
        }
        private void FillComboBoxWithEnums()
        {
            cbSpecialiseringar.ItemsSource = Enum.GetValues(typeof(Specialiseringar));
        }
    }
}

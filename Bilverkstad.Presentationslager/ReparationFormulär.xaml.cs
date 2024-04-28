using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for ReparationFormulär.xaml
    /// </summary>
    public partial class ReparationFormulär : Window
    {
        int inmatning;
        ReparationController controller = new ReparationController();
        Reparation reparation = new Reparation();
        public ReparationFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            reparation = controller.GetOneReparation(inmatning);
            txtÅtgärd.Text = reparation.Åtgärd.ToString();
            FillComboBoxWithEnums();
            cbReparationsstatus.SelectedItem = reparation.Reparationsstatus;
        }

        public void UpdateReparation_Click(object sender, RoutedEventArgs e)
        {
            reparation = controller.GetOneReparation(inmatning);
            reparation.Åtgärd = txtÅtgärd.Text;
            reparation.Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem; // Uppdatera reparationens Reparationsstatus
            controller.UpdateReparation(reparation);
        }

        private void cbReparationsstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbReparationsstatus.SelectedItem != null)
            {
                var selectedReparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem;
            }
        }

        private void FillComboBoxWithEnums()
        {
            cbReparationsstatus.ItemsSource = Enum.GetValues(typeof(Reparationsstatus));
        }
    }
}

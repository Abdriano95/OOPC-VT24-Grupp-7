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
    /// Interaction logic for LäggTillReparationWindow.xaml
    /// </summary>
    public partial class LäggTillReparationWindow : Window
    {
        ReparationController controller = new ReparationController();
        public LäggTillReparationWindow()
        {
            InitializeComponent();
            FillComboBoxWithEnums();
        }
        public void AddReparation_Click(object sender, RoutedEventArgs e)
        {
            var reparation = new Reparation
            {
                Åtgärd = txtÅtgärd.Text,
                Reparationsstatus = (Reparationsstatus)cbReparationsstatus.SelectedItem
                //Bokning ID
                // Reservdelar
                // Mekaniker ID och kopplad till åtgärd
            };
            controller.AddReparation(reparation);
        }
        private void cbReparationsstatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbReparationsstatus.SelectedItem != null)
            {
                var selectedSpecialisering = (Reparationsstatus)cbReparationsstatus.SelectedItem;
            }
        }
        private void FillComboBoxWithEnums()
        {
            cbReparationsstatus.ItemsSource = Enum.GetValues(typeof(Reparationsstatus));
        }
    }
}

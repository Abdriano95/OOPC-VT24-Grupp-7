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
    /// Interaction logic for TaBortReparationWindow.xaml
    /// </summary>
    public partial class TaBortReparationWindow : Window
    {
        ReparationController controller = new ReparationController();
        public TaBortReparationWindow()
        {
            InitializeComponent();
            Reparation.ItemsSource = controller.GetReparation();
        }
        public void TaBortReparation_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Reparation befintligReparation = new Reparation();
            befintligReparation.ReparationsId = int.Parse(inmatning);
            controller.DeleteReparation(befintligReparation);
        }
    }
}

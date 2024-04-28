using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

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

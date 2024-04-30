using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaReparationerWindow.xaml
    /// </summary>
    public partial class VisaReparationerWindow : Window
    {
        public VisaReparationerWindow()
        {
            InitializeComponent();
            ReparationController reparationController = new ReparationController();
            reparation.ItemsSource = reparationController.GetReparation();
        }
    }
}

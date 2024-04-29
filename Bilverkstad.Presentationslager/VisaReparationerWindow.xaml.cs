using Bilverkstad.Affärslager;
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
            Reparation.ItemsSource = reparationController.GetReparation();
        }
    }
}

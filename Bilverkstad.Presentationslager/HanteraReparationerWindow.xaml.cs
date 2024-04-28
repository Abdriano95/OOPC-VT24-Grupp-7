using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraReparationerWindow.xaml
    /// </summary>
    public partial class HanteraReparationerWindow : Window
    {
        public HanteraReparationerWindow()
        {
            InitializeComponent();
        }
        public void VisaReparation_Clicked(object sender, RoutedEventArgs e)
        {
            VisaReparationerWindow visaReparationerWindow = new VisaReparationerWindow();
            visaReparationerWindow.Show();
        }

        public void LäggTillReparation_Clicked(object sender, RoutedEventArgs e)
        {
            LäggTillReparationWindow läggTillReparationWindow = new LäggTillReparationWindow();
            läggTillReparationWindow.Show();
        }

        public void TaBortReparation_Clicked(object sender, RoutedEventArgs e)
        {
            TaBortReparationWindow tabortReparationWindow = new TaBortReparationWindow();
            tabortReparationWindow.Show();
        }
        public void UppdateraReparation_Clicked(object sender, RoutedEventArgs e)
        {
            UppdateraReparationerWindow uppdateraReparation = new UppdateraReparationerWindow();
            uppdateraReparation.Show();
        }
    }
}

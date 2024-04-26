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

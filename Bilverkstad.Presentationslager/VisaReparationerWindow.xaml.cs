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

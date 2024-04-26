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
    /// Interaction logic for UppdateraReparationerWindow.xaml
    /// </summary>
    public partial class UppdateraReparationerWindow : Window
    {
        ReparationController controller = new ReparationController();
        public UppdateraReparationerWindow()
        {
            InitializeComponent();
            Reparation.ItemsSource = controller.GetReparation();
        }
        public void UppdateraReparation_Click(object sender, RoutedEventArgs e)
        {

            ReparationFormulär reparationsFormulär = new ReparationFormulär(inputtxt.Text);
            reparationsFormulär.Show();
        }
    }
}

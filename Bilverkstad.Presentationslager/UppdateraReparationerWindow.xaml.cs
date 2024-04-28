using Bilverkstad.Affärslager;
using System.Windows;

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

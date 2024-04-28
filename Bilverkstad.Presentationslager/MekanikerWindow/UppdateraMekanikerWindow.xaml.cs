using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for UppdateraMekanikerWindow.xaml
    /// </summary>
    public partial class UppdateraMekanikerWindow : Window
    {
        MekanikerController controller = new MekanikerController();
        public UppdateraMekanikerWindow()
        {
            InitializeComponent();
            Mekaniker.ItemsSource = controller.GetMekaniker();
        }
        public void UppdateraMekaniker_Click(object sender, RoutedEventArgs e)
        {

            MekanikerFormulär mekanikerFormulär = new MekanikerFormulär(inputtxt.Text);
            mekanikerFormulär.Show();
        }
    }
}

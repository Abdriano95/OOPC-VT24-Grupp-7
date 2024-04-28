using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortMekanikerWindow.xaml
    /// </summary>
    public partial class TaBortMekanikerWindow : Window
    {
        MekanikerController controller = new MekanikerController();
        public TaBortMekanikerWindow()
        {
            InitializeComponent();
            Mekaniker.ItemsSource = controller.GetMekaniker();
        }
        public void TaBortMekaniker_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Mekaniker befintligMekaniker = new Mekaniker();
            befintligMekaniker.AnställningsNummer = int.Parse(inmatning);
            controller.DeleteMekaniker(befintligMekaniker);
        }
    }
}

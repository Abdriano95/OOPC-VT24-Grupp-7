using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortAnställdWindow.xaml
    /// </summary>
    public partial class TaBortAnställdWindow : Window
    {
        AnställdController controller = new AnställdController();
        public TaBortAnställdWindow()
        {
            InitializeComponent();
            Anställda.ItemsSource = controller.GetAnställd();
        }


        public void TaBortAnställd_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Anställd befintligAnställd = new Anställd();
            befintligAnställd.AnställningsNummer = int.Parse(inmatning);
            controller.DeleteAnställd(befintligAnställd);
        }
    }
}

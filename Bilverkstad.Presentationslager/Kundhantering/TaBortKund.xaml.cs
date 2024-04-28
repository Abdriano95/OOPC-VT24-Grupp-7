using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortKund.xaml
    /// </summary>
    public partial class TaBortKund : Window
    {
        KundController controller = new KundController();

        public TaBortKund()
        {
            InitializeComponent();
            Kunder.ItemsSource = controller.GetKundWithFordon();
        }
        public void TaBortKund_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Kund befintligKund = new Kund();
            befintligKund.Id = int.Parse(inmatning);
            controller.DeleteKund(befintligKund);
        }
    }
}

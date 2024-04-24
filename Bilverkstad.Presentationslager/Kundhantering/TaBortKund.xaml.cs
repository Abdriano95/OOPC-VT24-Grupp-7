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
        KundContoller controller = new KundContoller();
        
        public TaBortKund()
        {
            InitializeComponent();
            Kunder.ItemsSource = controller.GetKund();
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

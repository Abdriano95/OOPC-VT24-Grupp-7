using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortReceptionistWindow.xaml
    /// </summary>
    public partial class TaBortReceptionistWindow : Window
    {
        ReceptionistController controller = new ReceptionistController();
        public TaBortReceptionistWindow()
        {
            InitializeComponent();
            Receptionist.ItemsSource = controller.GetReceptionist();
        }
        public void TaBortReceptionist_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Receptionist befintligReceptionist = new Receptionist();
            befintligReceptionist.AnställningsNummer = int.Parse(inmatning);
            controller.DeleteReceptionist(befintligReceptionist);
        }
    }
}

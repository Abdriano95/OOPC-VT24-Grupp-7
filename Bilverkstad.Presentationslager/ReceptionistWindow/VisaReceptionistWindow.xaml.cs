using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaReceptionistWindow.xaml
    /// </summary>
    public partial class VisaReceptionistWindow : Window
    {
        public VisaReceptionistWindow()
        {
            InitializeComponent();
            ReceptionistController receptionistController = new ReceptionistController();
            Receptionist.ItemsSource = receptionistController.GetReceptionist();
        }
    }
}

using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for UppdateraReceptionistWindow.xaml
    /// </summary>
    public partial class UppdateraReceptionistWindow : Window
    {
        ReceptionistController controller = new ReceptionistController();
        public UppdateraReceptionistWindow()
        {
            InitializeComponent();
            Receptionist.ItemsSource = controller.GetReceptionist();
        }
        public void UppdateraReceptionist_Click(object sender, RoutedEventArgs e)
        {

            ReceptionistFormulär receptionistFormulär = new ReceptionistFormulär(inputtxt.Text);
            receptionistFormulär.Show();
        }
    }
}

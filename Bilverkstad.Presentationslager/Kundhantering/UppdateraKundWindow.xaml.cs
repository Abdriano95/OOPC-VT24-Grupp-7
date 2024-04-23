using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for UppdateraKundWindow.xaml
    /// </summary>
    public partial class UppdateraKundWindow : Window
    {
        KundController controller = new KundController();
        public UppdateraKundWindow()
        {
            InitializeComponent();
            Kunder.ItemsSource = controller.GetKund();
        }
        public void UppdateraKund_Click(object sender, RoutedEventArgs e)
        {

            KundFormulär kundFormulär = new KundFormulär(inputtxt.Text);
            kundFormulär.Show();
        }
    }
}

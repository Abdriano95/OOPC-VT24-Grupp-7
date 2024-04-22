using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for UppdateraAnställdWindow.xaml
    /// </summary>
    public partial class UppdateraAnställdWindow : Window
    {
        AnställdController controller = new AnställdController();
        public UppdateraAnställdWindow()
        {
            InitializeComponent();
            Anställda.ItemsSource = controller.GetAnställd();
        }
        public void UppdateraAnställd_Click(object sender, RoutedEventArgs e)
        {

            AnställdFormulär anställdFormulär = new AnställdFormulär(inputtxt.Text);
            anställdFormulär.Show();
        }
    }
}

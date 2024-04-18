using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bilverkstad.Presentationslager
{
 
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
 ;
        }


        public void VisaKund_Clicked (object sender, RoutedEventArgs e) 
        {
            VisaKunderWindow visaKunderWindow = new VisaKunderWindow();
            visaKunderWindow.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
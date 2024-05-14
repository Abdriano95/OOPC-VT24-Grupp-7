using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{

    public partial class HanteraKunderWindow : Window
    {

        public HanteraKunderWindow()
        {
            InitializeComponent();

        }


        public void VisaKund_Clicked(object sender, RoutedEventArgs e)
        {
            VisaKunderWindow visaKunderWindow = new VisaKunderWindow();
            visaKunderWindow.Show();
        }


        public void LäggTillKund_Clicked(object sender, RoutedEventArgs e)
        {
            SkapaKundWindow skapaKundWindow = new SkapaKundWindow();
            skapaKundWindow.Show();
        }

        public void TaBortKund_Clicked(object sender, RoutedEventArgs e)
        {
            TaBortKund tabortkund = new TaBortKund();
            tabortkund.Show();
        }
        public void UppdateraKund_Clicked(object sender, RoutedEventArgs e)
        {
            UppdateraKundWindow uppdateraKund = new UppdateraKundWindow();
            uppdateraKund.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
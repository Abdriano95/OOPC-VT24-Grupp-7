using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaKunderWindow.xaml
    /// </summary>
    public partial class VisaKunderWindow : Window
    {
        public VisaKunderWindow()
        {
            InitializeComponent();
            KundContoller kundContoller = new KundContoller();
            Kunder.ItemsSource = kundContoller.GetKund();
        }



    }
}

using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraReservdelarWindow.xaml
    /// </summary>
    public partial class HanteraReservdelarWindow : Window
    {
        public HanteraReservdelarWindow()
        {
            InitializeComponent();
        }
        public void VisaReservdel_Clicked(object sender, RoutedEventArgs e)
        {
            VisaReservdelWindow visaReservdelWindow = new VisaReservdelWindow();
            visaReservdelWindow.Show();
        }

        public void LäggTillReservdel_Clicked(object sender, RoutedEventArgs e)
        {
            LäggTillReservdelWindow läggTillReservdelWindow = new LäggTillReservdelWindow();
            läggTillReservdelWindow.Show();
        }

        public void TaBortReservdel_Clicked(object sender, RoutedEventArgs e)
        {
            TaBortReservdelWindow tabortReservdelWindow = new TaBortReservdelWindow();
            tabortReservdelWindow.Show();
        }
        public void UppdateraReservdel_Clicked(object sender, RoutedEventArgs e)
        {
            UppdateraReservdelWindow uppdateraReservdel = new UppdateraReservdelWindow();
            uppdateraReservdel.Show();
        }
    }
}

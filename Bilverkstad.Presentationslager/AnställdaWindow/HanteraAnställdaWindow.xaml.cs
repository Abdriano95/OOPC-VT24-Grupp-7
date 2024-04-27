using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaAnställdaWindow.xaml
    /// </summary>
    public partial class HanteraAnställdaWindow : Window
    {
        public HanteraAnställdaWindow()
        {
            InitializeComponent();
        }
        public void VisaReceptionist_Clicked(object sender, RoutedEventArgs e)
        {
            VisaReceptionistWindow visaReceptionistWindow = new VisaReceptionistWindow();
            visaReceptionistWindow.Show();
        }

        public void LäggTillReceptionist_Clicked(object sender, RoutedEventArgs e)
        {
            LäggTillReceptionistWindow läggTillReceptionistWindow = new LäggTillReceptionistWindow();
            läggTillReceptionistWindow.Show();
        }
        public void TaBortReceptionist_Clicked(object sender, RoutedEventArgs e)
        {
            TaBortReceptionistWindow taBortReceptionistWindow = new TaBortReceptionistWindow();
            taBortReceptionistWindow.Show();
        }
        public void UppdateraReceptionist_Clicked(object sender, RoutedEventArgs e)
        {
            UppdateraReceptionistWindow uppdateraReceptionistWindow = new UppdateraReceptionistWindow();
            uppdateraReceptionistWindow.Show();
        }

        public void VisaMekaniker_Clicked(object sender, RoutedEventArgs e)
        {
            VisaMekanikerWindow visaMekanikerWindow = new VisaMekanikerWindow();
            visaMekanikerWindow.Show();
        }

        public void LäggTillMekaniker_Clicked(object sender, RoutedEventArgs e)
        {
            LäggTillMekanikerWindow läggTillMekanikerWindow = new LäggTillMekanikerWindow();
            läggTillMekanikerWindow.Show();
        }
        public void TaBortMekaniker_Clicked(object sender, RoutedEventArgs e)
        {
            TaBortMekanikerWindow taBortMekanikerWindow = new TaBortMekanikerWindow();
            taBortMekanikerWindow.Show();
        }
        public void UppdateraMekaniker_Clicked(object sender, RoutedEventArgs e)
        {
            UppdateraMekanikerWindow uppdateraMekanikerWindow = new UppdateraMekanikerWindow();
            uppdateraMekanikerWindow.Show();
        }
    }
}

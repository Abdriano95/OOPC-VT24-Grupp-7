using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaMekanikerWindow.xaml
    /// </summary>
    public partial class VisaMekanikerWindow : Window
    {
        public VisaMekanikerWindow()
        {
            InitializeComponent();
            MekanikerController mekanikerController = new MekanikerController();
            Mekaniker.ItemsSource = mekanikerController.GetMekaniker();
        }
    }
}

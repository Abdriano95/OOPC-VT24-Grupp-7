using Bilverkstad.Affärslager;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for VisaAnställdaWindow.xaml
    /// </summary>
    public partial class VisaAnställdaWindow : Window
    {
        public VisaAnställdaWindow()
        {
            InitializeComponent();
            AnställdController anställdController = new AnställdController();
            Anställda.ItemsSource = anställdController.GetAnställd();
        }
    }
}

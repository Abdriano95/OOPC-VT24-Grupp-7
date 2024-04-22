using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for TaBortMekanikerWindow.xaml
    /// </summary>
    public partial class TaBortMekanikerWindow : Window
    {
        MekanikerController controller = new MekanikerController();
        public TaBortMekanikerWindow()
        {
            InitializeComponent();
            Mekaniker.ItemsSource = controller.GetMekaniker();
        }
        public void TaBortMekaniker_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Mekaniker befintligMekaniker = new Mekaniker();
            befintligMekaniker.AnställningsNummer = int.Parse(inmatning);
            controller.DeleteMekaniker(befintligMekaniker);
        }
    }
}

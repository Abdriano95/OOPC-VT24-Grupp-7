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
    /// Interaction logic for TaBortKund.xaml
    /// </summary>
    public partial class TaBortKund : Window
    {
        KundContoller controller = new KundContoller();
        
        public TaBortKund()
        {
            InitializeComponent();
            Kunder.ItemsSource = controller.GetKund();
        }
        public void TaBortKund_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Kund befintligKund = new Kund();
            befintligKund.Id = int.Parse(inmatning);            
            controller.DeleteKund(befintligKund);
        }
    }
}

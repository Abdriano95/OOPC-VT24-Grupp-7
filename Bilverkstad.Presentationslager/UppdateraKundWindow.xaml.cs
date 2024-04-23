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
    /// Interaction logic for UppdateraKundWindow.xaml
    /// </summary>
    public partial class UppdateraKundWindow : Window
    {
        KundController controller = new KundController();
        public UppdateraKundWindow()
        {
            InitializeComponent();
            Kunder.ItemsSource = controller.GetKund();
        }
        public void UppdateraKund_Click(object sender, RoutedEventArgs e)
        {

            KundFormulär kundFormulär = new KundFormulär(inputtxt.Text);
            kundFormulär.Show();
        }
    }
}

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
    /// Interaction logic for TaBortReceptionistWindow.xaml
    /// </summary>
    public partial class TaBortReceptionistWindow : Window
    {
        ReceptionistController controller = new ReceptionistController();
        public TaBortReceptionistWindow()
        {
            InitializeComponent();
            Receptionist.ItemsSource = controller.GetReceptionist();
        }
        public void TaBortReceptionist_Click(object sender, RoutedEventArgs e)
        {
            string inmatning = inputtxt.Text;
            Receptionist befintligReceptionist = new Receptionist();
            befintligReceptionist.AnställningsNummer = int.Parse(inmatning);
            controller.DeleteReceptionist(befintligReceptionist);
        }
    }
}

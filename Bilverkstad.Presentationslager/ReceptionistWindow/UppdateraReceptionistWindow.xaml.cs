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
    /// Interaction logic for UppdateraReceptionistWindow.xaml
    /// </summary>
    public partial class UppdateraReceptionistWindow : Window
    {
        ReceptionistController controller = new ReceptionistController();
        public UppdateraReceptionistWindow()
        {
            InitializeComponent();
            Receptionist.ItemsSource = controller.GetReceptionist();
        }
        public void UppdateraReceptionist_Click(object sender, RoutedEventArgs e)
        {

            ReceptionistFormulär receptionistFormulär = new ReceptionistFormulär(inputtxt.Text);
            receptionistFormulär.Show();
        }
    }
}

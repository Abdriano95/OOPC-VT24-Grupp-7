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
    /// Interaction logic for ReceptionistFormulär.xaml
    /// </summary>
    public partial class ReceptionistFormulär : Window
    {
        int inmatning;
        ReceptionistController controller = new ReceptionistController();
        Receptionist receptionist = new Receptionist();
        public ReceptionistFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            receptionist = controller.GetOneReceptionist(inmatning);
            txtFörnamn.Text = receptionist.Förnamn.ToString();
            txtEfternamn.Text = receptionist.Efternamn.ToString();
            txtLösenord.Text = receptionist.Lösenord.ToString();
        }
        public void UpdateReceptionist_Click(object sender, RoutedEventArgs e)
        {
            receptionist = controller.GetOneReceptionist(inmatning);
            receptionist.Förnamn = txtFörnamn.Text;
            receptionist.Efternamn = txtEfternamn.Text;
            receptionist.Lösenord = txtLösenord.Text;
            controller.UpdateReceptionist(receptionist);
        }
    }
}

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
    /// Interaction logic for MekanikerFormulär.xaml
    /// </summary>
    public partial class MekanikerFormulär : Window
    {
        int inmatning;
        MekanikerController controller = new MekanikerController();
        Mekaniker mekaniker = new Mekaniker();
        public MekanikerFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            mekaniker = controller.GetOneMekaniker(inmatning);
            txtFörnamn.Text = mekaniker.Förnamn.ToString();
            txtEfternamn.Text = mekaniker.Efternamn.ToString();
            txtLösenord.Text = mekaniker.Lösenord.ToString();
        }
        public void UpdateMekaniker_Click(object sender, RoutedEventArgs e)
        {
            mekaniker = controller.GetOneMekaniker(inmatning);
            mekaniker.Förnamn = txtFörnamn.Text;
            mekaniker.Efternamn = txtEfternamn.Text;
            mekaniker.Lösenord = txtLösenord.Text;
            controller.UpdateMekaniker(mekaniker);
        }
    }
}

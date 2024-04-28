using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

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

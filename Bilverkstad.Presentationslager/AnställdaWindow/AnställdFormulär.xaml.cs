using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{

    public partial class AnställdFormulär : Window
    {
        int inmatning;
        AnställdController controller = new AnställdController();
        Anställd anställd = new Anställd();
        public AnställdFormulär(string data)
        {
            InitializeComponent();
            inmatning = int.Parse(data);
            anställd = controller.GetOneAnställd(inmatning);
            txtFörnamn.Text = anställd.Förnamn.ToString();
            txtEfternamn.Text = anställd.Efternamn.ToString();
            txtLösenord.Text = anställd.Lösenord.ToString();
        }
        public void UpdateAnställd_Click(object sender, RoutedEventArgs e)
        {
            anställd = controller.GetOneAnställd(inmatning);
            anställd.Förnamn = txtFörnamn.Text;
            anställd.Efternamn = txtEfternamn.Text;
            anställd.Lösenord = txtLösenord.Text;
            controller.UpdateAnställd(anställd);
        }
    }



}

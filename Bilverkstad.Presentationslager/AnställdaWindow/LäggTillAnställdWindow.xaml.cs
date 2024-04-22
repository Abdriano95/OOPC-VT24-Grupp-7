using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for LäggTillAnställdWindow.xaml
    /// </summary>
    public partial class LäggTillAnställdWindow : Window
    {
        AnställdController anställdController = new AnställdController();
        public LäggTillAnställdWindow()
        {
            InitializeComponent();
        }
        public void AddAnställd_Click(object sender, RoutedEventArgs e)
        {
            var anställd = new Anställd
            {
                Förnamn = txtFörnamn.Text,
                Efternamn = txtEfternamn.Text,
                Lösenord = txtLösenord.Text,
            };

            anställdController.AddAnställd(anställd);

        }
    }
}

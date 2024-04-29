using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.HanteraBokningWindow;
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
    /// Interaction logic for HanteraBokningMekanikerWindow.xaml
    /// </summary>
    public partial class HanteraBokningMekanikerWindow : Window
    {
        private readonly BokningsController bokningsController;
        private readonly MekanikerController mekanikerController;

        public HanteraBokningMekanikerWindow()
        {
            InitializeComponent();
            bokningsController = new BokningsController();
            mekanikerController = new MekanikerController();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string anställningsnummerStr = txtAnställningsNummer.Text;
            int anställningsnummerInt;

            if (int.TryParse(anställningsnummerStr, out anställningsnummerInt))
            {
                Mekaniker mekaniker = mekanikerController.GetOneMekaniker(anställningsnummerInt);

                if (mekaniker != null)
                {
                    IList<Bokning> mekanikernsBokningar = bokningsController.GetBokningarByAnställningsnummer(mekaniker.AnställningsNummer);
                    cmbBokning.ItemsSource = mekanikernsBokningar;
                }
                else
                {
                    MessageBox.Show("Mekaniker med angivet anställningsnummer hittades inte.");
                }
            }
            else
            {
                MessageBox.Show("Felaktigt format på anställningsnummer.");
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bokning valdBokning = cmbBokning.SelectedItem as Bokning;

            if (valdBokning != null)
            {
                ÄndraBokningMekanikerWindow ändraBokningMekanikerWindow = new ÄndraBokningMekanikerWindow(valdBokning);
                ändraBokningMekanikerWindow.Show();
            }
            else
            {
                MessageBox.Show("Vänligen välj en bokning.");
            }
        }
    }
}

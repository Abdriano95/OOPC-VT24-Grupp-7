using System.Windows;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NavigationComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)navigationComboBox.SelectedItem;
            if (selectedItem != null)
            {
                string option = selectedItem.Content.ToString();
                switch (option)
                {
                    case "Hantera Kunder":
                        OpenWindow1();
                        break;
                    case "Hantera Anställda":
                        OpenWindow2();
                        break;
                    case "Hantera Reservdelar":
                        OpenWindow3();
                        break;
                    case "Hantera Reparationer":
                        OpenWindow4();
                        break;
                    default:
                        break;
                    case "Hantera Bokning":
                        OpenWindow5();
                        break;

                }
            }
        }



        private void OpenWindow1()
        {
            HanteraKunderWindow hanteraKunder = new HanteraKunderWindow();
            hanteraKunder.Show();
        }

        private void OpenWindow2()
        {
            HanteraAnställdaWindow hanteraAnställda = new HanteraAnställdaWindow();
            hanteraAnställda.Show();
        }
        private void OpenWindow3()
        {
            HanteraReservdelarWindow hanteraReservdelar = new HanteraReservdelarWindow();
            hanteraReservdelar.Show();
        }
        private void OpenWindow4()
        {
            HanteraReparationerWindow hanteraReparationer = new HanteraReparationerWindow();
            hanteraReparationer.Show();
        }
        private void OpenWindow5()
        {
            HanteraBokningarWindow hanteraBokningar = new HanteraBokningarWindow();
            hanteraBokningar.Show();
        }


    }


}


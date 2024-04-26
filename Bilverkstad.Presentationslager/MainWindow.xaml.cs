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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    default:
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

    }


}


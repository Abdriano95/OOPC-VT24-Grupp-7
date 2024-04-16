using Bilverkstad.Affärslager;
using Bilverkstad.Datalager;
using Bilverkstad.Presentationslager.ViewModel;
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
    /// Interaction logic for VisaKunderWindow.xaml
    /// </summary>
    public partial class VisaKunderWindow : Window
    {
        public VisaKunderWindow()
        {
            InitializeComponent();
            KundContoller kundContoller = new KundContoller();
            Kunder.ItemsSource = kundContoller.GetKund();
        }

         

    }
}

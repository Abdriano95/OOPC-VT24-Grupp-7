using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ReservdelsHantering.xaml
    /// </summary>
    public partial class ReservdelsHantering : UserControl
    {       
        public ReservdelsHantering()
        {
            InitializeComponent();
            DataContext = new ReservdelHanteringViewModel();
        }
    }
}

using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ReparationsHantering.xaml
    /// </summary>
    public partial class ReparationsHantering : UserControl
    {
        public ReparationsHantering()
        {
            InitializeComponent();
            DataContext = new ReparationsHanteringViewModel();

        }
    }
}

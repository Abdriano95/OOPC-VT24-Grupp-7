using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for KundHantering.xaml
    /// </summary>
    public partial class KundHantering : UserControl
    {
        public KundHantering()
        {
            InitializeComponent();
            DataContext = new KundHanteringViewModel();
        }   
    }
}

using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
   
    public partial class KundHantering : UserControl
    {
        public KundHantering()
        {
            InitializeComponent();
            DataContext = new KundHanteringViewModel();
        }
    }
}

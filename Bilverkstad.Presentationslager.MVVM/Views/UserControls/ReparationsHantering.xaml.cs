using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
   
    public partial class ReparationsHantering : UserControl
    {
        public ReparationsHantering()
        {
            InitializeComponent();
            DataContext = new ReparationsHanteringViewModel();
        }
    }
}

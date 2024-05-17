using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    
    public partial class BokningsHantering : UserControl
    {

        public BokningsHantering()
        {
            InitializeComponent();
            DataContext = new BokningsHanteringViewModel();
        }

    }
}

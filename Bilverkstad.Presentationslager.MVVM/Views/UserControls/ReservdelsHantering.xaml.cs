using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;

namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    
    public partial class ReservdelsHantering : UserControl
    {
        public ReservdelsHantering()
        {
            InitializeComponent();
            DataContext = new ReservdelHanteringViewModel();
        }
    }
}

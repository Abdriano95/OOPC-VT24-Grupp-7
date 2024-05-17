using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    
    public partial class PersonalHantering : UserControl
    {
        public PersonalHantering()
        {
            InitializeComponent();
            DataContext = new PersonalHanteringViewModel();
        }   
    }
}

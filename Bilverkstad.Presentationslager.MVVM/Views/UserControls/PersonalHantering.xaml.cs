using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PersonalHantering.xaml
    /// </summary>
    public partial class PersonalHantering : UserControl
    {
        public PersonalHantering()
        {
            InitializeComponent();
            DataContext = new PersonalHanteringViewModel();
        }   
    }
}

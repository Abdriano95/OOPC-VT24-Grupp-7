using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BokningsHantering.xaml
    /// </summary>
    public partial class BokningsHantering : UserControl
    {

        public string UserRole { get; set; } // Receptionist, Mechanic, Admin
        public BokningsHantering()
        {
            InitializeComponent();
        }

    }
}

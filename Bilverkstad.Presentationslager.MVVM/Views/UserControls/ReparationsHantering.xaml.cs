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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reparationen är nu bokad!");
        }
    }
}

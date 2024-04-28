using Bilverkstad.Presentationslager.HanteraBokningWindow;
using System.Windows;

namespace Bilverkstad.Presentationslager
{
    /// <summary>
    /// Interaction logic for HanteraBokningWindow.xaml
    /// </summary>
    public partial class HanteraBokningarWindow : Window
    {
        public HanteraBokningarWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SkapaBokningWindow skapaBokningWindow = new SkapaBokningWindow();
            skapaBokningWindow.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ÄndraBokningWindow ändraBokningWindow = new ÄndraBokningWindow();
            ändraBokningWindow.Show();

        }
    }
}

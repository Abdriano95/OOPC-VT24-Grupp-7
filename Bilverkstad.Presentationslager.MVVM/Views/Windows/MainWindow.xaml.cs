using System.Windows;
using Bilverkstad.Presentationslager.MVVM.ViewModels;
namespace Bilverkstad.Presentationslager.MVVM.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}

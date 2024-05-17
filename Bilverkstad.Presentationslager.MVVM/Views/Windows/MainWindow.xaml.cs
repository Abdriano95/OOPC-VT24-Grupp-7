using Bilverkstad.Presentationslager.MVVM.ViewModels;
using System.Windows;
namespace Bilverkstad.Presentationslager.MVVM.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}

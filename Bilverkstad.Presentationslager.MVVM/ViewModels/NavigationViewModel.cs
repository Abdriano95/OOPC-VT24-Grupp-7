using Bilverkstad.Affärslager;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class NavigationViewModel : ObservableObject
    {
        //private object _currentView;

        //public object CurrentView
        //{
        //    get => _currentView;
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged();  // Ensure this matches the method name in your ObservableObject
        //    }
        //}

        //// Properties for each UserControl as part of the tabs
        //public object KunderView { get; private set; }
        //public object BokningarView { get; private set; }
        //public object ReservdelarView { get; private set; }
        //public object PersonalView { get; private set; }


        //public NavigationViewModel()
        //{
        //    // Assuming you have some way to access or create an AnställdController instance
        //    AnställdController controller = new AnställdController();
        //    LoginViewModel loginViewModel = new LoginViewModel(controller);
        //    loginViewModel.LoginSuccessful += OnLoginSuccessful;
        //    // Initialize views for tabs

        //    CurrentView = loginViewModel;
        //}

        //private void OnLoginSuccessful()
        //{
        //    CurrentView = new MainViewModel(); // Update this to the actual ViewModel if different
        //}
    }
}

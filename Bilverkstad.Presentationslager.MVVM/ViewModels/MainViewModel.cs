using Bilverkstad.Presentationslager.MVVM.Commands;
using System.Windows.Input;
using Bilverkstad.Presentationslager.MVVM.Models;
using Bilverkstad.Affärslager;
using System.Windows;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;
using System.Windows.Documents;
using Bilverkstad.Entitetlagret;


namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
       public string AnvändarNamn => AnvändarSession.InloggadAnvändare.AnvändarNamn;
       public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;


        private bool _isViewVisible;
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }
        public bool ShowWelcomeTab { get; set; } = false;
        public bool ShowKunderTab { get; set; } = true; // Default to visible
        public bool ShowBokningarTab { get; set; } = true; // Default to visible
        public bool ShowReservdelarTab { get; set; } = true; // Default to visible
        public bool ShowPersonalTab { get; set; } = true; // Default to visible
         

        public MainViewModel()
        { 
            OnPropertyChanged(nameof(AnvändarNamn));
            OnPropertyChanged(nameof(AnställningsNummer));
            DetermineVisabilityTab();
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand => _logoutCommand ??= new RelayCommand(() =>
        {
            // Loggar ut användare genom att rensa sessionen
            AnvändarSession.Logout();

            // Stänger nuvarande fönster och öppnar login-fönstret
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is MainWindow)
                    {
                        
                        LoginWindow loginWindow = new LoginWindow();
                        loginWindow.Show();
                        window.Close();
                        break;
                    }
                }

                
             
            });
        });

        public void DetermineVisabilityTab()
        {
            Anställd _nuvarandeAnvändare = new Anställd();
            AnställdController ctrl = new AnställdController();
            _nuvarandeAnvändare = ctrl.GetSubTypeAnställd(AnställningsNummer);  
            
            if (_nuvarandeAnvändare is Receptionist receptionist)
            {
                if(receptionist.Auktoritet == Auktoritet.NotAdmin)
                {
                    ShowReservdelarTab = false;
                    ShowPersonalTab = false;
                }
            }
            else if (_nuvarandeAnvändare is Mekaniker)
            {
                ShowPersonalTab = false;
                ShowKunderTab = false;
            }

        }

        private bool isModified = false;
        public bool IsModified { get { return isModified; } set { isModified = value; OnPropertyChanged(); } }

       

    }
    
}


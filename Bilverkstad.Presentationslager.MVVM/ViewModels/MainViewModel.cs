using Bilverkstad.Presentationslager.MVVM.Commands;
using System.Windows.Input;
using Bilverkstad.Presentationslager.MVVM.Models;
using Bilverkstad.Affärslager;
using System.Windows;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;


namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
       public string AnvändarNamn => AnvändarSession.InloggadAnvändare.AnvändarNamn;
       public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;


        public MainViewModel()
        { 
            OnPropertyChanged(nameof(AnvändarNamn));
            OnPropertyChanged(nameof(AnställningsNummer));
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

        private bool isModified = false;
        public bool IsModified { get { return isModified; } set { isModified = value; OnPropertyChanged(); } }

       

    }
    
}


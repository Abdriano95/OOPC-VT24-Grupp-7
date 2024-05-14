using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;
using System;
using System.Windows;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public AnställdController _anställdController;
        private IWindowService _windowService;

        private string _userId = "";
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _password = "";
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public LoginViewModel()
        {
            _anställdController = new AnställdController();
            _windowService = new WindowService();

        }


        private ICommand _loginCommand = null!;
        public ICommand LoginCommand => _loginCommand ??= _loginCommand = new RelayCommand(() =>
        {
            int id;
            if (int.TryParse(UserId, out id))
            {
                if (_anställdController.ValideraInlogg(id, Password))
                {
                    Anställd anställd = _anställdController.GetSubTypeAnställd(id);
                    AnvändarSession.InloggadAnvändare = new Användare
                    {
                        AnvändarNamn = anställd.Förnamn + " " + anställd.Efternamn,
                        AnställningsNummer = anställd.AnställningsNummer
                    };

                    _windowService.OpenWindow("MainWindow");
                    _windowService.CloseWindow("LoginWindow");
                    
                }
                else
                {
                    MessageBox.Show("Fel användarID eller lösenord");
                }
            }
            else
            {
                MessageBox.Show("Ogiltig användarID");
            }

        });
    }

}


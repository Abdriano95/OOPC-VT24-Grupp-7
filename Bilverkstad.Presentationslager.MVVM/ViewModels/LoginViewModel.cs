using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.Commands;
using Bilverkstad.Presentationslager.Models;
using Bilverkstad.Presentationslager.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : MainViewModel
    {
        private readonly AnställdController _anställdController;
        private readonly WindowService _windowService;

        public LoginViewModel() { }
            

        public LoginViewModel(AnställdController anställdController, WindowService windowService)
        {
            _anställdController = anställdController;
            _windowService = windowService;
            LoginCommand = new RelayCommand(Login);
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(nameof(UserId)); }
        }

        private string _lösenord;
        public string Lösenord
        {
            get { return _lösenord; }
            set { _lösenord = value; OnPropertyChanged(nameof(Lösenord)); }
        }
    
        public ICommand LoginCommand { get; private set; }

        private void Login()
        {
            Anställd anställd = _anställdController.GetSubTypeAnställd(UserId);

            if (_anställdController.ValideraInlogg(UserId, Lösenord))
            {
                AnvändarSession.InloggadAnvändare = new Användare { AnvändarNamn = anställd.Förnamn + " " + anställd.Efternamn, AnställningsNummer = anställd.AnställningsNummer };

                _windowService.Show(new MainViewModel(anställd));
                _windowService.CloseWindow(this);
                _windowService.Show("Welcome!");
            }
            else
            {
                _windowService.Show("Incorrect username or password");
            }
        }
    }
}

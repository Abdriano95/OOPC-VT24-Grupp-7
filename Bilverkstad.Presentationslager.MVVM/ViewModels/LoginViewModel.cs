using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : MainViewModel
    {
        private readonly AnställdController _anställdController;
        

        public LoginViewModel() { }
            

        public LoginViewModel(AnställdController anställdController)
        {
            _anställdController = anställdController;
            
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

                
            }
            else
            {
                
            }
        }
    }
}

using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : MainViewModel
    {
        public AnställdController _anställdController = new AnställdController();

        // Define an event to notify about successful login
        public event Action LoginSuccessful;
        public LoginViewModel()
        {

        }

        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(nameof(UserId)); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        private bool _isViewVisible;
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        private ICommand _loginCommand = null!;
        public ICommand LoginCommand => _loginCommand ??= _loginCommand = new RelayCommand(() =>
        {
            int id;

            if (int.TryParse(UserId, out id))
            {
                Anställd anställd = _anställdController.GetSubTypeAnställd(id);
                if (_anställdController.ValideraInlogg(id, Password))
                {
                    AnvändarSession.InloggadAnvändare = new Användare
                    {
                        AnvändarNamn = anställd.Förnamn + " " + anställd.Efternamn,
                        AnställningsNummer = anställd.AnställningsNummer
                    };
                    IsViewVisible = false;
                    // Trigger the LoginSuccessful event
                    LoginSuccessful?.Invoke();
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


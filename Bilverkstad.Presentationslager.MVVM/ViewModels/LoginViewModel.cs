using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Views.Windows;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
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

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window is LoginWindow)
                            {

                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                window.Close();
                                break;
                            }
                        }



                    });
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


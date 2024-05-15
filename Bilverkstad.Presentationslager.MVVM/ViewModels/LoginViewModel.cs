using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private AnställdController _anställdController;
        private IWindowService _windowService;
        private IUserMessageService _userMessageService;

        public ObservableCollection<Anställd> Anställda { get; } = new ObservableCollection<Anställd>();

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
            _userMessageService = new UserMessageService();
            _ = LoadAnställdaAsync();

        }

        private async Task LoadAnställdaAsync()
        {
            Anställda.Clear();
            foreach (var anställd in await Task.Run(() => _anställdController.GetAnställd()))
            {
                Anställda.Add(anställd);
            }
        }


        private ICommand _loginCommand = null!;
        public ICommand LoginCommand => _loginCommand ??= _loginCommand = new RelayCommand(() =>
        {
            //UserId = UserId.Trim();
            if (!int.TryParse(UserId, out int id))
            {
                _userMessageService.ShowMessage("Ogiltig användarID");
                return;
            }

            var anställd = Anställda.FirstOrDefault(e => e.AnställningsNummer == id);
            if (anställd == null)
            {
                _userMessageService.ShowMessage("Ingen anställd hittades med detta ID.");
                return;
            }

            if (!_anställdController.ValideraInlogg(id, Password))
            {
                _userMessageService.ShowMessage("Fel användarID eller lösenord");
                return;
            }

            // Successful login
            AnvändarSession.InloggadAnvändare = new Användare
            {
                AnvändarNamn = anställd.Förnamn + " " + anställd.Efternamn,
                AnställningsNummer = anställd.AnställningsNummer
            };

            _windowService.OpenWindow("MainWindow");
            _windowService.CloseWindow("LoginWindow");

        });
    }

}


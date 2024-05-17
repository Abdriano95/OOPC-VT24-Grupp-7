using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using System.Windows.Input;


namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly AnställdController _anställdController;

        private readonly IWindowService _windowService;
        public string AnvändarNamn => AnvändarSession.InloggadAnvändare.AnvändarNamn;
        public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;
        public bool ShowWelcomeTab { get; set; } = false;
        public bool ShowKunderTab { get; set; } = true;
        public bool ShowBokningarTab { get; set; } = true;
        public bool ShowReservdelarTab { get; set; } = true;
        public bool ShowPersonalTab { get; set; } = true;
        public bool ShowReparationerTab { get; set; } = true;

        // KONSTRUKTOR

        public MainViewModel()
        {
            _anställdController = new AnställdController();
            _windowService = new WindowService();
            DetermineVisabilityTab();
        }

        // LOGGA UT

        private ICommand? _logoutCommand;
        public ICommand LogoutCommand => _logoutCommand ??= new RelayCommand(() =>
        {

            _windowService.OpenWindow("LoginWindow");
            _windowService.CloseWindow("MainWindow");
            AnvändarSession.Logout();

        });

        // VISA TABS BEROENDE PÅ ANVÄNDARE

        public void DetermineVisabilityTab()
        {
            Anställd _nuvarandeAnvändare = new Anställd();
            _nuvarandeAnvändare = _anställdController.GetSubTypeAnställd(AnställningsNummer);

            if (_nuvarandeAnvändare is Receptionist receptionist)
            {
                if (receptionist.Auktoritet == Auktoritet.NotAdmin)
                {
                    ShowReservdelarTab = false;
                    ShowPersonalTab = false;
                }
            }
            else if (_nuvarandeAnvändare is Mekaniker)
            {
                ShowPersonalTab = false;
                ShowKunderTab = false;
                ShowBokningarTab = false;
            }

        }
    }

}


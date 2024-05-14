using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using System.Collections.ObjectModel;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class BokningsHanteringViewModel : BaseViewModel
    {
        private readonly AnställdController _anställdController;
        private readonly KundController _kundController;
        public string AnvändarNamn => AnvändarSession.InloggadAnvändare.AnvändarNamn;
        public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;

        private ObservableCollection<Kund> _kundSuggestions;

        public ObservableCollection<Kund> KundSuggestions
        {
            get => _kundSuggestions;
            private set => SetProperty(ref _kundSuggestions, value);
        }
        private Kund _selectedKund;
        public Kund SelectedKund
        {
            get => _selectedKund;
            set => SetProperty(ref _selectedKund, value);
        }

        private bool _isReceptionist;
        public bool IsReceptionist
        {
            get => _isReceptionist;
            set => SetProperty(ref _isReceptionist, value);
        }

        private bool _isMekaniker;
        public bool IsMekaniker
        {
            get => _isMekaniker;
            set => SetProperty(ref _isMekaniker, value);
        }

        private int _kundId;
        public int KundId
        {
            get => _kundId;
            set => SetProperty(ref _kundId, value);
        }

        private string _fordonRegNr;
        public string FordonRegNr
        {
            get => _fordonRegNr;
            set => SetProperty(ref _fordonRegNr, value);
        }

        private int _receptionistId;
        public int ReceptionistId
        {
            get => _receptionistId;
            set => SetProperty(ref _receptionistId, value);
        }

        private int? _mekanikerId;
        public int? MekanikerId
        {
            get => _mekanikerId;
            set => SetProperty(ref _mekanikerId, value);
        }

        private DateTime _inlämningsDatum;
        public DateTime InlämningsDatum
        {
            get => _inlämningsDatum;
            set => SetProperty(ref _inlämningsDatum, value);
        }

        private DateTime? _utlämningsDatum;

        public DateTime? UtlämningsDatum
        {
            get => _utlämningsDatum;
            set => SetProperty(ref _utlämningsDatum, value);
        }

        private string _syfteMedBesök;
        public string SyfteMedBesök
        {
            get => _syfteMedBesök;
            set => SetProperty(ref _syfteMedBesök, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    UpdateKundSuggestions();
                }
            }
        }



        public BokningsHanteringViewModel()
        {
            _anställdController = new AnställdController();
            _kundController = new KundController();
            KundSuggestions = new ObservableCollection<Kund>();
            DetermineUserType();
        }

        private void UpdateKundSuggestions()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                KundSuggestions.Clear();
            }
            else
            {
                var searchResults = _kundController.SearchKunder(SearchText);
                KundSuggestions = new ObservableCollection<Kund>(searchResults);
            }
        }

        public void DetermineUserType()
        {
            Anställd _nuvarandeAnvändare = new Anställd();
            _nuvarandeAnvändare = _anställdController.GetSubTypeAnställd(AnställningsNummer);

            if (_nuvarandeAnvändare is Receptionist receptionist)
            {
                if (receptionist.Auktoritet == Auktoritet.NotAdmin)
                {
                    IsReceptionist = true;
                    IsMekaniker = false;
                }
                else
                {
                    IsReceptionist = true;
                    IsMekaniker = true;
                }

            }
            else if (_nuvarandeAnvändare is Mekaniker)
            {
                IsMekaniker = true;
                IsReceptionist = false;
            }
        }
        }


    }


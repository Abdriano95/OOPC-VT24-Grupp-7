using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class BokningsHanteringViewModel : BaseViewModel
    {
        private readonly AnställdController _anställdController;
        private readonly KundController _kundController;
        private readonly BokningsController _bokningsController;
        private readonly IUserMessageService _messageService;
        public string AnvändarNamn => AnvändarSession.InloggadAnvändare.AnvändarNamn;
        public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;

        public BokningsHanteringViewModel()
        {
            _messageService = new UserMessageService();
            _anställdController = new AnställdController();
            _kundController = new KundController();
            _bokningsController = new BokningsController();
            KundSuggestions = new ObservableCollection<Kund>();
            Mekanikers = new ObservableCollection<Mekaniker>();
            Specialiseringar = new ObservableCollection<Specialiseringar>(Enum.GetValues(typeof(Specialiseringar)).Cast<Specialiseringar>());
            DetermineUserType();
        }

        private bool _isDropDownOpen;
        public bool IsDropDownOpen
        {
            get => _isDropDownOpen;
            set => SetProperty(ref _isDropDownOpen, value);
        }

        private bool _updatingFromSelection = false;

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
            set
            {
                if (SetProperty(ref _selectedKund, value))
                {
                    _updatingFromSelection = true;
                    if (value != null)
                    {
                        SearchText = value.FullständigtNamn; // Uppdaterar sökfältet med den valda kundens namn
                        UpdateKundFordon(value); // Uppdaterar fordonen som tillhör kunden
                    }
                    else
                    {
                        KundFordon.Clear();
                    }
                    _updatingFromSelection = false;
                }
            }
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

        private ObservableCollection<Fordon> _kundFordon;
        public ObservableCollection<Fordon> KundFordon
        {
            get => _kundFordon;
            set => SetProperty(ref _kundFordon, value);
        }


        private string _selectedFordon;
        public string SelectedFordon
        {
            get => _selectedFordon;
            set => SetProperty(ref _selectedFordon, value);
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
            set
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    _messageService.ShowMessage("Syftet med besöket kan inte vara tomt."); 
                    return; 
                }

                SetProperty(ref _syfteMedBesök, value);
            }
        }

        public ObservableCollection<Specialiseringar> Specialiseringar { get; private set; }

        private Specialiseringar _selectedSpecialisering;
        public Specialiseringar SelectedSpecialisering
        {
            get => _selectedSpecialisering;
            set 
            {
                if (SetProperty(ref _selectedSpecialisering, value))
                {
                    LoadMekanikerForSpecialisering();
                }
            }
        }

        private void LoadMekanikerForSpecialisering()
        {
            Mekanikers.Clear();
            var mechanics = _bokningsController.GetMekanikerBySpecialisering(SelectedSpecialisering);
            foreach (var mechanic in mechanics)
            {
                if (mechanic.Specialiseringar.HasFlag(SelectedSpecialisering))
                {
                    Mekanikers.Add(mechanic);
                }
            }
        }


        private ObservableCollection<Mekaniker> _mekanikers;
        public ObservableCollection<Mekaniker> Mekanikers
        {
            get => _mekanikers;
            set => SetProperty(ref _mekanikers, value);
        }


        private Mekaniker _selectedMekaniker;
        public Mekaniker SelectedMekaniker
        {
            get => _selectedMekaniker;
            set => SetProperty(ref _selectedMekaniker, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    if (!_updatingFromSelection) // Only update suggestions and check text if not updating from selection
                    {
                        UpdateKundSuggestions(); // Refreshes the customers list shown in the dropdown
                        IsDropDownOpen = !string.IsNullOrEmpty(value);
                        CheckAndResetSearchText(value);
                    }
                }
            }
        }

        private void CheckAndResetSearchText(string newText)
        {
            if (SelectedKund != null && !_updatingFromSelection)
            {
                if (newText != SelectedKund.FullständigtNamn)
                {
                    // Kolla om den valda kunden inte matchar söktexten
                    if (!SelectedKund.FullständigtNamn.StartsWith(newText))
                    {
                        _updatingFromSelection = true;
                        SearchText = SelectedKund.FullständigtNamn;
                        _updatingFromSelection = false;
                    }
                }
            }
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

        private void UpdateKundFordon(Kund kund)
        {
            if (kund != null && kund.Fordon != null && kund.Fordon.Any())
            {
                KundFordon = new ObservableCollection<Fordon>(kund.Fordon);
            }
            else
            {
                KundFordon = new ObservableCollection<Fordon>();
                _messageService.ShowMessage("Inga fordon hittade för kunden");
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


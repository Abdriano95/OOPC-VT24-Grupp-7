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
        // Service och kontrollers för bokningshantering/reparation
        private readonly AnställdController _anställdController;
        private readonly KundController _kundController;
        private readonly BokningsController _bokningsController;
        private readonly FordonController _fordonController;
        private readonly IUserMessageService _messageService;

        // Konstruktor
        public BokningsHanteringViewModel()
        {
            _messageService = new UserMessageService();
            _anställdController = new AnställdController();
            _kundController = new KundController();
            _bokningsController = new BokningsController();
            _fordonController = new FordonController();
            KundSuggestions = new ObservableCollection<Kund>();
            Bokningar = new ObservableCollection<Bokning>();
            Mekanikers = new ObservableCollection<Mekaniker>();
            Specialiseringar = new ObservableCollection<Specialiseringar>(Enum.GetValues(typeof(Specialiseringar)).Cast<Specialiseringar>());
            LoadBokningarForReceptionist();
            DetermineUserType();
        }
        public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;

        Anställd _nuvarandeAnvändare = new Anställd();

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
        // Properties - För sökfält och dropdown för kunder
        private bool _isDropDownOpen;
        public bool IsDropDownOpen
        {
            get => _isDropDownOpen;
            set => SetProperty(ref _isDropDownOpen, value);
        }
        private bool _updatingFromSelection = false;
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
        // Collections
        private ObservableCollection<Bokning> _bokningar;
        public ObservableCollection<Bokning> Bokningar
        {
            get => _bokningar;
            set => SetProperty(ref _bokningar, value);
        }

        private ObservableCollection<Kund> _kundSuggestions;
        public ObservableCollection<Kund> KundSuggestions
        {
            get => _kundSuggestions;
            private set => SetProperty(ref _kundSuggestions, value);
        }
        private ObservableCollection<Mekaniker> _mekanikers;
        public ObservableCollection<Mekaniker> Mekanikers
        {
            get => _mekanikers;
            set => SetProperty(ref _mekanikers, value);
        }
        private ObservableCollection<Fordon> _kundFordon;
        public ObservableCollection<Specialiseringar> Specialiseringar { get; private set; }

        public ObservableCollection<Bokning> _mekanikersBokningar;
        public ObservableCollection<Bokning> MekanikersBokningar
        {
            get => _mekanikersBokningar;
            set => SetProperty(ref _mekanikersBokningar, value);
        }

        // Properties för fordons journal
        public ObservableCollection<Bokning> _fordonsJournal;
        public ObservableCollection<Bokning> FordonsJournal
        {
            get => _fordonsJournal;
            set => SetProperty(ref _fordonsJournal, value);
        }

        public ICommand VisaJournalCommand => new RelayCommand(LoadVehicleJournal);


        public void LoadVehicleJournal()
        {
            if (SelectedFordon != null)
            {
                FordonsJournal = new ObservableCollection<Bokning>(_bokningsController.GetBokningarByFordonRegNr(SelectedFordon.RegNr));
            }
            else
            {
                _messageService.ShowMessage("No vehicle selected.");
            }
        }



        // Sökproperties för fordonsjournal

        private ObservableCollection<Fordon> _fordonSuggestions;
        public ObservableCollection<Fordon> FordonSuggestions
        {
            get => _fordonSuggestions;
            private set => SetProperty(ref _fordonSuggestions, value);
        }

        private Fordon _selectedFordonJournal;
        public Fordon SelectedFordonJournal
        {
            get => _selectedFordonJournal;
            set
            {
                if (SetProperty(ref _selectedFordonJournal, value))
                {
                    _updatingFromSelectionJournal = true;
                    if (value != null)
                    {
                        SearchJournalText = value.RegNr;
                    }
                    else
                    {
                        FordonsJournal.Clear();
                    }
                    _updatingFromSelectionJournal = false;

                }

            }
        }

        private bool _isFordonDropDownOpen;
        public bool IsFordonDropDownOpen
        {
            get => _isFordonDropDownOpen;
            set => SetProperty(ref _isFordonDropDownOpen, value);
        }

        private bool _updatingFromSelectionJournal = false;
        private string _searchJournalText;
        public string SearchJournalText
        {
            get => _searchJournalText;
            set
            {
                if (SetProperty(ref _searchJournalText, value))
                {
                    if (!_updatingFromSelectionJournal)
                    {
                        UpdateJournalSuggestions();
                        IsFordonDropDownOpen = !string.IsNullOrEmpty(value);
                        CheckAndResetSearchJournalText(value);
                    }
                }
            }
        }

        private void CheckAndResetSearchJournalText(string newText)
        {
            if (SelectedFordonJournal != null && !_updatingFromSelectionJournal)
            {
                if (newText != SelectedFordonJournal.RegNr)
                {
                    if (!SelectedFordonJournal.RegNr.StartsWith(newText))
                    {
                        _updatingFromSelectionJournal = true;
                        SearchJournalText = SelectedFordonJournal.RegNr;
                        _updatingFromSelectionJournal = false;
                    }
                }
            }
        }

        private void UpdateJournalSuggestions()
        {
            if (string.IsNullOrEmpty(SearchJournalText))
            {
                FordonSuggestions.Clear();
            }
            else
            {
                var searchResults = _fordonController.SearchFordon(SearchJournalText);
                FordonSuggestions = new ObservableCollection<Fordon>(searchResults);
            }
        }




        // Properties för valda objekt
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
                    _updatingFromSelection = false;
                }
            }
        }
        public List<string> BokningStatusStatusar => Enum.GetNames(typeof(Status)).ToList();

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
        private Mekaniker _selectedMekaniker;
        public Mekaniker SelectedMekaniker
        {
            get => _selectedMekaniker;
            set => SetProperty(ref _selectedMekaniker, value);
        }

        private Bokning _selectedBokningForReceptionist;
        public Bokning SelectedBokningForReceptionist
        {
            get => _selectedBokningForReceptionist;
            set
            {
                if (SetProperty(ref _selectedBokningForReceptionist, value))
                {
                    if (value != null)
                    {
                        _nuvarandeAnvändare = value.Receptionist;
                        SelectedKund = value.Kund;
                        SelectedFordon = value.Fordon;
                        SelectedMekaniker = value.Mekaniker;
                        InlämningsDatum = value.InlämningsDatum;
                        UtlämningsDatum = value.UtlämningsDatum;
                        SelectedSpecialisering = value.Mekaniker.Specialiseringar;
                        SelectedSyfteMedBesök = value.SyfteMedBesök;
                        SelectedBokningStatus = (Status)value.BokningStatus;
                    }
                }
            }
        }



        // Properties för bokning
        public ObservableCollection<Fordon> KundFordon
        {
            get => _kundFordon;
            set => SetProperty(ref _kundFordon, value);
        }



        private Fordon _selectedFordon;
        public Fordon SelectedFordon
        {
            get => _selectedFordon;
            set => SetProperty(ref _selectedFordon, value);
        }



        private DateTime? _inlämningsDatum;
        public DateTime? InlämningsDatum
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

        private string _SelectedSyfteMedBesök;
        public string SelectedSyfteMedBesök
        {
            get => _SelectedSyfteMedBesök;
            set => SetProperty(ref _SelectedSyfteMedBesök, value);

        }
        private Status _selectedBokningStatus;
        public Status SelectedBokningStatus
        {
            get => _selectedBokningStatus;
            set
            {
                if (_selectedBokningStatus != value)
                {
                    _selectedBokningStatus = value;
                    OnPropertyChanged(nameof(SelectedBokningStatus));
                }
            }
        }


        //Add Commands

        private ICommand _addBokningCommand = null!;
        public ICommand AddBokningCommand => _addBokningCommand ??= _addBokningCommand = new RelayCommand(() =>
        {
            if (SelectedKund == null || SelectedFordon == null || SelectedMekaniker == null ||
                string.IsNullOrWhiteSpace(SelectedSyfteMedBesök) || InlämningsDatum == null || UtlämningsDatum == null)
            {
                _messageService.ShowMessage("Alla fält måste vara i fyllda för att skapa en bokning.");
                return;
            }

            if (InlämningsDatum < DateTime.Today)
            {
                _messageService.ShowMessage("Du kan inte skapa en bokning i tidigare datum än idag.");
                return;
            }

            Bokning nyBokning = new Bokning
            {

                KundId = SelectedKund.Id,
                FordonRegNr = SelectedFordon.RegNr,
                ReceptionistId = AnställningsNummer,
                MekanikerId = SelectedMekaniker?.AnställningsNummer,
                InlämningsDatum = InlämningsDatum ?? DateTime.Now,
                UtlämningsDatum = UtlämningsDatum,
                SyfteMedBesök = SelectedSyfteMedBesök,
                BokningStatus = SelectedBokningStatus,
            };
            _bokningsController.AddBokning(nyBokning);
            RefreshFieldsCommand.Execute(null);
            LoadBokningarForReceptionist();
            _messageService.ShowMessage("Bokningen är skapad.");
        });
        //Refresh
        private RelayCommand refreshFieldsCommand;
        public ICommand RefreshFieldsCommand => refreshFieldsCommand ??= new RelayCommand(RefreshFields);

        private void RefreshFields()
        {
            SelectedKund = null;
            SelectedFordon = null;
            SelectedMekaniker = null;
            InlämningsDatum = null;
            UtlämningsDatum = null;
            SelectedSyfteMedBesök = string.Empty;
            SelectedBokningStatus = Status.Inlämnad;
            SearchText = string.Empty;
        }


        //Update Command
        private ICommand _updateBokningCommand = null!;

        public ICommand UpdateBokningCommand => _updateBokningCommand ??= _updateBokningCommand = new RelayCommand(() =>
        {
            if (SelectedBokningForReceptionist == null)
            {
                _messageService.ShowMessage("Välj en bokning att uppdatera.");
                return;
            }

            if (SelectedKund == null || SelectedFordon == null || SelectedMekaniker == null ||
                           string.IsNullOrWhiteSpace(SelectedSyfteMedBesök) || InlämningsDatum == null || UtlämningsDatum == null)
            {
                _messageService.ShowMessage("Alla fält måste vara i fyllda för att uppdatera en bokning.");
                return;
            }

            if (InlämningsDatum < DateTime.Today)
            {
                _messageService.ShowMessage("Du kan inte uppdatera en bokning i tidigare datum än idag.");
                return;
            }

            SelectedBokningForReceptionist.KundId = SelectedKund.Id;
            SelectedBokningForReceptionist.FordonRegNr = SelectedFordon.RegNr;
            SelectedBokningForReceptionist.ReceptionistId = AnställningsNummer;
            SelectedBokningForReceptionist.MekanikerId = SelectedMekaniker?.AnställningsNummer;
            SelectedBokningForReceptionist.InlämningsDatum = InlämningsDatum ?? DateTime.Now;
            SelectedBokningForReceptionist.UtlämningsDatum = UtlämningsDatum;
            SelectedBokningForReceptionist.SyfteMedBesök = SelectedSyfteMedBesök;
            SelectedBokningForReceptionist.BokningStatus = SelectedBokningStatus;

            _bokningsController.UpdateBokning(SelectedBokningForReceptionist);
            RefreshFieldsCommand.Execute(null);
            LoadBokningarForReceptionist();
            _messageService.ShowMessage("Bokningen är uppdaterad.");
        });

        // Delete Command
        private ICommand _deleteBokningCommand = null!;

        public ICommand DeleteBokningCommand => _deleteBokningCommand ??= _deleteBokningCommand = new RelayCommand(() =>
        {
            if (SelectedBokningForReceptionist == null)
            {
                _messageService.ShowMessage("Välj en bokning att ta bort.");
                return;
            }

            _bokningsController.DeleteBokning(SelectedBokningForReceptionist.Id);
            RefreshFieldsCommand.Execute(null);
            LoadBokningarForReceptionist();
            _messageService.ShowMessage("Bokningen är borttagen.");
        });

        // Metoder för att uppdatera, hämta data och validera om användaren är mekaniker eller receptionist
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



        private void LoadBokningarForReceptionist()
        {

            Bokningar.Clear();
            var bookings = _bokningsController.GetBokning();
            foreach (var booking in bookings)
            {
                Bokningar.Add(booking);
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

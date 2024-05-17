using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class ReparationsHanteringViewModel : BaseViewModel
    {

        // Services och kontroller
        private readonly ReparationController _reparationController;
        private readonly BokningsController _bokningController;
        private readonly ReservdelController _reservdelController;
        private readonly FordonController _fordonController;
        private readonly IUserMessageService _userMessageService;

        public ReparationsHanteringViewModel()
        {
            _reparationController = new ReparationController();
            _bokningController = new BokningsController();
            _reservdelController = new ReservdelController();
            _fordonController = new FordonController();
            _userMessageService = new UserMessageService();
            Bokningar = new ObservableCollection<Bokning>(_bokningController.GetBokningarByMekaniker(AnställningsNummer));
            Reparationsstatusar = new ObservableCollection<Reparationsstatus>(Enum.GetValues(typeof(Reparationsstatus)).Cast<Reparationsstatus>());
        }

        // Användarsession;
        public int AnställningsNummer => AnvändarSession.InloggadAnvändare.AnställningsNummer;


        // Collections
        public ObservableCollection<Bokning> Bokningar { get; set; }
       
        private ObservableCollection<Reparation> _reparationer;
        public ObservableCollection<Reparation> Reparationer
        {
            get { return _reparationer; }
            set { SetProperty(ref _reparationer, value); }
        }

        private ObservableCollection<Reparationsstatus> _reparationsstatusar;
        public ObservableCollection<Reparationsstatus> Reparationsstatusar
        {
            get { return _reparationsstatusar; }
            set { SetProperty(ref _reparationsstatusar, value); }

        }
        // Sökfunktion för reservdelar
        private ObservableCollection<Reservdel> _reservdelSuggestions;
        public ObservableCollection<Reservdel> ReservdelSuggestions
        {
            get => _reservdelSuggestions;
            set => SetProperty(ref _reservdelSuggestions, value);
        }

        private bool _isReservdelDropDownOpen;
        public bool IsReservdelDropDownOpen
        {
            get => _isReservdelDropDownOpen;
            set => SetProperty(ref _isReservdelDropDownOpen, value);
        }

        private bool _updatingFromReservdelSelection = false;

        private string _reservdelSearchText;
        public string ReservdelSearchText
        {
            get => _reservdelSearchText;
            set
            {
                if (SetProperty(ref _reservdelSearchText, value))
                {
                    if (!_updatingFromReservdelSelection)
                    {
                        UpdateReservdelSuggestions();
                        IsReservdelDropDownOpen = !string.IsNullOrEmpty(value);
                        CheckAndResetSearchText(value);
                    }
                }
            }
        }

        private void CheckAndResetSearchText(string newText)
        {
            if(SelectedReservdel != null && !_updatingFromReservdelSelection)
            {
                if(newText != SelectedReservdel.Namn)
                {
                    if (!SelectedReservdel.Namn.StartsWith(newText))
                    {
                        _updatingFromReservdelSelection = true;
                        ReservdelSearchText = SelectedReservdel.Namn;
                        _updatingFromReservdelSelection = false;
                    }
                }
            }   
        }

        private void UpdateReservdelSuggestions()
        {
            if (string.IsNullOrEmpty(ReservdelSearchText))
            {
                ReservdelSuggestions.Clear();
            }
            else
            {
                var searchResults = _reservdelController.SearchReservdel(ReservdelSearchText);
                ReservdelSuggestions = new ObservableCollection<Reservdel>(searchResults);
            }
        }




        // Properties
        private Bokning? _selectedBokning;
        public Bokning? SelectedBokning
        {
            get { return _selectedBokning; }
            set
            {
                if (SetProperty(ref _selectedBokning, value))
                {
                    if (value != null)
                    {
                        Reparationer = new ObservableCollection<Reparation>(_reparationController.GetReparationerByBokning(value.Id));
                    }
                }
            }
        }

        private Reparation _selectedReparation;
        public Reparation SelectedReparation
        {
            get { return _selectedReparation; }
            set 
            { 
                if(SetProperty(ref _selectedReparation, value))
                {
                    if(value != null)
                    {
                        SelectedReparationsstatus = value.Reparationsstatus;
                        SelectedÅtgärd = value.Åtgärd;
                        SelectedReservdel = value.Reservdelar;
                    }
                }
            }

        }

        private Reparationsstatus _selectedReparationsstatus;
        public Reparationsstatus SelectedReparationsstatus
        {
            get { return _selectedReparationsstatus; }
            set { SetProperty(ref _selectedReparationsstatus, value); }
        }

        private string _selectedÅtgärd;
        public string SelectedÅtgärd
        {
            get { return _selectedÅtgärd; }
            set { SetProperty(ref _selectedÅtgärd, value); }
        }

        private Reservdel _selectedReservdel;
        public Reservdel SelectedReservdel
        {
            get { return _selectedReservdel; }
            set 
            {
                if (SetProperty(ref _selectedReservdel, value))
                {
                    _updatingFromReservdelSelection = true;
                    if(value != null)
                    {
                        ReservdelSearchText = value.Namn;
                    }
                    else
                    {
                        ReservdelSearchText = "";
                        if (ReservdelSuggestions != null)
                        {
                            ReservdelSuggestions.Clear();
                        }
                          
                    }
                    _updatingFromReservdelSelection = false;
                }

            }
        }

        // Commands

        private ICommand _refreshCommand = null!;
        public ICommand RefreshCommand => _refreshCommand ??= _refreshCommand = new RelayCommand(() =>
        {
            SelectedBokning = SelectedBokning;
            SelectedReparationsstatus = Reparationsstatus.EjPåbörjad;
            SelectedÅtgärd = "";
            SelectedReservdel = null;
            LoadBokningarForMekaniker();
            LoadReparationerForBokning();
        });


        private ICommand _addReparationCommand = null!;
        public ICommand AddReparationCommand => _addReparationCommand ??= _addReparationCommand = new RelayCommand(() =>
        {
            if (SelectedReparationsstatus == null)
            {
                _userMessageService.ShowMessage("Välj en reparationstatus");
                return;
            }
            if (SelectedÅtgärd == null)
            {
                _userMessageService.ShowMessage("Fyll i åtgärd");
                return;
            }
            if (SelectedBokning == null)
            {
                _userMessageService.ShowMessage("Ingen bokning vald");
                return;
            }

            if(SelectedReservdel == null)
            {
                _userMessageService.ShowMessage("Välj en reservdel");
                return;
            }

                Reparation reparation = new Reparation
                {
                    
                    BokningsId = SelectedBokning.Id,
                    Reparationsstatus = SelectedReparationsstatus,
                    Åtgärd = SelectedÅtgärd,
                    ReservdelId = SelectedReservdel.Artikelnummer,
                };
                _reparationController.AddReparation(reparation);
                SelectedBokning.Reparation.Add(reparation);
                _bokningController.UpdateBokning(SelectedBokning);
                Reparationer.Add(reparation);
                RefreshCommand.Execute(null);
            
        });

        private ICommand _updateReparationCommand = null!;
        public ICommand UpdateReparationCommand => _updateReparationCommand ??= _updateReparationCommand = new RelayCommand(() =>
        {
            if (SelectedReparation == null)
            {
                _userMessageService.ShowMessage("Ingen reparation vald");
                return;
            }
            if (SelectedReparationsstatus == null)
            {
                _userMessageService.ShowMessage("Välj en reparationstatus");
                return;
            }
            if (SelectedÅtgärd == null)
            {
                _userMessageService.ShowMessage("Fyll i åtgärd");
                return;
            }

                SelectedReparation.Reparationsstatus = SelectedReparationsstatus;
                SelectedReparation.Åtgärd = SelectedÅtgärd;
                SelectedReparation.ReservdelId = SelectedReservdel.Artikelnummer;
                _reparationController.UpdateReparation(SelectedReparation);
                _bokningController.UpdateBokning(SelectedBokning);
           
                RefreshCommand.Execute(null);
                LoadBokningarForMekaniker();
        });


        private ICommand _deleteReparationCommand = null!;
        public ICommand DeleteReparationCommand => _deleteReparationCommand ??= _deleteReparationCommand = new RelayCommand(() =>
        {
            if (SelectedReparation == null)
            {
                _userMessageService.ShowMessage("Ingen reparation vald");
                return;
            }

            if(SelectedBokning == null)
            {
                _userMessageService.ShowMessage("Ingen bokning vald");
                return;
            }

                _reparationController.DeleteReparation(SelectedReparation);
                SelectedBokning?.Reparation?.Remove(SelectedReparation);
                _bokningController.UpdateBokning(SelectedBokning);
                Reparationer.Remove(SelectedReparation);
                RefreshCommand.Execute(null);
                LoadBokningarForMekaniker();

        });

        // Sökfunktion för fordonsjournal

       
        public ObservableCollection<Bokning> _fordonsJournal;
        public ObservableCollection<Bokning> FordonsJournal
        {
            get => _fordonsJournal;
            set => SetProperty(ref _fordonsJournal, value);
        }

        public ICommand VisaJournalCommand => new RelayCommand(LoadVehicleJournal);


        public void LoadVehicleJournal()
        {
            if (SelectedFordonJournal != null)
            {
                FordonsJournal = new ObservableCollection<Bokning>(_bokningController.GetBokningarByFordonRegNr(SelectedFordonJournal.RegNr));
            }
            else
            {
                _userMessageService.ShowMessage("Inga fordon hittade.");
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

        // load metoder
        private void LoadBokningarForMekaniker()
        {
            Bokningar.Clear();
            var bokningar = _bokningController.GetBokningarByMekaniker(AnställningsNummer);
            foreach (var bokning in bokningar)
            {
                Bokningar.Add(bokning);
            }
        }

        private void LoadReparationerForBokning()
        {
            if(SelectedReparation == null || SelectedBokning == null)
            {
                return;
            }
            Reparationer.Clear();
            var reparationer = _reparationController.GetReparationerByBokning(SelectedBokning.Id);
            foreach (var reparation in reparationer)
            {
                Reparationer.Add(reparation);
            }
        }

    }
}

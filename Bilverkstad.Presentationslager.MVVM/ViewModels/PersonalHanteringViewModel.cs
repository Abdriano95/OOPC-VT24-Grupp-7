using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Bilverkstad.Presentationslager.MVVM.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class PersonalHanteringViewModel : BaseViewModel
    {
        private AnställdController _anställdcontroller;
        private ReceptionistController _receptionistcontroller;
        private MekanikerController _mekanikercontroller;
        private readonly IUserMessageService _messageService;

        // KONSTRUKTOR

        public PersonalHanteringViewModel()
        {
            _messageService = new UserMessageService();
            _receptionistcontroller = new ReceptionistController();
            _mekanikercontroller = new MekanikerController();
            _anställdcontroller = new AnställdController();

            LoadPersonal();
            FiltreradePersonal = CollectionViewSource.GetDefaultView(PersonalData);
            FiltreradePersonal.Filter = PersonalFilter;

            TypList = new ObservableCollection<string> { "Mekaniker", "Receptionist" }; // Fyller "Typ" CB
            SpecialiseringarList = new List<Specialiseringar>(Enum.GetValues(typeof(Specialiseringar)).Cast<Specialiseringar>()); // Fyller Mekaniker CB
            AuktoritetList = new List<Auktoritet>(Enum.GetValues(typeof(Auktoritet)).Cast<Auktoritet>()); // Fyller Receptionist CB
        }

        // PROPERTIES

        private string _förnamn = "";
        public string Förnamn
        {
            get => _förnamn;
            set => SetProperty(ref _förnamn, value);
        }

        private string _efternamn = "";
        public string Efternamn
        {
            get => _efternamn;
            set => SetProperty(ref _efternamn, value);
        }

        private string _lösenord = "";
        public string Lösenord
        {
            get => _lösenord;
            set => SetProperty(ref _lösenord, value);
        }

        private string _typ;
        public string Typ
        {
            get => _typ;
            set
            {
                _typ = value;
                OnPropertyChanged();
                UpdateLists();
            }
        }

        private void UpdateLists()
        {
            if (Typ == "Mekaniker")
            {
                SpecialiseringarList = Enum.GetValues(typeof(Specialiseringar)).Cast<Specialiseringar>().ToList();
                AuktoritetList = new List<Auktoritet>();
            }
            else if (Typ == "Receptionist")
            {
                AuktoritetList = Enum.GetValues(typeof(Auktoritet)).Cast<Auktoritet>().ToList();
                SpecialiseringarList = new List<Specialiseringar>();
            }
        }


        private Specialiseringar _selectedSpecialiseringar;
        public Specialiseringar SelectedSpecialiseringar
        {
            get => _selectedSpecialiseringar;
            set => SetProperty(ref _selectedSpecialiseringar, value);
        }

        private Auktoritet _selectedAuktoritet;
        public Auktoritet SelectedAuktoritet
        {
            get => _selectedAuktoritet;
            set => SetProperty(ref _selectedAuktoritet, value);
        }


        private string _söktext;
        public string Söktext
        {
            get => _söktext;
            set
            {
                _söktext = value;
                OnPropertyChanged(nameof(Söktext));
                FiltreraPersonal();
            }
        }

        private List<Specialiseringar> _specialiseringarList;
        public List<Specialiseringar> SpecialiseringarList
        {
            get => _specialiseringarList;
            set
            {
                _specialiseringarList = value;
                OnPropertyChanged();
            }
        }

        private List<Auktoritet> _auktoritetList;
        public List<Auktoritet> AuktoritetList
        {
            get => _auktoritetList;
            set
            {
                _auktoritetList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> TypList { get; set; }


        // DATAGRID 


        private void LoadPersonal()
        {
            PersonalData = new ObservableCollection<Anställd>(_anställdcontroller.GetAnställd());
        }

        private Anställd _valdAnställd;
        public Anställd ValdAnställd
        {
            get => _valdAnställd;
            set
            {
                _valdAnställd = value;                
                if (value != null)
                {
                    Förnamn = value.Förnamn;
                    Efternamn = value.Efternamn;
                    Lösenord = value.Lösenord;


                    if (value is Mekaniker mekaniker)
                    {
                        SelectedSpecialiseringar = mekaniker.Specialiseringar;
                    }
                    else if (value is Receptionist receptionist)
                    {
                        SelectedAuktoritet = receptionist.Auktoritet;
                    }
                    OnPropertyChanged();
                }
            }
        }



        public IList<Anställd> _personaldata;
        public IList<Anställd> PersonalData
        {
            get => _personaldata;
            set => SetProperty(ref _personaldata, value);
        }

        private ICollectionView _filtreradePersonal;
        public ICollectionView FiltreradePersonal
        {
            get => _filtreradePersonal;
            private set
            {
                _filtreradePersonal = value;
                OnPropertyChanged(nameof(FiltreradePersonal));
            }
        }


        // SÖKFUNKTION


        private bool PersonalFilter(object obj)
        {
            if (obj is Anställd anställd)
            {

                return string.IsNullOrEmpty(Söktext) ||
                       anställd.AnställningsNummer.ToString().Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       anställd.Förnamn.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       anställd.Efternamn.Contains(Söktext, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        private void FiltreraPersonal()
        {
            FiltreradePersonal.Refresh(); // Uppdatera CollectionView när söktexten ändras
        }


        // LÄGG TILL ANSTÄLLD


        private ICommand? _läggTillAnställd;
        public ICommand LäggTillAnställdCommand => _läggTillAnställd ??= _läggTillAnställd = new RelayCommand(() =>
        {
            if (string.IsNullOrWhiteSpace(Förnamn) || string.IsNullOrWhiteSpace(Efternamn))
            {
                _messageService.ShowMessage("Förnamn och efternamn är obligatoriska fält.");
                return;
            }
            if (!IsLösenordValid(Lösenord) || string.IsNullOrWhiteSpace(Lösenord))
            {
                _messageService.ShowMessage("Lösenordet måste vara minst 8 tecken långt.");
                return;
            }

            if (Typ == "Mekaniker")
            {
                var mekaniker = new Mekaniker
                {
                    Förnamn = Förnamn,
                    Efternamn = Efternamn,
                    Lösenord = Lösenord,
                    Specialiseringar = SelectedSpecialiseringar
                };
                _anställdcontroller.AddAnställd(mekaniker);
                PersonalData.Add(mekaniker);
                _messageService.ShowMessage("Mekaniker tillagd.");
            }
            else if (Typ == "Receptionist")
            {
                var receptionist = new Receptionist
                {
                    Förnamn = Förnamn,
                    Efternamn = Efternamn,
                    Lösenord = Lösenord,
                    Auktoritet = SelectedAuktoritet
                };
                _anställdcontroller.AddAnställd(receptionist);
                PersonalData.Add(receptionist);
                _messageService.ShowMessage("Receptionist tillagd.");
            }
            // Nollställ textbox-värden
            Förnamn = "";
            Efternamn = "";
            Lösenord = "";
        });


        // TA BORT ANSTÄLLD


        public ICommand? _taBortAnställd;
        public ICommand TaBortAnställdCommand => _taBortAnställd ??= _taBortAnställd = new RelayCommand(() =>
        {
            // Kontrollerar om en anställd har en bokning
            if (ValdAnställd is Mekaniker mekaniker)
            {
                if (_mekanikercontroller.HarMekanikerBokning(mekaniker.AnställningsNummer))
                {
                    _messageService.ShowMessage("Mekaniker har en bokning och kan inte tas bort.");
                    return;
                }
            }
            else if (ValdAnställd is Receptionist receptionist)
            {
                if (_receptionistcontroller.HarReceptionistBokning(receptionist.AnställningsNummer))
                {
                    _messageService.ShowMessage("Receptionist har en bokning och kan inte tas bort.");
                    return;
                }
            }
            if (ValdAnställd != null)
            {
                _anställdcontroller.DeleteAnställd(ValdAnställd);
                PersonalData.Remove(ValdAnställd); // Ta bort reservdelen från IList för att uppdatera datagriden
                ValdAnställd = null; // Nollställ ValdReservdel efter borttagning
                LoadPersonal();
                _messageService.ShowMessage("Anställd borttagen.");

                // Nollställ textbox-värden
                Förnamn = "";
                Efternamn = "";
                Lösenord = "";

            }
        }, () => ValdAnställd != null);


        // UPPDATERA ANSTÄLLD


        public ICommand? _updateAnställd;
        public ICommand UpdateAnställdCommand => _updateAnställd ??= _updateAnställd = new RelayCommand(() =>
        {
            if (ValdAnställd != null)
            {
                if (string.IsNullOrWhiteSpace(Förnamn) || string.IsNullOrWhiteSpace(Efternamn))
                {
                    _messageService.ShowMessage("Förnamn och efternamn är obligatoriska fält.");
                    return;
                }
                if (!IsLösenordValid(Lösenord) || string.IsNullOrWhiteSpace(Lösenord))
                {
                    _messageService.ShowMessage("Lösenordet måste vara minst 8 tecken långt.");
                    return;
                }                

                ValdAnställd.Förnamn = Förnamn.ToLower();
                ValdAnställd.Efternamn = Efternamn.ToLower();
                ValdAnställd.Lösenord = Lösenord.ToLower();

                if (ValdAnställd is Mekaniker mekaniker)
                {
                    mekaniker.Specialiseringar = SelectedSpecialiseringar;
                }
                else if (ValdAnställd is Receptionist receptionist)
                {
                    receptionist.Auktoritet = SelectedAuktoritet;
                }

                _anställdcontroller.UpdateAnställd(ValdAnställd);

                LoadPersonal();
                _messageService.ShowMessage("Anställd uppdaterad.");

                // Nollställ textbox-värden
                Förnamn = "";
                Efternamn = "";
                Lösenord = "";


                ValdAnställd = null; // Nollställ ValdReservdel efter borttagning

            }
        }, () => ValdAnställd != null);


        // FELHANTERING


        private bool IsLösenordValid(string lösenord)
        {
            return lösenord.Length >= 8;
        }
    }
}

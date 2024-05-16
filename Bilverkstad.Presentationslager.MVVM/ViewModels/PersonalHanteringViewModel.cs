
using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class PersonalHanteringViewModel : BaseViewModel
    {
        private AnställdController _anställdcontroller;
        private ReceptionistController _receptionistcontroller;
        private MekanikerController _mekanikercontroller;

        // KONSTRUKTOR

        public PersonalHanteringViewModel()
        {
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
                OnPropertyChanged();
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


        // LÄGG TILL RESERVDEL

        private ICommand? _läggTillAnställd;
        public ICommand LäggTillAnställdCommand => _läggTillAnställd ??= _läggTillAnställd = new RelayCommand(() =>
        {

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
                MessageBox.Show("Mekaniker tillagd.");
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
                MessageBox.Show("Receptionist tillagd.");
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
            if (ValdAnställd != null)
            {
                _anställdcontroller.DeleteAnställd(ValdAnställd);
                PersonalData.Remove(ValdAnställd); // Ta bort reservdelen från IList för att uppdatera datagriden
                ValdAnställd = null; // Nollställ ValdReservdel efter borttagning
                LoadPersonal();
                MessageBox.Show("Anställd borttagen.");

                // Nollställ textbox-värden
                Förnamn = "";
                Efternamn = "";
                Lösenord = "";

            }
        }, () => ValdAnställd != null);


        //private void AddEmployee_Click(object sender, RoutedEventArgs e)
        //{
        //    string förnamn = FörnamnTextBox.Text;
        //    string efternamn = EfternamnTextBox.Text;
        //    string lösenord = LosenordPasswordBox.Password;
        //    string typ = (TypComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

        //    if (typ == "Mekaniker" && SpecializationComboBox.SelectedItem != null)
        //    {
        //        Specialiseringar specialisering = (Specialiseringar)Enum.Parse(typeof(Specialiseringar), (SpecializationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
        //        _allPersonal.Add(new Mekaniker
        //        {
        //            AnställningsNummer = _nextAnstallningsNummer++,
        //            Förnamn = förnamn,
        //            Efternamn = efternamn,
        //            Lösenord = lösenord,
        //            Specialiseringar = specialisering
        //        });
        //    }
        //    else if (typ == "Receptionist" && AuthorityComboBox.SelectedItem != null)
        //    {
        //        Auktoritet auktoritet = (Auktoritet)Enum.Parse(typeof(Auktoritet), (AuthorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
        //        _allPersonal.Add(new Receptionist
        //        {
        //            AnställningsNummer = _nextAnstallningsNummer++,
        //            Förnamn = förnamn,
        //            Efternamn = efternamn,
        //            Lösenord = lösenord,
        //            Auktoritet = auktoritet
        //        });
        //    }


        //    ClearInputFields();
        //}

        //private void EditEmployee_Click(object sender, RoutedEventArgs e)
        //{
        //    if (PersonalDataGrid.SelectedItem is Anställd selectedPersonal)
        //    {
        //        string förnamn = FörnamnTextBox.Text;
        //        string efternamn = EfternamnTextBox.Text;
        //        string lösenord = LosenordPasswordBox.Password;
        //        string typ = (TypComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

        //        selectedPersonal.Förnamn = förnamn;
        //        selectedPersonal.Efternamn = efternamn;
        //        selectedPersonal.Lösenord = lösenord;

        //        if (selectedPersonal is Mekaniker mekaniker && typ == "Mekaniker")
        //        {
        //            mekaniker.Specialiseringar = (Specialiseringar)Enum.Parse(typeof(Specialiseringar), (SpecializationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
        //        }
        //        else if (selectedPersonal is Receptionist receptionist && typ == "Receptionist")
        //        {
        //            receptionist.Auktoritet = (Auktoritet)Enum.Parse(typeof(Auktoritet), (AuthorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
        //        }


        //        ClearInputFields();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an employee to edit.");
        //    }
        //}

        



        //private void ClearInputFields()
        //{
        //    FörnamnTextBox.Clear();
        //    EfternamnTextBox.Clear();
        //    LosenordPasswordBox.Clear();
        //    TypComboBox.SelectedIndex = -1;
        //    SpecializationComboBox.Visibility = Visibility.Collapsed;
        //    SpecializationLabel.Visibility = Visibility.Collapsed;
        //    AuthorityComboBox.Visibility = Visibility.Collapsed;
        //    AuthorityLabel.Visibility = Visibility.Collapsed;
        //}

        
    }
}

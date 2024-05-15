using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class KundHanteringViewModel : BaseViewModel
    {
        private KundController _kundcontroller;
        private FordonController _fordoncontroller;



        private void LoadKunder()
        {
            KundData = _kundcontroller.GetKundWithFordon();
        }

        private Kund _valdKund;

        public Kund ValdKund
        {
            get { return _valdKund; }
            set
            {
                _valdKund = value;
                // När en kund väljs, kopiera dess attributvärden till egenskaperna
                if (_valdKund != null)
                {
                    Personnummer = _valdKund.Personnummer;
                    Förnamn = _valdKund.Förnamn;
                    Efternamn = _valdKund.Efternamn;
                    Gatuadress = _valdKund.Gatuadress;
                    Postnummer = _valdKund.Postnummer;
                    Ort = _valdKund.Ort;
                    Telefonnummer = _valdKund.Telefonnummer;
                    Epost = _valdKund.Epost;
                }
                OnPropertyChanged(nameof(ValdKund));
            }
        }


        private string _personnummer = "";
        public string Personnummer
        {
            get => _personnummer;
            set => SetProperty(ref _personnummer, value);
        }

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

        private string _gatuadress = "";
        public string Gatuadress
        {
            get => _gatuadress;
            set => SetProperty(ref _gatuadress, value);
        }
        private string _postnummer = "";
        public string Postnummer
        {
            get => _postnummer;
            set => SetProperty(ref _postnummer, value);
        }

        private string _ort = "";
        public string Ort
        {
            get => _ort;
            set => SetProperty(ref _ort, value);
        }
        private string _telefonnummer = "";
        public string Telefonnummer
        {
            get => _telefonnummer;
            set => SetProperty(ref _telefonnummer, value);
        }

        private string _epost = "";
        public string Epost
        {
            get => _epost;
            set => SetProperty(ref _epost, value);
        }
        private string _regNr = "";
        public string RegNr
        {
            get => _regNr;
            set => SetProperty(ref _regNr, value);
        }

        private string _bilmärke = "";
        public string Bilmärke
        {
            get => _bilmärke;
            set => SetProperty(ref _bilmärke, value);
        }
        private string _modell = "";
        public string Modell
        {
            get => _modell;
            set => SetProperty(ref _modell, value);
        }

        private string _söktext;
        public string Söktext
        {
            get => _söktext;
            set
            {
                _söktext = value;
                OnPropertyChanged(nameof(Söktext));
                FiltreraKunder();
            }
        }


        public IList<Kund> _kunddata;
        public IList<Kund> KundData
        {
            get => _kunddata;
            set => SetProperty(ref _kunddata, value);
        }

        private ICollectionView _filtreradeKunder;
        public ICollectionView FiltreradeKunder
        {
            get => _filtreradeKunder;
            private set
            {
                _filtreradeKunder = value;
                OnPropertyChanged(nameof(FiltreradeKunder));
            }
        }


        // KONSTRUKTOR
        public KundHanteringViewModel()
        {
            _kundcontroller = new KundController();
            _fordoncontroller = new FordonController();
            LoadKunder();
            KundData = new ObservableCollection<Kund>(_kundcontroller.GetKundWithFordon());
            FiltreradeKunder = CollectionViewSource.GetDefaultView(KundData);
            FiltreradeKunder.Filter = KundFilter;
        }

        // SÖKFUNKTION

        private bool KundFilter(object obj)
        {
            if (obj is Kund kund)
            {

                return string.IsNullOrEmpty(Söktext) ||
                       kund.Förnamn.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Efternamn.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Personnummer.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Telefonnummer.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Epost.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Id.ToString().Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       kund.Fordon.Any(f => f.RegNr.Contains(Söktext, StringComparison.OrdinalIgnoreCase)); ;
            }
            
            return false;
        }

        private void FiltreraKunder()
        {
            FiltreradeKunder.Refresh(); // Uppdatera CollectionView när söktexten ändras
        }



        // LÄGG TILL KUND MED FORDON

        private ICommand? _läggTillKund;
        public ICommand LäggTillKundCommand => _läggTillKund ??= _läggTillKund = new RelayCommand(() =>
        {

            if (string.IsNullOrWhiteSpace(Personnummer) || string.IsNullOrWhiteSpace(Förnamn) || string.IsNullOrWhiteSpace(Efternamn))
            {
                MessageBox.Show("Personnummer, förnamn och efternamn är obligatoriska fält.");
                return;
            }

            if (!IsPersonnummerValid(Personnummer))
            {
                MessageBox.Show("Personnummer måste vara 10 eller 12 tecken långt.");
                return;
            }

            if (IsDuplicateKund(Personnummer))
            {
                MessageBox.Show("En kund med detta personnummer finns redan.");
                return;
            }

            if (!IsTelefonnummerValid(Telefonnummer))
            {
                MessageBox.Show("Telefonnumret måste vara 10 eller 12 tecken långt.");
                return;
            }


            var kund = new Kund();
            kund = new Kund
            {
                Personnummer = Personnummer,
                Förnamn = Förnamn,
                Efternamn = Efternamn,
                Gatuadress = Gatuadress,
                Postnummer = Postnummer,
                Ort = Ort,
                Telefonnummer = Telefonnummer,
                Epost = Epost
            };

            if (!string.IsNullOrWhiteSpace(RegNr))
            {
                if (!IsRegNrValid(RegNr))
                {
                    MessageBox.Show("Registreringsnumret måste vara 6 tecken långt.");
                    return;
                }

                if (IsDuplicateRegNr(RegNr))
                {
                    MessageBox.Show("Ett fordon med detta registreringsnummer finns redan.");
                    return;
                }

                var fordon = new Fordon
                {
                    RegNr = RegNr,
                    Bilmärke = Bilmärke,
                    Modell = Modell
                };

                // Lägg till det nya fordonet på den valda kunden
                kund.Fordon.Add(fordon);
                _kundcontroller.AddKund(kund);
                LoadKunder();
                MessageBox.Show("Kund tillagd.");

                // Nollställ textbox-värden
                Personnummer = "";
                Förnamn = "";
                Efternamn = "";
                Gatuadress = "";
                Postnummer = "";
                Ort = "";
                Telefonnummer = "";
                Epost = "";
                RegNr = "";
                Bilmärke = "";
                Modell = "";

            }
        });

        // TA BORT KUND

        public ICommand? _taBortKund;
        public ICommand TaBortKundCommand => _taBortKund ??= _taBortKund = new RelayCommand(() =>
        {
            if (ValdKund != null)
            {
                _kundcontroller.DeleteKund(ValdKund);
                KundData.Remove(ValdKund); // Ta bort kunden från IList för att uppdatera datagriden
                ValdKund = null; // Nollställ ValdKund efter borttagning
                LoadKunder();
                MessageBox.Show("Kund borttagen.");

                // Nollställ textbox-värden
                Personnummer = "";
                Förnamn = "";
                Efternamn = "";
                Gatuadress = "";
                Postnummer = "";
                Ort = "";
                Telefonnummer = "";
                Epost = "";
            }
        }, () => ValdKund != null);

        // UPPDATERA KUND

        public ICommand? _updateKund;

        public ICommand UpdateKundCommand => _updateKund ??= _updateKund = new RelayCommand(() =>
        {
            if (ValdKund != null)
            {
                if (string.IsNullOrWhiteSpace(Personnummer) || string.IsNullOrWhiteSpace(Förnamn) || string.IsNullOrWhiteSpace(Efternamn))
                {
                    MessageBox.Show("Personnummer, förnamn och efternamn är obligatoriska fält.");
                    return;
                }

                if (!IsPersonnummerValid(Personnummer))
                {
                    MessageBox.Show("Personnummer måste vara 10 eller 12 tecken långt.");
                    return;
                }

                if (!IsTelefonnummerValid(Telefonnummer))
                {
                    MessageBox.Show("Telefonnumret måste vara 10 eller 12 tecken långt.");
                    return;
                }

                ValdKund.Personnummer = Personnummer;
                ValdKund.Förnamn = Förnamn;
                ValdKund.Efternamn = Efternamn;
                ValdKund.Gatuadress = Gatuadress;
                ValdKund.Postnummer = Postnummer;
                ValdKund.Ort = Ort;
                ValdKund.Telefonnummer = Telefonnummer;
                ValdKund.Epost = Epost;
                _kundcontroller.UpdateKund(ValdKund);

                LoadKunder();
                MessageBox.Show("Kund uppdaterad.");

                // Nollställ textbox-värden
                Personnummer = "";
                Förnamn = "";
                Efternamn = "";
                Gatuadress = "";
                Postnummer = "";
                Ort = "";
                Telefonnummer = "";
                Epost = "";
                ValdKund = null; // Nollställ ValdKund efter borttagning

            }
        }, () => ValdKund != null);



        // LÄGG TILL ETT NYTT FORDON PÅ KUND

        public ICommand? _läggTillFordonPåKundCommand;

        public ICommand LäggTillFordonPåKundCommand => _läggTillFordonPåKundCommand ??= _läggTillFordonPåKundCommand = new RelayCommand(() =>
        {
            if (ValdKund == null)
            {
                MessageBox.Show("Vänligen välj en kund innan du lägger till ett fordon.");
                return;
            }

            if (string.IsNullOrWhiteSpace(RegNr))
            {
                MessageBox.Show("Registreringsnummer är obligatoriskt.");
                return;
            }

            if (!IsRegNrValid(RegNr))
            {
                MessageBox.Show("Registreringsnumret måste vara 6 tecken långt.");
                return;
            }

            if (IsDuplicateRegNr(RegNr))
            {
                MessageBox.Show("Ett fordon med detta registreringsnummer finns redan.");
                return;
            }

            var nyttFordon = new Fordon
            {
                RegNr = RegNr,
                Bilmärke = Bilmärke,
                Modell = Modell,
                KundId = ValdKund.Id
            };

            _fordoncontroller.AddFordon(nyttFordon);
            // Lägg till det nya fordonet på den valda kunden
            ValdKund.Fordon.Add(nyttFordon);

            // Uppdatera kunden i databasen med det nya fordonet
            _kundcontroller.UpdateKund(ValdKund);
            LoadKunder();
            MessageBox.Show("Fordon tillagd.");

        }, () => ValdKund != null);

        // FELHANTERING 

        private bool IsPersonnummerValid(string personnummer)
        {
            return personnummer.Length == 10 || personnummer.Length == 12;
        }

        private bool IsTelefonnummerValid(string telefonnummer)
        {
            return telefonnummer.Length == 10 || telefonnummer.Length == 12;
        }

        private bool IsRegNrValid(string regNr)
        {
            return regNr.Length == 6;
        }

        private bool IsDuplicateKund(string personnummer)
        {
            return KundData.Any(k => k.Personnummer == personnummer);
        }

        private bool IsDuplicateRegNr(string regNr)
        {
            return KundData.SelectMany(k => k.Fordon).Any(f => f.RegNr == regNr);
        }
    }
}

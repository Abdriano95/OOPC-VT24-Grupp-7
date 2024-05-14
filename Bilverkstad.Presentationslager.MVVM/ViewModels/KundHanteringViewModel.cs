using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        public IList<Kund> _kunddata;
        public IList<Kund> KundData
        {
            get => _kunddata;
            set => SetProperty(ref _kunddata, value);
        }

        private string _sök = "";
        public string Sök
        {
            get => _sök;
            set => SetProperty(ref _sök, value);
        }
        
        public KundHanteringViewModel() 
        { 
            _kundcontroller = new KundController(); 
            _fordoncontroller = new FordonController();
            LoadKunder();
        }

        private ICommand? _läggTillKund;
        public ICommand LäggTillKundCommand => _läggTillKund ??= _läggTillKund = new RelayCommand(() =>
        {
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

        });
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

        public ICommand? _updateKund;

        public ICommand UpdateKundCommand => _updateKund ??= _updateKund = new RelayCommand(() =>
        {
            if (ValdKund != null)
            {
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

        public ICommand? _läggTillFordonPåKundCommand;

        public ICommand LäggTillFordonPåKundCommand => _läggTillFordonPåKundCommand ??= _läggTillFordonPåKundCommand = new RelayCommand(() =>
        {
            if (ValdKund != null)
            {
                var nyttFordon = new Fordon
                {
                    RegNr = RegNr,
                    Bilmärke = Bilmärke,
                    Modell = Modell
                };

                // Lägg till det nya fordonet på den valda kunden
                ValdKund.Fordon.Add(nyttFordon);

                // Uppdatera kunden i databasen med det nya fordonet
                _kundcontroller.AddOrUpdateKund(ValdKund);
                LoadKunder();
                MessageBox.Show("Fordon tillagd.");
            }

        }, () => ValdKund != null); 
    }
}

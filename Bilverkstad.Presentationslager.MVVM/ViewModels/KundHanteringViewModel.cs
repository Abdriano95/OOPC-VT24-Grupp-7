using Bilverkstad.Affärslager;
using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class KundHanteringViewModel : BaseViewModel
    {
        private KundController _kundcontroller;
        private FordonController _fordoncontroller;

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
            var fordon = new Fordon();
            fordon = new Fordon
            {
                RegNr = RegNr,
                Bilmärke = Bilmärke,
                Modell = Modell   
            };
            kund.Fordon.Add(fordon);
            _kundcontroller.AddKund(kund);
               
        });
        public ICommand TaBortKund { get; }
        public ICommand UpdateKund { get; }
    }
}

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
    public class ReservdelHanteringViewModel : BaseViewModel
    {
        private ReservdelController _reservdelcontroller;    

        // KONSTRUKTOR
        public ReservdelHanteringViewModel()
        {
            _reservdelcontroller = new ReservdelController();
            LoadReservdelar();
            ReservdelData = new ObservableCollection<Reservdel>(_reservdelcontroller.GetReservdel());
            FiltreradeReservdelar = CollectionViewSource.GetDefaultView(ReservdelData);
            FiltreradeReservdelar.Filter = ReservdelFilter;
        }

        // PROPERTIES
        // test

        private string _namn = "";
        public string Namn
        {
            get => _namn;
            set => SetProperty(ref _namn, value);
        }

        private float _pris;
        public float Pris
        {
            get => _pris;
            set => SetProperty(ref _pris, value);
        }

        private string _söktext;
        public string Söktext
        {
            get => _söktext;
            set
            {
                _söktext = value;
                OnPropertyChanged(nameof(Söktext));
                FiltreraReservdelar();
            }
        }

        // DATAGRID

        private void LoadReservdelar()
        {
            ReservdelData = _reservdelcontroller.GetReservdel();
        }

        private Reservdel _valdReservdel;

        public Reservdel ValdReservdel
        {
            get { return _valdReservdel; }
            set
            {
                _valdReservdel = value;
                // När en reservdel väljs, kopiera dess attributvärden till egenskaperna
                if (_valdReservdel != null)
                {
                    Namn = _valdReservdel.Namn;
                    Pris = _valdReservdel.Pris;
                    
                }
                OnPropertyChanged(nameof(ValdReservdel));
            }
        }

        public IList<Reservdel> _reservdeldata;
        public IList<Reservdel> ReservdelData
        {
            get => _reservdeldata;
            set => SetProperty(ref _reservdeldata, value);
        }

        private ICollectionView _filtreradeReservdelar;
        public ICollectionView FiltreradeReservdelar
        {
            get => _filtreradeReservdelar;
            private set
            {
                _filtreradeReservdelar = value;
                OnPropertyChanged(nameof(FiltreradeReservdelar));
            }
        }

        // SÖKFUNKTION

        private bool ReservdelFilter(object obj)
        {
            if (obj is Reservdel reservdel)
            {

                return string.IsNullOrEmpty(Söktext) ||
                       reservdel.Artikelnummer.ToString().Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       reservdel.Namn.Contains(Söktext, StringComparison.OrdinalIgnoreCase) ||
                       reservdel.Pris.ToString().Contains(Söktext, StringComparison.OrdinalIgnoreCase);      
            }

            return false;
        }

        private void FiltreraReservdelar()
        {
            FiltreradeReservdelar.Refresh(); // Uppdatera CollectionView när söktexten ändras
        }

        // LÄGG TILL RESERVDEL

        private ICommand? _läggTillReservdel;
        public ICommand LäggTillReservdelCommand => _läggTillReservdel ??= _läggTillReservdel = new RelayCommand(() =>
        {

            var reservdel = new Reservdel();
            reservdel = new Reservdel
            { 
                Namn = Namn,
                Pris = Pris
                
            };

            if (IsDuplicateReservdel(Namn))
            {
                MessageBox.Show("En reservdel med detta namn finns redan.");
                return;
            }

            _reservdelcontroller.AddReservdel(reservdel);
            LoadReservdelar();
            MessageBox.Show("Reservdel tillagd.");

            // Nollställ textbox-värden
            Namn = "";
            Pris = 0;
        });


        // TA BORT RESERVDEL

        public ICommand? _taBortReservdel;
        public ICommand TaBortReservdelCommand => _taBortReservdel ??= _taBortReservdel = new RelayCommand(() =>
        {
            if (ValdReservdel != null)
            {
                _reservdelcontroller.DeleteReservdel(ValdReservdel);
                ReservdelData.Remove(ValdReservdel); // Ta bort reservdelen från IList för att uppdatera datagriden
                ValdReservdel = null; // Nollställ ValdReservdel efter borttagning
                LoadReservdelar();
                MessageBox.Show("Reservdel borttagen.");

                // Nollställ textbox-värden
                Namn = "";
                Pris = 0;
                
            }
        }, () => ValdReservdel != null);


        // UPPDATERA RESERVDEL

        public ICommand? _updateReservdel;

        public ICommand UpdateReservdelCommand => _updateReservdel ??= _updateReservdel = new RelayCommand(() =>
        {
            if (ValdReservdel != null)
            {
                if (string.IsNullOrWhiteSpace(Namn))
                {
                    MessageBox.Show("Namn och pris är obligatoriska fält.");
                    return;
                }
                if (Pris == 0 || float.IsNegative(Pris))
                {
                    MessageBox.Show("Pris måste vara ett positivt värde.");
                    return;
                }

                ValdReservdel.Namn = Namn;
                ValdReservdel.Pris = Pris;
                
                _reservdelcontroller.UpdateReservdel(ValdReservdel);

                LoadReservdelar();
                MessageBox.Show("Reservdel uppdaterad.");

                // Nollställ textbox-värden
                Namn = "";
                Pris = 0;
                
                ValdReservdel = null; // Nollställ ValdReservdel efter borttagning

            }
        }, () => ValdReservdel != null);

        // FELHANTERING 

        private bool IsDuplicateReservdel(string namn)
        {
            return ReservdelData.Any(r => r.Namn == namn);
        }

    }
}

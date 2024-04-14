using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Bilverkstad.Presentationslager.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private IKundDataService _kundDataService;
        private Kund _selectedKund;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(IKundDataService kundDataService)
        {
            Kunder = new ObservableCollection<Kund>();
            _kundDataService = kundDataService;
        }

        public void Load()
        { 
            var kunder = _kundDataService.GetAll();

            Kunder.Clear();// Tömma listan efter man har adderad för att undvika duplikat 
            foreach (var kund in kunder)
            {
               Kunder.Add(kund);
            }
        }
        public ObservableCollection<Kund> Kunder { get; set; }

        public Kund SelectedKund
        {
            get { return _selectedKund; }
            set { _selectedKund = value;
                OnPropertyChanged();
            }
        }

        

        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

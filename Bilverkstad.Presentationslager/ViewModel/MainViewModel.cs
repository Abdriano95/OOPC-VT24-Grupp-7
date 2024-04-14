using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.Data;
using System.Collections.ObjectModel;


namespace Bilverkstad.Presentationslager.ViewModel
{
    public class MainViewModel
    {
        private IKundDataService _kundDataService;
        private Kund _selectedKund;
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
            set { _selectedKund = value; }
        }

    }
}

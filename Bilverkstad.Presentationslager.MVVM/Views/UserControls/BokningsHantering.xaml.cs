using Bilverkstad.Entitetlagret;
using System.Windows;
using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BokningsHantering.xaml
    /// </summary>
    public partial class BokningsHantering : UserControl
    {
        private List<Kund> _allCustomers;
        private List<Kund> _filteredCustomers;
        private List<JournalEntry> _allJournals;
        private List<Bokning> _allBookings;
        private List<Reparation> _allReparations;

        public string UserRole { get; set; } // Receptionist, Mechanic, Admin
        public BokningsHantering()
        {
            InitializeComponent();
        }

        public void LäggTillBokning_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bokning skapad!");
        }

        public void UppdateraBokning_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bokning ändrad!");
        }

        private void BookingsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookingsDataGrid.SelectedItem is Bokning selectedBooking)
            {
                var filteredJournal = _allJournals.Where(j => j.BokningId == selectedBooking.Id).ToList();
                ReparationsDataGrid.ItemsSource = filteredJournal;
            }
            else
            {
                ReparationsDataGrid.ItemsSource = new List<JournalEntry>();
            }
        }

        public void TaBortBokning_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bokning borttaget!");
        }

        private void CustomerSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = CustomerSearchTextBox.Text.ToLower();
            _filteredCustomers = _allCustomers.Where(c =>
                c.Förnamn?.ToLower().Contains(searchText) == true ||
                c.Efternamn?.ToLower().Contains(searchText) == true ||
                c.Personnummer?.ToLower().Contains(searchText) == true ||
                c.Id.ToString().Contains(searchText)).ToList();
            UpdateCustomerComboBox();
        }

        private void UpdateCustomerComboBox()
        {
            CustomerComboBox.ItemsSource = _filteredCustomers;
            CustomerComboBox.DisplayMemberPath = "FullständigtNamn";
        }

        private void LoadCustomers()
        {
            _allCustomers = new List<Kund>
            {
                new Kund { Id = 1, Förnamn = "John", Efternamn = "Doe", Personnummer = "900101-1234", Gatuadress = "Main St 123", Postnummer = "12345", Ort = "Stockholm", Telefonnummer = "0701234567", Epost = "john.doe@example.com" },
                new Kund { Id = 2, Förnamn = "Jane", Efternamn = "Doe", Personnummer = "920202-5678", Gatuadress = "Second Ave 456", Postnummer = "23456", Ort = "Göteborg", Telefonnummer = "0702345678", Epost = "jane.doe@example.com" },
                new Kund { Id = 3, Förnamn = "Alice", Efternamn = "Smith", Personnummer = "930303-9101", Gatuadress = "Third Blvd 789", Postnummer = "34567", Ort = "Malmö", Telefonnummer = "0703456789", Epost = "alice.smith@example.com" },
                new Kund { Id = 4, Förnamn = "Bob", Efternamn = "Johnson", Personnummer = "940404-2345", Gatuadress = "Fourth Rd 101", Postnummer = "45678", Ort = "Uppsala", Telefonnummer = "0704567890", Epost = "bob.johnson@example.com" },
                new Kund { Id = 5, Förnamn = "Carol", Efternamn = "Williams", Personnummer = "950505-6789", Gatuadress = "Fifth Ln 202", Postnummer = "56789", Ort = "Västerås", Telefonnummer = "0705678901", Epost = "carol.williams@example.com" }
            };

            _filteredCustomers = new List<Kund>(_allCustomers);
            UpdateCustomerComboBox();
        }

        private void LoadSampleData()
        {
            var bookings = new List<Bokning>
            {
                new Bokning { Id = 1, KundId = 1, FordonRegNr = "ABC123", ReceptionistId = 1, MekanikerId = 1, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Service", BokningStatus = Status.Inlämnad },
                new Bokning { Id = 2, KundId = 2, FordonRegNr = "DEF456", ReceptionistId = 2, MekanikerId = 2, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Reparation", BokningStatus = Status.Avbruten },
                new Bokning { Id = 3, KundId = 3, FordonRegNr = "GHI789", ReceptionistId = 3, MekanikerId = null, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Besiktning", BokningStatus = Status.Pågående },
                new Bokning { Id = 4, KundId = 4, FordonRegNr = "JKL012", ReceptionistId = 4, MekanikerId = 2, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Däckbyte", BokningStatus = Status.Utlämnad },
                new Bokning { Id = 5, KundId = 5, FordonRegNr = "MNO345", ReceptionistId = 5, MekanikerId = 1, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Service", BokningStatus = Status.Inlämnad },
                new Bokning { Id = 6, KundId = 1, FordonRegNr = "PQR678", ReceptionistId = 2, MekanikerId = 3, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Reparation", BokningStatus = Status.Avbruten },
                new Bokning { Id = 7, KundId = 2, FordonRegNr = "STU901", ReceptionistId = 3, MekanikerId = null, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Besiktning", BokningStatus = Status.Pågående },
                new Bokning { Id = 8, KundId = 3, FordonRegNr = "VWX234", ReceptionistId = 4, MekanikerId = 2, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Däckbyte", BokningStatus = Status.Utlämnad },
                new Bokning { Id = 9, KundId = 4, FordonRegNr = "YZÅÄ345", ReceptionistId = 5, MekanikerId = 1, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Service", BokningStatus = Status.Inlämnad },
                new Bokning { Id = 10, KundId = 5, FordonRegNr = "ÖÖÖ666", ReceptionistId = 2, MekanikerId = 3, InlämningsDatum = DateTime.Now, SyfteMedBesök = "Reparation", BokningStatus = Status.Avbruten }

            };

            _allJournals = new List<JournalEntry>
            {
                new JournalEntry { Id = 1, BokningId = 1, FordonRegNr = "ABC123", Description = "Service - Oil change", Date = DateTime.Now.AddMonths(-1) },
                new JournalEntry { Id = 2, BokningId = 1, FordonRegNr = "ABC123", Description = "Service - Tire rotation", Date = DateTime.Now.AddMonths(-2) },
                new JournalEntry { Id = 3, BokningId = 2, FordonRegNr = "DEF456", Description = "Reparation - Engine diagnostics", Date = DateTime.Now.AddMonths(-3) },
                new JournalEntry { Id = 4, BokningId = 3, FordonRegNr = "GHI789", Description = "Besiktning - Inspection passed", Date = DateTime.Now.AddMonths(-4) }
            };

            _allReparations = new List<Reparation>
            {
                new Reparation { ReparationsId = 1, BokningsId = 1, Artikelnummer = 101, Reparationsstatus = Reparationsstatus.Klar, Åtgärd = "Service - Oil change", ReservdelId = 1 },
                new Reparation { ReparationsId = 2, BokningsId = 1, Artikelnummer = 102, Reparationsstatus = Reparationsstatus.Klar, Åtgärd = "Service - Tire rotation", ReservdelId = 2 },
                new Reparation { ReparationsId = 3, BokningsId = 2, Artikelnummer = 103, Reparationsstatus = Reparationsstatus.Påbörjad, Åtgärd = "Reparation - Engine diagnostics", ReservdelId = 3 },
                new Reparation { ReparationsId = 4, BokningsId = 3, Artikelnummer = 104, Reparationsstatus = Reparationsstatus.EjPåbörjad, Åtgärd = "Besiktning - Inspection passed", ReservdelId = 4 }
            };




            ReparationsDataGrid.ItemsSource = new List<Reparation>();
            BookingsDataGrid.ItemsSource = bookings;
            JournalDataGrid.ItemsSource = new List<JournalEntry>();
        }
        private void AddReparation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Reparation Clicked!");
        }

        private void EditReparation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit Reparation Clicked!");
        }

        private void DeleteReparation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete Reparation Clicked!");
        }
    }

    public class JournalEntry
    {
        public int Id { get; set; }
        public int BokningId { get; set; }
        public string FordonRegNr { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => $"{Date.ToShortDateString()}: {Description}";
    }
}

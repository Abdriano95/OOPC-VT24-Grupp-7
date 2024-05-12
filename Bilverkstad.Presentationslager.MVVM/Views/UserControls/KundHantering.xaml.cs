using Bilverkstad.Entitetlagret;

using System.Windows.Controls;


namespace Bilverkstad.Presentationslager.MVVM.Views.UserControls
{
    /// <summary>
    /// Interaction logic for KundHantering.xaml
    /// </summary>
    public partial class KundHantering : UserControl
    {
        public KundHantering()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            var random = new Random();
            var sampleData = new List<Kund>
            {
                new Kund { Id = 1, Förnamn = "John", Efternamn = "Doe", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Main St 123", Postnummer = "12345", Ort = "Stockholm", Telefonnummer = "0701234567", Epost = "john.doe@example.com" },
                new Kund { Id = 2, Förnamn = "Jane", Efternamn = "Doe", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Second Ave 456", Postnummer = "23456", Ort = "Göteborg", Telefonnummer = "0702345678", Epost = "jane.doe@example.com" },
                new Kund { Id = 3, Förnamn = "Alice", Efternamn = "Smith", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Third Blvd 789", Postnummer = "34567", Ort = "Malmö", Telefonnummer = "0703456789", Epost = "alice.smith@example.com" },
                new Kund { Id = 4, Förnamn = "Bob", Efternamn = "Johnson", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Fourth Rd 101", Postnummer = "45678", Ort = "Uppsala", Telefonnummer = "0704567890", Epost = "bob.johnson@example.com" },
                new Kund { Id = 5, Förnamn = "Carol", Efternamn = "Williams", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Fifth Ln 202", Postnummer = "56789", Ort = "Västerås", Telefonnummer = "0705678901", Epost = "carol.williams@example.com" },
                new Kund { Id = 6, Förnamn = "David", Efternamn = "Brown", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Sixth Ave 234", Postnummer = "2345", Ort = "Kiruna", Telefonnummer = "073232445", Epost = "david.brown@asshole.se"},
                new Kund { Id = 7, Förnamn = "Eva", Efternamn = "Green", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Seventh St 456", Postnummer = "3456", Ort = "Luleå", Telefonnummer = "073232445", Epost = "Green@wowdude.se"},
                new Kund { Id = 8, Förnamn = "Fredrik", Efternamn = "Yellow", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Eighth Ave 678", Postnummer = "4567", Ort = "Piteå", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 9, Förnamn = "Greta", Efternamn = "Purple", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Ninth Blvd 890", Postnummer = "5678", Ort = "Haparanda", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 10, Förnamn = "Hans", Efternamn = "Orange", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Tenth Rd 101", Postnummer = "6789", Ort = "Kalix", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 11, Förnamn = "Ingrid", Efternamn = "Black", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Eleventh Ln 112", Postnummer = "7890", Ort = "Haparanda", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 12, Förnamn = "Johan", Efternamn = "White", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Twelfth St 131", Postnummer = "8901", Ort = "Kalix", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 13, Förnamn = "Karin", Efternamn = "Red", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Thirteenth Ave 141", Postnummer = "9012", Ort = "Luleå", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 14, Förnamn = "Lars", Efternamn = "Blue", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Fourteenth Blvd 151", Postnummer = "0123", Ort = "Kiruna", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 15, Förnamn = "Maja", Efternamn = "Pink", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Fifteenth Rd 161", Postnummer = "1234", Ort = "Västerås", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 16, Förnamn = "Nils", Efternamn = "Brown", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Sixteenth Ave 171", Postnummer = "2345", Ort = "Uppsala", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 17, Förnamn = "Olof", Efternamn = "Green", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Seventeenth St 181", Postnummer = "3456", Ort = "Malmö", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},
                new Kund { Id = 18, Förnamn = "Pia", Efternamn = "Yellow", Personnummer = GenerateRandomPersonnummer(random), Gatuadress = "Eighteenth Ave 191", Postnummer = "4567", Ort = "Göteborg", Telefonnummer = "073232445", Epost = "asdfsadfasdf"},

            };

            KunderDataGrid.ItemsSource = sampleData;
        }

        private string GenerateRandomPersonnummer(Random random)
        {
            var year = random.Next(1900, 2022);
            var month = random.Next(1, 13);
            var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            var lastFourDigits = random.Next(1000, 10000);

            return $"{year}{month:00}{day:00}-{lastFourDigits}";
        }
    }
}

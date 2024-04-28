using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Datalager
{
    public class BilverkstadSeed
    {
        // Define the Specialistområde enum
        public enum Specialistområde
        {
            Dackbyte,
            Motor
        }

        public static void Populate(BilverkstadContext bilverkstad)
        {
            // Seed customers and their vehicles
            var kund1 = new Kund
            {
                Förnamn = "Mohamud",
                Efternamn = "Abbass",
                Personnummer = "194506284783",
                Gatuadress = "La",
                Postnummer = "4353",
                Ort = "Happaranda",
                Telefonnummer = "112",
                Epost = "Mohamud@hotmail.com",
                Fordon = new List<Fordon>
                {
                    new Fordon { RegNr = "ABC123", Bilmärke = "Volvo", Modell = "X70" },
                    new Fordon { RegNr = "DEF456", Bilmärke = "Saab", Modell = "9-5" }
                }
            };

            var kund2 = new Kund
            {
                Förnamn = "Janne",
                Efternamn = "Svensson",
                Personnummer = "19300530-8118",
                Gatuadress = "Sveavägen 7",
                Postnummer = "23759",
                Ort = "Kiruna",
                Telefonnummer = "1177",
                Epost = "Jannesvesson@hotmail.com",
                Fordon = new List<Fordon>
                {
                    new Fordon { RegNr = "GHI789", Bilmärke = "Tesla", Modell = "Model S" }
                }
            };

            bilverkstad.Add(kund1);
            bilverkstad.Add(kund2);

            // Seed employees
            bilverkstad.Add(new Mekaniker { Förnamn = "Karl", Efternamn = "Andersson", Specialiseringar = Specialiseringar.Motor, Lösenord = "pwd12345" });
            bilverkstad.Add(new Mekaniker { Förnamn = "Eva", Efternamn = "Lund", Specialiseringar = Specialiseringar.Dackbyte, Lösenord = "pwd67890" });
            bilverkstad.Add(new Receptionist { Förnamn = "Lisa", Efternamn = "Karlsson", Lösenord = "Lösenord123", Auktoritet = Auktoritet.Admin });
            bilverkstad.Add(new Receptionist { Förnamn = "Anna", Efternamn = "Nilsson", Lösenord = "adminpwd", Auktoritet = Auktoritet.NotAdmin });

            // Seed spare parts
            bilverkstad.Add(new Reservdel { Namn = "Oljefilter", Pris = 150 });
            bilverkstad.Add(new Reservdel { Namn = "Vindruta", Pris = 2500 });
            bilverkstad.Add(new Reservdel { Namn = "Bromspad", Pris = 300 });
            bilverkstad.Add(new Reservdel { Namn = "Tändstift", Pris = 100 });

            bilverkstad.SaveChanges();
        }
    }
}

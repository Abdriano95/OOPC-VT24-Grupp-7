using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Datalager
{
    public class BilverkstadSeed
    {
        public static void Populate(BilverkstadContext bilverkstad)
        {
            // Check if the database has already been seeded
            if (!bilverkstad.Kund.Any())
            {
                var kund1 = new Kund
                {
                    Förnamn = "Markus",
                    Efternamn = "Adamnsson",
                    Personnummer = "194506284783",
                    Gatuadress = "Göteborgsvägen 4",
                    Postnummer = "4353",
                    Ort = "Stockholm",
                    Telefonnummer = "0735583876",
                    Epost = "Markus@hotmail.com",
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

                // Add customers in a batch
                bilverkstad.AddRange(kund1, kund2);

                // Add employees
                bilverkstad.AddRange(
                    new Receptionist { Förnamn = "Abraham", Efternamn = "Andersson", Lösenord = "123", Auktoritet = Auktoritet.Admin },
                    new Mekaniker { Förnamn = "Karl", Efternamn = "Andersson", Specialiseringar = Specialiseringar.Motor, Lösenord = "pwd12345" },
                    new Mekaniker { Förnamn = "Eva", Efternamn = "Lund", Specialiseringar = Specialiseringar.Dackbyte, Lösenord = "pwd67890" },
                    new Receptionist { Förnamn = "Lisa", Efternamn = "Karlsson", Lösenord = "Lösenord123", Auktoritet = Auktoritet.Admin },
                    new Receptionist { Förnamn = "Anna", Efternamn = "Nilsson", Lösenord = "jagäringenadmin", Auktoritet = Auktoritet.NotAdmin }

                );

                // Add spare parts
                bilverkstad.AddRange(
                    new Reservdel { Namn = "Oljefilter", Pris = 150 },
                    new Reservdel { Namn = "Vindruta", Pris = 2500 },
                    new Reservdel { Namn = "Bromspad", Pris = 300 },
                    new Reservdel { Namn = "Tändstift", Pris = 100 }
                );

                // Attempt to save all changes
                try
                {
                    bilverkstad.SaveChanges();
                    Console.WriteLine("Database seeded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                    }
                    else
                    {
                        Console.WriteLine("No inner exception is available.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Database is already seeded.");
            }
        }
    }
}

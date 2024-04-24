using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Datalager.BilverkstadSeed.cs
{
    public class BilverkstadSeed
    {
        public static void Populate(BilverkstadContext bilverkstad)
        {
            bilverkstad.Add(new Kund()
            {
                Förnamn = "Mohamud",
                Efternamn = "Abbass",
                Personnummer = "194506284783",
                Gatuadress = "Bergsjöngatan 43",
                Postnummer = "4353",
                Ort = "Happaranda",
                Telefonnummer = "112",
                Epost = "Mohamud@hotmail.com"
            });
            bilverkstad.Add(new Kund()
            {
                Förnamn = "Janne",
                Efternamn = "Svensson",
                Personnummer = "19300530-8118",
                Gatuadress = "Sveavägen 7",
                Postnummer = "23759",
                Ort = "Kiruna",
                Telefonnummer = "1177",
                Epost = "Jannesvesson@hotmail.com"

            });

            bilverkstad.Add(new Fordon()
            {
                RegNr = "ABC123",
                Bilmärke = "Volvo",
                Modell = "X70",
            });

            bilverkstad.SaveChanges();
        } 
    }
}

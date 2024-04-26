
using Bilverkstad.Affärslager;
using Bilverkstad.Datalager;
using Bilverkstad.Datalager.BilverkstadSeed.cs;

namespace Testlager
{
    public class Program
    {
        static void Main(string[] args)
        {
            KundController kundController = new KundController();
            FordonController fordonController = new FordonController();
            BilverkstadContext bilverkstad = new BilverkstadContext();

            //bilverkstad.Database.EnsureDeleted();
            //bilverkstad.Database.EnsureCreated();
            ////BilverkstadSeed.Populate(bilverkstad);
            //Kund kund = new Kund();
            //det här är min branch
            //kund.Förnamn = "Abdulla";
            //kund.Efternamn = "Mehdi";
            //kund.Personnummer = "19950420-8118";
            //kund.Gatuadress = "Riksdalersgatan 45";
            //kund.Postnummer = "4141";
            //kund.Ort = "Göteborg";
            //kund.Telefonnummer = "0707524755";
            //kund.Epost = "abdulla.m@live.se";

            //Fordon fordon = new Fordon();
            //fordon.RegNr = "ABE123";
            //fordon.Bilmärke = "Volkswagen";
            //fordon.Modell = "Golf";
            //fordon.Kund = kund;

            //kund.Fordon.Add(fordon);
            //kundController.AddKund(kund);

            //Console.WriteLine(kundController.GetKund().ToString());


            // hejhej
            bilverkstad.Database.EnsureDeleted();
            bilverkstad.Database.EnsureCreated();
            //BilverkstadSeed.PopulateReceptionist(bilverkstad);
            Console.ReadLine();
        }


    }
}

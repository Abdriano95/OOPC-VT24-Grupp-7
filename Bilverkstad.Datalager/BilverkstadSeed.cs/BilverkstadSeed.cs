using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Datalager.BilverkstadSeed.cs
{
    public class BilverkstadSeed
    {
        public static void Populate(BilverkstadContext bilverkstad)
        {
            bilverkstad.Add(new Kund() {Förnamn = "Mohamud", Efternamn = "Abbass", Personnummer = "194506284783",Gatuadress="La",
                Postnummer=145, Ort="Happaranda", Telefonnummer="112", Epost="Mohamud@hotmail.com" });
            bilverkstad.Add(new Kund()
            {
                Förnamn = "Janne",
                Efternamn = "Svensson",
                Personnummer = "19300530-8118",
                Gatuadress = "Sveavägen 7",
                Postnummer = 23759,
                Ort = "Kiruna",
                Telefonnummer = "1177",
                Epost = "Jannesvesson@hotmail.com"
            });

            bilverkstad.SaveChanges();
        }
    }
}

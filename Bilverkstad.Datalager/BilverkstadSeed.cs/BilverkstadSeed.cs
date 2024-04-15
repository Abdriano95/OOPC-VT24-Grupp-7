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
            bilverkstad.SaveChanges();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret
{
    public class Kund
    {
        [Key]  
        public int kundnummer { get; set; }
        public string förnamn { get; set; }
        public string efternamn { get; set; }
        public string personnummer { get; set; }
        public string gatuadress { get; set; }
        public int postnummer { get; set; }
        public string ort { get; set; }
        public string telnr { get; set; }
        public string epost { get; set; }


        //public Kund(int kundnummer, string förnamn, string efternamn, string personnummer)
        //{
        //    this.kundnummer = kundnummer;
        //    this.förnamn = förnamn;
        //    this.efternamn = efternamn;
        //    this.personnummer = personnummer;
        //}

        public override string ToString()
        {

            return string.Concat(kundnummer, förnamn, efternamn, personnummer);

        }
    }
}
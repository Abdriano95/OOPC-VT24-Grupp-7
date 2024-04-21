using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret
{
    public class Kund
    {
        [Key]
        public int Id { get; set; }
        public required string Förnamn { get; set; }
        public required string Efternamn { get; set; }
        public required string Personnummer { get; set; }
        public string? Gatuadress { get; set; }
        public string? Postnummer { get; set; }
        public string? Ort { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Epost { get; set; }

        public ICollection<Fordon>? Fordon { get; set; }


        //public Kund(int kundnummer, string förnamn, string efternamn, string personnummer)
        //{
        //    this.kundnummer = kundnummer;
        //    this.förnamn = förnamn;
        //    this.efternamn = efternamn;
        //    this.personnummer = personnummer;
        //}

        public override string ToString()
        {

            return string.Concat(Id, Förnamn, Efternamn, Personnummer);

        }
    }
}
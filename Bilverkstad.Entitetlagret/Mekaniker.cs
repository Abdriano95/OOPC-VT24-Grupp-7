using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Mekaniker : Anställd
    {
        public Specialiseringar Specialiseringar { get; set; }
        public virtual ICollection<Bokning> Bokningar { get; set; } = new List<Bokning>();

        [NotMapped]  
        public string FullständigtNamn
        {
            get { return $"{Förnamn} {Efternamn}"; }
        }

    }

    public enum Specialiseringar
    {
        Dackbyte,
        Motor,
        Elektronik,
        Kaross
    }

}

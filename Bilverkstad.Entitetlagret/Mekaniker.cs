namespace Bilverkstad.Entitetlagret
{
    public class Mekaniker : Anställd
    {
        public Specialiseringar Specialiseringar { get; set; }
        public virtual ICollection<Bokning> Bokningar { get; set; } = new List<Bokning>();

        public string FullName
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

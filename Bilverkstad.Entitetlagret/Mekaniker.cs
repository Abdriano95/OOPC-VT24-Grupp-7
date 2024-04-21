namespace Bilverkstad.Entitetlagret
{
    public class Mekaniker : Anställd
    {
        public Specialiseringar Specialiseringar { get; set; }

    }

    public enum Specialiseringar
    {
        Dackbyte,
        Motor,
        Elektronik,
        Kaross
    }

}

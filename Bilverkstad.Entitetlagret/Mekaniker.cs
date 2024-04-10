namespace Bilverkstad.Entitetlagret
{
    public class Mekaniker
    {
        private int anställningNr; { get; set; }
        private string förnamn; { get; set; }
        private string efternamn; { get; set; }
        private string yrkesroll; { get; set; }
        private string lösenord; { get; set; }
        public List<Specialiseringar> Specialisering { get; set; }

    }

    public Mekaniker()
    {
        Specialisering = new List<Specialiseringar>();
    }

    public enum Specialiseringar
    {
        Dackbyte,
        Motor,
        Elektronik,
        Kaross
    }
}

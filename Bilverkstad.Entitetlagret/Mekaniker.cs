namespace Bilverkstad.Entitetlagret
{
    public enum Specialiseringar
    {
        Dackbyte,
        Motor,
        Elektronik,
        Kaross
    }
    public class Mekaniker
    {
        public int anställningNr { get; set; }
        private string förnamn { get; set; }
        private string efternamn { get; set; }
        private string yrkesroll { get; set; }
        private string lösenord { get; set; }
        public Specialiseringar _specialisering { get; set; }

        public Mekaniker(int anställningNr, string förnamn, string efternamn, Specialiseringar _specialisering)
        {
            this.anställningNr = anställningNr;
            this.förnamn = förnamn;
            this.efternamn = efternamn;
            this._specialisering = _specialisering;

        }

        public override string ToString()
        {
            return String.Concat(anställningNr,förnamn,efternamn,_specialisering);
        }

    }

}

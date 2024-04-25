namespace Bilverkstad.Entitetlagret
{
    public class Receptionist : Anställd
    {
        public Auktoritet Auktoritet { get; set; }

    }
    public enum Auktoritet
    {
        NotAdmin,
        Admin
    }
}

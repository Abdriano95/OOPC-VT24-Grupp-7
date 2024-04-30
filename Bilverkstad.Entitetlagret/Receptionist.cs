using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Receptionist : Anställd
    {
        public Auktoritet Auktoritet { get; set; }

        [NotMapped] // This will hold the receptionist's full name, set manually after fetching the data
        public string FullständigtNamn
        {
            get { return $"{Förnamn} {Efternamn}"; }
        }
    }
    public enum Auktoritet
    {
        NotAdmin,
        Admin
    }
}

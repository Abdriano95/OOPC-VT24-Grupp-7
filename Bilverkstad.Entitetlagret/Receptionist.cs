using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Receptionist : Anställd
    {
        public Auktoritet Auktoritet { get; set; }

        [NotMapped] 
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

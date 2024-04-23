using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret
{
    public class Anställd
    {
        [Key]
        public int AnställningsNummer { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Yrkesroll { get; set; }
        public string? Lösenord { get; set; }
    }
}

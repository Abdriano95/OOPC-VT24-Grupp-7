using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Anställd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnställningsNummer { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Lösenord { get; set; }

    }
}

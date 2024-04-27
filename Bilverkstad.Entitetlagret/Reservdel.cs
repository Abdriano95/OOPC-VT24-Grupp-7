using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Reservdel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Artikelnummer { get; set; }
        public string? Namn { get; set; }
        public float Pris { get; set; }


        public override string ToString()
        {
            return string.Concat(Artikelnummer, Namn, Pris);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret
{
    public class Reservdel
    {
        [Key]
        public int Id { get; set; }
        public string? Namn { get; set; }
        public float Pris { get; set; }


        public override string ToString()
        {
            return string.Concat(Id, Namn, Pris);
        }
    }
}

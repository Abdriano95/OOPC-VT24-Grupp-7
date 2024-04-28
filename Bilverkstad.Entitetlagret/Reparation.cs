using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Reparation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReparationsId { get; set; }
        public Reparationsstatus Reparationsstatus { get; set; }
        public int BokningsId { get; set; }
        public int ResArtikelnummer { get; set; }
        public string? Åtgärd { get; set; }
        [ForeignKey("Artikelnummer")]
        public virtual ICollection<Reservdel>? Reservdelar { get; set; }
        public virtual Mekaniker? Mekaniker { get; set; } //required 
        public virtual Bokning? Bokning { get; set; }  // required  

        public Reparation()
        {
            Reservdelar = new List<Reservdel>();
        }

    }

    public enum Reparationsstatus
    {
        EjPåbörjad, Påbörjad, Klar
    }
}

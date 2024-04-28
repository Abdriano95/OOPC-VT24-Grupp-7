using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bilverkstad.Entitetlagret
{
    public class Reparation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReparationsId { get; set; }
        public int? Artikelnummer { get; set; }
        public Reparationsstatus Reparationsstatus { get; set; }
        public int BokningsId { get; set; }
        public string? Åtgärd { get; set; }

        public virtual ICollection<ReparationReservdel> ReparationReservdel { get; set; } = new List<ReparationReservdel>();
        public Mekaniker? Mekaniker { get; set; } //required 

        public virtual Bokning? Bokning { get; set; }  // required  

    }

    public enum Reparationsstatus
    {
        EjPåbörjad, Påbörjad, Klar
    }
}

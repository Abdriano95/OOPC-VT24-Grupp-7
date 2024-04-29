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
        public string? Åtgärd { get; set; }
        public int ReservdelId { get; set; } // nytt
        public virtual Reservdel? Reservdelar { get; set; }
        public Mekaniker? Mekaniker { get; set; } //required 
        public virtual Bokning? Bokning { get; set; }  // required  
        //public Reparation()
        //{
        //    Reservdelar = new List<Reservdel>();
        //}

    }

    public enum Reparationsstatus
    {
        EjPåbörjad, Påbörjad, Klar
    }
}

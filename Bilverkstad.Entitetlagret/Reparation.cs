using System.ComponentModel.DataAnnotations;

namespace Bilverkstad.Entitetlagret
{
    public class Reparation
    {
        [Key]
        public int ReparationsId { get; set; }
        public Reparationsstatus Reparationsstatus { get; set; }
        public string? Åtgärd { get; set; }
        public Bokning? Bokning { get; set; }  // required  
        public ICollection<Reservdel>? Reservdelar { get; set; }
        public Mekaniker? Mekaniker { get; set; } //required 
        public Reparation()
        { 
            Reservdelar = new List<Reservdel>();    
        }
        
    }
    
    public enum Reparationsstatus
    {
        EjPåbörjad,Påbörjad,Klar        
    }
}

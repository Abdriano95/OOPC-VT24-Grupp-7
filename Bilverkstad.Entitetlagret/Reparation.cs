using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Entitetlagret
{
    public class Reparation
    {
        [Key]
        public int Id { get; set; }    
        public required Bokning Bokning { get; set; }   
        public required ICollection<Reservdel>? Reservdelar {  get; set; } 
        public string? Åtgärd {  get; set; } 
    }
}

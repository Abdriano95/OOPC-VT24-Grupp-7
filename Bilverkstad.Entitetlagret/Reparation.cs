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
        public Bokning? Bokning { get; set; }  // required  
        public ICollection<Reservdel>? Reservdelar {  get; set; } 
        public Mekaniker Mekaniker { get; set; } //required 
        public string? Åtgärd {  get; set; } 
    }
}

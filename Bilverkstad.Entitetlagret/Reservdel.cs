using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Entitetlagret
{
    public class Reservdel
    {
        [Key]
        public int Id { get; set; } 
        public string? Namn {  get; set; }   
        public decimal Pris {  get; set; }


        public override string ToString()
        {
            return string.Concat(Id, Namn, Pris);
        }
    }
}

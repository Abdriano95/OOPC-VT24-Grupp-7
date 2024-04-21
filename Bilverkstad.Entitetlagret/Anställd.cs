using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Entitetlagret
{
    public class Anställd
    {
        [Key]
        public int AnställningsNummer { get; set; }
        public required string Förnamn { get; set; }
        public required string Efternamn { get; set; } 
        public required string Yrkesroll { get; set; }
        public required string Lösenord { get; set; } 
    }
}

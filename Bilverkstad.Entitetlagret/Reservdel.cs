using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Entitetlagret
{
    public class Reservdel
    {
        public string reservdelsnummer {  get; set; } 
        private int antal { get; set; } = 0;
        private double pris {  get; set; }

        public Reservdel(string reservdelnummer, int antal, double pris)
        {
            this.reservdelsnummer = reservdelnummer;
            this.antal = antal;
            this.pris = pris;
        }

        public override string ToString()
        {
            return string.Concat(reservdelsnummer, antal, pris);
        }
    }
}

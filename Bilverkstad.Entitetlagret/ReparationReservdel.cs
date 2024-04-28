using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Entitetlagret
{
    public class ReparationReservdel
    {
        public int ReparationId { get; set; }
        public virtual Reparation Reparation { get; set; }

        public int ReservdelId { get; set; }
        public virtual Reservdel Reservdel { get; set; }
    }
}


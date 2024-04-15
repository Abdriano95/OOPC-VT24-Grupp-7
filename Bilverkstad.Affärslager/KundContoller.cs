using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Affärslager
{
    public class KundContoller
    {
        public KundContoller() { }

        public IList <Kund> GetKund()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Kund>)unitOfWork.Kund.Query(q => q.Include(k => k.Id)
                .Include(k => k.Förnamn)
                .Include(k => k.Efternamn)
                .Include(k => k.Personnummer)
                .Include(k => k.Gatuadress)
                .Include(k => k.Postnummer)
                .Include(k => k.Ort)
                .Include(k => k.Telefonnummer)
                .Include(k => k.Epost));
                // ThenInclude <Fordon> 
            }
                
        } 
    }
}

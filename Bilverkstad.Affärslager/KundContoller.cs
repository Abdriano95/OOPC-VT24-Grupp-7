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
               return (IList<Kund>)unitOfWork.Kund.GetAll().ToList();

            }
                
        } 
    }
}

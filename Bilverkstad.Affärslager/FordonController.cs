using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Affärslager
{
    public class FordonController
    {
        KundController kundController = new KundController();
        public FordonController() { }

        public IList<Fordon> GetFordon()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Fordon>)unitOfWork.Fordon.GetAll().ToList();
            }

        }

    }
}   
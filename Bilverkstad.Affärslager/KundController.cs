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
    public class KundController
    {
        public KundController() { }

        public IList <Kund> GetKund()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
               return (IList<Kund>)unitOfWork.Kund.GetAll().ToList();
            }
            
        }

        public Kund GetOneKund(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Kund.Find(id);
            }
        }

        public void AddKund(Kund kund)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork()) 
            {
                unitOfWork.Kund.Add(kund);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteKund(Kund kund) 
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Kund gammalKund = uow.Kund.Find(kund.Id);
                uow.Kund.Delete(gammalKund);
                uow.SaveChanges(); 
            }
        }
        public void UpdateKund(Kund kund) 
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Kund benfintligKund = uow.Kund.Find(kund.Id);
                uow.Kund.Update(benfintligKund,kund);
                uow.SaveChanges();
            }
        }

    }
}

using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class KundController
    {
        public KundController() 
        
        {
        
        }

        public IList<Kund> GetKund()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Kund>)unitOfWork.Kund.GetAll().Include(k => k.Fordon).ToList();
            }

        }

        public IList<Kund> GetKundWithFordon()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Kund.GetAll().Include(k => k.Fordon).ToList();
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
                uow.Kund.Update(benfintligKund, kund);
                uow.SaveChanges();
            }
        }

        public List<Fordon> GetKundsFordon(int kundId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Hämta kunden från databasen
                var kund = unitOfWork.Kund.Find(kundId);

                // Om kunden inte hittades, returnera en tom lista
                if (kund == null)
                    return new List<Fordon>();

                // Returnera kundens fordon
                return kund.Fordon.ToList();
            }
        }


    }
}

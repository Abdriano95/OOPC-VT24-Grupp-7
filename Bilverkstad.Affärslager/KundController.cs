using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class KundController
    {
        public KundController() { }

        public IList<Kund> GetKundWithFordon()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var kundRepository = unitOfWork.Kund;
                if (kundRepository == null)
                {
                    // Hanterar null genom att retunera en tom lista
                    return new List<Kund>();
                }
                return kundRepository.GetAll().Include(k => k.Fordon).ToList();
            }
        }
        public IList<Kund> GetKund() // här är en metod för att lägga alla kunderi en lista
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var kundRepository = unitOfWork.Kund;
                if (kundRepository == null)
                {
                    
                    return new List<Kund>();
                }
                return kundRepository.GetAll().ToList();
            }
        }

        public Kund GetOneKund(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Kund kund = unitOfWork.Kund!.Find(id);
                if (kund == null)
                {
                    throw new KeyNotFoundException("Ingen kund hittat med given ID.");
                    
                }
                return kund;
            }
        }


        public void AddKund(Kund kund)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Kund!.Add(kund);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteKund(Kund kund)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Kund == null)
                {
                    throw new InvalidOperationException("Kund repository is not initialized.");
                }

                Kund? gammalKund = uow.Kund.Find(kund.Id);
                if (gammalKund == null)
                {
                    throw new KeyNotFoundException("No Kund found with the given ID.");
                }

                uow.Kund.Delete(gammalKund);
                uow.SaveChanges();
            }
        }


        public void UpdateKund(Kund kund)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Kund == null)
                {
                    throw new InvalidOperationException("Kund repository is not initialized.");
                }

                Kund? benfintligKund = uow.Kund.Find(kund.Id);
                if (benfintligKund == null)
                {
                    throw new KeyNotFoundException("No Kund found with the given ID to update.");
                }

                uow.Kund.Update(benfintligKund, kund);
                uow.SaveChanges();
            }
        }

    }
}

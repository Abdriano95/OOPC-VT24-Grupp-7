using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class ReparationController
    {
        public IList<Reparation> GetReparation()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Reparation.GetAll().ToList();
            }
        }



        public Reparation GetOneReparation(int ReparationsId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Reparation.Find(ReparationsId);
            }
        }

        public void AddReparation(Reparation reparation)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Reparation.Add(reparation);
                unitOfWork.SaveChanges();
            }
        }

        

        public void DeleteReparation(Reparation reparation)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Reparation gammalReparation = uow.Reparation.Find(reparation.ReparationsId);
                uow.Reparation.Delete(gammalReparation);
                uow.SaveChanges();
            }
        }
        public void UpdateReparation(Reparation reparation)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Reparation benfintligReparation = uow.Reparation.Find(reparation.ReparationsId);
                uow.Reparation.Update(benfintligReparation, reparation);
                uow.SaveChanges();
            }
        }


        public IList<Reparation> GetReparationerByBokning(int bokningId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    // Directly use the context to include related entities
                    var bokning = unitOfWork.Bokning.GetAll().Include(b => b.Reparation).ThenInclude(r => r.Reservdelar).FirstOrDefault(b => b.Id == bokningId);

                    // Return the list of reparations or an empty list if the booking is not found
                    return bokning?.Reparation?.ToList() ?? new List<Reparation>();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve reparations with reservdelar", ex);
            }
        }
    }
}

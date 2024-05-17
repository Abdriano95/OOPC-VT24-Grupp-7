using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public void AddReparationTillBokning(int bookingId, Reparation repair)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var booking = unitOfWork.Bokning.Find(bookingId);
                if (booking.MekanikerId == repair.Mekaniker.AnställningsNummer)  
                {
                    booking.Reparation.Add(repair);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException("MekanikerId matchar inte reparationen.");
                }
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

        public void CreateOrUpdateReparation(Reparation reparation, int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {

                if (reparation.ReparationsId == 0)
                {
                    unitOfWork.Reparation.Add(reparation);
                }
                else
                {
                    unitOfWork.Reparation.Update(reparation);
                }
                unitOfWork.SaveChanges();
            }


        }

        public IList<Reparation> GetReparationerByBokning(int bokningsId)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    // Fetch the specific Bokning with its associated Reparation and Reservdel
                    var bokning = unitOfWork.Bokning.GetAll().Include(b => b.Reparation).ThenInclude(r => r.Reservdelar).FirstOrDefault(b => b.Id == bokningsId);


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

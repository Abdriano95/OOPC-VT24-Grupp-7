using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Affärslager
{
    public class ReparationController
    {
        public IList<Reparation> GetReparation()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Reparation>)unitOfWork.Reparation.GetAll().ToList();
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
        public void CreateOrUpdateReparation(Reparation reparation, int Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var reservdel = unitOfWork.Reservdel.FirstOrDefault(r => r.Artikelnummer == Id);
                reparation.Reservdelar.Add(reservdel);
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
    }
}

using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Affärslager
{
    public class MekanikerController
    {
        public IList<Mekaniker> GetMekaniker()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Mekaniker>)unitOfWork.Mekaniker.GetAll().ToList();
            }

        }

        public Mekaniker GetOneMekaniker(int AnställningsNummer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Mekaniker.Find(AnställningsNummer);
            }
        }

        public void AddMekaniker(Mekaniker mekaniker)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Mekaniker.Add(mekaniker);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteMekaniker(Mekaniker mekaniker)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Mekaniker gammalMekaniker = uow.Mekaniker.Find(mekaniker.AnställningsNummer);
                uow.Mekaniker.Delete(gammalMekaniker);
                uow.SaveChanges();
            }
        }
        public void UpdateMekaniker(Mekaniker mekaniker)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Mekaniker benfintligMekaniker = uow.Mekaniker.Find(mekaniker.AnställningsNummer);
                uow.Mekaniker.Update(benfintligMekaniker, mekaniker);
                uow.SaveChanges();
            }
        }
    }
}

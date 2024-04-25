using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Affärslager
{
    public class AnställdController
    {
        public IList<Anställd> GetAnställd()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Anställd>)unitOfWork.Anställd.GetAll().ToList();
            }
        }

        public Anställd GetOneAnställd(int AnställningsNummer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Anställd.Find(AnställningsNummer);
            }
        }

        public void AddAnställd(Anställd anställd)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Anställd.Add(anställd);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteAnställd(Anställd anställd)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Anställd gammalAnställd = uow.Anställd.Find(anställd.AnställningsNummer);
                uow.Anställd.Delete(gammalAnställd);
                uow.SaveChanges();
            }
        }
        public void UpdateAnställd(Anställd anställd)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Anställd benfintligAnställd = uow.Anställd.Find(anställd.AnställningsNummer);
                uow.Anställd.Update(benfintligAnställd, anställd);
                uow.SaveChanges();
            }
        }
    }
}

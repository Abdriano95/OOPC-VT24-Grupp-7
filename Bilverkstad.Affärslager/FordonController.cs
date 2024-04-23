using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

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

        public Fordon GetOneFordon(string reg)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Fordon.FindStringID(reg);
            }
        }

        public void AddFordon(Fordon fordon)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Fordon.Add(fordon);
                unitOfWork.SaveChanges();
            }
        }

        public void AddFordontoKund(Kund kund, Fordon fordon)
        {
            kund.Fordon.Add(fordon);
            fordon.Kund = kund;
        }

        public void DeleteFordon(Fordon fordon)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Fordon gammaltFordon = uow.Fordon.FindStringID(fordon.RegNr);
                uow.Fordon.Delete(gammaltFordon);
                uow.SaveChanges();
            }
        }
        public void UpdateFordon(Fordon fordon)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Fordon benfintligtFordon = uow.Fordon.FindStringID(fordon.RegNr);
                uow.Fordon.Update(benfintligtFordon, fordon);
                uow.SaveChanges();
            }
        }

    }
}

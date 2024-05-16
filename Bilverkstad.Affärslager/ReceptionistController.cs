using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Affärslager
{
    public class ReceptionistController
    {
        public IList<Receptionist> GetReceptionist()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (unitOfWork.Receptionist.GetAll().ToList());
            }

        }

        public Receptionist GetOneReceptionist(int AnställningsNummer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Receptionist.Find(AnställningsNummer);
            }
        }

        public void AddReceptionist(Receptionist receptionist)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Receptionist.Add(receptionist);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteReceptionist(Receptionist receptionist)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Receptionist gammalReceptionist = uow.Receptionist.Find(receptionist.AnställningsNummer);
                uow.Receptionist.Delete(gammalReceptionist);
                uow.SaveChanges();
            }
        }
        public void UpdateReceptionist(Receptionist receptionist)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Receptionist benfintligReceptionist = uow.Receptionist.Find(receptionist.AnställningsNummer);
                uow.Receptionist.Update(benfintligReceptionist, receptionist);
                uow.SaveChanges();
            }
        }

        public void AddOrUpdateReceptionist(Receptionist receptionist)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var existingReceptionist = unitOfWork.Receptionist.Find(receptionist.AnställningsNummer);
                if (existingReceptionist == null)
                {
                    unitOfWork.Receptionist.Add(receptionist);
                }
                else
                {
                    unitOfWork.Receptionist.Update(existingReceptionist, receptionist);
                }
                unitOfWork.SaveChanges();
            }
        }

    }
}

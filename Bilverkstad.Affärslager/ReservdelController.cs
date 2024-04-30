using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Affärslager
{
    public class ReservdelController
    {
        public IList<Reservdel> GetReservdel()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Reservdel>)unitOfWork.Reservdel.GetAll().ToList();
            }
        }

        public Reservdel GetOneReservdel(int Artikelnummer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Reservdel reservdel = unitOfWork.Reservdel!.Find(Artikelnummer);

                if (reservdel == null)
                {                    
                    throw new Exception("Reservdel med angivet artikelnummer hittades inte.");
                }

                return reservdel;
            }
        }

        public void AddReservdel(Reservdel reservdel)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Reservdel.Add(reservdel);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteReservdel(Reservdel reservdel)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Reservdel gammalReservdel = uow.Reservdel.Find(reservdel.Artikelnummer);
                uow.Reservdel.Delete(gammalReservdel);
                uow.SaveChanges();
            }
        }
        public void UpdateReservdel(Reservdel reservdel)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Reservdel benfintligReservdel = uow.Reservdel.Find(reservdel.Artikelnummer);
                uow.Reservdel.Update(benfintligReservdel, reservdel);
                uow.SaveChanges();
            }
        }
        public IList<int> GetArtikelnummer()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var artikelnummerList = unitOfWork.Reservdel.GetAll().Select(reservdel => reservdel.Artikelnummer).ToList();
                return artikelnummerList;
            }
        }
    }
}

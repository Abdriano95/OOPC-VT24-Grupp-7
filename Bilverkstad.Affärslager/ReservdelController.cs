using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return unitOfWork.Reservdel.Find(Artikelnummer);
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
    }
}

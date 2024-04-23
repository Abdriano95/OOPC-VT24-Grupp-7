using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Affärslager
{
        public class FordonController
        {
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

            public void AddKund(Fordon fordon)
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.Fordon.Add(fordon);
                    unitOfWork.SaveChanges();
                }
            }

            public void DeleteKund(Fordon fordon)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Fordon gammaltFordon = uow.Fordon.FindStringID(fordon.RegNr);
                    uow.Fordon.Delete(gammaltFordon);
                    uow.SaveChanges();
                }
            }
            public void UpdateKund(Fordon fordon)
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

using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class FordonController
    {
       
        public FordonController() { }

        public void AddFordon(Fordon fordon)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Fordon!.Add(fordon);
                unitOfWork.SaveChanges();
            }
        }

       

        public List<Fordon> SearchFordon(string searchJournalText)
        {
            //söker på ett fordon via regnummer
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Fordon.Get(f => f.RegNr.Contains(searchJournalText)).ToList();
            }
        }
    }





}

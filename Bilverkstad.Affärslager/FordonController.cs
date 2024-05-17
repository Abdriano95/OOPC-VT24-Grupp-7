using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class FordonController
    {
        KundController kundController = new KundController();
        public FordonController() { }

        public void AddFordon(Fordon fordon)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Fordon!.Add(fordon);
                unitOfWork.SaveChanges();
            }
        }

        public IList<Fordon> GetFordon() // ta bort?
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Fordon.GetAll().ToList();
            }

        }
        public Fordon GetOneFordon(string regNr) // ta bort?
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Fetch the Fordon using the registration number
                Fordon fordon = unitOfWork.Fordon.GetAll().FirstOrDefault(f => f.RegNr == regNr);

                if (fordon == null)
                {
                    throw new KeyNotFoundException("No Fordon found with the given registration number.");
                }

                return fordon;
            }
        }

        public IList<Kund> GetKundWithFordon() // ANVÄNDS TA EJ BORT!
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Kund!.GetAll().Include(k => k.Fordon).ToList();
            }
        }

        public Kund? GetKundWithFordonById(int kundId) // ta bort?
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // FirstOrDefault för att hämta en kund
                return unitOfWork.Kund!.GetAll()
                                     .Include(k => k.Fordon)
                                     .FirstOrDefault(k => k.Id == kundId);
            }
        }

        public void UpdateFordon(Fordon fordon) // ta bort
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Fordon == null)
                {
                    throw new InvalidOperationException("Fordon repository is not initialized.");
                }


                Fordon? existingFordon = uow.Fordon.FindStringID(fordon.RegNr);
                if (existingFordon == null)
                {
                    throw new KeyNotFoundException("No Fordon found with the given RegNr to update.");
                }


                existingFordon.Bilmärke = fordon.Bilmärke;
                existingFordon.Modell = fordon.Modell;
                existingFordon.KundId = fordon.KundId;

                uow.Fordon.Update(existingFordon, fordon);
                uow.SaveChanges();
            }
        }

        public void AddOrUpdateFordon(Fordon fordon) // ta bort?
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var existingFordon = unitOfWork.Fordon.FindStringID(fordon.RegNr);
                if (existingFordon != null)
                {

                    unitOfWork.Fordon.Update(existingFordon, fordon);
                }
                else
                {

                    unitOfWork.Fordon.Add(fordon);
                }
                unitOfWork.SaveChanges();
            }
        }

        public List<Fordon> SearchFordon(string searchJournalText)
        {
            //searches for a Fordon by registration number
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Fordon.Get(f => f.RegNr.Contains(searchJournalText)).ToList();
            }
        }
    }





}

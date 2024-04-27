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

        public IList<Fordon> GetFordon()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return (IList<Fordon>)unitOfWork.Fordon.GetAll().ToList();
            }

        }
        public Fordon GetOneFordon(string regNr)
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

        public IList<Kund> GetKundWithFordon()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Kund!.GetAll().Include(k => k.Fordon).ToList();
            }
        }

        public Kund? GetKundWithFordonById(int kundId)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Using FirstOrDefault to retrieve a single customer or null if not found
                return unitOfWork.Kund!.GetAll()
                                     .Include(k => k.Fordon)
                                     .FirstOrDefault(k => k.Id == kundId);
            }
        }

        public void UpdateFordon(Fordon fordon)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Fordon == null)
                {
                    throw new InvalidOperationException("Fordon repository is not initialized.");
                }

                // Assuming RegNr is the primary key for Fordon
                Fordon? existingFordon = uow.Fordon.FindStringID(fordon.RegNr);
                if (existingFordon == null)
                {
                    throw new KeyNotFoundException("No Fordon found with the given RegNr to update.");
                }

                // Update properties; this assumes you have properties like Make, Model, etc.
                existingFordon.Bilmärke = fordon.Bilmärke;
                existingFordon.Modell = fordon.Modell;
                existingFordon.KundId = fordon.KundId; // Ensure all relevant properties are updated

                uow.Fordon.Update(existingFordon, fordon);
                uow.SaveChanges();
            }
        }

        public void AddOrUpdateFordon(Fordon fordon)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var existingFordon = unitOfWork.Fordon.FindStringID(fordon.RegNr);
                if (existingFordon != null)
                {
                    // Update existing record with new data
                    unitOfWork.Fordon.Update(existingFordon, fordon);
                }
                else
                {
                    // Add as a new record
                    unitOfWork.Fordon.Add(fordon);
                }
                unitOfWork.SaveChanges();
            }
        }


    }





}

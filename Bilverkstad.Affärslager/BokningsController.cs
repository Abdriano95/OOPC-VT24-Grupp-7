using Bilverkstad.Datalager;

namespace Bilverkstad.Affärslager
{
    public class BokningsController
    {
        public BokningsController() { }

        public void AddBokning(Bokning bokning)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Bokning.Add(bokning);
                unitOfWork.SaveChanges();
            }
        }

        public void CreateOrUpdateBokning(int kundId, string fordonRegNr, int receptionistId, Bokning bokningData)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Fetch existing entities
                var kund = unitOfWork.Kund.FirstOrDefault(k => k.Id == kundId);
                var fordon = unitOfWork.Fordon.FirstOrDefault(f => f.RegNr == fordonRegNr);
                var receptionist = unitOfWork.Receptionist.FirstOrDefault(r => r.AnställningsNummer == receptionistId);

                if (kund == null || fordon == null || receptionist == null)
                {
                    throw new ArgumentException("Invalid Kund, Fordon, or Receptionist ID");
                }

                // Assign existing entities to the new Bokning
                bokningData.Kund = kund;
                bokningData.Fordon = fordon;
                bokningData.Receptionist = receptionist;

                // Additional Bokning setup here (like setting dates, purpose, etc.)

                // Check if it's a new or existing booking
                if (bokningData.Id == 0)
                {
                    unitOfWork.Bokning.Add(bokningData);
                }
                else
                {
                    unitOfWork.Bokning.Update(bokningData);
                }

                unitOfWork.SaveChanges();
            }
        }
        public void UpdateBokning(Bokning bokning)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Bokning == null)
                {
                    throw new InvalidOperationException("Bokning repository is not initialized.");
                }

                Bokning? existingBokning = uow.Bokning.Find(bokning.Id);
                if (existingBokning == null)
                {
                    throw new KeyNotFoundException("No Bokning found with the given ID to update.");
                }

                // Assuming Update(Bokning oldBokning, Bokning newBokning) is implemented in the repository
                uow.Bokning.Update(existingBokning, bokning);
                uow.SaveChanges();
            }
        }

        public IList<Bokning> GetBokning()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var bokningar = unitOfWork.Bokning;
                if (bokningar == null)
                {

                    return new List<Bokning>();
                }
                return bokningar.GetAll().ToList();
            }
        }


    }
}

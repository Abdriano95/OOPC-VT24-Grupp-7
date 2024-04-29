using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

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

        public void CreateOrUpdateBokning(int kundId, string fordonRegNr, int receptionistId, int? mechanicId, Specialiseringar requiredSpecialisering, Bokning bokningData)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var kund = unitOfWork.Kund.FirstOrDefault(k => k.Id == kundId);
                var fordon = unitOfWork.Fordon.FirstOrDefault(f => f.RegNr == fordonRegNr);
                var receptionist = unitOfWork.Receptionist.FirstOrDefault(r => r.AnställningsNummer == receptionistId);
                Mekaniker? mekaniker = null;

                if (mechanicId.HasValue)
                {
                    mekaniker = unitOfWork.Mekaniker.Get(m => m.AnställningsNummer == mechanicId.Value && m.Specialiseringar == requiredSpecialisering).FirstOrDefault();
                    if (mekaniker == null)
                    {
                        throw new ArgumentException("Ingen mekaniker hittat eller specialisering matchar inte");
                    }
                }

                if (kund == null || fordon == null || receptionist == null)
                {
                    throw new ArgumentException("Ogiltig Kund, Fordon eller Receptionist ID");
                }

                bokningData.Kund = kund;
                bokningData.Fordon = fordon;
                bokningData.Receptionist = receptionist;
                bokningData.Mekaniker = mekaniker;  // Sätter mekaniker om den är hittad, annars null

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
                var bokningar = unitOfWork.Bokning.GetAll()
                    .Include(b => b.Mekaniker)  // Load Mekaniker data
                    .ToList();

                foreach (var bokning in bokningar)
                {
                    if (bokning.Mekaniker != null)
                    {
                        // Assuming Mekaniker has Förnamn and Efternamn properties
                        bokning.MekanikerFullName = $"{bokning.Mekaniker.Förnamn} {bokning.Mekaniker.Efternamn}";
                    }
                    else
                    {
                        bokning.MekanikerFullName = "Not Assigned";
                    }
                }

                return bokningar;
            }
        }


        public IList<Mekaniker> GetMechanicsBySpecialisering(Specialiseringar specialisering)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Mekaniker.Get(m => m.Specialiseringar == specialisering).ToList();
            }
        }


    }
}

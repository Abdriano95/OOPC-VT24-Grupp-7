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

        public void CreateOrUpdateBokning(int kundId, string fordonRegNr, int receptionistId, int? mekanikerID, Specialiseringar requiredSpecialisering, Bokning bokningData)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var kund = unitOfWork.Kund.FirstOrDefault(k => k.Id == kundId);
                var fordon = unitOfWork.Fordon.FirstOrDefault(f => f.RegNr == fordonRegNr);
                var receptionist = unitOfWork.Receptionist.FirstOrDefault(r => r.AnställningsNummer == receptionistId);
                Mekaniker? mekaniker = null;

                if (mekanikerID.HasValue)
                {
                    mekaniker = unitOfWork.Mekaniker.Get(m => m.AnställningsNummer == mekanikerID.Value && m.Specialiseringar == requiredSpecialisering).FirstOrDefault();
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


        public void UpdateBokning(Bokning updatedBokning)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var existingBokning = uow.Bokning.FirstOrDefault(b => b.Id == updatedBokning.Id);
                if (existingBokning == null)
                {
                    throw new KeyNotFoundException("No Bokning found with the given ID to update.");
                }

                uow.Bokning.Update(existingBokning, updatedBokning);
                uow.SaveChanges();
            }
        }


        public IList<Bokning> GetBokning()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var bokningar = unitOfWork.Bokning.GetAll()
            .Include(b => b.Kund)
            .Include(b => b.Fordon)
            .Include(b => b.Receptionist)
            .Include(b => b.Mekaniker) // Ensure all relevant navigation properties are included
            .ToList();
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

        public void DeleteBokning(int bokningId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var bokning = unitOfWork.Bokning.Find(bokningId);
                if (bokning != null)
                {
                    unitOfWork.Bokning.Delete(bokning);
                    unitOfWork.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException("Ingen bokning med given ID hittad.");
                }
            }
        }
       
            public List<Bokning> SearchBookings(string searchTerm)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    return unitOfWork.Bokning.GetAll()
                        .Where(b => b.Kund.Förnamn.Contains(searchTerm)
                                    || b.Kund.Efternamn.Contains(searchTerm)
                                    || b.Fordon.RegNr.Contains(searchTerm)
                                    || b.SyfteMedBesök.Contains(searchTerm)
                                    || b.Receptionist.Förnamn.Contains(searchTerm)
                                    || b.Receptionist.Efternamn.Contains(searchTerm)
                                    || b.Mekaniker.FullName.Contains(searchTerm))
                        .ToList();
                }
            }
        }

}

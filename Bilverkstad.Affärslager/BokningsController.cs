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
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    var bokningar = unitOfWork.Bokning.GetAll()
                        .Include(b => b.Kund)
                        .Include(b => b.Fordon)
                        .Include(b => b.Receptionist)
                        .Include(b => b.Mekaniker)
                        .Include(b => b.Reparation)  // Försäkrar att alla relevanta navigations properties är inkluderade
                        .ToList();
                    foreach (var bokning in bokningar)
                    {
                        if (bokning.Mekaniker != null)
                        {
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
            catch (Exception ex)
            {
                
                
                throw;  
            }
        }


        public Bokning GetOneBokning(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Inkluderar Fordon för att hämta fordon ihop med kund
                Bokning bokning = unitOfWork.Bokning!.GetAll().Include(r => r.Reparation).FirstOrDefault(r => r.Id == id);

                if (bokning == null)
                {
                    throw new KeyNotFoundException("Ingen bokning hittat med givet ID.");
                }

                return bokning;
            }
        }
        public List<Bokning> GetBokningarByAnställningsnummer(int anställningsnummer)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Antag att du har en relation mellan Mekaniker och Bokning där MekanikerId i Bokning-tabellen
                // refererar till ID i Mekaniker-tabellen
                return unitOfWork.Bokning.Get(b => b.Mekaniker.AnställningsNummer == anställningsnummer).ToList();
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

        public List<Bokning> SökBokningar(string searchTerm)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                searchTerm = searchTerm.ToLower();
                // Hämtar all data från databasen
                var allBookings = unitOfWork.Bokning.GetAll()
                    .Include(b => b.Kund)
                    .Include(b => b.Fordon)
                    .Include(b => b.Reparation)
                    .Include(b => b.Receptionist)
                    .Include(b => b.Mekaniker)
                    .ToList();  

                
                return allBookings.Where(b =>
                    (b.Kund.Förnamn != null && b.Kund.Förnamn.ToLower().Contains(searchTerm)) ||
                    (b.Kund.Efternamn != null && b.Kund.Efternamn.ToLower().Contains(searchTerm)) ||
                    (b.Fordon.RegNr != null && b.Fordon.RegNr.ToLower().Contains(searchTerm)) ||
                    (b.SyfteMedBesök != null && b.SyfteMedBesök.ToLower().Contains(searchTerm)) ||
                    
                    (b.Receptionist.Förnamn != null && b.Receptionist.Förnamn.ToLower().Contains(searchTerm)) ||
                    (b.Receptionist.Efternamn != null && b.Receptionist.Efternamn.ToLower().Contains(searchTerm)) ||
                    (b.Mekaniker.Förnamn != null && b.Mekaniker.Förnamn.ToLower().Contains(searchTerm)) ||
                    (b.Mekaniker.Efternamn != null && b.Mekaniker.Efternamn.ToLower().Contains(searchTerm))
                ).ToList();  
            }
        }



    }

}

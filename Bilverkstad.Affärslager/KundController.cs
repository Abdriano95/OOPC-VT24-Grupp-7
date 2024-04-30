using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Affärslager
{
    public class KundController
    {
        public KundController() { }

        public IList<Kund> GetKundWithFordon()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var kundRepository = unitOfWork.Kund;
                if (kundRepository == null)
                {
                    // Hanterar null genom att retunera en tom lista
                    return new List<Kund>();
                }
                return kundRepository.GetAll().Include(k => k.Fordon).ToList();
            }
        }

        public IList<Kund> GetKund() // här är en metod för att lägga alla kunderi en lisa
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var kundRepository = unitOfWork.Kund;
                if (kundRepository == null)
                {

                    return new List<Kund>();
                }
                return kundRepository.GetAll().ToList();
            }
        }

        public Kund GetOneKund(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Include the Fordon navigation property to fetch vehicles along with the customer
                Kund kund = unitOfWork.Kund!.GetAll().Include(k => k.Fordon).FirstOrDefault(k => k.Id == id);

                if (kund == null)
                {
                    throw new KeyNotFoundException("Ingen kund hittat med given ID.");
                }

                return kund;
            }
        }



        public void AddKund(Kund kund)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.Kund!.Add(kund);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteKund(Kund kund)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Kund == null)
                {
                    throw new InvalidOperationException("Kund repository is not initialized.");
                }

                Kund? gammalKund = uow.Kund.Find(kund.Id);
                if (gammalKund == null)
                {
                    throw new KeyNotFoundException("No Kund found with the given ID.");
                }

                uow.Kund.Delete(gammalKund);
                uow.SaveChanges();
            }
        }


        public void UpdateKund(Kund kund)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (uow.Kund == null)
                {
                    throw new InvalidOperationException("Kund repository is not initialized.");
                }

                Kund? benfintligKund = uow.Kund.Find(kund.Id);
                if (benfintligKund == null)
                {
                    throw new KeyNotFoundException("No Kund found with the given ID to update.");
                }

                uow.Kund.Update(benfintligKund, kund);
                uow.SaveChanges();
            }
        }

        public void AddOrUpdateKund(Kund kund)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var existingKund = unitOfWork.Kund.Find(kund.Id);
                if (existingKund == null)
                {
                    unitOfWork.Kund.Add(kund);
                }
                else
                {
                    // Use repository update method
                    unitOfWork.Kund.Update(existingKund, kund);
                }
                unitOfWork.SaveChanges();
            }
        }

        public List<Kund> SökKunder(string sökterm)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                sökterm = sökterm.ToLower();
                //Hämta all data från databasen
                var allaKunder = unitOfWork.Kund.GetAll().Include(k => k.Fordon).ToList();

                return allaKunder.Where(k =>
                      (k.Förnamn != null && k.Förnamn.ToLower().Contains(sökterm)) ||
                      (k.Efternamn != null && k.Efternamn.ToLower().Contains(sökterm)) ||
                      (k.Personnummer != null && k.Personnummer.ToLower().Contains(sökterm)) ||
                      (k.Gatuadress != null && k.Gatuadress.ToLower().Contains(sökterm)) ||
                      (k.Postnummer != null && k.Postnummer.ToLower().Contains(sökterm)) ||
                      (k.Ort != null && k.Ort.ToLower().Contains(sökterm)) ||
                      (k.Telefonnummer != null && k.Telefonnummer.ToLower().Contains(sökterm)) ||
                      (k.Epost != null && k.Epost.ToLower().Contains(sökterm)))
                      .ToList();
            }
        }
        }


    }


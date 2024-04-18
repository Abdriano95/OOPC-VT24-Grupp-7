using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Affärslager
{
    public class KundContoller
    {
        public KundContoller() { }

        public IList <Kund> GetKund()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
               return (IList<Kund>)unitOfWork.Kund.GetAll().ToList();
            }
                
        } 

        public Kund AddKund(Kund kund)
        {
            Kund newKund = null!;
            using (UnitOfWork uow = new UnitOfWork())
            {
                newKund = new Kund();
                uow.Kund.Add(newKund);
                uow.SaveChanges();
            }
            return newKund;
        }

        public void UpdateKund(Kund kund) 
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Kund emptyKund = uow.Kund.Find(kund.Id);
                emptyKund.Förnamn = kund.Förnamn;
                emptyKund.Efternamn = kund.Efternamn;
                emptyKund.Personnummer = kund.Personnummer;
                emptyKund.Gatuadress = kund.Gatuadress;
                emptyKund.Postnummer = kund.Postnummer;
                emptyKund.Ort = kund.Ort; 
                emptyKund.Telefonnummer = kund.Telefonnummer;
                emptyKund.Epost = kund.Epost;
                uow.Kund.Update(emptyKund);
                uow.SaveChanges();
            }
        }
    }
}

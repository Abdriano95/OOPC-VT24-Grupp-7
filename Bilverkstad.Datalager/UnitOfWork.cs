using Bilverkstad.Datalager.Respositories;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

namespace Bilverkstad.Datalager
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed = false;
        private readonly bool disopseContext = false;
        protected BilverkstadContext Context { get; }
        private IKundRepository kund = null!;
        public IKundRepository? Kund => kund ??= new KundRepository(Context);
        

        private IFordonRepository fordon = null!;
        public IFordonRepository Fordon => fordon ??= new FordonRepository(Context);
        

        private IAnställdRepository anställd = null!;
        public IAnställdRepository? Anställd => anställd ??= new AnställdRepository(Context);

        

        private IMekanikerRepository mekaniker = null!;
        public IMekanikerRepository? Mekaniker => mekaniker ??= new MekanikerRepository(Context);

        

        private IReceptionistRepository receptionist = null!;
        public IReceptionistRepository? Receptionist => receptionist ??= new ReceptionistRepository(Context);

        


        private IBokningRepository bokning = null!;
        public IBokningRepository Bokning => bokning ??= new BokningRepository(Context);
        

        private IReservdelRepository reservdel = null!;
        public IReservdelRepository? Reservdel => reservdel ??= new ReservdelRepository(Context);

        

        private IReparationRepository reparation = null!;
        public IReparationRepository? Reparation => reparation ??= new ReparationRepository(Context);

        




        public UnitOfWork()
          : this(new BilverkstadContext())
        {
            disopseContext = true;
        }

        public UnitOfWork(BilverkstadContext context)
        {
            Context = context;
        }

        public int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (DbUpdateException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }
            if (disposing)
            {
                if (disopseContext)
                {
                    Context.Dispose();
                }
            }
            isDisposed = true;
        }


        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
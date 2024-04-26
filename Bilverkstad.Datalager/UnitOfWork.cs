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
        public IKundRepository Kunder => throw new NotImplementedException();

        private IFordonRepository fordon = null!;
        public IFordonRepository Fordon => fordon ??= new FordonRepository(Context);
        public IFordonRepository? Fordons => throw new NotImplementedException();

        private IAnställdRepository anställd = null!;
        public IAnställdRepository? Anställd => anställd ??= new AnställdRepository(Context);

        public IAnställdRepository? Anställda => throw new NotImplementedException();

        private IMekanikerRepository mekaniker = null!;
        public IMekanikerRepository? Mekaniker => mekaniker ??= new MekanikerRepository(Context);

        public IMekanikerRepository? Mekanikers => throw new NotImplementedException();

        private IReceptionistRepository receptionist = null!;
        public IReceptionistRepository? Receptionist => receptionist ??= new ReceptionistRepository(Context);

        public IReceptionistRepository? Receptionists => throw new NotImplementedException();

        private IBokningRepository bokning = null!;
        public IBokningRepository Bokning => bokning ??= new BokningRepository(Context);
        public IBokningRepository Boknings => throw new NotImplementedException();


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
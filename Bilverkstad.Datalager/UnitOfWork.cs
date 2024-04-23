using Bilverkstad.Datalager.Respositories;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Datalager
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool isDisposed = false;
        private readonly bool disopseContext = false;
        protected BilverkstadContext Context { get; }

     
        private IFordonRepository fordon = null!;
        public IFordonRepository Fordon => fordon ??= new FordonRepository(Context);
        public IFordonRepository? Fordons => throw new NotImplementedException();

        private IKundRepository kund = null!;
        public IKundRepository? Kund => kund ??= new KundRepository(Context);

        public IKundRepository? Kunder => throw new NotImplementedException();

        public UnitOfWork()
          : this( new BilverkstadContext())
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
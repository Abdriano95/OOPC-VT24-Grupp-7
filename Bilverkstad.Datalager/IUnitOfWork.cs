using Bilverkstad.Datalager.Respositories.Interfaces;

namespace Bilverkstad.Datalager
{

    public interface IUnitOfWork : IDisposable
    {
        IKundRepository Kunder { get; }
        IFordonRepository Fordon { get; }

        int SaveChanges();
    }
}
using Bilverkstad.Datalager.Respositories.Interfaces;

namespace Bilverkstad.Datalager
{

    public interface IUnitOfWork : IDisposable
    {
        IKundRepository Kunder { get; }
        IFordonRepository Fordon { get; }
        IKundRepository Kund { get; }
>>>>>>>>> Temporary merge branch 2
        IFordonRepository Fordon { get; }
        IKundRepository Kund { get; }
>>>>>>>>> Temporary merge branch 2
        IFordonRepository Fordon { get; }

        int SaveChanges();
    }
}
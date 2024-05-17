using Bilverkstad.Datalager.Respositories.Interfaces;

namespace Bilverkstad.Datalager
{

    public interface IUnitOfWork : IDisposable
    {
        IKundRepository Kund { get; }
        IAnställdRepository Anställd { get; }
        IMekanikerRepository Mekaniker { get; }
        IReceptionistRepository Receptionist { get; }
        IFordonRepository Fordon { get; }

        IBokningRepository Bokning { get; }


        IReservdelRepository Reservdel { get; }
        IReparationRepository Reparation { get; }

        int SaveChanges();
    }
}
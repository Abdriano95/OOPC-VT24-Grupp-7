using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Datalager.Respositories.Interfaces
{
    public interface IFordonRepository : IBaseRepository<Fordon>
    {
        public void AddOrUpdate(Fordon fordon);
    }
}
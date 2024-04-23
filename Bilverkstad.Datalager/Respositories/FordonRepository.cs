using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class FordonRepository : BaseRepository<Fordon>, IFordonRepository
    {
        public FordonRepository(DbContext context) : base(context)
        {
        }
    }
}

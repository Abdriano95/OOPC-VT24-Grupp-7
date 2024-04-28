using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class MekanikerRepository : BaseRepository<Mekaniker>, IMekanikerRepository
    {
        public MekanikerRepository(DbContext context) : base(context)
        {
        }
    }
}

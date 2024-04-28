using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class ReparationRepository : BaseRepository<Reparation>, IReparationRepository
    {
        public ReparationRepository(DbContext context) : base(context)
        {
        }
    }
}

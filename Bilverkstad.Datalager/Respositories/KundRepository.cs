using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class KundRepository : BaseRepository<Kund>, IKundRepository
    {
        public KundRepository(DbContext context) : base(context)
        {
        }
    }
}

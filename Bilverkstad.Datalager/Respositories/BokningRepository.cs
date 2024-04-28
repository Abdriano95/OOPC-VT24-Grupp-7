using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class BokningRepository : BaseRepository<Bokning>, IBokningRepository
    {
        public BokningRepository(DbContext context) : base(context)
        {
        }
    }
}

using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class AnställdRepository : BaseRepository<Anställd>, IAnställdRepository
    {
        public AnställdRepository(DbContext context) : base(context)
        {
        }
    }
}

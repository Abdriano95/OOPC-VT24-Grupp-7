using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class ReservdelRepository : BaseRepository<Reservdel>, IReservdelRepository
    {
        public ReservdelRepository(DbContext context) : base(context)
        {
        }
    }
}

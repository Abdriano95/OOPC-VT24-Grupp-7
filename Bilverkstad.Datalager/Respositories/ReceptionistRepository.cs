using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;

namespace Bilverkstad.Datalager.Respositories
{
    public class ReceptionistRepository : BaseRepository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(DbContext context) : base(context)
        {
        }
    }
}

using Bilverkstad.Datalager.Respositories.BaseRepository;
using Bilverkstad.Datalager.Respositories.Interfaces;
using Bilverkstad.Entitetlagret;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilverkstad.Datalager.Respositories
{
    public class ReparationRepository : BaseRepository<Reparation>, IReparationRepository
    {
        public ReparationRepository(DbContext context) : base(context)
        {
        }
    }
}

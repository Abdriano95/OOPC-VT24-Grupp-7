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

        public void AddOrUpdate(Fordon fordon)
        {
            var existingFordon = FindStringID(fordon.RegNr);
            if (existingFordon != null)
            {
                existingFordon.Bilmärke = fordon.Bilmärke;
                existingFordon.Modell = fordon.Modell;
                
                Update(existingFordon);
            }
            else
            {
                Add(fordon);
            }
        }
    }
}

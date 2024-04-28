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
                // Manually update properties if there's no helper to automatically copy values
                existingFordon.Bilmärke = fordon.Bilmärke;
                existingFordon.Modell = fordon.Modell;
                // Add more properties to update as needed
                Update(existingFordon);
            }
            else
            {
                Add(fordon);
            }
            // Assuming SaveChanges is called outside this method or you could call it here
        }
    }
}

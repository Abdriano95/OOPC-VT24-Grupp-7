using Bilverkstad.Entitetlagret;

namespace Bilverkstad.Presentationslager.Data
{
    public interface IKundDataService
    {
        IEnumerable<Kund> GetAll();
    }
}
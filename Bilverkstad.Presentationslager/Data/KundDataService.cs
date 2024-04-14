using Bilverkstad.Entitetlagret;


namespace Bilverkstad.Presentationslager.Data
{
    public class KundDataService : IKundDataService
    {
        //TODO: Load data from real database
        public IEnumerable<Kund> GetAll()
        {
            yield return new Kund { förnamn = "Jocke", efternamn = "Olsson" };
            yield return new Kund { förnamn = "Abbe", efternamn = "Mehdi" };
        }
    }
}

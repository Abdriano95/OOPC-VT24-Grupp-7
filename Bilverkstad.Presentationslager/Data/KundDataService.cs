using Bilverkstad.Entitetlagret;


namespace Bilverkstad.Presentationslager.Data
{
    public class KundDataService : IKundDataService
    {
        //TODO: Load data from real database
        public IEnumerable<Kund> GetAll()
        {
            yield return new Kund { Förnamn = "Jocke", Efternamn = "Olsson" };
            yield return new Kund { Förnamn = "Abbe", Efternamn = "Mehdi" };
        }
    }
}

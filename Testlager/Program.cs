
using Bilverkstad.Affärslager;
using Bilverkstad.Datalager;
using Bilverkstad.Entitetlagret;


namespace Testlager
{
    public class Program
    {
        static void Main(string[] args)
        {
            BilverkstadContext bilverkstad = new BilverkstadContext();


            bilverkstad.Database.EnsureDeleted();
            bilverkstad.Database.EnsureCreated();
            BilverkstadSeed.Populate(bilverkstad);

            foreach (var entry in bilverkstad.ChangeTracker.Entries())
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State.ToString()}");
            }
            Console.ReadLine();



        }
    }
}


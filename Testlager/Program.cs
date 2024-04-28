
using Bilverkstad.Affärslager;
using Bilverkstad.Datalager;


namespace Testlager
{
    public class Program
    {
        static void Main(string[] args)
        {
            KundController kundController = new KundController();
            FordonController fordonController = new FordonController();
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

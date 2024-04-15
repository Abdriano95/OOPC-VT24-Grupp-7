
using Bilverkstad.Datalager;
using Bilverkstad.Datalager.BilverkstadSeed.cs;
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
            Console.ReadLine();
        }


    }
}

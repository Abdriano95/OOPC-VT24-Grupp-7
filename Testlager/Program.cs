
using Bilverkstad.Datalager;
using Bilverkstad.Datalager.BilverkstadSeed.cs;

namespace Testlager
{
    public class Program
    {
        static void Main(string[] args)
        {

            BilverkstadContext bilverkstad = new BilverkstadContext();

            bilverkstad.Database.EnsureDeleted();
            bilverkstad.Database.EnsureCreated();
            //BilverkstadSeed.PopulateReceptionist(bilverkstad);
            Console.ReadLine();
        }


    }
}

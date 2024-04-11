using Bilverkstad.Entitetlagret;

namespace Testlager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Kund k1 = new Kund(123, "Abdulla", "Mehdi", "500420-1181");
            Console.WriteLine(k1.ToString());
            Reservdel r1 = new Reservdel("broms", 1, 300.50);
            

            Mekaniker m1 = new Mekaniker(1235, "Mahmod", "Abbas", _specialisering: Specialiseringar.Dackbyte);

            Console.WriteLine(r1.ToString());

        }
    }
}

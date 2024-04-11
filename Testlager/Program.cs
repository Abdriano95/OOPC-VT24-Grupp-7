using Bilverkstad.Entitetlagret;

namespace Testlager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kund k1 = new Kund(123, "Abdulla", "Mehdi", "500420-1181");
            Console.WriteLine(k1.ToString());

            Mekaniker m1 = new Mekaniker(1235, "Mahmod", "Abbas", _specialisering: Specialiseringar.Dackbyte);

            Console.WriteLine(m1.ToString());
        }
    }
}

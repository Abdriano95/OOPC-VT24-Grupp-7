
namespace Testlager
{
    internal class Program
    {
        static void Main(string[] args)
        {
        

            Kund k1 = new Kund(123, "Abdulla", "Mehdi", "500420-1181");

            Bokning b1 = new Bokning(555, k1);

            Fordon f1 = new Fordon("ABC123", "Volvo", k1);


            Console.WriteLine(k1.ToString());
            Console.WriteLine(b1.ToString());   
            Console.WriteLine(f1.ToString());


        }
    }
}

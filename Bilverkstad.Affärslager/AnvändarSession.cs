namespace Bilverkstad.Affärslager
{
    public static class AnvändarSession
    {
        public static Användare? InloggadAnvändare { get; set; }

        public static void Logout()
        {
            InloggadAnvändare = null; // Rensar sessionen 
        }
    }

    public class Användare
    {
        public string? AnvändarNamn { get; set; }
        public int AnställningsNummer { get; set; }
    }
}

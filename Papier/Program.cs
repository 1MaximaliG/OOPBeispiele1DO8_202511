namespace Papier
{
    public class Papier
    {
        public double lang;
        public double breit;
        public Papier(double einglang, double breit)
        {
            lang = einglang;
            this.breit = breit; 
        }
        public Papier() { }

        public void fläche()
        {
            Console.WriteLine($"Länge: {lang:F2}");
            Console.WriteLine($"Breite: {breit:F2}");
            Console.WriteLine($"Fläche: {lang * breit/10000}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Papier meinZettel = new Papier(50.3, 100.8);
            Papier euerZettel = new Papier();

            meinZettel.fläche();


            euerZettel.lang = 22.5;
            euerZettel.breit = 15.4;
            euerZettel.fläche();
        }
    }
}

using System.Reflection.Emit;

namespace InterfaceBeispiele
{
    public interface IFahrzeug
    {
        public void Starten();
    }
    public interface IElektroFahrzeug
    {
        public void Laden();
    }

    public class Elektroauto : IFahrzeug, IElektroFahrzeug
    {
        public void Starten() { Console.WriteLine("das Auto wird gestartet"); }
        public void Laden() { Console.WriteLine("Das Auto lädt"); }
    }

    //Explizit
    interface IMyInterface1
    {
        public void Methode1();
    }
    interface IMyInterface2
    {
        public void Methode1();
    }
    class MeineKlasse : IMyInterface1, IMyInterface2
    {
        void IMyInterface1.Methode1()
        {
            Console.WriteLine("Ausgabe im Kontext von Interface 1");
        }
        public void Methode1()
        {
            Console.WriteLine("Das ist die generelle Methode der Klasse");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Elektroauto auto = new Elektroauto();
            //auto.Starten();
            //auto.Laden();
            //IFahrzeug fz = auto;
            ////fz.Laden();//Geht hier nicht
            //fz.Starten();
            MeineKlasse mk = new MeineKlasse();
            mk.Methode1();
            IMyInterface1 i1 = mk;
            i1.Methode1();
            IMyInterface2 i2 = mk;
            i2.Methode1();
        }
    }
}

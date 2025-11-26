using System.Net.WebSockets;

namespace Automobil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto herbie = new Auto();
            herbie.SetMarke("VW");
            herbie.Starten();
            herbie.SetGeschwindigkeit(300);
            //herbie.Aus();
            herbie.Fahren(2);
            herbie.Fahren(0.5);
            herbie.Fahren(4.2);
            string xyz = herbie.GetMarke();
            Console.WriteLine(herbie.GetMarke());

        }
    }
}

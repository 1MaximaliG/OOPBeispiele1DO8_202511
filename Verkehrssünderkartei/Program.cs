namespace Verkehrssünderkartei
{
    public class Punktekonto
    {
        private int[] verstöße = new int[10];
        private int index;
        private int punktestand;
        private bool isFull;
        private string name;

        public Punktekonto(string name)
        {
            this.name = name;
        }
        public void GetInfo()
        {
            Console.WriteLine("Konto von :" + name);
            if (index == 0)
            {
                Console.WriteLine("Es liegen keie delikte vor!");
            }
            else
            {
                Punktestand();
            }
        }
        private void neuerVerstoß(int punkte)
        {
            if (!isFull)
            {
                verstöße[index] = punkte;
                punktestand += punkte;
                if (index == 9)
                {
                    Console.WriteLine("Das Konto ist Voll");
                    isFull = true;
                    Console.WriteLine("Sperrzeit: " + Sperrzeit());
                }
                index++;
            }
            else
            {
                Console.WriteLine("Das Konto DOCH SCHON ist Voll");
            }
        }
        public void LeichterVerstoß()
        {
            neuerVerstoß(1);
        }
        public void SchwererVerstoß()
        {
            neuerVerstoß(2);
        }
        public void Punktestand()
        {
            this.punktestand = 0;
            foreach (int punkt in verstöße)
            {
                if (punkt == 0)
                {
                    break;
                }
                if (punkt == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Leichter Verstoß");
                }
                else if (punkt == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Schwerer Verstoß");
                }
                Console.ResetColor();

                this.punktestand += punkt;
            }
            Console.WriteLine("Punktestand: " + punktestand);
            if (isFull)
            {
                Console.WriteLine($"Der Führerschein ist für {Sperrzeit()} entzogen!");
            }
        }
        private string Sperrzeit()
        {
            switch (punktestand)
            {
                case <= 12: return "1 Monat";
                case <= 15: return "3 Monat";
                case <= 18: return "6 Monat";
                default: return "1 Jahr";
            }
        }
        public bool IsFull() {  return isFull; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Punktekonto eins = new Punktekonto("Horst");
            Punktekonto zwei = new Punktekonto("Petra");
            Punktekonto drei = new Punktekonto("Friedhelm");

            Punktekonto[] Verkehrssünder = { eins, zwei, drei };
            List<Punktekonto> Verkehrssünder2 = new List<Punktekonto>();
            Verkehrssünder2.Add(eins);
            Verkehrssünder2.Add(zwei);
            Verkehrssünder2.Add(drei);

            Random randy = new Random();
            do
            {
                if (randy.Next(2) == 1)
                    Verkehrssünder2[randy.Next(Verkehrssünder2.Count)].SchwererVerstoß();
                else
                    Verkehrssünder2[randy.Next(Verkehrssünder2.Count)].LeichterVerstoß();
            } while (!(eins.IsFull()&&zwei.IsFull()&&drei.IsFull()));

            eins.GetInfo();
            zwei.GetInfo();
            drei.GetInfo();

        }
    }
}

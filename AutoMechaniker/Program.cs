using AutoMechanikerKlassen;
namespace AutoMechaniker
{
    public class Motor
    {
        private string _name;
        public Motor(string a)
        {
            _name = a;
        }
        public string GetName() { return _name; }
    }

    public class Kunde
    {
        private string _name;
        private List<Auto> _autos = new List<Auto>();
        public Kunde(string name)
        {
            _name = name;
        }
        public void Kaufen(Auto auto)
        {
            _autos.Add(auto);
        }
        public List<Auto> Hat() { return _autos; }
        public void Info()
        {
            Console.WriteLine($"{_name} hat in seiner Garage:");
            foreach (Auto auto in _autos)
            {
                auto.Info();
            }
        }
        public void AllesMussRaus() { _autos.Clear(); }
    }
    public class Mechaniker
    {
        private string _name;
        private List<Kunde> _kunden;
        public Mechaniker(string name)
        {
            _kunden = new List<Kunde>();
            _name = name;
        }
        public void Reaparieren(Werkzeug tool, Kunde kunde, Auto auto)
        {
            if (!_kunden.Contains(kunde))
            {
                Console.WriteLine("Das ist kein Kunde von mir!");
                _kunden.Add(kunde);
            }
            if (!kunde.Hat().Contains(auto))
            {
                Console.WriteLine("Der Kunde besitzt diesesAuto gar nicht!");
                return;
            }
            if (auto.IsKaputt())
            {
                auto.Reparieren();
                Console.WriteLine("Das Auto wurde repariert");
                return;
            }
            Console.WriteLine("Das auto ist nicht kaputt");
        }
        public void Info()
        {
            Console.WriteLine($"{_name} hat schon Autos repariert von:");
            foreach (Kunde kunde in _kunden)
            {
                kunde.Info();
            }
        }
    }
    public class Werkzeug
    {
        public string Name2 { get; private set; }
        private string name;
        public string Name {
            get { return name; }
            private set { name = value +"XXX"; } 
        }
        public string zusatnd
        {
            get { return Name2 + " " + name; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Werkzeug w = new Werkzeug();
            Console.WriteLine(w.zusatnd);
            Console.WriteLine(w.Name);


            //Mechaniker dd = new Mechaniker("Daniel Düsentrieb");
            //Kunde k = new Kunde("Dagobert");
            //Kunde k2 = new Kunde("Issam");
            //Auto a = new Auto("VW", "Phaeton", "V12");
            //Auto a4 = new Auto("BatMobil", "Ich mach alles Kaputt", "XXXXXXXXX");
            //Auto a2 = new Auto("Trabant", "kombi", "600cc");
            //Auto a3 = new Auto("Porsche", "992 Targa", "6Zylinder Boxer");
            //k.Kaufen(a);
            //k2.Kaufen(a2);
            //k2.Kaufen(a3);

            //a3.Info();
            //Console.WriteLine("####################");
            //a3 = a4;
            ////k2.AllesMussRaus();
            ////k2.Info();
            //a3.Info();
            ////a2.Fahren(1_000_001);
            ////Werkzeug werkzeug = new Werkzeug("Hammer");
            ////dd.Reaparieren(werkzeug, k, a2);
            ////dd.Reaparieren(werkzeug, k2, a2);
            ////dd.Info();
        }
    }
}

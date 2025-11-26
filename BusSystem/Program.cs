using System.IO.Pipes;

namespace BusSystem
{
    public class Passagier
    {
        public string Name { get; }
        public Passagier(string name)
        {
            Name = name;
        }
    }
    public enum Belegung
    {
        Leer,
        Teilbelegt,
        Voll
    }
    public enum Fahren
    {
        Garage,
        Fahren,
        Haltestelle
    }
    public class Laderaum//Passagiere
    {
        private Belegung _belegung = Belegung.Leer;
        public Belegung Belegung { get { return _belegung; } }
        public Laderaum(int n, Bus bus)
        {
            _maximal = n;
            Bus = bus;
        }
        public Bus Bus { get; }
        private List<Passagier> _sitzplätze = new List<Passagier>();
        public List<Passagier> Sitzplätze { get { return _sitzplätze; } }
        private int _maximal;

        //Operationen
        public bool Einsteigen(Passagier p)
        {
            if (_belegung != Belegung.Voll && !_sitzplätze.Contains(p))//_sitzplätze.Count != _maximal
            {
                _sitzplätze.Add(p);
                if (_sitzplätze.Count == _maximal)
                    _belegung = Belegung.Voll;
                else
                    _belegung = Belegung.Teilbelegt;

                return true;
            }
            return false;
        }

        //Erweiterung
        public bool EinsteigenGruppe(List<Passagier> gruppe)// ÜBERLADUNG:public bool Einsteigen(List<Passagier> gruppe)
        {
            foreach (Passagier person in gruppe)
            {
                if (!Einsteigen(person))
                {
                    if (_belegung == Belegung.Voll)
                    {
                        Console.WriteLine("Der Bus ist zu voll");
                    }
                    else
                    {
                        Console.WriteLine("Die Person ist schon drin");
                    }
                    return false;
                }
            }
            return true;
        }
        public bool Aussteigen(Passagier p)
        {
            if (_sitzplätze.Contains(p))
            {
                _sitzplätze.Remove(p);
                if (_sitzplätze.Count == 0)
                    _belegung = Belegung.Leer;
                else
                    _belegung = Belegung.Teilbelegt;
                return true;
            }
            return false;
        }
    }
    public interface IFahen
    {
        public void StreckeFahren(int strecke, Fahren ziel);
    }
    public class Bus:IFahen
    {
        public Bus(double verbrauchsGrundwert)
        {
            _laderaum = new Laderaum(24, this);
            _verbrauch = verbrauchsGrundwert;
        }
        private Laderaum _laderaum;
        //public Laderaum Laderaum { get; }

        private Fahren _fahren = Fahren.Garage;
        private double _gesamtKilometer;
        private double _verbrauch;

        //Operationen
        public void Einsteigen(Passagier person)
        {
            if (_fahren == Fahren.Haltestelle)
                _laderaum.Einsteigen(person);
        }
        public void Einsteigen(List<Passagier> personen)
        {
            foreach (Passagier person in personen)
            {
                if (_fahren == Fahren.Haltestelle)
                    _laderaum.Einsteigen(person);
            }
        }
        public void Aussteigen(Passagier person)
        {
            if (_fahren == Fahren.Haltestelle)
            {
                _laderaum.Aussteigen(person);
            }
        }
        public void StreckeFahren(int streckeInKm, Fahren ziel)
        {
            if (ziel != Fahren.Fahren)
            {
                _fahren = Fahren.Fahren;
                double verbrauch = 0;
                if (_laderaum.Belegung == Belegung.Leer)
                {
                    verbrauch = _verbrauch / 100 * streckeInKm;
                }
                else if (_laderaum.Belegung == Belegung.Voll)
                {
                    verbrauch = _verbrauch * 1.1 / 100 * streckeInKm;
                }
                else
                {
                    verbrauch = VerbrauchBerechnen(streckeInKm);
                }
                Console.WriteLine($"der Bus is {streckeInKm}km gefahren und hat dabei {verbrauch}l verbraucht.");
                _gesamtKilometer += streckeInKm;
                Console.WriteLine($"der Bus ist insgesammt {_gesamtKilometer}km gefahren");
                _fahren = ziel;
            }

        }
        public double VerbrauchBerechnen(int strecke)
        {
            double verbrauch = 0;
            if (_fahren == Fahren.Fahren)
            {
                verbrauch += _verbrauch;
                verbrauch += (_verbrauch * 0.1 / 24) * _laderaum.Sitzplätze.Count; //TODO 24 dynamisch machen
            }
            return verbrauch / 100 * strecke;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Bus L537 = new Bus(25);
            Passagier p1 = new Passagier("Anna");
            Passagier p2 = new Passagier("Peter");
            Passagier p3 = new Passagier("Arif");
            Passagier p4 = new Passagier("Issam");
            Passagier p5 = new Passagier("Walia");
            Passagier p6 = new Passagier("Max");
            Passagier p7 = new Passagier("Bilbo");
            Passagier p8 = new Passagier("Iulia");
            Passagier p9 = new Passagier("Gollum");
            List<Passagier> gruppe = new List<Passagier> {
                new Passagier("G'Gandalf"),
                new Passagier("G'Gandalf"),
                new Passagier("G'Gandalf"),
                new Passagier("Pallando"),
                new Passagier("Alator"),
                new Passagier("Radagast"),
                new Passagier("Saruman"),
                new Passagier("Bombadil") };
            L537.StreckeFahren(100, Fahren.Haltestelle);
            L537.Einsteigen(p1);
            L537.Einsteigen(p1);
            L537.Einsteigen(p2);
            L537.Einsteigen(p3);
            L537.Einsteigen(p4);
            L537.StreckeFahren(100, Fahren.Haltestelle);
            L537.Einsteigen(p5);
            L537.Einsteigen(p6);
            L537.Einsteigen(p7);
            L537.Einsteigen(p8);
            L537.Einsteigen(p9);
            L537.Einsteigen(gruppe);
            L537.StreckeFahren(100, Fahren.Haltestelle);


        }
    }
}

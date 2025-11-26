using System.Diagnostics.Metrics;
using System.IO;

namespace assoziationen
{
    public class Lehrer
    {
        private string _name;
        private string _fach;
        private List<Schüler> _schülerListe;
        public Lehrer(string name, string fach)
        {
            _fach = fach;
            _name = name;
            _schülerListe = new List<Schüler>();
        }
        public string GetName() { return _name; }
        public string GetFach() { return _fach; }
        public void AddSchüler(Schüler schüler)
        {
            if (!this._schülerListe.Contains(schüler))
            {
                this._schülerListe.Add(schüler);
            }
        }
        public void Unterrichtet()
        {
            foreach (Schüler s in this._schülerListe)
            {
                Console.WriteLine(s.GetName());
            }
        }
    }
    public class Schüler
    {
        private string _name;
        private string _klasse;
        public Schüler(string name, string klasse)
        {
            _name = name;
            _klasse = klasse;
        }
        public string GetName() { return _name; }
        public string GetKlasse() { return _klasse; }
    }

    public class Arzt
    {
        private string _name;
        private string _fachgebiet;
        private List<Patient> _patienten = new List<Patient>();

        public void SetName(string name) { this._name = name; }
        public void SetFachgebiet(string fachgebiet) { this._fachgebiet = fachgebiet; }
        public string GetName() { return _name; }
        public string GetFachgebiet() { return _fachgebiet; }
        public void PatientHinzufügen(List<Patient> p)
        {
            foreach (Patient pat in p)
            {
                PatientHinzufügen(pat);
            }
        }
        public void PatientHinzufügen(Patient p)
        {
            if (!this._patienten.Contains(p))
                this._patienten.Add(p);
        }
        public void Behandeln()
        {
            foreach(Patient pat in this._patienten)
            {
                Console.WriteLine($"{pat.GetName()} hat {pat.GetKrankheit()} wird betreut von {this._name} : {this._fachgebiet}");
            }
        }
    }
    public class Patient
    {
        private string _name;
        private string _krankheit;

        public void SetName(string name) { this._name = name; }
        public void SetKrankheit(string krankheit) { this._krankheit = krankheit; }
        public string GetName() { return _name; }
        public string GetKrankheit() { return _krankheit; }
    }

    public class Musiker
    {
        private string _name;
        private string _musikrichtung;
        private Instrument _instrument;
        public Musiker(string name,string musikrichtugn,Instrument instrument)
        {
            this._instrument = instrument;
            _name = name;
            _musikrichtung = musikrichtugn;
        }
        public string GetName() { return _name; }
        public Instrument GetInstrument() { return _instrument; }
        public string Musikrichtung() {  return _musikrichtung; }
        public void SpielMusik()
        {
            Console.WriteLine($"{_name} spielt auf {_instrument.GetName()}, ein {_instrument.GetTyp()}, {_musikrichtung}");
        }
    }
    public class Instrument
    {
        private string _name;
        private string _typ;
        public Instrument(string name, string typ)
        {
            _name = name;
            _typ = typ;
        }
        public string GetName() { return _name; } 
        public string GetTyp() { return _typ; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schüler eins = new Schüler("Draco Malfoy", "Slytherin");
            //Schüler zwei = new Schüler("Ron Weasley", "Griffindor");

            //Lehrer leins = new Lehrer("Severus Snape", "Zaubertränke");
            //leins.AddSchüler(eins);
            //leins.AddSchüler(zwei);
            //leins.Unterrichtet();
            //Patient eins = new Patient();
            //eins.SetName("Peter");
            //eins.SetKrankheit("Super Aids");
            //Patient zwei = new Patient();
            //zwei.SetName("Zero");
            //zwei.SetKrankheit("Mangelnder Reichtum");

            //Arzt a1 = new Arzt();
            //a1.SetName("Dr. Holiday");
            //a1.SetFachgebiet("Schmuddelheftchen");
            //a1.PatientHinzufügen(new List<Patient> { eins, zwei });
            //a1.Behandeln();

            Instrument item = new Instrument("Triangel", "Perkusionsinstrument");
            Musiker eins = new Musiker("Mozart", "Techno", item);
            eins.SpielMusik();

        }
    }
}

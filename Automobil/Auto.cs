namespace Automobil
{
    public class Auto
    {
        //Felder / Attribute
        private string _marke;
        private bool _gestartet;
        private double _geschwindigkeit;
        private double _kilometerstand;

        //Operationen / Methoden
        public bool IstAn() { return _gestartet; }
        public void Starten() { _gestartet = true; }
        public void Aus() { 
            _gestartet = false;
            _geschwindigkeit = 0;
        }
        public string GetMarke() { return _marke; }
        public void SetMarke(string marke) { _marke = marke; }
        //fahren mit Zeit und Geschwindigkeit
        public void SetGeschwindigkeit(double KMH)
        {
            if (_gestartet == true)
            {
                if (KMH < 0)
                {
                    Console.WriteLine("Geschwindigkeit kann nicht klein als 0 sein");
                }
                else
                {
                    this._geschwindigkeit = KMH;
                }
            }
        }
        public void Fahren(double stunden)
        {
            _kilometerstand += stunden*_geschwindigkeit;
            Console.WriteLine($"Du Fährst {stunden * _geschwindigkeit}km und der neue Kilometerstand ist {_kilometerstand}km");
        }

    }
}

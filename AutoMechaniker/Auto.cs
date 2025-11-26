using AutoMechaniker;
namespace AutoMechanikerKlassen
{
    public class Auto
    {
        private string _marke;
        private string _model;
        private int _gKilometer;
        private Motor _motor;
        private bool _isKaputt;
        private Kunde _besitzer;
        private int _letzteReperatur;
        public Auto(string marke, string model, string motorTyp)
        {
            _marke = marke;
            _model = model;
            _gKilometer = 0;
            _motor = new Motor(motorTyp);//für Komposition in der Klasse auto erstellt
            _isKaputt = false;
            _letzteReperatur = 0;
        }
        public void Info()
        {
            Console.WriteLine($"{_marke} {_model} mit einem {_motor.GetName()}:");
            Console.WriteLine($"Kilometerstand: {_gKilometer}");
            Console.WriteLine($"Zuletzt repariert vor: {_letzteReperatur} Status: {_isKaputt}");
            //TODO eigentümer
        }
        public void Fahren(int strecke)
        {
            Console.WriteLine("Das auto Fährt");
            _gKilometer += strecke;
            _letzteReperatur += strecke;

            if (_letzteReperatur > 50_000)
            {
                _isKaputt = true;
                Console.WriteLine("Auto geht Kaputt");
            }
            else
            {
                Random rng = new Random();
                if (rng.Next(1_000_000) < _gKilometer)
                {
                    _isKaputt = true;
                    Console.WriteLine("Auto geht Kaputt");
                }
            }
        }
        public void Reparieren()
        {
            _letzteReperatur = 0;
            _isKaputt = false;
        }
        public bool IsKaputt() { return _isKaputt; }
    }
}

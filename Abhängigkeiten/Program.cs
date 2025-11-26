namespace Abhängigkeiten
{
    public class Dokument
    {
        private string _inhalt;
        public void SetInhalt(string inhalt)
        {
            this._inhalt = inhalt;
        }
        public string GetInhalt()
        {
            return this._inhalt;
        }
    }
    public class Printer
    {
        public void PrintFile(Dokument dokument)
        {
            Console.WriteLine("Drucker: " + dokument.GetInhalt());
        }
    }
    public class Benutzer
    {
        private string _name;
        private string _telefonnummer;

        public Benutzer(string name, string nummer)
        {
            this._name = name;
            this._telefonnummer = nummer;
        }
        public string GetName() { return this._name; }
        public string GetTelefonnummer() { return this._telefonnummer; }
    }
    public class SMSDienst
    {
        public static void Senden(Benutzer benutzer, string nachricht)
        {
            Console.WriteLine($"An: {benutzer.GetName()} - {benutzer.GetTelefonnummer()}");
            Console.WriteLine(nachricht);
        }
    }
    public class Konto
    {
        private string _kontonummer;
        private decimal _kontostand;

        public Konto(string nummer)
        {
            _kontonummer = nummer;
            _kontostand = 500;
        }
        public string GetKontonummer() { return this._kontonummer; }
        public decimal GetKontostand() { return this._kontostand; }
        public void ChangeBalance(decimal betrag) { _kontostand += betrag; }

    }
    public class Bank
    {
        public static void Überweisen(Konto von,Konto nach, decimal betrag)
        {
            von.ChangeBalance(-betrag);
            nach.ChangeBalance(betrag);
            Console.WriteLine($"{betrag}€ von {von.GetKontonummer()} nach {nach.GetKontonummer()}");
            Console.WriteLine(von.GetKontonummer());
            Console.WriteLine("Kontostand: "+von.GetKontostand());
            Console.WriteLine(nach.GetKontonummer());
            Console.WriteLine("Kontostand: " + nach.GetKontostand());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Printer printer = new Printer();
            //Dokument d = new Dokument();
            //d.SetInhalt("Text aus dem Dokument");
            //printer.PrintFile(d);

            //Benutzer b = new Benutzer("Ingo Regenbogen","0231/123456789");
            //SMSDienst.Senden(b, "Omma kommt morgen, hol noch Schokolade!");

            Konto eins = new Konto("1234567");
            Konto zwei = new Konto("9874566");
            Bank.Überweisen(eins, zwei,337);
            Bank.Überweisen(zwei, eins,1337);
            Bank.Überweisen(zwei, eins,-85546);

        }
    }
}

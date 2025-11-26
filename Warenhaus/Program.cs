namespace Warenhaus
{
    //Felder/Attribute
    public class Warenhaus
    {
        private int _warenbestand;
        private decimal _kassenbestand;
        private string _name;
        private decimal _umsatz;
        private decimal _geldfluss;

        //Operationen
        public Warenhaus(string name)
        {
            this._name = name;
            this._warenbestand = 50;
            this._kassenbestand = 100.44m;//m für decimal(money)
        }
        public void SetName(string name) { _name = name; }
        public void Einkauf(int menge)
        {
            if (_kassenbestand >= menge * 10)
            {
                _warenbestand += menge;
                _kassenbestand -= 10 * menge;
                _geldfluss += 10 * menge;
            }
            else
            {
                Console.WriteLine("Keine Geld Ya!");
            }
        }
        public void Verkauf(int menge)
        {
            if (_warenbestand >= menge)
            {
                _warenbestand -= menge;
                _kassenbestand += 20 * menge;
                _geldfluss += 20 * menge;
                _umsatz += 20 * menge;
            }
            else
            {
                Console.WriteLine("Keine Ware mehr!");
            }
        }
        public void GetInfo()
        {
            Console.WriteLine($"Warenhaus: {_name}");
            Console.WriteLine($"Warenbestand: {_warenbestand} Stück");
            Console.WriteLine($"Kassenbestand: {_kassenbestand} Geld");
            Console.WriteLine($"Umsatz: {_umsatz} Geld");
            Console.WriteLine($"Geldfluss: {_geldfluss} Geld");
            Console.WriteLine("___________________________________________");
        }
        public static void TuWas()
        {
            Warenhaus[] whKette = [new Warenhaus("KarstadtQuelle"), new Warenhaus("LakeTownMicroServer"), new Warenhaus("Weingroßhandel")];
            Random zufall = new Random();

            for (int i = 0; i < 100; i++)
            {
                Warenhaus temp = whKette[zufall.Next(3)];
                if (Convert.ToBoolean(zufall.Next(2)))
                {
                    temp.Verkauf(zufall.Next(10));
                }
                else
                {
                    temp.Einkauf(zufall.Next(10));
                }
            }
            foreach (Warenhaus w in whKette)
            {
                w.GetInfo();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Warenhaus.TuWas();

        }
    }
}

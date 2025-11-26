namespace Steintal
{
    public class SteintalBewohner
    {
        public string _wohnort { get; protected set; }
        protected DateTime _geburtsdatum { get; set; }
        public SteintalBewohner(string wohnort)
        {
            _wohnort = wohnort;
            _geburtsdatum = DateTime.Now;
        }
    }
    public class Mensch : SteintalBewohner
    {
        protected string _vorname { get; set; }
        public string _nachname { get; protected set; }
        public Mensch(string wohnort, string vorname, string nachname) : base(wohnort)
        {
            _vorname = vorname;
            _nachname = nachname;
        }
        public void Sprechen() { Console.WriteLine(_vorname + " Spricht!"); }
    }
    public class Haustier :SteintalBewohner
    {
        public Haustier(string wohnort,string name,Erwachsener erwachsener) : base(wohnort)
        {
            _name = name;
            _besitzer = erwachsener;
        }
        protected string _name { get; set; }
        protected Erwachsener _besitzer { get; set; }
    }
    public class Erwachsener:Mensch
    {
        public Erwachsener(string wohnort, string vorname, string nachname) : base(wohnort, vorname, nachname)
        {
        }

        public Kind? _kind { get; set; }
        public void AutoFahren() { Console.WriteLine("Person Fährt!"); }
    }
    public class Kind : Mensch
    {
        public Kind(string wohnort, string vorname, string nachname,Mann vater,Frau mutter) : base("", vorname, "")
        {
            _vater = vater;
            _vater._kind = this;
            _mutter = mutter;
            _mutter._kind = this;
            _nachname = _mutter._nachname;
            _wohnort = _mutter._wohnort;
        }
        protected Mann _vater { get; set; }
        protected Frau _mutter { get; set; }
    }
    public class Dino:Haustier
    {
        public Dino(Erwachsener erwachsener) : base("Steintal", "Dino", erwachsener)
        {
            
        }

        public void GesichtAbschlecken(Mensch m) { Console.WriteLine("Dino schleckt {0} übers gesicht",m); }
    }
    public class Hoppy:Haustier
    {
        public Hoppy(Erwachsener erwachsener) : base("Steintal", "Hoppy", erwachsener)
        {
        }

        public void Rumhoppsen() { Console.WriteLine("Hoppy hoppst happy :D"); }
    }
    public class Baby_Puss: Haustier
    {
        public Baby_Puss(Erwachsener erwachsener) : base("Steintal", "Baby-Puss", erwachsener)
        {        }
        public void FredRauswerfen(Fred fred) { Console.WriteLine("Die Katze wirft einen Fred raus"); }
    }
    public class Frau:Erwachsener
    {
        public Frau(string wohnort, string vorname, string nachname) : base(wohnort, vorname, nachname)
        {
        }
        public void Heiraten(Mann mann)
        {
            if (_ehemann == null)
            {
                _ehemann = mann;
                _mädchenname = _nachname;
                _nachname = mann._nachname;
                _ehemann.Heiraten(this);
            }
        }
        protected Mann? _ehemann { get; set; }
        protected string? _mädchenname { get; set; }
        public void Tratschen() { Console.WriteLine("hast du schon gehört?....."); }
    }
    public class Mann:Erwachsener
    {
        public Mann(string wohnort, string vorname, string nachname) : base(wohnort, vorname, nachname)
        {
        }
        public void Heiraten(Frau frau)
        {
            if(_ehefrau == null)
            {
                _ehefrau = frau;
                _ehefrau.Heiraten(this);
            }
        }
        protected Frau? _ehefrau { get; set; }
        public void Kegeln() { Console.WriteLine("Strike!!!"); }
    }
    public class Pebbels:Kind
    {
        public Pebbels(Mann vater, Frau mutter) : base("Steintal", "Pebbels", "Flintstone", vater, mutter)
        {
        }
        public void Krabbeln() { Console.WriteLine("Vorsicht treppe!! oO"); }
    }
    public class Bamm_Bamm:Kind
    {
        public Bamm_Bamm(Mann vater, Frau mutter) : base("Steintal", "Bamm-Bamm", "Geröllheimer", vater, mutter)
        {
        }

        public void KaputtSchlagen() { Console.WriteLine("BAMM"); }
    }
    public class Betty:Frau
    {
        public Betty() : base("Steintal", "Betty", "McBricker")
        {
        }

        public void Shoppen() { Console.WriteLine("Nice, more Stuff"); }
    }
    public class Wilma:Frau
    {
        public Wilma() : base("Steintal", "Wilma", "Slaghoople")
        {
        }
        public void Kochen() { Console.WriteLine("Wilma kocht Kuchen"); }
    }
    public class Barney:Mann
    {
        public Barney() : base("Steintal", "Barney", "Geröllheimer")
        {
        }

        public void Kichern() { Console.WriteLine("Hihihihi"); }
    }
    public class Fred:Mann
    {
        public Fred() : base("Steintal", "Fred", "Flintstone")
        {
        }

        public void YabbaDabbaDoo() { Console.WriteLine("YABBADABBADOOoooOOOOO1111"); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fred fred = new Fred();
            Wilma wilma = new Wilma();
            Pebbels pebbels = new Pebbels(fred, wilma);

            Betty betty = new Betty();
            Barney barney = new Barney();
            Bamm_Bamm bamm = new Bamm_Bamm(barney, betty);
            Console.WriteLine(fred._nachname);
            //Console.WriteLine(wilma._mädchenname);//das geht nicht
            betty._kind = pebbels;//das geht leider
            
        }
    }
}

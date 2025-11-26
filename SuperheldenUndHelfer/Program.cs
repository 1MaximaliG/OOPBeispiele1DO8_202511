using System.Security.AccessControl;

namespace SuperheldenUndHelfer
{
    public class Superheld
    {
        private string _name; //zur unterscheidung der Instanzen
        private Helfer[] _helfer = new Helfer[5];
        public Superheld(string name)
        {
            _name = name;   
        }
        public string GetName() {  return _name; }
        public bool HelferHinzufügen(Helfer helfer)
        {
            for(int i = 0; i< _helfer.Length; i++)
            {
                if (_helfer[i] == helfer)
                {
                    return true;//um endlos schleifen mir aufrufen zu brechen
                }
                if (_helfer[i] == null)
                {
                    _helfer[i] = helfer;
                    helfer.setHeld(this);//das 'this' bezieht sich auf die Aktuelle Instanz des Helden(ich)
                    return true; 
                }
            }
            return false;
        }
    }
    public class Helfer
    {
        private string _name;
        private Superheld _held;
        public Helfer(string name)
        {
            _name = name;
        }
        public string GetName() { return _name; }
        public void setHeld(Superheld sh)
        {
            _held = sh;
            if (_held.HelferHinzufügen(this))
            {
                Console.WriteLine($"Helfer unterstüztz {_held.GetName()}");
            }
        }
        public void Unterstützen(Gegenstand item)
        {
            if(_held != null)
            {
            Console.WriteLine($"{_name} hilft {_held.GetName()} mit {item.GetBezeichnung()} sodass er {item.GetTyp()}!");
            }
            else
            {
                Console.WriteLine($"{_name} ist Arbeistlos und braucht was zu tun!");
            }
        }
    }
    public class Gegenstand
    {
        private string _bezeichnung;
        private string _typ;
        public Gegenstand(string bezeichnung, string typ)
        {
            _bezeichnung = bezeichnung;
            _typ = typ;
        }
        public string GetBezeichnung() { return _bezeichnung; }
        public string GetTyp() { return _typ; } 
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Superheld held1 = new Superheld("Thor");
            Helfer helfer1 = new Helfer("LowKey");
            Helfer helfer2 = new Helfer("Odin");
            Gegenstand gegenstand1 = new Gegenstand("Mjölnir","Blitze beschwört");

            held1.HelferHinzufügen(helfer1 );
            //held1.HelferHinzufügen(helfer2 );
            helfer1.Unterstützen(gegenstand1 );
            helfer2.Unterstützen(gegenstand1 );
        }
    }
}

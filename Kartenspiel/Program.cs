using System.Runtime.InteropServices;

namespace Kartenspiel
{
    public enum Kartenfarbe
    {
        Kreuz,
        Pik,
        Herz,
        Karo
    }
    public enum Kartenwert
    {
        Sieben = 7,
        Acht,
        Neun,
        Zehn,
        Bube,
        Dame,
        König,
        Ass
    }
    public class Spielkarte(Kartenfarbe farbe, Kartenwert wert)
    {
        private Kartenfarbe _farbe = farbe;
        private Kartenwert _wert = wert;
        public Kartenfarbe GetFarbe() { return _farbe; }
        public Kartenwert GetWert() { return _wert; }
        public string Info() { return $"{_farbe} {_wert}"; }

        public static List<Spielkarte> AkinShuffle(List<Spielkarte> sortiert)
        {
            int[] zahlen = new int[sortiert.Count];
            Array.Fill(zahlen, 99);
            int i = 0;
            Random randy = new Random();
            while (i < zahlen.Length)
            {
                int zahl = randy.Next(zahlen.Length);
                if (!zahlen.Contains(zahl))
                {
                    zahlen[i] = zahl;
                    i++;
                }
            }
            List<Spielkarte> unsortiert1 = new List<Spielkarte>();
            for (int n = 0; n < sortiert.Count; n++)
            {
                unsortiert1.Add(sortiert[zahlen[n]]);
            }
            return unsortiert1;
        }
        public static List<Spielkarte> ThomasMischen(List<Spielkarte> sortiert, int times)
        {
            List<Spielkarte> unsortiert = new List<Spielkarte>();
            Random randy = new Random();
            do
            {
                int current = randy.Next(sortiert.Count);
                unsortiert.Add(sortiert[current]);
                sortiert.RemoveAt(current);
            } while (sortiert.Count > 0);
            if (times <= 0)
            {
                return unsortiert;
            }
            else
            {
                return ThomasMischen(unsortiert, times - 1);
            }
        }
        public static List<Spielkarte> TimMischen(List<Spielkarte> sortiert)
        {
            Random randy = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = randy.Next(sortiert.Count);
                int b = randy.Next(sortiert.Count);
                (sortiert[a], sortiert[b]) = (sortiert[b], sortiert[a]);
            }
            return sortiert;
        }
        public static List<Spielkarte> StapelErstellen()
        {
            List<Spielkarte> kartenStapel = new List<Spielkarte>();
            var alleFarben = Enum.GetValues(typeof(Kartenfarbe));
            var allewerte = Enum.GetValues(typeof(Kartenwert));
            foreach (Kartenfarbe k in alleFarben)
                foreach (Kartenwert w in allewerte)
                    kartenStapel.Add(new Spielkarte(k, w));
            return kartenStapel;
        }
    }
    public class MauMau
    {
        private List<Spielkarte> _deck;
        private List<Spielkarte> _spieler;
        private List<Spielkarte> _gegner;
        private List<Spielkarte> _ablage;
        private Spielkarte _liegtGrade;
        private int _sonderbedient;

        public MauMau(List<Spielkarte> gemischterStapel)
        {
            //Startaufbau des Spiels
            _deck = gemischterStapel;
            _spieler = new List<Spielkarte>();
            //for (int i = 0; i < 7; i++) { _spieler.Add(Ziehen()); }
            _spieler.AddRange(_deck.GetRange(0, 7));
            _deck.RemoveRange(0, 7);
            _gegner = new List<Spielkarte>();
            for (int i = 0; i < 7; i++) { _gegner.Add(Ziehen()); }
            _ablage = new List<Spielkarte>();
            _liegtGrade = Ziehen();
            _ablage.Add(_liegtGrade);
        }
        public bool SpielEnde()
        {
            if (_spieler.Count == 0 || _gegner.Count == 0)
                return true;
            return false;
        }
        private Spielkarte Ziehen()
        {
            Spielkarte karte = _deck[0];
            _deck.RemoveAt(0);
            if (_deck.Count == 0)
            {
                Spielkarte temp = _ablage[_ablage.Count - 1];
                _ablage.RemoveAt(_ablage.Count - 1);
                _deck = Spielkarte.AkinShuffle(_ablage);
                _ablage.Clear();
                Console.WriteLine("DAS DECK WURDE NEU GEMISCHT!");
            }
            return karte;
        }
        public void Anzeige()
        {
            Console.Clear();
            if (SpielEnde())
            {
                if (_spieler.Count == 0)
                {
                    Console.WriteLine("##########################");
                    Console.WriteLine("##                      ##");
                    Console.WriteLine("##      Herzlichen      ##");
                    Console.WriteLine("##      Glückwunsch     ##");
                    Console.WriteLine("##                      ##");
                    Console.WriteLine("##########################");
                }
                else
                {
                    Console.WriteLine("##########################");
                    Console.WriteLine("##                      ##");
                    Console.WriteLine("##         Leider       ##");
                    Console.WriteLine("##        Verloren      ##");
                    Console.WriteLine("##                      ##");
                    Console.WriteLine("##########################");
                }
            }
            else
            {
                //gegner Karten
                Console.Write(" | ");
                foreach (Spielkarte karte in _gegner) { Console.Write("######" + " | "); }
                Console.WriteLine();
                //Spielfeld
                Console.WriteLine();
                Console.WriteLine("Es ist zu bedienen: " + _liegtGrade.Info());
                Console.WriteLine($"Es liegt: {_ablage[_ablage.Count - 1].Info()}");//letzte Karte der Ablage
                Console.WriteLine("Der Stapel hat noch {0} Karten", _deck.Count);
                Console.WriteLine();
                //Hand des Spielers
                Console.Write(" | ");
                foreach (Spielkarte karte in _spieler) { Console.Write(karte.Info() + " | "); }
                Console.WriteLine();
            }
        }
        public void Eingabe()
        {
            Anzeige();
            Thread.Sleep(1000);
            //Liegt eine 7
            if (_liegtGrade.GetWert() == (Kartenwert)7 && _sonderbedient > 0)
            {
                if (ZugMöglichSonder(_spieler))
                {
                    int eingabe = 99;
                    do
                    {
                        Console.WriteLine("Welche Karte möchtest du spielen?");
                        foreach (Spielkarte karte in _spieler)
                        {
                            Console.Write("    -" + _spieler.IndexOf(karte) + "-    ");
                        }
                        eingabe = Convert.ToInt32(Console.ReadLine());
                    } while (!ValidierungSonder(_liegtGrade, _spieler[eingabe]));//TODO: Wäre hier schön mit einem delegate zu ändern
                    //Ist die karte Valide, kann eine 7 gelegt werden
                    _ablage.Add(_spieler[eingabe]);
                    _spieler.RemoveAt(eingabe);
                    _liegtGrade = _spieler[eingabe];
                    Sonderprüfung();
                }
                else
                {
                    for (int i = 0; i < _sonderbedient; i++)
                    {
                        _spieler.Add(Ziehen());
                        _spieler.Add(Ziehen());
                    }
                    _sonderbedient = 0;
                }
            }//Liegt eine 8
            else if (_liegtGrade.GetWert() == (Kartenwert)8 && _sonderbedient > 0)
            {
                if (ZugMöglichSonder(_spieler))
                {
                    int eingabe = 99;
                    do
                    {
                        Console.WriteLine("Welche Karte möchtest du spielen?");
                        foreach (Spielkarte karte in _spieler)
                        {
                            Console.Write("    -" + _spieler.IndexOf(karte) + "-    ");
                        }
                        eingabe = Convert.ToInt32(Console.ReadLine());
                    } while (!ValidierungSonder(_liegtGrade, _spieler[eingabe]));//TODO: Wäre hier schön mit einem delegate zu ändern
                    //Ist die karte Valide, kann eine 7 gelegt werden
                    _ablage.Add(_spieler[eingabe]);
                    _liegtGrade = _spieler[eingabe];
                    _spieler.RemoveAt(eingabe);
                    Sonderprüfung();
                }
                else
                {
                    //spieler setzt aus
                }
            }
            else
            {
                if (!ZugMöglich(_spieler))
                {
                    _spieler.Add(Ziehen());
                }
                else
                {
                    //wiederholen bis ok
                    int eingabe = 99;
                    do
                    {
                        Console.WriteLine("Welche Karte möchtest du spielen?");
                        foreach (Spielkarte karte in _spieler)
                        {
                            Console.Write("    -" + _spieler.IndexOf(karte) + "-    ");
                        }
                        eingabe = Convert.ToInt32(Console.ReadLine());
                    } while (!Validierung(_liegtGrade, _spieler[eingabe]));//TODO: Wäre hier schön mit einem delegate zu ändern
                                                                           //Ist die karte Valide
                    _ablage.Add(_spieler[eingabe]);
                    if (_spieler[eingabe].GetWert() == Kartenwert.Bube)
                    {
                        int farbe = 99;
                        do
                        {
                            Console.WriteLine("Welche Farbe soll bedient werden?");
                            Console.WriteLine("Kreuz    Pik    Herz    Karo");
                            Console.WriteLine(" -0-     -1-     -2-     -3-");
                            farbe = Convert.ToInt32(Console.ReadLine());
                        } while (farbe > 3 || farbe < 0);
                        //ändern der zu bedienenden farbe
                        _liegtGrade = new Spielkarte((Kartenfarbe)farbe, _spieler[eingabe].GetWert());
                    }
                    else
                    {
                        _liegtGrade = _spieler[eingabe];
                    }
                    _spieler.RemoveAt(eingabe);
                    Sonderprüfung();
                }
            }

            Anzeige();
            Thread.Sleep(1000);
            if (!SpielEnde())
            {
                Thread.Sleep(3000);
                if (_spieler.Count > 0)
                {
                    Gegnerzug();
                }
            }
            Anzeige();
            Thread.Sleep(1000);
        }
        private void Sonderprüfung()
        {
            if (_liegtGrade.GetWert() == (Kartenwert)7 || _liegtGrade.GetWert() == (Kartenwert)8)
            {
                _sonderbedient++;
            }
        }
        private bool Validierung(Spielkarte a, Spielkarte b)
        {
            if (a != null && b != null)
            {
                if (a.GetWert() == b.GetWert() || a.GetFarbe() == b.GetFarbe())
                {
                    return true;
                }
            }
            return false;
        }
        private bool ValidierungSonder(Spielkarte a, Spielkarte b)
        {
            if (a != null && b != null)
            {
                if (a.GetWert() == b.GetWert())
                {
                    return true;
                }
            }
            return false;
        }

        private void Gegnerzug()
        {
            if (_liegtGrade.GetWert() == (Kartenwert)7 && _sonderbedient > 0)
            {
                Console.WriteLine("gegner muss ziehen oder 7 legen");
                foreach (Spielkarte karte in _gegner)
                {
                    if (ValidierungSonder(karte, _liegtGrade))
                    {
                        Console.WriteLine("Gegner wirft eine 7 dazu");
                        _ablage.Add(karte);
                        _gegner.Remove(karte);
                        _liegtGrade = karte;
                        Sonderprüfung();
                        return;
                    }
                }
                for (int i = 0; i <= _sonderbedient; i++)
                {
                    _gegner.Add(Ziehen());//für jede 7 die zusätzlich auf die ablage gelegt wurde, zwei karten ziehen
                    _gegner.Add(Ziehen());
                }
                _sonderbedient = 0;
                return;

                //TODO falls Regel, nach 2.karte noch zu spielen->Anpassen der logik
            }
            else if (_liegtGrade.GetWert() == (Kartenwert)8 && _sonderbedient > 0)
            {
                Console.WriteLine("Gegner muss 8 legen oder Aussetzen");
                foreach (Spielkarte karte in _gegner)
                {
                    if (ValidierungSonder(karte, _liegtGrade))
                    {
                        Console.WriteLine("Gegner wirft eine 8 dazwischen");
                        _ablage.Add(karte);
                        _gegner.Remove(karte);
                        _liegtGrade = karte;
                        Sonderprüfung();
                        return;
                    }
                }
                _sonderbedient = 0;//bei 8 muss nur einer aussetzen, desshalb wird hier resettet
                return;//Wenn keine 8 zwischengeworfen werden kann, setzt der spieler aus
            }
            else
            //TODO Bube auf Bube geht nicht
            {
                foreach (Spielkarte karte in _gegner)
                {
                    if (Validierung(karte, _liegtGrade))
                    {
                        _ablage.Add(karte);
                        _gegner.Remove(karte);
                        _liegtGrade = karte;
                        Sonderprüfung();
                        if (_liegtGrade.GetWert() == Kartenwert.Bube)//bei CPU random Farbe
                        {
                            Random rnd = new Random();
                            rnd.Next(0, 5);
                            _liegtGrade = new Spielkarte((Kartenfarbe)rnd.Next(0, 4), _liegtGrade.GetWert());//ändern der "Farbe" der liegenden(zu bedienenden Karte)
                            Console.WriteLine("der Gegner hat einen Buben gelegt, es wird die Farbe geändert");
                        }
                        return;
                    }
                }
            }
            _gegner.Add(Ziehen());//einfaches Ziehen
        }

        private bool ZugMöglich(List<Spielkarte> hand)
        {
            foreach (Spielkarte s in hand)
            {
                if (Validierung(s, _liegtGrade)) { return true; }
            }
            return false;
        }
        private bool ZugMöglichSonder(List<Spielkarte> hand)
        {
            foreach (Spielkarte s in hand)
            {
                if (ValidierungSonder(s, _liegtGrade)) { return true; }
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Spielkarte> kartenStapel = Spielkarte.StapelErstellen();
            kartenStapel = Spielkarte.TimMischen(kartenStapel);
            MauMau spiel = new MauMau(kartenStapel);
            while (!spiel.SpielEnde())
            {
                spiel.Eingabe();
            }

        }
    }
}

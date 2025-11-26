namespace AgentenUndBösewichte
{
    public class Maskierter
    {
        public string Deckname { get; set; } = "Unbekannt";
        public string WahreIdentität { get; set; } = "Streng Geheim";
        public void Vorstellen()
        {
            Console.WriteLine($"Ich bin {this.Deckname}");
        }
        public virtual void GeheimeMission()
        {
            Console.WriteLine("Die Mission ist streng geheim!");
        }
        public virtual void EnttarneDich()
        {
            Console.WriteLine($"Meine wahre Identität ist {WahreIdentität}");
        }
    }
    public class Agent : Maskierter
    {
        public new string Deckname { get; set; } = "Schattenläufer";
        public new void Vorstellen()
        {
            Console.WriteLine($"Ich bin {Deckname}");
        }
        public override void GeheimeMission()
        {
            Console.WriteLine("Ich beschaffe geheime Inforamtinen aus dem Untergrund!");
        }
        public override void EnttarneDich()
        {
            Console.WriteLine($"Ich bin ein Agent");
        }
    }
    public class Bösewicht : Maskierter
    {
        public new string Deckname { get; set; } = "Dunkelfürst";
        public new void Vorstellen()
        {
            Console.WriteLine($"Ich bin {Deckname}");
        }
        public override void GeheimeMission()
        {
            Console.WriteLine("Ich plane einen großen Coup und werde die Welt beherrschen!");
        }
        public override void EnttarneDich()
        {
            Console.WriteLine($"Ich bin ein Bösewicht");
        }
    }
    public class DoppelAgent : Agent
    {
        public new string Deckname { get; set; } = "Phantom";
        public new void Vorstellen()
        {
            Console.WriteLine($"Ich bin {Deckname}");
        }
        public sealed override void GeheimeMission()//sealed verhindert das erbende klassen weiter überschreiben können
        {
            Console.WriteLine("Ich spiele ein doppeltes Spiel – niemand kennt meine wahre Loyalität!");
        }
        public override void EnttarneDich()
        {
            Console.WriteLine($"Ich bin ein Doppelagent");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Maskierter mask = new Maskierter();
            Agent agent = new Agent();
            Maskierter m = agent;
            //mask.Vorstellen();
            //agent.Vorstellen();
            //m.Vorstellen();
            //Console.WriteLine(mask.Deckname);
            //Console.WriteLine(agent.Deckname);
            //Console.WriteLine(m.Deckname);
            //mask.GeheimeMission();
            //agent.GeheimeMission();
            //m.GeheimeMission();
            Maskierter unbekannterNr1 = new Bösewicht();
            Maskierter unbekannterNr2 = new DoppelAgent();
            m.EnttarneDich();
            unbekannterNr1.EnttarneDich();
            unbekannterNr2.EnttarneDich();
        }
    }
}

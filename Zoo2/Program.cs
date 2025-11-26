using System.Runtime.CompilerServices;

namespace Zoo2
{
    public class Visitor
    {
        protected int _anzahl = 1;
        public int Anzahl { get { return _anzahl; } }
    }
    public class Group : Visitor
    {
        public Group(int anzahl)
        {
            base._anzahl = anzahl;
        }
    }
    public class Child : Visitor { }
    public class Adult : Visitor { }
    public class Entrance
    {
        private List<Visitor> _visitors = new List<Visitor>();
        private int _count = 0;
        private int _capacity;
        public Entrance(int maxAnzahl)
        {
            _capacity = maxAnzahl;
        }
        public void AddVisitor(Visitor visitor)
        {
            if (_count + visitor.Anzahl > _capacity)
            {
                Console.WriteLine("der Park ist schon voll");
                return;
            }
            _visitors.Add(visitor);
            _count += visitor.Anzahl;
        }
        public decimal GetTurnover()
        {
            decimal n = 0;
            foreach (Visitor visitor in _visitors)
            {
                if (visitor is Adult)
                    n += 15;
                else if(visitor is Group)
                {
                    if(visitor.Anzahl >= 5)
                    {
                        n += 50;
                    }
                    else
                    {
                        n += visitor.Anzahl * 15;
                    }
                }
            }
            return n;
        }
        public int GetVisitors()
        {
            int n = 0;
            foreach (Visitor visitor in _visitors)
            {
                n += visitor.Anzahl;
            }
            return n;
        }
        public List<Visitor> Visitors {  get { return _visitors; }  }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            Entrance eingang = new Entrance(10);
            Child kind1 = new Child();
            Adult erw1 = new Adult();
            Group gruppe1 = new Group(9);
            eingang.AddVisitor(gruppe1);
            eingang.AddVisitor(kind1);
            eingang.AddVisitor(erw1);
            Console.WriteLine(eingang.GetTurnover());
            Child kind2 = visitor as Child;
            if(kind2 == null)
            Console.WriteLine("das objekt ist leer");
            //Group gruppe2 = eingang.Visitors[0] as Group;
            //if (gruppe2 == null)
            //    Console.WriteLine("das objekt ist leer");
            //else
            //{
            //    Console.WriteLine(gruppe2.Anzahl);
            //}

        }
    }
}

namespace Zoo
{
    public class Entrance
    {
        private List<Visitor> _visitors = new List<Visitor>();
        private int _count = 0;
        private int _capacity;
        public Entrance(int maxAnzahl)
        {
            _capacity=maxAnzahl;
        }
        public void AddVisitor(Visitor visitor)
        {
            if(_count+visitor.Anzahl > _capacity)
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
                n += visitor.Eintrittspreis;
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
    }
}

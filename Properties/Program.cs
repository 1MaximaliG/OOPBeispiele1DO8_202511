namespace Properties
{
    public class HaustierNeu
    {
        public string Name { get; set; }
        public string Tierart { get; }
        public int Alter { get; private set; }
        public void altwerden(int n) { Alter+=n; }

    }
    public class Haustier
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private string _tierart;
        public string Tierart
        {
            get { return _tierart; }
        }


        private int _alter;
        public int Alter
        {
            get { return _alter; }
            private set { _alter = value; }
        }

    }
    public class HaustierAlt
    {
        private string _name;
        private string _tierart;
        private int _alter;
        public string GetName() { return _name; }
        public void SetName(string name) { _name = name; }
        public string GetTierart() { return _tierart; }
        public int GetAlter() { return _alter; }
        private void SetAlter(int jahr) { _alter = jahr; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

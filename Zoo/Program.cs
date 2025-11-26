namespace Zoo
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Entrance eingang = new Entrance(10);
            Child kind1 = new Child();
            Adult erw1 = new Adult();
            Group gruppe1 = new Group(9);
            eingang.AddVisitor(gruppe1);
            eingang.AddVisitor(erw1);
            eingang.AddVisitor(kind1);
            Console.WriteLine(eingang.GetTurnover());

        }
    }
}

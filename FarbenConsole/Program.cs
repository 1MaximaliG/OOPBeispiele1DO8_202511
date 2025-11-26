namespace FarbenConsole
{
    public enum FarbeRGB
    {
        Rot ,
        Grün,
        Blau,
        Gelb,
        Weiss
    }

    internal class Program
    {
        public static void DruckeTextInFarbe(string text, FarbeRGB farbe)
        {
            switch ((int)farbe)
            {
                case 0: Console.ForegroundColor = ConsoleColor.Red;break;
                case 1: Console.ForegroundColor = ConsoleColor.Green;break;
                case 2: Console.ForegroundColor = ConsoleColor.Blue;break;
                case 3: Console.ForegroundColor = ConsoleColor.Yellow;break;
                default: Console.ForegroundColor = ConsoleColor.White;break;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            string text = "In einem Loch im Boden, da lebte ein Hobbit. Nicht in einem feuchten, schmutzigen Loch, wo es nach Moder riecht und Wurmzipfel von den Wänden herabhängen, und auch nicht in einer trockenen kahlen Sandgrube ohne Tische und Stühle, wo man sich zum Essen hinsetzen kann: Nein, das Loch war eine Hobbithöhle, und das heißt, es war sehr komfortabel";
            FarbeRGB eingabeFarbe;
            Console.WriteLine("gib eine farbe ein(0-4)");
            try {
                string eingabe = Console.ReadLine();
                eingabeFarbe = (FarbeRGB)Enum.Parse(typeof(FarbeRGB), eingabe, true);
            }
            catch { Console.WriteLine("die farbe gibt es nicht");
                eingabeFarbe = FarbeRGB.Weiss;
            }

            DruckeTextInFarbe(text, eingabeFarbe);
        }
    }
}

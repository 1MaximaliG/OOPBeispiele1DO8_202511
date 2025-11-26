namespace CaseBeispiel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definition
            char auswahl;

            //Prozedur
            Console.WriteLine("Bitte geben Sie eine Option ein (A, B, C oder D) :");
            auswahl = Convert.ToChar(Console.ReadLine().ToUpper());
            switch (auswahl)
            {
                case 'A': 
                    Console.WriteLine("Sie haben Option A ausgewählt."); 
                    break;
                case 'B': 
                    Console.WriteLine("Sie haben Option B ausgewählt."); 
                    break;
                case 'C': 
                    Console.WriteLine("Sie haben Option C ausgewählt."); 
                    break;
                case 'D':
                    Console.WriteLine("Sie haben Option D ausgewählt."); 
                    break;
                default: 
                    Console.WriteLine("Ungültige Option.");
                    break;
            }
            Console.ReadLine();
        }
    }
}

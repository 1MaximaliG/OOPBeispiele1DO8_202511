namespace VierGewinnt
{
    public class Spiellogik
    {
        private int[,] spielfeld = new int[6, 7];
        private int aktuellerSpieler = 1;

        public bool ZugSpielen(int spalte)
        {
            // Finde die unterste freie Zeile in der Spalte
            for (int zeile = 5; zeile >= 0; zeile--)
            {
                if (spielfeld[zeile, spalte] == 0)
                {
                    spielfeld[zeile, spalte] = aktuellerSpieler;
                    return true;
                }
            }
            return false; // Spalte voll
        }

        public int[,] GibSpielfeld() => spielfeld;

        public void NächsterSpieler() => aktuellerSpieler = aktuellerSpieler == 1 ? 2 : 1;
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
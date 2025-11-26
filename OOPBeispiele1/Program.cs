using System.Security.Cryptography.X509Certificates;

namespace OOPBeispiele1
{
    interface IPlayable
    {
        public void Play();
        public void Stop();
    }
    interface ITuneable { public void Tune(); }
    interface IPercussion { public void Hit(); }
    class Instrument { }
    class Guitar : Instrument, IPlayable, ITuneable
    {
        bool _tuned = false;
        bool _playing = false;
        public void Play()
        {
            if (_tuned)
            {
                System.Console.WriteLine("The Guitar is being played");
                _playing = true;
            }
            else
                System.Console.WriteLine("The Guitar isnt tuned!");
        }
        public void Stop()
        {
            if (_playing)
            {
                System.Console.WriteLine("The Guitar is no longer being played");
                _playing = false;
            }
            else
                System.Console.WriteLine("The Guitar is not being played.");
        }
        public void Tune()
        {
            System.Console.WriteLine("The Guitar is being tuned");
            _tuned = true;
        }
    }
    class Piano : Instrument, IPlayable
    {
        bool _playing = false;
        public void Play()
        {
            System.Console.WriteLine("The Piano is being played");
            _playing = true;
        }
        public void Stop()
        {
            if (_playing)
            {
                System.Console.WriteLine("The Piano is no longer being played");
                _playing = false;
            }
            else
                System.Console.WriteLine("The Piano is not being played");
        }
    }
    class Drums : Instrument, IPlayable, IPercussion
    {
        bool _playing = false;
        public void Play()
        {
            System.Console.WriteLine("The Drum is being played");
            _playing = true;
        }
        public void Stop()
        {
            if (_playing)
            {
                System.Console.WriteLine("The Drum is no longer being played");
                _playing = false;
            }
            else
                System.Console.WriteLine("The Drum is not being played");
        }
        public void Hit()
        {
            System.Console.WriteLine("The Drums are being hit!");
        }
    }
    class Band
    {
        List<IPlayable> _instrumentList = [];
        public void AddInstrument(IPlayable i)
        {
            _instrumentList.Add(i);
        }
        public void PlayAll()
        {
            foreach (IPlayable i in _instrumentList)
            {
                i.Play();
            }
        }
        public void StopAll()
        {
            foreach (Instrument i in _instrumentList)
            {
                switch (i)
                {
                    case Guitar guitar:
                        guitar.Stop();
                        break;
                    case Piano piano:
                        piano.Stop();
                        break;
                    case Drums drums:
                        drums.Stop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            //Band band = new();
            //Guitar guitar = new();
            //Piano piano = new();
            //Drums drums = new();
            //band.AddInstrument(guitar);
            //band.AddInstrument(piano);
            //band.AddInstrument(drums);
            //guitar.Tune();
            //band.PlayAll();
            //band.StopAll();
            //drums.Hit();
            //120 bpm => viertelnote = 125ms
            //Console.ReadLine();
            //Console.Beep(880, 125);
            //Console.Beep(988, 125);
            //Console.Beep(1175, 125);
            //Console.Beep(988, 125);//

            //Console.Beep(1480, 375);
            //Console.Beep(1480, 375);
            //Console.Beep(1319, 625);
            //Console.Beep(880, 125);
            //Console.Beep(998, 125);
            //Console.Beep(1175, 125);
            //Console.Beep(988, 125);//

            //Console.Beep(1319, 375);
            //Console.Beep(1319, 375);
            //Console.Beep(1175, 125);
            //Console.Beep(1109, 250);

            //Console.Beep(880, 125);
            //Console.Beep(988, 125);
            //Console.Beep(1175, 125);
            //Console.Beep(988, 125);

            // kleine Hilfsfunktion
            void B(int freq, int dur) => Console.Beep(freq, dur);

            // Rick Astley – Never Gonna Give You Up (Intro + "Never gonna give you up")
            // Notenfrequenzen (vereinfacht):
            int A4 = 440;
            int B4 = 494;
            int C5 = 523;
            int D5 = 587;
            int E5 = 659;
            int G4 = 392;

            Console.WriteLine("Rickroll startet...");

            // Intro-Linie (erkennbar)
            B(B4, 300); B(C5, 300); B(D5, 500);
            Thread.Sleep(100);
            B(D5, 300); B(E5, 300); B(D5, 500);
            Thread.Sleep(150);

            // "Never gonna give you up"
            B(B4, 300); B(D5, 300); B(B4, 300); B(G4, 300);
            B(A4, 500);
            Thread.Sleep(150);

            // "Never gonna let you down"
            B(B4, 300); B(D5, 300); B(B4, 300); B(G4, 300);
            B(E5, 500);
            Thread.Sleep(200);

            Console.WriteLine("Fertig!");


        }
    }
}

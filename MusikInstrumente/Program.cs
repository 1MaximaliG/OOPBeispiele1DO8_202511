using System.Runtime.InteropServices;

namespace MusikInstrumente
{
    internal class Program
    {
        public interface IPlayable
        {
            public void Play();
            public void Stop();
        }
        public interface ITunable
        {

            public void Tune();
        }
        public interface IPercussion
        {
            public void Hit();
        }
        public class Guitar : IPlayable, ITunable
        {
            public bool IsTuned { get; private set; }
            public bool IsPlaying { get; private set; }
            public void Play()
            {
                if (!IsPlaying)
                {

                    if (IsTuned)
                    {
                        Console.WriteLine("Die Gitarre macht Musik");
                        IsPlaying = true;
                    }
                    else
                        Console.WriteLine("Die Gitarre ist nicht gestimmt!");
                }
            }
            public void Stop()
            {
                if (IsPlaying)
                {
                    Console.WriteLine("Die Gitarre hört zu spielen auf");
                    IsTuned = false;
                    IsPlaying = false;
                }
                else
                {
                    Console.WriteLine("Die Gitarre spielt nicht");
                }
            }
            public void Tune()
            {
                IsTuned = true;
                Console.WriteLine("Die Gitarre ist jetzt gestimmt");
            }
        }
        public class Piano : IPlayable
        {
            public bool IsPlaying { get; private set; }
            public void Play()
            {
                if (!IsPlaying)
                {
                    Console.WriteLine("Das Klavier macht Musik");
                }
            }
            public void Stop()
            {
                if (IsPlaying)
                {
                    Console.WriteLine("Das Klavier hört zu spielen auf");
                    IsPlaying = false;
                }
                else
                {
                    Console.WriteLine("Das Klavier spielt nicht");
                }
            }
        }
        public class Drum : IPlayable, IPercussion
        {
            public bool IsPlaying { get; private set; }
            public void Hit()
            {
                if (IsPlaying)
                    Console.WriteLine("Trommel macht bumm 'BUMM'");
            }

            public void Play()
            {
                if (!IsPlaying)
                {
                    IsPlaying = true;
                    Hit();
                    Hit();
                    Hit();
                    Hit();
                }
                else
                {
                    Console.WriteLine("Die Trommel wird schon gespielt");
                }
            }
            public void Stop()
            {
                if (IsPlaying)
                {
                    Hit();
                    IsPlaying = false;
                    Console.WriteLine("Die Trommel hört auf zu spielen");
                }
            }
        }
        public class Band
        {
            private List<IPlayable> _instrumente = new List<IPlayable>();
            public void AddIstrument(IPlayable instrument)
            {
                _instrumente.Add(instrument);
            }
            public void PlayAll()
            {
                foreach (IPlayable ip in _instrumente)
                {
                    ITunable tuneable;
                    if (ip is ITunable)
                    {
                        tuneable = ip as ITunable;
                        if (tuneable != null)
                            tuneable.Tune();
                    }
                }

                foreach (IPlayable ip in _instrumente)
                    ip.Play();
            }
            public void StopAll()
            {
                foreach (IPlayable ip in _instrumente)
                    ip.Stop();
            }
        }
        static void Main(string[] args)
        {
            Band beatles = new Band();
            beatles.AddIstrument(new Guitar());
            beatles.AddIstrument(new Drum());
            beatles.AddIstrument(new Piano());
            beatles.AddIstrument(new Guitar());
            beatles.PlayAll();
            beatles.PlayAll();
            beatles.StopAll();
        }
    }
}

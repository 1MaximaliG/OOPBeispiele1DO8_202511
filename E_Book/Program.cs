namespace E_Book
{
    public class EBook
    {
        private DateOnly _erscheinungsjahr;
        private Autor _autor;
        private List<MediaAsset> _mediaAssets = new List<MediaAsset>();
        public EBook(DateOnly erscheinungsJahr, Autor autor, List<MediaAsset> assets)
        {
            _erscheinungsjahr = erscheinungsJahr;
            _autor = autor;
            _mediaAssets = assets;
        }
        public int AnzahlSeiten()
        {
            double n = 0;
            foreach (MediaAsset asset in _mediaAssets)
            {
                //Variante 1 #####################
                //if (asset is TextAsset)
                //{
                //    //TextAsset t = asset as TextAsset;
                //    //n += t.Seiten();
                //    TextAsset ta= (TextAsset)asset;
                //    n += ta.Seiten();
                //}
                //else if (asset is BildAsset)
                //{
                //    n += ((BildAsset)asset).SeitenAnzahl();
                //}
                //else if (asset is VideoAsset)
                //{
                //    n += ((VideoAsset)asset).SeitenAnzahl();
                //}
                //###########################
                switch (asset)
                {
                    case TextAsset text:
                        n += text.Seiten();
                        break;
                    case BildAsset bild:
                        n += bild.SeitenAnzahl();
                        break;
                    case VideoAsset video:
                        n += video.SeitenAnzahl();
                        break;
                    default: break;
                }
            }
            return (int)Math.Ceiling(n);
        }
    }
    public class Autor
    {
        private string _name;
        private DateTime _geburtsdatum;
        private List<EBook> _bibliographie = new List<EBook>();
        public string Name { get { return _name; } }
    }
    public enum Sprache
    {
        Deutsch,
        Englisch,
        Klingonisch,
        Quenya,
        Sindarin,
        Khuzdul,
        Garethi,
        Polnisch
    }
    public class MediaAsset
    {
        protected string _name;
        protected int _größeByte;
        protected Sprache _sprache;
    }
    public class TextAsset : MediaAsset
    {
        private double _zeichen;
        public TextAsset(string text)
        {
            _zeichen = text.Length;
        }
        public int Seiten()
        {
            //return (_zeichen+1999)/2000;
            return (int)Math.Ceiling(_zeichen / 2000);
        }
    }
    public class BildAsset : MediaAsset
    {
        private int _pixelHöhe;
        private int _pixelBreite;
        public BildAsset(int höhe, int breite)
        {
            _pixelBreite = breite;
            _pixelHöhe = höhe;
        }
        private int SkalierteBreite()
        {
            return _pixelBreite * (960 / _pixelBreite);
        }
        private int SkalierteHöhe()
        {
            return _pixelHöhe * (960 / _pixelBreite);
        }
        public double SeitenAnzahl()
        {
            if (SkalierteHöhe() > 600)
            {
                return 1;
            }
            return 0.5;
        }
    }
    public class VideoAsset : MediaAsset
    {
        private int _pixelHöhe;
        private int _pixelBreite;
        private int _spieldauerSek;
        public VideoAsset(int höhe, int breite, int sekunden)
        {
            _pixelBreite = breite;
            _pixelHöhe = höhe;
            _spieldauerSek = sekunden;
        }
        private int SkalierteBreite()
        {
            return _pixelBreite * (960 / _pixelBreite);
        }
        private int SkalierteHöhe()
        {
            return _pixelHöhe * (960 / _pixelBreite);
        }
        public double SeitenAnzahl()
        {
            if (SkalierteHöhe() > 600)
            {
                return 1;
            }
            return 0.5;
        }
    }
    public class AudioAsset : MediaAsset
    {
        private int _spieldauerSek;
        public AudioAsset(int spieldauerInSekunden)
        {
            _spieldauerSek = spieldauerInSekunden;
        }
    }
    internal class Program
    {  
        static void Main(string[] args)
        {
          
        }
    }
}


using System.Text;

namespace Warenkorb2
{
    public abstract class Article
    {
        public Article(decimal preis)
        {
            s_artikelcounter += 1;
            _articleNumber = s_artikelcounter;
            _price = preis;
        }
        private static int s_artikelcounter;
        protected int _articleNumber;
        protected decimal _price;
        public abstract decimal GetPrice();
        public virtual void GetInfo()
        {
            Console.WriteLine($"Artikel: {_articleNumber}");
            Console.WriteLine($"Preis: {_price} bzw {GetPrice():C}");
        }
    }
    public class Buch : Article
    {
        public Buch(decimal preis, string autor, string title, int jahr) : base(preis)
        {
            _autor = autor;
            _titel = title;
            _erscheinungsjahr = jahr;
        }
        private string _autor;
        private string _titel;
        private int _erscheinungsjahr;
        public override decimal GetPrice() { return _price * 1.07m; }
        public override void GetInfo()
        {
            Console.WriteLine("Autor: "+ _autor);
            Console.WriteLine("Titel: "+ _titel);
            Console.WriteLine("Erscheinugsjahr: "+ _erscheinungsjahr);
            base.GetInfo();
        }
    }
    public class DVD : Article
    {
        public DVD(decimal preis, string titel, int dauer, string ländercode) : base(preis)
        {
            _filmtitel = titel;
            _dauer = dauer;
            _DVDLändercode = ländercode;
        }
        private string _filmtitel;
        private int _dauer;
        private string _DVDLändercode;
        public override decimal GetPrice() { return _price * 1.19m; }
    }
    public class Warenkorb
    {
        private List<Article> _article = new List<Article>();

        public void Add(Article artikel)
        {
            _article.Add(artikel);
        }
        public decimal GetGesamtPreis()
        {
            decimal geld = 0;
            foreach (Article artikel in _article)
            {
                geld += artikel.GetPrice();
            }
            return geld;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;//um € anzuzeigen
            Article art = new Buch(12.99m, "JRR Tolkien", "Silmarillion", 1977);
            art.GetInfo();
            Warenkorb wk1 = new Warenkorb();
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            wk1.Add(art);
            Console.WriteLine(wk1.GetGesamtPreis());
        }
    }
}

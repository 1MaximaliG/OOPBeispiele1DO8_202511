namespace Fernseher
{
    public class TV
    {
        private bool _switchedOn = false;
        private int _volume = 0;
        private int _channel = 0;
        private string[] _channels = ["ARD", "ZDF", "WDR"];

        public bool IsON() { return _switchedOn; }
        public void RaiseVolume()
        {
            if (IsON() && _volume < 100)
            {
                _volume++;
            }
        }
        public void LowerVolume()
        {
            if (IsON() && _volume > 0)
            {
                _volume--;
            }
        }
        public void TurnOn()
        {
            _switchedOn = true;
            Console.WriteLine("Der Fernseher ist jetzt an!");
        }
        public void TurnOff()
        {
            _switchedOn = false;
            Console.WriteLine("Der Fernseher ist jetzt aus!");
        }
        public void GetInfo()
        {
            Console.Write("Fernseher");
            if (IsON())
            {
                Console.Write(" ON,");
                Console.Write($" Sender: {_channels[_channel]}");
                Console.WriteLine(" Lautstärke {0}", _volume);
            }
            else
            {
                Console.Write(" OFF!");
            }
        }
        public void ChannelVor()
        {
            if (_channel < _channels.Length - 1)
            {
                _channel++;
            }
        }
        public void ChannelZurück()
        {
            if (_channel > 0)
            {
                _channel--;
            }
        }
        public void SenderHinzufügen(string neuerSender)
        {
            //string[] SenderListe = [.._channels,neuerSender];
            string[] SenderListe = new string[_channels.Length + 1];
            for (int i = 0; i < _channels.Length; i++)
            {
                SenderListe[i] = _channels[i];
            }
            SenderListe[SenderListe.Length - 1] = neuerSender;
            _channels = SenderListe;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TV sony = new TV();
            sony.GetInfo();
            sony.TurnOff();
            sony.TurnOn();
            sony.ChannelVor();
            sony.ChannelVor();
            sony.ChannelVor();
            sony.ChannelVor();
            sony.GetInfo();
            sony.RaiseVolume();
            for (int i = 0; i < 200; i++)
            {
               sony.RaiseVolume();
            }
            sony.GetInfo();
            for (int i = 0; i < 200; i++)
            {
                sony.LowerVolume();
            }
            sony.SenderHinzufügen("Pro7");
            sony.ChannelVor();
            sony.GetInfo();
            sony.TurnOff();
            sony.GetInfo();

        }
    }
}

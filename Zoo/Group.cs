namespace Zoo
{
    public class Group : Visitor
    {
        public Group(int anzahl)
        {
            base._anzahl = anzahl;
            base._eintrittspreis = anzahl * 15;
            if(_eintrittspreis > 50) { _eintrittspreis = 50;}
        }
    }
}

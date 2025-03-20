
namespace DurakGame
{
    enum Mast
    {
        Пики, Крести, Бубни, Черви
    }
    enum Number
    {
        Шесть, Семь, Восемь, Девять, Десять, Валет, Дама, Король, Туз
    }

    class Card
    {
        private Mast Mast;
        private Number number;
        private int size;
        private bool isTrump;

        public Mast CardMast
        {
            get { return Mast; }
        }

        public Number Number
        {
            get { return number; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public bool IsTrump
        {
            get { return isTrump; }
            set {  isTrump = value; }
        }

        public Card(Number number, Mast Mast)
        {
            this.Mast = Mast;
            this.number = number;
            size = Size;
        }

        public string ShowCard()
        {
            return number.ToString() + " " + Mast.ToString();
        }
    }
}

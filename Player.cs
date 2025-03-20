
namespace DurakGame
{
    class Player
    {
        private int id;
        public string name = "";
        public int cardCount;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public int CardCount
        {
            get { return cardCount; }
        }

        public Player(int id, string name, int cardCount)
        {
            this.id = id;
            this.name = name;
            this.cardCount = cardCount;
        }
    }
}

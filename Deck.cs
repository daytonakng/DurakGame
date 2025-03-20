
namespace DurakGame
{
    class Deck
    {
        static Random randomTrump = new Random();
        private Card[] cardDeck = new Card[36];
        public Mast trump;

        public Deck()
        {
            for (Mast mast = Mast.Пики; mast <= Mast.Черви; mast++)
            {
                for (Number number = Number.Шесть; number <= Number.Туз; number++)
                {
                    cardDeck[((int)mast) * 9 + (int)number] = new Card(number, mast);
                }
            }

            foreach (Card card in cardDeck)
            {
                if (card.CardMast == trump) { card.IsTrump = true; }

                if (card.Number == Number.Шесть) { card.Size = 6; }
                if (card.Number == Number.Семь) { card.Size = 7; }
                if (card.Number == Number.Восемь) { card.Size = 8; }
                if (card.Number == Number.Девять) { card.Size = 9; }
                if (card.Number == Number.Десять) { card.Size = 10; }
                if (card.Number == Number.Валет) { card.Size = 11; }
                if (card.Number == Number.Дама) { card.Size = 12; }
                if (card.Number == Number.Король) { card.Size = 13; }
                if (card.Number == Number.Туз) { card.Size = 14; }
            }
        }
        public void Shuffle()
        {
            Random.Shared.Shuffle(cardDeck);
            trump = cardDeck[cardDeck.Length - 1].CardMast;
        }
        public Card[] GiveCards
        {
            get { return cardDeck; }
        }
    }
}

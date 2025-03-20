
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DurakGame
{
    internal class Game
    {
        public Deck cardDeck = new Deck();

        public List<Card> gameDeck = new List<Card>();
        public List<Card> leaveCards = new List<Card>();

        public List<Card> firstPlayerHand = new List<Card>();
        public List<Card> secondPlayerHand = new List<Card>();

        public List<Card> comparableCards = new List<Card>();

        public int gameDeckCount;

        public void GetCards()
        {
            cardDeck.Shuffle();

            for (int i = 0; i < 36; i++)
            {
                gameDeck.Add(cardDeck.GiveCards[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                firstPlayerHand.Add(cardDeck.GiveCards[i]);
                secondPlayerHand.Add(cardDeck.GiveCards[i + 6]);
            }
        }

        public void ShowLeaveCards()
        {
            string lc = "";

            foreach (var item in leaveCards)
            {
                lc += item.ShowCard() + " ";
            }
            int leaveCardsCount = leaveCards.Count;

            MessageBox.Show($"Карты в бито ({leaveCardsCount}):\n{lc}");
        }

        public void ShowDeck()
        {
            string cd = "";

            foreach (var item in gameDeck)
            {
                cd += item.ShowCard() + " ";
            }
            gameDeckCount = gameDeck.Count;

            MessageBox.Show($"Карты в колоде ({gameDeckCount}):\n{cd}");
        }

        public void ShowCards()
        {
            string cd1 = "";
            string cd2 = "";
            string cd = "";

            string trmp = "";

            foreach (Card item in firstPlayerHand)
            {
                cd1 += item.ShowCard() + " ";
            }
            foreach (var item in secondPlayerHand)
            {
                cd2 += item.ShowCard() + " ";
            }
            foreach (var item in gameDeck)
            {
                cd += item.ShowCard() + " ";
            }

            int cd1Count = firstPlayerHand.Count;
            int cd2Count = secondPlayerHand.Count;
            gameDeckCount = gameDeck.Count;
            trmp = cardDeck.trump.ToString();

            MessageBox.Show($"Козырь: {trmp}\n\nКолода Игрока 1 ({cd1Count}):\n{cd1}\n\nКолода Игрока 2 ({cd2Count}):\n{cd2}\n\nОставшиеся в колоде карты после раздачи ({gameDeckCount}):\n{cd}");
        }

        public bool CheckCard(Card card1, Card card2)
        {
            bool card1Trump = card1.CardMast == cardDeck.trump;
            bool card2Trump = card2.CardMast == cardDeck.trump;

            if (card1Trump && card2Trump)
            {
                if (card2.Size > card1.Size) { return true; }
                else { return false; }
            }
            else if ((!card2Trump && !card1Trump))
            {
                if (card2.CardMast == card1.CardMast && card2.Size > card1.Size) { return true; }
                else { return false; }
            }
            else if (!card1Trump && card2Trump) { return true; }
            else { return false; }
        }
    }
}

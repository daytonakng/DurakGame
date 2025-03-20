using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DurakGame
{
    public partial class GameTable : Page
    {
        Game a = new Game();

        List<Image> cardsInGame = new List<Image>();

        Random randomPlayer = new Random();

        List<Image> firstHandImages = new List<Image>();
        List<Image> secondHandImages = new List<Image>();

        List<int> playedCardPlayer1Ind = new List<int>();
        List<int> playedCardPlayer2Ind = new List<int>();

        public int defaultRowFirstPlayer;
        public int defaultColumnFirstPlayer;

        public int defaultRowSecondPlayer;
        public int defaultColumnSecondPlayer;

        public bool isTaken = false;

        public GameTable()
        {
            InitializeComponent();
            AddImagesToLists();

            gameAreaGrid.Visibility = Visibility.Hidden;
            durakLogoImage.Visibility = Visibility.Visible;
            takeButtonBorder.Visibility = Visibility.Hidden;
            leaveCardsGroupBox.Visibility = Visibility.Hidden;
            trumpGroupBox.Visibility = Visibility.Hidden;
            deckGroupBox.Visibility = Visibility.Hidden;
        }

        private void AddImagesToLists()
        {
            firstHandImages.Add(card0Player1Image);
            firstHandImages.Add(card1Player1Image);
            firstHandImages.Add(card2Player1Image);
            firstHandImages.Add(card3Player1Image);
            firstHandImages.Add(card4Player1Image);
            firstHandImages.Add(card5Player1Image);

            secondHandImages.Add(card0Player2Image);
            secondHandImages.Add(card1Player2Image);
            secondHandImages.Add(card2Player2Image);
            secondHandImages.Add(card3Player2Image);
            secondHandImages.Add(card4Player2Image);
            secondHandImages.Add(card5Player2Image);
        }

        private void ShowTrumpImage()
        {
            Image trumpImg = (Image)FindName("trumpImage");

            if (a.cardDeck.trump == Mast.Пики)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-spade.png", UriKind.Relative));
            }
            else if (a.cardDeck.trump == Mast.Крести)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-club.png", UriKind.Relative));
            }
            else if (a.cardDeck.trump == Mast.Бубни)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-diamond.png", UriKind.Relative));
            }
            else if (a.cardDeck.trump == Mast.Черви)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-heart.png", UriKind.Relative));
            }
        }

        private void SetTrumpImage()
        {
            int x = (int)a.gameDeck.Last().Number;
            int y = (int)a.gameDeck.Last().CardMast;

            trumpCardImage.Source = BitmapFrame.Create(new Uri("img/cards/" + x.ToString() + y.ToString() + ".png", UriKind.Relative));
        }

        private void SetCardImage(List<Card> deck, List<Image> Images, int i, int j)
        {
            int a = (int)deck[i].CardMast;
            int b = (int)deck[i].Number;
            Image item = Images[j];

            item.Source = BitmapFrame.Create(new Uri("img/cards/" + b.ToString() + a.ToString() + ".png", UriKind.Relative));
        }

        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            logTextBox.Text = "Игра началась!";

            gameAreaGrid.Visibility = Visibility.Visible;
            durakLogoImage.Visibility = Visibility.Hidden;
            gameDeckImage.Visibility = Visibility.Visible;
            startButtonBorder.Visibility = Visibility.Hidden;
            leaveCardsGroupBox.Visibility = Visibility.Visible;
            trumpGroupBox.Visibility = Visibility.Visible;
            trumpCardImage.Visibility = Visibility.Visible;
            deckGroupBox.Visibility = Visibility.Visible;

            await Task.Delay(TimeSpan.FromSeconds(3));

            int playerTime = randomPlayer.Next(1, 3);

            if (playerTime == 1)
            {
                foreach (Image cardImage in secondHandImages)
                {
                    cardImage.IsEnabled = false;
                }
                logTextBox.Text = "Игра началась!\n\nОжидание хода Игрока 1...";
            }
            else
            {
                foreach (Image cardImage in firstHandImages)
                {
                    cardImage.IsEnabled = false;
                }
                logTextBox.Text = "Игра началась!\n\nОжидание хода Игрока 2...";
            }

            a.GetCards();

            for (int i = 0; i < 6; i++)
            {
                SetCardImage(a.gameDeck, firstHandImages, i, i);
                SetCardImage(a.gameDeck, secondHandImages, i + 6, i);
            }

            a.gameDeck.RemoveAll(card => a.firstPlayerHand.Contains(card));
            a.gameDeck.RemoveAll(card => a.secondPlayerHand.Contains(card));
            SetTrumpImage();
            ShowTrumpImage();

            gameDeckCount.Text = a.gameDeck.Count.ToString();
        }

        Dictionary<int, int> takeCardIndex = new Dictionary<int, int>
        {
            {6, 1},
            {7, 2},
            {8, 3},
            {9, 4},
            {10, 5},
            {11, 6},
            {12, 1},
            {13, 2},
            {14, 3},
            {15, 4},
            {16, 5},
            {17, 6},
            {18, 1},
            {19, 2},
            {20, 3},
            {21, 4},
            {22, 5},
            {23, 6},
            {24, 1},
            {25, 2},
            {26, 3},
            {27, 4},
            {28, 5},
            {29, 6},
            {30, 1},
        };

        private void takeButton_Click(object sender, RoutedEventArgs e)
        {
            bool player1Attacked = true;

            isTaken = true;

            if (a.secondPlayerHand.Contains(a.comparableCards[0]))
            {
                player1Attacked = false;
            }

            if (player1Attacked)
            {
                Image image = cardsInGame[0];
                Card card = a.comparableCards[0];

                logTextBox.Text = $"Игрок 2 взял карту {card.ShowCard()}\n\nОжидание хода Игрока 1...";

                a.secondPlayerHand.Add(card);
                secondHandImages.Add(image);
                firstHandImages.Remove(image);
                a.comparableCards.Clear();

                image.IsEnabled = true;

                int cardsCount = secondHandImages.Count;

                int newImageInd = secondHandImages.IndexOf(image);
                int columnPosition = takeCardIndex[newImageInd];

                Grid.SetRow(image, 1);
                Grid.SetColumn(image, columnPosition);

                for (int i = 6; i < cardsCount; i++)
                {
                    secondHandImages[i].Visibility = Visibility.Hidden;
                }

                cardsInGame.RemoveAt(0);

                nextSecondHandButtonBorder.Visibility = Visibility.Visible;

                foreach (Image cardImage in firstHandImages)
                {
                    cardImage.IsEnabled = true;
                }

                foreach (Image cardImage in secondHandImages)
                {
                    cardImage.IsEnabled = false;
                }

                takeButtonBorder.Visibility = Visibility.Hidden;
            }
            
        }

        private async void playCard(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            takeButtonBorder.Visibility = Visibility.Visible;

            Image image = (Image)sender;
            bool player1 = true;
            int ind = firstHandImages.IndexOf(image);

            if (ind == -1)
            {
                ind = secondHandImages.IndexOf(image);
                player1 = false;
            }

            if (cardsInGame.Count == 0)
            {
                if (player1)
                {
                    foreach (Image cardImage in firstHandImages)
                    {
                        cardImage.IsEnabled = false;
                    }

                    cardsInGame.Add(image);
                    a.comparableCards.Add(a.firstPlayerHand[ind]);
                    playedCardPlayer1Ind.Add(ind);

                    defaultRowFirstPlayer = Grid.GetRow(image);
                    defaultColumnFirstPlayer = Grid.GetColumn(image);

                    Grid.SetRow(image, 4);
                    Grid.SetColumn(image, 3);

                    logTextBox.Text = ($"Игрок 1 атакует картой {a.comparableCards[0].ShowCard()}\n\nОжидание действия Игрока 2...");

                    foreach (Image cardImage in secondHandImages)
                    {
                        cardImage.IsEnabled = true;
                    }
                }
                else
                {
                    foreach (Image cardImage in secondHandImages)
                    {
                        cardImage.IsEnabled = false;
                    }

                    cardsInGame.Add(image);
                    a.comparableCards.Add(a.secondPlayerHand[ind]);
                    playedCardPlayer2Ind.Add(ind);

                    defaultRowSecondPlayer = Grid.GetRow(image);
                    defaultColumnSecondPlayer = Grid.GetColumn(image);

                    Grid.SetRow(image, 3);
                    Grid.SetColumn(image, 4);
                    logTextBox.Text = ($"Игрок 2 атакует картой {a.comparableCards[0].ShowCard()}\n\nОжидание действия Игрока 1...");

                    foreach (Image cardImage in firstHandImages)
                    {
                        cardImage.IsEnabled = true;
                    }
                }
            }

            else if (cardsInGame.Count == 1)
            {
                bool cardAccesed = false;

                if (player1)
                {
                    a.comparableCards.Add(a.firstPlayerHand[ind]);
                    cardAccesed = a.CheckCard(a.comparableCards[0], a.comparableCards[1]) == true;
                }
                else
                {
                    a.comparableCards.Add(a.secondPlayerHand[ind]);
                    cardAccesed = a.CheckCard(a.comparableCards[0], a.comparableCards[1]) == true;
                }

                if (cardAccesed)
                {
                    cardsInGame.Add(image);

                    if (player1)
                    {
                        logTextBox.Text = ($"Игрок 1 успешно защитился!\nКарта {a.comparableCards[1].ShowCard()} побила карту {a.comparableCards[0].ShowCard()}\n\nОжидание хода Игрока 1...");

                        playedCardPlayer1Ind.Add(ind);

                        defaultRowFirstPlayer = Grid.GetRow(image);
                        defaultColumnFirstPlayer = Grid.GetColumn(image);

                        Grid.SetRow(image, 4);
                        Grid.SetColumn(image, 3);
                        await Task.Delay(TimeSpan.FromSeconds(3));

                        a.firstPlayerHand.Remove(a.comparableCards[1]);
                        a.secondPlayerHand.Remove(a.comparableCards[0]);

                        Grid.SetRow(cardsInGame[1], defaultRowFirstPlayer);
                        Grid.SetColumn(cardsInGame[1], defaultColumnFirstPlayer);

                        Grid.SetRow(cardsInGame[0], defaultRowSecondPlayer);
                        Grid.SetColumn(cardsInGame[0], defaultColumnSecondPlayer);

                        foreach (Image cardImage in firstHandImages)
                        {
                            cardImage.IsEnabled = true;
                        }
                    }
                    else
                    {
                        logTextBox.Text = ($"Игрок 2 успешно защитился!\nКарта {a.comparableCards[1].ShowCard()} побила карту {a.comparableCards[0].ShowCard()}\n\nОжидание хода Игрока 2...");

                        playedCardPlayer2Ind.Add(ind);

                        defaultRowSecondPlayer = Grid.GetRow(image);
                        defaultColumnSecondPlayer = Grid.GetColumn(image);

                        Grid.SetRow(image, 3);
                        Grid.SetColumn(image, 4);
                        await Task.Delay(TimeSpan.FromSeconds(3));

                        a.firstPlayerHand.Remove(a.comparableCards[0]);
                        a.secondPlayerHand.Remove(a.comparableCards[1]);

                        Grid.SetRow(cardsInGame[0], defaultRowFirstPlayer);
                        Grid.SetColumn(cardsInGame[0], defaultColumnFirstPlayer);

                        Grid.SetRow(cardsInGame[1], defaultRowSecondPlayer);
                        Grid.SetColumn(cardsInGame[1], defaultColumnSecondPlayer);

                        foreach (Image cardImage in firstHandImages)
                        {
                            cardImage.IsEnabled = false;
                        }
                    }

                    foreach (var item in a.comparableCards) { a.leaveCards.Add(item); }

                    if (a.gameDeck.Count > 0)
                    {
                        foreach (int index in playedCardPlayer1Ind)
                        {
                            a.firstPlayerHand.Insert(index, a.gameDeck.First());
                            SetCardImage(a.gameDeck, firstHandImages, 0, index);
                            a.gameDeck.RemoveAt(0);
                        }

                        foreach (int index in playedCardPlayer2Ind)
                        {
                            a.secondPlayerHand.Insert(index, a.gameDeck.First());
                            SetCardImage(a.gameDeck, secondHandImages, 0, index);
                            a.gameDeck.RemoveAt(0);
                        }
                    }
                    else
                    {
                        foreach (Image card in cardsInGame) { card.Visibility = Visibility.Hidden; }
                        firstHandImages.RemoveAll(image => cardsInGame.Contains(image));
                        secondHandImages.RemoveAll(image => cardsInGame.Contains(image));

                        trumpCardImage.Visibility = Visibility.Hidden;
                        gameDeckImage.Visibility = Visibility.Hidden;
                    }

                    a.comparableCards.Clear();
                    cardsInGame.Clear();

                    playedCardPlayer1Ind.Clear();
                    playedCardPlayer2Ind.Clear();

                    takeButtonBorder.Visibility = Visibility.Hidden;

                    leaveCardsCount.Text = a.leaveCards.Count.ToString();
                    gameDeckCount.Text = a.gameDeck.Count.ToString();
                    leaveCardsImage.Visibility = Visibility.Visible;
                }
                else
                {
                    a.comparableCards.RemoveAt(1);
                    if (a.secondPlayerHand.Count == 0 && a.firstPlayerHand.Count == 1) { logTextBox.Text = "Победу одержал Игрок 2!\n\nСпасибо участникам за игру!"; }
                    else if (a.secondPlayerHand.Count == 1 && a.firstPlayerHand.Count == 0) { logTextBox.Text = "Победу одержал Игрок 1!\n\nСпасибо участникам за игру!"; }
                }
            }
            if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count > 1) { logTextBox.Text = "Победу одержал Игрок 1!\n\nСпасибо участникам за игру!"; }
            else if (a.secondPlayerHand.Count == 0 && a.firstPlayerHand.Count > 1) { logTextBox.Text = "Победу одержал Игрок 2!\n\nСпасибо участникам за игру!"; }
            else if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count == 0) { logTextBox.Text = "Ничья!\n\nСпасибо участникам за игру!"; }
        }

        private void deckGroupBox_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            a.ShowDeck();
        }

        private void leaveCardsCount_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            a.ShowLeaveCards();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AutoScrolltoEnd (object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToEnd();
        }

        private void nextSecondHandButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 6;  i++)
            {
                secondHandImages[i].Visibility = Visibility.Hidden;
            }

            for (int i = 6; i < secondHandImages.Count; i++)
            {
                secondHandImages[i].Visibility = Visibility.Visible;
            }

            nextSecondHandButtonBorder.Visibility = Visibility.Hidden;
            prevSecondHandButtonBorder.Visibility = Visibility.Visible;
        }

        private void prevSecondHandButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 6; i < secondHandImages.Count; i++)
            {
                secondHandImages[i].Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < 6; i++)
            {
                secondHandImages[i].Visibility = Visibility.Visible;
            }

            prevSecondHandButtonBorder.Visibility = Visibility.Hidden;
            nextSecondHandButtonBorder.Visibility = Visibility.Visible;
        }
    }
}

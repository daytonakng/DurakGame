using System;
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

        public int pageFirstPlayer = 0;
        public int pageSecondPlayer = 0;

        private MediaPlayer music = new MediaPlayer();


        public GameTable()
        {
            InitializeComponent();
            AddImagesToLists();
            StartPage();
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            AddImagesToLists();
            StartPage();
        }

        private void StartPage()
        {
            gameAreaGrid.Visibility = Visibility.Hidden;
            durakLogoImage.Visibility = Visibility.Visible;
            takeButton.Visibility = Visibility.Hidden;
            leaveCardsGroupBox.Visibility = Visibility.Hidden;
            trumpGroupBox.Visibility = Visibility.Hidden;
            deckGroupBox.Visibility = Visibility.Hidden;

            secondPlayerText.Visibility = Visibility.Hidden;
            firstPlayerText.Visibility = Visibility.Hidden;

            hideFirstCardsBorder.Visibility = Visibility.Hidden;
            hideSecondCardsBorder.Visibility = Visibility.Hidden;
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
            if (a.cardDeck.trump == Mast.Крести)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-club.png", UriKind.Relative));
            }
            if (a.cardDeck.trump == Mast.Бубни)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-diamond.png", UriKind.Relative));
            }
            if (a.cardDeck.trump == Mast.Черви)
            {
                trumpImg.Source = new BitmapImage(new Uri("img/cards/suit-heart.png", UriKind.Relative));
            }
        }

        private void ShowGameUI()
        {
            gameAreaGrid.Visibility = Visibility.Visible;
            gameAreaGrid.IsEnabled = false;
            durakLogoImage.Visibility = Visibility.Hidden;
            gameDeckImage.Visibility = Visibility.Visible;
            startButton.Visibility = Visibility.Hidden;
            leaveCardsGroupBox.Visibility = Visibility.Visible;
            trumpGroupBox.Visibility = Visibility.Visible;
            trumpCardImage.Visibility = Visibility.Visible;
            deckGroupBox.Visibility = Visibility.Visible;

            secondPlayerText.Visibility = Visibility.Visible;
            firstPlayerText.Visibility = Visibility.Visible;
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

            ShowGameUI();

            await Task.Delay(TimeSpan.FromSeconds(3));

            int playerTime = randomPlayer.Next(1, 3);

            gameAreaGrid.IsEnabled = true;

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
            firstPlayerHandCount.Text = a.firstPlayerHand.Count.ToString();
            secondPlayerHandCount.Text = a.secondPlayerHand.Count.ToString();
        }

        private void HideGameUI()
        {
            gameAreaGrid.Visibility = Visibility.Hidden;
            durakLogoImage.Visibility = Visibility.Visible;
            durakLogoImage.Margin = new Thickness(300, 0, 0, 0);
            takeButton.Visibility = Visibility.Hidden;
            leaveCardsGroupBox.Visibility = Visibility.Hidden;
            trumpGroupBox.Visibility = Visibility.Hidden;
            deckGroupBox.Visibility = Visibility.Hidden;
        }

        private void takeButton_Click(object sender, RoutedEventArgs e)
        {
            if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count > 1)
            {
                logTextBox.Text = "Победу одержал Игрок 1!\n\nСпасибо участникам за игру!";
                HideGameUI();
                startButton.MouseLeftButtonUp += restartButton_Click;
                startButton.Visibility = Visibility.Visible;
                return;
            }
            else if (a.secondPlayerHand.Count == 0 && a.firstPlayerHand.Count > 1)
            {
                logTextBox.Text = "Победу одержал Игрок 2!\n\nСпасибо участникам за игру!";
                HideGameUI();
                startButton.MouseLeftButtonUp += restartButton_Click;
                startButton.Visibility = Visibility.Visible;
                return;
            }
            else if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count == 0)
            {
                logTextBox.Text = "Ничья!\n\nСпасибо участникам за игру!";
                HideGameUI();
                return;
            }
            else
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

                    Grid.SetRow(image, defaultRowFirstPlayer);
                    Grid.SetColumn(image, defaultColumnFirstPlayer);

                    a.secondPlayerHand.Add(card);
                    a.comparableCards.Clear();

                    for (int i = firstHandImages.IndexOf(image); i < a.firstPlayerHand.Count - 1; i++)
                    {
                        firstHandImages[i].Source = firstHandImages[i + 1].Source;
                    }
                    firstHandImages[a.firstPlayerHand.Count - 1].Visibility = Visibility.Hidden;
                    a.firstPlayerHand.Remove(card);

                    image.IsEnabled = true;

                    cardsInGame.RemoveAt(0);

                    ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);
                    int topdeckCount = 6 - a.firstPlayerHand.Count;
                    if (a.gameDeck.Count > 0)
                    {
                        for (int i = 0; i < topdeckCount; i++)
                        {
                            a.firstPlayerHand.Add(a.gameDeck.First());
                            SetCardImage(a.gameDeck, firstHandImages, 0, a.firstPlayerHand.Count - 1);
                            firstHandImages[a.firstPlayerHand.Count - 1].Visibility = Visibility.Visible;
                            a.gameDeck.RemoveAt(0);
                        }
                    }

                    foreach (Image cardImage in firstHandImages)
                    {
                        cardImage.IsEnabled = true;
                    }

                    foreach (Image cardImage in secondHandImages)
                    {
                        cardImage.IsEnabled = false;
                    }

                    takeButton.Visibility = Visibility.Hidden;
                }
                else if (!player1Attacked)
                {
                    Image image = cardsInGame[0];
                    Card card = a.comparableCards[0];

                    logTextBox.Text = $"Игрок 1 взял карту {card.ShowCard()}\n\nОжидание хода Игрока 2...";

                    Grid.SetRow(image, defaultRowSecondPlayer);
                    Grid.SetColumn(image, defaultColumnSecondPlayer);

                    a.firstPlayerHand.Add(card);
                    a.comparableCards.Clear();

                    for (int i = secondHandImages.IndexOf(image); i < a.secondPlayerHand.Count - 1; i++)
                    {
                        secondHandImages[i].Source = secondHandImages[i + 1].Source;
                    }
                    secondHandImages[a.secondPlayerHand.Count - 1].Visibility = Visibility.Hidden;
                    a.secondPlayerHand.Remove(card);

                    image.IsEnabled = true;

                    cardsInGame.RemoveAt(0);

                    ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
                    int topdeckCount = 6 - a.secondPlayerHand.Count;
                    if (a.gameDeck.Count > 0)
                    {
                        for (int i = 0; i < topdeckCount; i++)
                        {
                            a.secondPlayerHand.Add(a.gameDeck.First());
                            SetCardImage(a.gameDeck, secondHandImages, 0, a.secondPlayerHand.Count - 1);
                            secondHandImages[a.secondPlayerHand.Count - 1].Visibility = Visibility.Visible;
                            a.gameDeck.RemoveAt(0);
                        }
                    }

                    foreach (Image cardImage in firstHandImages)
                    {
                        cardImage.IsEnabled = false;
                    }

                    foreach (Image cardImage in secondHandImages)
                    {
                        cardImage.IsEnabled = true;
                    }

                    takeButton.Visibility = Visibility.Hidden;
                }
                gameDeckCount.Text = a.gameDeck.Count.ToString();
                firstPlayerHandCount.Text = a.firstPlayerHand.Count.ToString();
                secondPlayerHandCount.Text = a.secondPlayerHand.Count.ToString();
                if (a.gameDeck.Count == 0)
                {
                    trumpCardImage.Visibility = Visibility.Hidden;
                }
            }
        }

        private async void playCard(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            takeButton.Visibility = Visibility.Visible;

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
                    //MessageBox.Show($"Вы выбрали карту {a.firstPlayerHand[ind].ShowCard()}\nЧисло карт в руке: {a.firstPlayerHand.Count}\nЧисло картинок в руке: {firstHandImages.Count}");

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
                    //MessageBox.Show($"Вы выбрали карту {a.secondPlayerHand[ind].ShowCard()}\nЧисло карт в руке: {a.secondPlayerHand.Count}\nЧисло картинок в руке: {secondHandImages.Count}");

                    foreach (Image cardImage in secondHandImages)
                    {
                        cardImage.IsEnabled = false;
                    }

                    cardsInGame.Add(image);
                    a.comparableCards.Add(a.secondPlayerHand[pageSecondPlayer*6+ ind]);
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
                    a.comparableCards.Add(a.firstPlayerHand[ind + pageFirstPlayer * 6]);
                    cardAccesed = a.CheckCard(a.comparableCards[0], a.comparableCards[1]);
                    //MessageBox.Show($"Вы выбрали карту {a.firstPlayerHand[ind + pageFirstPlayer * 6].ShowCard()}");
                }
                else
                {
                    a.comparableCards.Add(a.secondPlayerHand[ind + pageSecondPlayer * 6]);
                    cardAccesed = a.CheckCard(a.comparableCards[0], a.comparableCards[1]);
                    //MessageBox.Show($"Вы выбрали карту {a.secondPlayerHand[ind + pageSecondPlayer * 6].ShowCard()}");
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

                        if (a.gameDeck.Count > 0)
                        {
                            if (a.secondPlayerHand.Count < 6)
                            {
                                a.secondPlayerHand.Add(a.gameDeck[0]);
                                SetCardImage(a.gameDeck, secondHandImages, 0, 5);
                                a.gameDeck.RemoveAt(0);
                            }
                            if (a.firstPlayerHand.Count < 6)
                            {
                                a.firstPlayerHand.Add(a.gameDeck[0]);
                                SetCardImage(a.gameDeck, firstHandImages, 0, 5);
                                a.gameDeck.RemoveAt(0);
                            }
                        }
                        else
                        {
                            foreach (Image card in cardsInGame) { card.Visibility = Visibility.Hidden; }

                            trumpCardImage.Visibility = Visibility.Hidden;
                            gameDeckImage.Visibility = Visibility.Hidden;
                        }

                        pageFirstPlayer = 0;
                        pageSecondPlayer = 0;
                        ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
                        ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);

                        if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count > 1)
                        {
                            logTextBox.Text = "Победу одержал Игрок 1!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        else if (a.secondPlayerHand.Count == 0 && a.firstPlayerHand.Count > 1)
                        {
                            logTextBox.Text = "Победу одержал Игрок 2!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        else if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count == 0)
                        {
                            logTextBox.Text = "Ничья!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        int p = firstHandImages.IndexOf(image);
                        if (p == -1)
                        {
                            for (int i = secondHandImages.IndexOf(image); i < Math.Min(a.secondPlayerHand.Count - 1, 5); i++)
                            {
                                secondHandImages[i].Source = secondHandImages[i + 1].Source;
                            }
                        }
                        else
                        {
                            for (int i = p; i < Math.Min(a.firstPlayerHand.Count - 1, 5); i++)
                            {
                                firstHandImages[i].Source = firstHandImages[i + 1].Source;
                            }
                        }

                        if (a.firstPlayerHand.Count > 5)
                        {
                            int x = (int)a.firstPlayerHand[pageFirstPlayer * 6 + 5].Number;
                            int y = (int)a.firstPlayerHand[pageFirstPlayer * 6 + 5].CardMast;
                            firstHandImages[5].Source = BitmapFrame.Create(new Uri("img/cards/" + x.ToString() + y.ToString() + ".png", UriKind.Relative));
                        }
                        else firstHandImages[Math.Min(a.firstPlayerHand.Count - 1, 5)].Visibility = Visibility.Hidden;

                        pageFirstPlayer = 0;
                        pageSecondPlayer = 0;
                        ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
                        ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);
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

                        if (a.gameDeck.Count > 0)
                        {
                            if (a.firstPlayerHand.Count < 6)
                            {
                                a.firstPlayerHand.Add(a.gameDeck[0]);
                                SetCardImage(a.gameDeck, firstHandImages, 0, 5);
                                a.gameDeck.RemoveAt(0);
                            }
                            if (a.secondPlayerHand.Count < 6)
                            {
                                a.secondPlayerHand.Add(a.gameDeck[0]);
                                SetCardImage(a.gameDeck, secondHandImages, 0, 5);
                                a.gameDeck.RemoveAt(0);
                            }
                        }
                        else
                        {
                            foreach (Image card in cardsInGame) { card.Visibility = Visibility.Hidden; }

                            trumpCardImage.Visibility = Visibility.Hidden;
                            gameDeckImage.Visibility = Visibility.Hidden;
                        }

                        pageFirstPlayer = 0;
                        pageSecondPlayer = 0;
                        ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
                        ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);
                        if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count > 1)
                        {
                            logTextBox.Text = "Победу одержал Игрок 1!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        else if (a.secondPlayerHand.Count == 0 && a.firstPlayerHand.Count > 1)
                        {
                            logTextBox.Text = "Победу одержал Игрок 2!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        else if (a.firstPlayerHand.Count == 0 && a.secondPlayerHand.Count == 0)
                        {
                            logTextBox.Text = "Ничья!\n\nСпасибо участникам за игру!";
                            HideGameUI();
                            return;
                        }
                        int p = firstHandImages.IndexOf(image);
                        if (p == -1)
                        {
                            for (int i = secondHandImages.IndexOf(image); i < Math.Min(a.secondPlayerHand.Count - 1, 5); i++)
                            {
                                secondHandImages[i].Source = secondHandImages[i + 1].Source;
                            }
                        }
                        else
                        {
                            for (int i = p; i < Math.Min(a.firstPlayerHand.Count - 1, 5); i++)
                            {
                                firstHandImages[i].Source = firstHandImages[i + 1].Source;
                            }
                        }
                        if (a.secondPlayerHand.Count > 5)
                        {
                            int x = (int)a.secondPlayerHand[pageSecondPlayer * 6 + 5].Number;
                            int y = (int)a.secondPlayerHand[pageSecondPlayer * 6 + 5].CardMast;
                            secondHandImages[5].Source = BitmapFrame.Create(new Uri("img/cards/" + x.ToString() + y.ToString() + ".png", UriKind.Relative));
                        }
                        else secondHandImages[Math.Min(a.secondPlayerHand.Count - 1, 5)].Visibility = Visibility.Hidden;

                        pageFirstPlayer = 0;
                        pageSecondPlayer = 0;
                        ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
                        ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);
                    }

                    foreach (var item in a.comparableCards) { a.leaveCards.Add(item); }

                    a.comparableCards.Clear();
                    cardsInGame.Clear();

                    playedCardPlayer1Ind.Clear();
                    playedCardPlayer2Ind.Clear();

                    takeButton.Visibility = Visibility.Hidden;

                    leaveCardsCount.Text = a.leaveCards.Count.ToString();
                    gameDeckCount.Text = a.gameDeck.Count.ToString();
                    leaveCardsImage.Visibility = Visibility.Visible;

                    if (a.gameDeck.Count == 0)
                    {
                        trumpCardImage.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    MessageBox.Show("Этой картой нельзя покрыть!");
                    a.comparableCards.RemoveAt(1);
                }
            }

            firstPlayerHandCount.Text = a.firstPlayerHand.Count.ToString();
            secondPlayerHandCount.Text = a.secondPlayerHand.Count.ToString();
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

        private void ShowPage(List<Card> playerHand, int page, List<Image> playerImages,Button borderPre,Button borderNext)
        {
            if (page * 6 + 6 >= playerHand.Count && page>0)
            {
                borderNext.Visibility = Visibility.Hidden;
                borderPre.Visibility = Visibility.Visible;
                int cardCount = playerHand.Count % 6;
                if (cardCount == 0) cardCount = 6;
                for (int i = 0; i < cardCount; i++)
                {
                    
                    int x = (int)playerHand[page * 6 + i].Number;
                    int y = (int)playerHand[page * 6 + i].CardMast;
                    playerImages[i].Source = BitmapFrame.Create(new Uri("img/cards/" + x.ToString() + y.ToString() + ".png", UriKind.Relative));
                    playerImages[i].Visibility = Visibility.Visible;
                }
                for (int i = cardCount; i < 6; i++) { playerImages[i].Visibility = Visibility.Hidden; }
            }
            else
            {
                if (page == 0)
                {
                    if (playerHand.Count > 6)
                    {
                        borderNext.Visibility = Visibility.Visible;
                        borderPre.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        borderNext.Visibility = Visibility.Hidden;
                        borderPre.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    borderNext.Visibility = Visibility.Visible;
                    borderPre.Visibility = Visibility.Visible;
                }
                int i;
                for (i = 0; i < Math.Min(6, playerHand.Count); i++) 
                {
                    int x = (int)playerHand[page * 6 + i].Number;
                    int y = (int)playerHand[page * 6 + i].CardMast;
                    playerImages[i].Source = BitmapFrame.Create(new Uri("img/cards/" + x.ToString() + y.ToString() + ".png", UriKind.Relative));
                    playerImages[i].Visibility = Visibility.Visible;
                }
                    for(i = playerHand.Count; i < 6; i++)
                    {
                        playerImages[i].Visibility = Visibility.Hidden;
                    }
                
            }
        }

        private void nextSecondHandButton_Click(object sender, RoutedEventArgs e)
        {
            pageSecondPlayer++;

            ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton,nextSecondHandButton);
        }

        private void prevSecondHandButton_Click(object sender, RoutedEventArgs e)
        {
            pageSecondPlayer--;

            ShowPage(a.secondPlayerHand, pageSecondPlayer, secondHandImages, prevSecondHandButton, nextSecondHandButton);
        }

        private void nextFirstHandButton_Click(object sender, RoutedEventArgs e)
        {
            pageFirstPlayer++;

            ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
        }

        private void prevFirstHandButton_Click(object sender, RoutedEventArgs e)
        {
            pageFirstPlayer--;

            ShowPage(a.firstPlayerHand, pageFirstPlayer, firstHandImages, prevFirstHandButton, nextFirstHandButton);
        }

        private async void changeTextOnScreen_Click(object sender, RoutedEventArgs e)
        {
            specImage.Visibility = Visibility.Visible;

            music.Open(new Uri("specialsound.mp3", UriKind.Relative));
            music.Volume = 0.05;
            music.Play();

            await Task.Delay(TimeSpan.FromSeconds(6));
            specImage.Visibility = Visibility.Hidden;
        }
    }
}

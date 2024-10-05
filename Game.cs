using PROJECT.BlackJack;

public class Game
{
    private Deck deck;
    private IPlayer player;
    private IDealer dealer;

    public Game()
    {

    }

    private void PlayerTurn()
    {
        while (true)  // Бесконечный цикл для хода игрока
        {
            player.ShowPlayerHand(); 
            dealer.ShowFirstCard();

            Console.Write("Нажмите");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write(" 'Y', ");
            Console.ResetColor();
            Console.Write("чтобы взять карту, или");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" 'N', ");
            Console.ResetColor();
            Console.WriteLine("чтобы остановиться");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);  

            if (keyInfo.Key == ConsoleKey.Y)  
            {
                Card drawnCard = deck.DealCard();  
                player.AddCard(drawnCard); 

                if (player.HasBusted())
                {
                    break;  
                }
            }
            else if (keyInfo.Key == ConsoleKey.N)  
            {
                break;  
            }
        }
    }

    //Ход дилера
    private void DealerTurn()
    {
        while (dealer.Hand.CalculateValue() < 17)
        {
            Card dealerDrawnCard = deck.DealCard(); 
            dealer.AddCard(dealerDrawnCard); 
            Console.WriteLine($"{dealer} получает карту: {dealerDrawnCard}"); 
            dealer.ShowHand();
        }
    }

    //Начало игры
    public void Start()
    {
        do // Цикл для новой игры
        {
            
            deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("Введите имя игрока:");
            string playerName = Console.ReadLine();
            player = new Player(playerName, deck);
            dealer = new Dealer(deck);

            for (int i = 0; i < 2; i++)
            {
                player.AddCard(deck.DealCard());
            }

            dealer.AddCard(deck.DealCard()); 
            dealer.AddCard(deck.DealCard()); 

            player.ShowPlayerHand();
            dealer.ShowFirstCard();

            PlayerTurn();

            if (!player.HasBusted())
            {
                Console.WriteLine($"{dealer} показывает свои карты:");
                dealer.ShowHand(); 

                DealerTurn();
            }

            DetermineWinner();

        } while (PlayAgain()); 
    }

    //Для игры заново
    private bool PlayAgain()
    {
        Console.WriteLine("Хотите сыграть еще раз? (Y/N)");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true); 

        return keyInfo.Key == ConsoleKey.Y; 
    }

    //Определение победителя
    private void DetermineWinner()
    {
        int playerPoints = player.Hand.CalculateValue();
        int dealerPoints = dealer.Hand.CalculateValue();

        if (playerPoints > 21)
        {
            Console.WriteLine($"{player.Name} проиграл 💔 Перебор очков 😭");
        }
        else if (dealerPoints > 21 || playerPoints > dealerPoints)
        {
            Console.WriteLine($"{player.Name} выиграл 💖");
        }
        else if (playerPoints < dealerPoints)
        {
            Console.WriteLine("Дилер выиграл 💖");
        }
        else
        {
            Console.WriteLine("Ничья 👌");
        }
    }
}

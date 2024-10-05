using PROJECT.BlackJack;
using System;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public Hand Hand { get; private set; }
    private Deck deck;

    public Player(string name, Deck deck) 
    {
        Name = name;
        Hand = new Hand();
        this.deck = deck; 
    }

    //Добавляем игроку карту
    public void AddCard(Card card)
    {
        Hand.AddCard(card); 
        Console.WriteLine($"{Name} получает карту: {card}");
    }

    //Показ руки игрока
    public void ShowPlayerHand()
    {
        Console.Clear();
        Console.WriteLine(new string('=', 30));
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{Name} имеет следующие карты:");
        Console.ResetColor();
        Console.WriteLine(Hand);
        Console.WriteLine($"Очки: {Hand.CalculateValue()}");

        if (HasBusted())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} проиграл! Перебор очков.");
            Console.ResetColor();
        }
        Console.WriteLine(new string('=', 30));
    }

    public bool HasBusted()
    {
        return Hand.IsBusted();
    }
}

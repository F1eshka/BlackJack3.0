using PROJECT.BlackJack;

public interface IPlayer
{
    string Name { get; }
    Hand Hand { get; }
    void AddCard(Card card);
    bool HasBusted();
    void ShowPlayerHand();
}
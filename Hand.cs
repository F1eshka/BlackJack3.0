using PROJECT.BlackJack;
using System.Collections.Generic;

public class Hand
{
    public List<Card> cards; 
    private Card hiddenCard;

    public Hand()
    {
        cards = new List<Card>();
    }

    // Добавление карты в руку
    public void AddCard(Card card, bool isHidden = false)
    {
        if (isHidden)
        {
            hiddenCard = card; //Скрытая
        }
        else
        {
            cards.Add(card); 
        }
    }

    //Счёт очков
    public int CalculateValue()
    {
        int totalValue = 0;
        foreach (var card in cards)
        {
            totalValue += card.Value;
        }
        return totalValue;
    }

    // Проверка, если очков больше 21
    public bool IsBusted()
    {
        return CalculateValue() > 21;
    }

    // Отображение карт в руке
    public override string ToString()
    {
        string handDescription = "Карты в руке: ";
        foreach (var card in cards)
        {
            handDescription += $"{card} ";
        }

        // Если есть скрытая карта, не показываем ее
        if (hiddenCard != null)
        {
            handDescription += "(одна карта скрыта)";
        }
        return handDescription;
    }

    // Возвращаем количество карт в руке, включая скрытую
    public int CardsRemaining()
    {
        return cards.Count + (hiddenCard != null ? 1 : 0); 
    }

    // Отображение только открытых карт
    public string ShowVisibleCards()
    {
        string visibleCardsDescription = "Открытые карты: ";
        foreach (var card in cards)
        {
            visibleCardsDescription += $"{card} ";
        }
        return visibleCardsDescription.Trim();
    }

    // Получение скрытой карты 
    public Card GetHiddenCard()
    {
        return hiddenCard;
    }
}

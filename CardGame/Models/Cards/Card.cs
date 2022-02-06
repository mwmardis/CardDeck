using CardGame.Enums;

namespace CardGame.Models.Cards;

public abstract class Card
{

    public CardType CardType { get; set; }

    public abstract override string ToString();
}
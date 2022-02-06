using CardGame.Enums;

namespace CardGame.Models.Cards;

public class PlayingCard : Card
{
    public PlayingCard(Suit suit, CardValue cardValue)
    {
        CardType = CardType.Standard;
        Suit = suit;
        CardValue = cardValue;
    }
    public Suit Suit { get; }
    public CardValue CardValue { get; }

    public override string ToString()
    {
        return $"{Enum.GetName(CardValue)} of {Enum.GetName(Suit)}";
    }
}
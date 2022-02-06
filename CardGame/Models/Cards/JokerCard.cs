using CardGame.Enums;

namespace CardGame.Models.Cards;

public class JokerCard : Card
{
    public JokerCard()
    {
        CardType = CardType.Joker;
    }

    public override string ToString()
    {
        return "Joker";
    }
}
using CardGame.Enums;
using CardGame.Models.Cards;

namespace CardGame.Models.Decks;

public sealed class JokersIncludedCardDeck : Deck
{
    public JokersIncludedCardDeck()
    {
        DeckType = DeckType.JokersIncluded;
        InitializeDeck();
    }

    protected override void InitializeDeck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                Cards.Add(new PlayingCard(suit, value));
            }
        }

        Cards.Add(new JokerCard());
        Cards.Add(new JokerCard());
    }
}
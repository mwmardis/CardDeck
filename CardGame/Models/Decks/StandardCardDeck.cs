using CardGame.Enums;
using CardGame.Models.Cards;

namespace CardGame.Models.Decks;

public sealed class StandardCardDeck : Deck
{
    public StandardCardDeck()
    {
        DeckType = DeckType.Standard;
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
    }
}
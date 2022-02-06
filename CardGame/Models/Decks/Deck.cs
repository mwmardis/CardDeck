using CardGame.Enums;
using CardGame.Models.Cards;

namespace CardGame.Models.Decks;

public abstract class Deck
{

    public List<Card> Cards { get; set; } = new();
    public DeckType DeckType { get; set; }

    public virtual void Shuffle()
    {
        Cards = Cards.OrderBy(_ => Guid.NewGuid()).ToList();
    }

    public virtual Card? DealTopCard()
    {
        var card = Cards.FirstOrDefault();
        if (card != null)
        {
            Cards.Remove(card);
        }

        return card;
    }

    protected abstract void InitializeDeck();

    public new virtual string ToString()
    {
        var returnString = "";
        if (!Cards.Any())
        {
            return "Empty";
        }
        foreach (var card in Cards)
        {
            returnString += card + "\n";
        }

        return returnString;

    }
}
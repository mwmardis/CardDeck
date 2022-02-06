using CardGame.Models.Cards;

namespace CardGame;

public class Player
{
    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public string Name { get; }
    public List<Card> Hand { get; set; }

    // a lot of reuse here with Deck's ToString(). Could create a base that Hand and deck both inherit from. A hand and a deck are at the simplest a collection of cards.
    public override string ToString()
    {
        var handStringRepresentation = "";
        if (!Hand.Any())
        {
            return "Empty";
        }
        foreach (var card in Hand)
        {
            handStringRepresentation += card + "\n";
        }

        return $"{Name} - Hand: \n{handStringRepresentation}";

    }
}
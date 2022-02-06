using CardGame.Enums;
using CardGame.Models.Decks;

namespace CardGame.Models.GameInfo;

public class JokerDeckPokerGame : Game
{
    public JokerDeckPokerGame(List<Player> players)
    {
        GameType = GameType.JokerDeckPoker;
        CardDeck = new JokersIncludedCardDeck();
        Players = players;
    }
}

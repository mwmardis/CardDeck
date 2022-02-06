using CardGame.Enums;
using CardGame.Models.Decks;

namespace CardGame.Models.GameInfo;

public class StandardDeckPokerGame : Game
{
    public StandardDeckPokerGame(List<Player> players)
    {
        GameType = GameType.StandardDeckPoker;
        CardDeck = new StandardCardDeck();
        Players = players;
    }
}

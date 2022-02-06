using CardGame.Enums;

namespace CardGame.Models.GameInfo;


// Good candidate for a singleton. You could create games and view details of all ongoing/past games from here, but how the heck do you easily wire up DI in this .NET 6 console app?!
public class GameManager
{
    public Game CreateGameFromUserPrompts()
    {
        var players = CreatePlayersFromInput();
        return CreateGameFromUserInput(players);
    }

    private static List<Player> CreatePlayersFromInput()
    {
        Console.WriteLine("Today we're playing a card game with made up rules! How many players are playing? (Please enter as an integer) ");
        var numPlayers = Console.ReadLine();
        var players = new List<Player>();
        if (numPlayers != null && int.TryParse(numPlayers, out var actualNumPlayers))
        {
            for (int i = 0; i < actualNumPlayers; i++)
            {
                Console.Write($"player {i}: ");
                var playerInput = Console.ReadLine();
                players.Add(playerInput != null ? new Player(playerInput) : new Player($"Edwin{i}"));
            }
        }
        else
        {
            players.Add(new Player("Edwin"));
            players.Add(new Player("Arturo"));
            Console.WriteLine($"You didn't listen to the rules. I've decided there will be two players named {players[0].Name} and {players[1].Name}.");
        }

        return players;
    }

    private Game CreateGameFromUserInput(List<Player> players)
    {
        var gamesList = Enum.GetValues(typeof(GameType)).Cast<GameType>().Select(Enum.GetName);
        Console.WriteLine($"Please select a game type from the options {string.Join(", ", gamesList)}");
        var selectedGameType = Console.ReadLine();

        return Enum.TryParse<GameType>(selectedGameType, out var gameType) ? CreateGame(gameType, players) : CreateGame((GameType)(-1), players);
    }

    private Game CreateGame(GameType gameType, List<Player> players)
    {
        switch (gameType)
        {
            case GameType.StandardDeckPoker:
                return new StandardDeckPokerGame(players);
            case GameType.JokerDeckPoker:
                return new JokerDeckPokerGame(players);
            default:
                Console.WriteLine($"You didn't put a valid value. You'll be playing {Enum.GetName(GameType.JokerDeckPoker)}");
                return new JokerDeckPokerGame(players);
        }
    }
}
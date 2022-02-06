using CardGame.Enums;
using CardGame.Models.Cards;
using CardGame.Models.Decks;

namespace CardGame.Models.GameInfo;

public abstract class Game
{
    public GameType GameType { get; set; }
    public bool InitialDealHappened { get; set; }
    public Deck CardDeck { get; set; }
    public List<Player> Players { get; set; }
    public int NumCardsDealtInPreviousRound { get; set; }

    private const int CardsToDeal = 5;

    public void Play()
    {
        //Console.WriteLine($"Step 1: Display cards on the console app:");
        Console.WriteLine($"{CardDeck.ToString()}");

        CardDeck.Shuffle();
        //Console.WriteLine($"Step 2: Shuffle the deck and display the cards: ");
        Console.WriteLine($"{CardDeck.ToString()}");

        var dealAgain = true;
        while (dealAgain)
        {
            if (!InitialDealHappened)
            {
                Deal(CardsToDeal);
            }
            else
            {
                DealAgain();
            }
            
            //Console.WriteLine("Step 3: Deal the cards. Display the players and what cards were dealt to each player, and what is remaining in the deck. (went against prompt instructions a bit here because I know the players from this game object.)");
            PrintPlayerHands();
            Console.WriteLine($"Remaining cards in deck: \n {CardDeck.ToString()}");

            DetermineWinner();

            //Console.WriteLine("Step 4: Add deal again operation that deals the same number of cards to the same players in the previous step. Display the cards in each players hand and what is left in the deck.");
            Console.WriteLine("Shall we play another hand? No shuffling or anything. Please input Y/N");

            var dealAgainUserInput = Console.ReadLine();
            dealAgain = dealAgainUserInput != null &&
                        dealAgainUserInput.Equals("Y", StringComparison.OrdinalIgnoreCase);
        }
        Console.WriteLine("Thanks for playing!");

    }

    public virtual void Deal(int numCardsToDealEachPlayer)
    {
        InitialDealHappened = true;
        NumCardsDealtInPreviousRound = numCardsToDealEachPlayer;
        int numCardsDealtEachPlayer = 0;
        while (numCardsDealtEachPlayer < numCardsToDealEachPlayer)
        {
            Players.ForEach(player => player.Hand.Add(CardDeck.DealTopCard()));
            numCardsDealtEachPlayer++;
        }
    }

    public virtual void DealAgain()
    {
        CardDeck.Cards.AddRange(Players.SelectMany(player => player.Hand));
        ClearPlayerHands();
        CardDeck.Shuffle();
        Deal(NumCardsDealtInPreviousRound);
        
    }

    public virtual Player DetermineWinner()
    {
        var winningTotal = 0;
        var winningPlayer = Players[0];
        foreach (var player in Players)
        {
            var handValue = GetHandValue(player);
            if (handValue >= winningTotal)
            {
                winningPlayer = player;
                winningTotal = handValue;
            }
            PrintPlayerPointsInHand(player.Name, handValue);
        }
        Console.WriteLine($"{winningPlayer.Name} wins with a point total of {winningTotal}");
        return winningPlayer;
    }

    public virtual int GetHandValue(Player player)
    {
        var handValue = 0;
        foreach (var card in player.Hand)
        {
            if (card.CardType == CardType.Standard)
            {
                if ((int)((PlayingCard)card).CardValue >= (int)CardValue.Jack)
                {
                    handValue++;
                }
            }
            // jokers are worth double points since they gave me a fit to design.
            else
            {
                handValue += 2;
            }
        }

        return handValue;
    }

    public void PrintPlayerHands()
    {
        foreach (var player in Players)
        {
            Console.WriteLine(player);
            Console.WriteLine();
        }
    }

    public void PrintPlayerPointsInHand(string playerName, int pointsInHand)
    {
        Console.WriteLine($"{playerName} Points in hand: {pointsInHand}");
        Console.WriteLine();
        
    }

    public void ClearPlayerHands()
    {
        foreach (var player in Players)
        {
            player.Hand.Clear();
        }
    }
}
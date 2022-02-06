# CardDeck

CardDeck is a .NET 6 console application to play a simple card game with a couple of different deck types

## Installation

Clone and Run in visual studio. .NET 6 is required


## Usage

follow the command line prompt once running. You can choose number of players, their names, and what kind of game you want to play, and if you want to play again.

## notes
- I wasn't happy with my original approach and had Sunday morning free, so I figured there's worse things to do than build the card game in a better way than my original path.
- Did a lot with abstract classes/methods and virtual methods. Interfaces could have worked as well, and the initial abstract classes could implement an interface if deemed necessary.
- GameManager is a good use case for a Singleton. Especially if we wanted to allow concurrent games to go on, we could track all ongoing games through GameManager. I didn't wire the console app up to use DI, so I just kept it as a normal class that I newed up.
- Could easily get Human readable Enums throughout with Dictionary<Enum, string>
- feels like an overuse of ToString overrides and Console.Write() are pretty scattered, but it was a simple way to go for presentational purposes
- some methods from later in the requirements were just shoved in game and likely could have been put in Deck
- rushed at the end because I have a birthday party to attend and won't be able to get back into working on this until later next week.

// See https://aka.ms/new-console-template for more information

using CardGame.Models.GameInfo;

var gameManager = new GameManager();
var game = gameManager.CreateGameFromUserPrompts();
game.Play();

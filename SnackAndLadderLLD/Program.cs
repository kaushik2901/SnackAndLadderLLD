using SnackAndLadderLLD;

var board = new BoardBuilder()
    .Build();

var diceManager = new DiceManager(1);

var players = new List<Player> { new("Player 1"), new("Player 2") };

var game = new Game(board, diceManager, players);

game.Start();

while(game.Status != GameStatus.Won)
{
    game.Next();
}

var winningPlater = game.GetWinner();
Console.WriteLine($"Winner is {winningPlater.Name}");
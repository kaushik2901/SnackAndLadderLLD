using SnakeAndLadderLLD;

var board = new BoardBuilder()
    .WithSize(10)
    .WithSpecialBlock(new SpecialBlock(1, 37))
    .WithSpecialBlock(new SpecialBlock(3, 13))
    .WithSpecialBlock(new SpecialBlock(6, 16))
    .WithSpecialBlock(new SpecialBlock(8, 30))
    .WithSpecialBlock(new SpecialBlock(20, 41))
    .WithSpecialBlock(new SpecialBlock(27, 83))
    .WithSpecialBlock(new SpecialBlock(53, 33))
    .WithSpecialBlock(new SpecialBlock(61, 18))
    .WithSpecialBlock(new SpecialBlock(86, 35))
    .Build();

var diceManager = new DiceManager(1);

var players = new List<Player> { new Player("Player 1"), new Player("Player 2") };

var game = new Game(board, diceManager, players);

game.Start();

while (game.Status != GameStatus.Won)
{
    game.Next();
}

var winner = game.Winner;

Console.WriteLine($"Winner is {winner.Name}");

game.Reset();
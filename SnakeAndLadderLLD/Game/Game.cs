using SnakeAndLadderLLD.Board;
using SnakeAndLadderLLD.DiceManager;

namespace SnakeAndLadderLLD.Game;

public class Game(IBoard board, IDiceManager diceManager, IEnumerable<Player> players)
{
    private Player? _winner = null;

    private IBoard Board { get; init; } = board;
    private int CurrentPlayer { get; set; } = 0;
    private IDiceManager DiceManager { get; init; } = diceManager;
    private Player[] Players { get; init; } = players.ToArray();

    public GameStatus Status { get; private set; } = GameStatus.Ready;
    public Player Winner { get { return _winner ?? throw new Exception("Winner not found"); } }

    public void Next()
    {
        if (Status != GameStatus.Running) return;

        PlayNextMove();

        CurrentPlayer = (CurrentPlayer + 1) % Players.Length;
    }

    public void Reset()
    {
        CurrentPlayer = 0;

        foreach (var player in Players)
        {
            player.Position = 0;
        }

        Status = GameStatus.Ready;
    }

    public void Start()
    {
        Status = GameStatus.Running;
    }

    private bool IsValidPosition(int position) => position <= Board.MaxPosition;

    private bool IsWinningPosition(int position) => position == Board.MaxPosition;

    private void PlayNextMove()
    {
        var player = Players[CurrentPlayer];

        var diceValue = DiceManager.RollDices();

        var newPosition = player.Position + diceValue;

        if (!IsValidPosition(newPosition)) return;

        if (Board.SpecialBlockAtPosition(newPosition))
        {
            newPosition = Board.GetEndPositionForSpecialBlock(newPosition);
        }

        player.Position = newPosition;

        if (IsWinningPosition(newPosition))
        {
            _winner = player;
            Status = GameStatus.Won;
        }
    }
}
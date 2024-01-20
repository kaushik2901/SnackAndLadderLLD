namespace SnackAndLadderLLD;

public class BoardBuilder
{
    public IBoard Build()
    {
        return new Board(0, new Dictionary<int, int>());
    }
}

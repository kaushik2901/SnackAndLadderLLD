namespace SnackAndLadderLLD;

public class Board : IBoard
{
    public Board(int size, IDictionary<int, int> specialBlocks)
    {
        MaxPosition = (size * size) - 1;
        Size = size;
        SpecialBlocks = specialBlocks ?? throw new Exception($"{specialBlocks} required");
    }

    public int MaxPosition { get; init; }
    public int Size { get; init; }
    private IDictionary<int, int> SpecialBlocks { get; init; }

    public bool SpecialBlockAtPosition(int position)
    {
        return SpecialBlocks.ContainsKey(position);
    }

    public int GetEndPositionForSpecialBlock(int position) => SpecialBlocks[position];
}
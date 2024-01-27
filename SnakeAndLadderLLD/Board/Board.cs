namespace SnakeAndLadderLLD.Board;

public class Board(int size, IDictionary<int, int> specialBlocks) : IBoard
{
    public int MaxPosition { get; init; } = size * size - 1;
    public int Size { get; init; } = size;
    private IDictionary<int, int> SpecialBlocks { get; init; } = specialBlocks ?? throw new Exception($"{specialBlocks} required");

    public bool SpecialBlockAtPosition(int position)
    {
        return SpecialBlocks.ContainsKey(position);
    }

    public int GetEndPositionForSpecialBlock(int position) => SpecialBlocks[position];
}
namespace SnackAndLadderLLD;

public interface IBoard
{
    int MaxPosition { get; init; }
    int Size { get; init; }

    int GetEndPositionForSpecialBlock(int position);
    bool SpecialBlockAtPosition(int position);
}
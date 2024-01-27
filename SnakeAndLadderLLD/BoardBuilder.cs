namespace SnakeAndLadderLLD;

public class BoardBuilder
{
    private int Size { get; set; }
    private List<SpecialBlock> SpecialBlocks { get; set; } = [];

    public BoardBuilder WithSize(int size)
    {
        Size = size;
        return this;
    }

    public BoardBuilder WithSpecialBlock(SpecialBlock specialBlock)
    {
        SpecialBlocks.Add(specialBlock);
        return this;
    }

    public IBoard Build()
    {
        return new Board(Size, SpecialBlocks.ToDictionary(x => x.StartPosition, x => x.EndPosition));
    }
}

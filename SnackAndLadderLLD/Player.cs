namespace SnackAndLadderLLD;

public class Player(string name)
{
    public string Name { get; init; } = name;
    public int Position { get; set; } = 0;
}
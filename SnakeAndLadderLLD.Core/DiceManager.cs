namespace SnackAndLadderLLD.Core;

public class DiceManager(int numberOfDice) : IDiceManager
{
    private int NumberOfDice { get; init; } = numberOfDice;

    private const int MAX_VALUE_FOR_SINGLE_DICE = 6;

    public int RollDices()
    {
        return new Random().Next(NumberOfDice, NumberOfDice * MAX_VALUE_FOR_SINGLE_DICE);
    }
}
namespace CaptainCoder.SnakeGame;

public class RandomPositionGenerator : IPositionGenerator
{
    private readonly Random _random;
    public RandomPositionGenerator(Random random) => _random = random;
    public Position Generate(int rows, int columns)
    {
        int row = _random.Next(rows);
        int column = _random.Next(columns);
        return new Position(row, column);
    }
}
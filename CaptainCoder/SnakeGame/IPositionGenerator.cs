namespace CaptainCoder.SnakeGame;

public interface IPositionGenerator
{
    public Position Generate(int rows, int columns);
}
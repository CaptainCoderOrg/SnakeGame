namespace CaptainCoder.SnakeGame;

public interface ISnakeBody : IEnumerable<Position>
{
    public int Count { get; }
    public void AddFirst(Position data);
    public Position RemoveLast();
    public bool Contains(Position position);
}
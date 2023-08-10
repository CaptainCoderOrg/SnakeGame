using System.Collections;
namespace CaptainCoder.SnakeGame;

public class DynamicArraySnakeBody : ISnakeBody
{
    private readonly List<Position> _positions = new List<Position>();
    public int Count => _positions.Count;
    public void AddFirst(Position data) => _positions.Insert(0, data);
    public bool Contains(Position position) => _positions.Contains(position);
    public Position RemoveLast()
    {
        Position last = _positions[_positions.Count - 1];
        _positions.RemoveAt(Count - 1);
        return last;
    }

    // Implementation for the GetEnumerator method.
    // Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
    public IEnumerator<Position> GetEnumerator() => _positions.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _positions.GetEnumerator();
}
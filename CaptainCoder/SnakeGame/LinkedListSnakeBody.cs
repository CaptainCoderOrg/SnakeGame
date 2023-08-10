using System.Collections;
namespace CaptainCoder.SnakeGame;

public class LinkedListSnakeBody : ISnakeBody
{
    private readonly LinkedList<Position> _positions = new LinkedList<Position>();
    private readonly HashSet<Position> _positionLookup = new HashSet<Position>();
    public int Count => _positions.Count;
    public void AddFirst(Position data)
    {
        _positions.AddFirst(data);
        _positionLookup.Add(data);
    }
    public bool Contains(Position position) => _positionLookup.Contains(position);
    public Position RemoveLast()
    {
        Position last = _positions.Last.Value;
        _positions.RemoveLast();
        _positionLookup.Remove(last);
        return last;
    }

    // Implementation for the GetEnumerator method.
    // Must implement GetEnumerator, which returns a new StreamReaderEnumerator.
    public IEnumerator<Position> GetEnumerator() => _positions.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _positions.GetEnumerator();
}
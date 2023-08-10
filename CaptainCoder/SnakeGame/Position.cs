namespace CaptainCoder.SnakeGame
{
    public readonly record struct Position(int Row, int Column)
    {
        // public Position(int row, int column) => (Row, Column) = (row, column);
        // public int Row { get; private set; }
        // public int Column { get; private set; }
        public Position Forward(Direction direction)
        {
            return direction switch
            {
                Direction.North => new Position() { Row = Row - 1, Column = Column },
                Direction.South => new Position() { Row = Row + 1, Column = Column },
                Direction.East => new Position() { Row = Row, Column = Column + 1 },
                Direction.West => new Position() { Row = Row, Column = Column - 1 },
                _ => throw new ArgumentException("Invalid Direction. Must be North, South, East, or West")
            };
        }

        public Position Backward(Direction direction) => Forward(direction.Rotate180());
    }
}
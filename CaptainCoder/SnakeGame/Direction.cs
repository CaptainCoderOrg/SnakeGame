namespace CaptainCoder.SnakeGame
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class Directions
    {
        public static Direction Rotate180(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.South,
                Direction.East => Direction.West,
                Direction.South => Direction.North,
                Direction.West => Direction.East,
                _ => throw new ArgumentException($"Cannot rotate direction {direction}."),
            };
        }

        public static Direction RotateClockwise(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new ArgumentException($"Cannot rotate direction {direction}."),
            };
        }

        public static Direction RotateCounterClockwise(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => throw new ArgumentException($"Cannot rotate direction {direction}."),
            };
        }
    }
}
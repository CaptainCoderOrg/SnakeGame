using System;
namespace CaptainCoder.SnakeGame
{
    public class GameController
    {
        private IPositionGenerator _random  { get; set; } = new RandomPositionGenerator(new Random());
        public GameController(int rows, int columns, IPositionGenerator random)
        {
            _random = random;
            Rows = rows;
            Columns = columns;
            Position start = new Position(Rows/2, Columns/2);
            Snake = new Snake(Direction.North, start, new LinkedListSnakeBody());
            FoodPosition = RandomPosition();
        }

        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Snake Snake { get; private set; }
        public Position FoodPosition { get; private set; }
        public bool IsBoardFull => Snake.Length >= Rows * Columns;

        public bool Step()
        {
            Position nextSpace = Snake.Body.First().Forward(Snake.Facing);
            // Out of bounds
            if (nextSpace.Row < 0 || nextSpace.Column < 0 || nextSpace.Row >= Rows || nextSpace.Column >= Columns)
            {
                return false;
            }

            // Snake eats self
            if (Snake.Body.Contains(nextSpace))
            {
                return false;
            }

            // Snake eats food
            if (nextSpace == FoodPosition)
            {
                Snake.Extend();
                // Board is full
                if (IsBoardFull)
                {
                    return false;
                }
                FoodPosition = RandomPosition();
                return true;
            }
            
            // Snake moves
            Snake.Step();
            
            return true;
        }

        private Position RandomPosition()
        {
            if (IsBoardFull)
            {
                throw new InvalidOperationException("Cannot generate a position on a full board!");
            }
            Position candidatePosition;
            do
            {
                candidatePosition = _random.Generate(Rows, Columns);
            } while(Snake.Body.Contains(candidatePosition));
            return candidatePosition;
        }
    }
}
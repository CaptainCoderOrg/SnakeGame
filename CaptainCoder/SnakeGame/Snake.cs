using System;
using System.Collections.Generic;
namespace CaptainCoder.SnakeGame
{
    public class Snake
    {
        public Direction Facing { get; private set; }
        public IList<Position> Body { get; private set; }
        public int Length { get; private set; }

        public void Extend()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            throw new NotImplementedException();
        }
    }
}
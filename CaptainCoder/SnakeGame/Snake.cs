using System;
using System.Collections.Generic;
namespace CaptainCoder.SnakeGame
{
    public class Snake
    {
        public Snake(Direction facing, Position headPosition, ISnakeBody bodyContainer)
        {
            Facing = facing;
            Body = bodyContainer;
            Body.AddFirst(headPosition.Backward(facing));  
            Body.AddFirst(headPosition);
        }

        public Direction Facing { get; private set; }
        public ISnakeBody Body { get; private set; }
        public int Length => Body.Count;

        public void RotateClockwise() => Facing = Facing.RotateClockwise();
        public void RotateCounterClockwise() => Facing = Facing.RotateCounterClockwise();

        public void Extend()
        {
            Position newHeadPosition = Body.First().Forward(Facing);
            Body.AddFirst(newHeadPosition);
        }

        public void Step()
        {
            Extend();
            Body.RemoveLast();
        }
    }
}
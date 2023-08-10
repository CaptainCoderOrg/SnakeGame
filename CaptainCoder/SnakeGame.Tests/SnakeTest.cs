using Shouldly;
namespace CaptainCoder.SnakeGame.Tests;

public class SnakeTest
{

    [Theory]
    [InlineData(Direction.North)]
    [InlineData(Direction.East)]
    [InlineData(Direction.South)]
    [InlineData(Direction.West)]
    public void test_construct_snake(Direction facing)
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();

        // Act
        Snake snake = new Snake(facing, new Position(5, 5), body);

        // Assert
        snake.Length.ShouldBe(2);
        snake.Facing.ShouldBe(facing);
        body.ShouldContain(new Position(5, 5));
        body.ShouldContain(new Position(5, 5).Backward(facing));
    }

    [Fact]
    public void test_extend_once()
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();
        Snake snake = new Snake(Direction.North, new Position(5, 5), body);

        // Act
        snake.Extend();

        // Assert
        snake.Length.ShouldBe(3);
        snake.Facing.ShouldBe(Direction.North);
        body.ShouldContain(new Position(4, 5));
        body.ShouldContain(new Position(5, 5));
        body.ShouldContain(new Position(6, 5));
    }

    [Fact]
    public void test_extend_thrice()
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();
        Snake snake = new Snake(Direction.North, new Position(5, 5), body);

        // Act
        snake.Extend();
        snake.RotateClockwise();
        snake.Extend();
        snake.RotateCounterClockwise();
        snake.Extend();

        // Assert
        snake.Length.ShouldBe(5);
        snake.Facing.ShouldBe(Direction.North);
        body.ShouldContain(new Position(3, 6));
        body.ShouldContain(new Position(4, 6));
        body.ShouldContain(new Position(4, 5));
        body.ShouldContain(new Position(5, 5));
        body.ShouldContain(new Position(6, 5));
    }

    [Fact]
    public void test_step_once()
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();
        Snake snake = new Snake(Direction.North, new Position(5, 5), body);

        // Act
        snake.Step();

        // Assert
        snake.Length.ShouldBe(2);
        snake.Facing.ShouldBe(Direction.North);
        body.ShouldContain(new Position(4, 5));
        body.ShouldContain(new Position(5, 5));
    }

    [Fact]
    public void test_step_thrice()
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();
        Snake snake = new Snake(Direction.North, new Position(5, 5), body);

        // Act
        snake.Step();
        snake.RotateClockwise();
        snake.Step();
        snake.RotateCounterClockwise();
        snake.Step();

        // Assert
        snake.Length.ShouldBe(2);
        snake.Facing.ShouldBe(Direction.North);
        body.ShouldContain(new Position(3, 6));
        body.ShouldContain(new Position(4, 6));
    }

    [Fact]
    public void test_step_longer_body()
    {
        // Arrange
        ISnakeBody body = new LinkedListSnakeBody();
        Snake snake = new Snake(Direction.South, new Position(3, 6), body);
        snake.Extend();
        snake.Extend();
        snake.RotateClockwise(); // Turn right

        // Act
        snake.Step();

        // Assert
        snake.Length.ShouldBe(4);
        snake.Facing.ShouldBe(Direction.West);
        body.ShouldContain(new Position(3, 6));
        body.ShouldContain(new Position(4, 6));
        body.ShouldContain(new Position(5, 6));
        body.ShouldContain(new Position(5, 5));
    }
}
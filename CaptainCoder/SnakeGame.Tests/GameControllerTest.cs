using Shouldly;
using NSubstitute;
namespace CaptainCoder.SnakeGame.Tests;

public class GameControllerTest
{
    [Fact]
    public void test_initialization()
    {
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 10;
        int columns = 10;
        rng.Generate(rows, columns).Returns(new Position(3, 3));

        // Act
        GameController controller = new GameController(rows, columns, rng);

        // Assert
        controller.FoodPosition.ShouldBe(new Position(3, 3));
        controller.Snake.Facing.ShouldBe(Direction.North);
        controller.Snake.Length.ShouldBe(2);
        controller.Snake.Body.First().ShouldBe(new Position(rows / 2, columns / 2));
    }

    // Snake moves
    [Fact]
    public void test_snake_move()
    {
        // Triple A (AAA)
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 10;
        int columns = 10;
        rng.Generate(rows, columns).Returns(new Position(3, 3));
        GameController controller = new GameController(rows, columns, rng);
        // Act
        bool result = controller.Step();

        // Assert
        result.ShouldBeTrue();
        controller.Snake.Length.ShouldBe(2);
        controller.Snake.Body.ShouldContain(new Position(4, 5));
        controller.Snake.Body.ShouldContain(new Position(5, 5));        
    }

    // Snake eats food
    [Fact]
    public void test_snake_eat()
    {
        // Triple A (AAA)
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 10;
        int columns = 10;
        // Spawn the food in front of the snake
        rng.Generate(rows, columns).Returns(new Position(4, 5));
        GameController controller = new GameController(rows, columns, rng);

        // After spawned, spawn elsewhere
        rng.Generate(rows, columns).Returns(new Position(7, 7));

        // Act
        bool result = controller.Step();

        // Assert
        result.ShouldBeTrue();
        controller.Snake.Length.ShouldBe(3);
        controller.Snake.Body.ShouldContain(new Position(4, 5));
        controller.Snake.Body.ShouldContain(new Position(5, 5));      
        controller.Snake.Body.ShouldContain(new Position(6, 5));
        controller.FoodPosition.ShouldBe(new Position(7, 7));
    }

    // Snake eats self
    [Fact]
    public void test_snake_eat_self()
    {
        // Triple A (AAA)
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 10;
        int columns = 10;
        // Spawn the food in front of the snake
        rng.Generate(rows, columns).Returns(new Position(3, 3));
        GameController controller = new GameController(rows, columns, rng);

        Snake snake = controller.Snake;
        snake.RotateClockwise();
        snake.Extend();
        snake.RotateClockwise();
        snake.Extend();
        snake.RotateClockwise();
        
        // Act
        bool result = controller.Step();

        // Assert
        result.ShouldBeFalse();
    }

    // Out of bounds
    [Fact]
    public void test_snake_move_out_of_bounds()
    {
        // Triple A (AAA)
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 10;
        int columns = 10;
        // Spawn the food in front of the snake
        rng.Generate(rows, columns).Returns(new Position(3, 3));
        GameController controller = new GameController(rows, columns, rng);

        // Move snake to edge of board
        Snake snake = controller.Snake;
        snake.Step();
        snake.Step();
        snake.Step();
        snake.Step();
        snake.Step();

        // Act
        bool result = controller.Step();

        // Assert
        result.ShouldBeFalse();
    }

    // Board is full
    [Fact]
    public void test_board_full()
    {
        // Triple A (AAA)
        // Arrange
        IPositionGenerator rng = Substitute.For<IPositionGenerator>();
        int rows = 3;
        int columns = 3;
        // Spawn the food in top left
        rng.Generate(rows, columns).Returns(new Position(0, 0));
        GameController controller = new GameController(rows, columns, rng);

        // Extend snake around board
        Snake snake = controller.Snake;
        snake.Step();
        snake.RotateClockwise();
        snake.Extend();
        snake.RotateClockwise();
        snake.Extend();
        snake.Extend();
        snake.RotateClockwise();
        snake.Extend();
        snake.Extend();
        snake.RotateClockwise();
        snake.Extend();

        // Act
        bool result = controller.Step();

        // Assert
        result.ShouldBeFalse();
        snake.Length.ShouldBe(9);
    }
}
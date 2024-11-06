using HiQ.Technical.Test.Console;

namespace HiQ.Technical.Test.UnitTest;

public class CarManagerTests
{
    [Fact]
    public void CheckPositionInRoom_WhenCarHitsNorthWall_ReturnsCrashMessage()
    {
        // Arrange
        var car = new Car(5, 10, Direction.North);
        var room = new Room(10, 10);
        var carManager = new CarManager(room, car);

        // Act
        var result = carManager.RunCommands("F");

        // Assert
        Assert.Equal("Car crashed into the North wall.", result);
    }

    [Fact]
    public void CheckPositionInRoom_WhenCarIsInsideRoom_ReturnsSuccessfulMessage()
    {
        // Arrange
        var car = new Car(5, 10, Direction.North);
        var room = new Room(10, 10);
        var carManager = new CarManager(room, car);
        var expectedCarSettings = new Car(5, 9, Direction.North);

        // Act
        var result = carManager.RunCommands("B");

        // Assert
        Assert.Equal($"The car moved according to the commands and with the result successful.\n New carposition is X:{expectedCarSettings.CurrentX}, Y:{expectedCarSettings.CurrentY} and direction: {expectedCarSettings.CurrentDirection}. Well done. :-) ", result);
    }
}
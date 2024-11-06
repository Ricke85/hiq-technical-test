namespace HiQ.Technical.Test.Console;

/// <summary>
///     Class just to create a car with primary constructor.
/// </summary>
public class Car(int startX, int startY, Direction startDirection)
{
    public int CurrentX { get; set; } = startX;
    public int CurrentY { get; set; } = startY;
    public Direction CurrentDirection { get; set; } = startDirection;
}

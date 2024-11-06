namespace HiQ.Technical.Test.Console;

// <summary>
///     Class to handle car commands. Movements of the car in the room.
/// </summary>
public class CarManager(Room room, Car car)
{
    private readonly Room _room = room;
    private readonly Car _car = car;

    // Run all commands.
    public string RunCommands(string commands)
    {
        foreach (var command in commands.ToUpper())
        {
            switch (command)
            {
                case 'F':
                    MoveForward();
                    break;
                case 'B':
                    MoveBack();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                default:
                    break;
            }

            string? carPosisionResult = CheckPosisionInRoom();

            if (carPosisionResult != string.Empty)
                return carPosisionResult;
        }

        return $"The car moved according to the commands and with the result successful.\n New carposition is X:{_car.CurrentX}, Y:{_car.CurrentY} and direction: {_car.CurrentDirection}. Well done. :-) ";
    }

    /// <summary>
    ///     Moves the car forward one step.
    /// </summary>
    private void MoveForward()
    {
        switch (_car.CurrentDirection)
        {
            case Direction.East:
                _car.CurrentX++;
                break;
            case Direction.North:
                _car.CurrentY++;
                break;
            case Direction.South:
                _car.CurrentY--;
                break;
            case Direction.West:
                _car.CurrentX--;
                break;
        }
    }

    /// <summary>
    ///     Move the car back one step.
    /// </summary>
    private void MoveBack()
    {
        switch (_car.CurrentDirection)
        {
            case Direction.East:
                _car.CurrentX--;
                break;
            case Direction.North:
                _car.CurrentY--;
                break;
            case Direction.South:
                _car.CurrentY++;
                break;
            case Direction.West:
                _car.CurrentX++;
                break;
        }
    }

    /// <summary>
    ///     Turns the car 90 degrees to the left, but doesn't move it.
    /// </summary>
    private void TurnLeft()
    {
        switch (_car.CurrentDirection)
        {
            case Direction.East:
                _car.CurrentDirection = Direction.North;
                break;
            case Direction.North:
                _car.CurrentDirection = Direction.West;
                break;
            case Direction.South:
                _car.CurrentDirection = Direction.East;
                break;
            case Direction.West:
                _car.CurrentDirection = Direction.South;
                break;
        }

    }

    /// <summary>
    ///     Turns the car 90 degrees to the right, but doesn't move it.
    /// </summary>
    private void TurnRight()
    {
        switch (_car.CurrentDirection)
        {
            case Direction.East:
                _car.CurrentDirection = Direction.South;
                break;
            case Direction.North:
                _car.CurrentDirection = Direction.East;
                break;
            case Direction.South:
                _car.CurrentDirection = Direction.West;
                break;
            case Direction.West:
                _car.CurrentDirection = Direction.North;
                break;
        }
    }

    /// <summary>
    ///     Check if car is crashing into any wall.
    /// </summary>
    /// <returns>Crash message string.Empty if no crash</returns>
    private string CheckPosisionInRoom()
    {
        if (_car.CurrentY > _room.Y ||
            _car.CurrentY == 0 ||
            _car.CurrentX > _room.X ||
            _car.CurrentX == 0)
        {
            return $"Car crashed into the {_car.CurrentDirection} wall.";
        }

        return string.Empty;
    }
}

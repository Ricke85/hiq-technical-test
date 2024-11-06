namespace HiQ.Technical.Test.Console;

/// <summary>
///     Class to set size of the room and to vaildate the "room input string".
/// </summary>

public class Room(int x, int y)
{
    const int _minValue = 1;
    const int _maxValue = 20;

    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    /// <summary>
    ///     Validate roomSizeInput
    /// </summary>
    /// <param name="roomSizeInput"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    internal static string ValidateRoomSizeInput(string? roomSizeInput, out int x, out int y)
    {
        x = 0;
        y = 0;

        try
        {
            if (roomSizeInput == string.Empty)
                return "Roomsize input missing.";

            // Splitt roomSize.
            var dimensions = roomSizeInput!.Split();    // roomSizeInput will not be empty here.

            // Check if there are 2 values.
            if (dimensions.Length != 2)
                return "Number of parameters not correct.";

            // Check values.
            x = int.Parse(dimensions[0]);
            y = int.Parse(dimensions[1]);

            if (x < _minValue || x > _maxValue || y < _minValue || y > _maxValue)
                return "Some values are not within the limit.";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return string.Empty;
    }

    /// <summary>
    ///     Validate that the car start position is within the walls of the room.
    /// </summary>
    /// <param name="carSettingInput"></param>
    /// <param name="room"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    internal static string ValidateCarStartPosition(string? carSettingInput, Room room, out int x, out int y, out Direction direction)
    {
        x = 0;
        y = 0;
        direction = Direction.East;

        try
        {
            if (carSettingInput == string.Empty)
                return "Carsetting input missing.";

            // Splitt roomSize.
            var settings = carSettingInput!.Split();     // carSettingInput will not be empty here.

            // Check if there are 3 values.
            if (settings.Length != 3)
                return "Number of parameters not correct.";

            // Check values.
            x = int.Parse(settings[0]);
            y = int.Parse(settings[1]);

            // Make sure the car is placed inside the room.
            if (x < 1 || x > room.X || y < 1 || y > room.Y)
                return "Some values are not within the limit.";

            direction = settings[2].ToUpper() switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => throw new ArgumentException($"Input direction '{settings[2]}' is not valid.")
            };
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return string.Empty;
    }
}

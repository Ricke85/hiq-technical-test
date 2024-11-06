// See https://aka.ms/new-console-template for more information

using HiQ.Technical.Test.Console;

Console.WriteLine("HiQ Technical Test");

// ==========      Room     ==========
Console.WriteLine("Enter room size in whole meters in format 'x y'. (Maximum 20 in each direction)");
var roomInput = Console.ReadLine();

var validationResult = Room.ValidateRoomSizeInput(roomInput, out int roomX, out int roomY);
if (validationResult != string.Empty)
{
    Console.WriteLine(validationResult);
    Console.WriteLine("Hit Enter to terminate the application...");
    Console.ReadLine();
}

var room = new Room(roomX, roomY);
Console.WriteLine($"Room created with dimensions X:{roomX} and Y:{roomY} meter.\n");


// ==========      Car position and direction    ==========
Console.WriteLine("Enter starting posision and direction for the car in format 'x y d'");
var carPosisionAndDirectionInput = Console.ReadLine();

validationResult = Room.ValidateCarStartPosition(carPosisionAndDirectionInput, room, out int carX, out int carY, out Direction direction);
if (validationResult != string.Empty)
{
    Console.WriteLine(validationResult);
    Console.WriteLine("Hit Enter to terminate the application...");
    Console.ReadLine();
}

var car = new Car(carX, carY, direction);
Console.WriteLine($"Car created with startingpoint X:{car.CurrentX} and Y:{car.CurrentY} and with direction {car.CurrentDirection}.\n");


// ==========      Car commands     ==========
// f:forward, b:back, l:left and r:right
Console.WriteLine("Enter some driving commands for the car in format 'fblr'");
var commands = Console.ReadLine();

if (commands != string.Empty)
{
    var carManager = new CarManager(room, car);
    Console.WriteLine(carManager.RunCommands(commands!));   // carSettingInput will not be empty here.
}
else
    Console.WriteLine("Commands missing.");

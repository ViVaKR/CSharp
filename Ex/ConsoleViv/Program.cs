using System.Data;
using UtilityLibraries;

// using ConsoleViv.Playground;

// Console.WriteLine("What is your name?");
// var name = Console.ReadLine();
// var currentDate = DateTime.Now;
// Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");

// int a = 123;
// int b = 456;
// int sum = a + b;
// Console.WriteLine(sum);
// Generics generics = new();
// generics.Efficiency();

int row = 0;
do
{
    if (row == 0 || row >= 25)
        ResetConsole();

    string? input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) break;
    Console.WriteLine($"Input: {input}");
    Console.WriteLine($"Starts with uppercase? {(input.StartsWithUpper() ? "Yes" : "No")}");
    Console.WriteLine();
    row += 4;
} while (true);


void ResetConsole()
{
    if (row > 0)
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    Console.Clear();
    Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; oterwise, enter a string and press <Enter>:{Environment.NewLine}");
    row = 3;
}



using System.ComponentModel;
using BM;


// var demoA = new DemoA();


// var hashSet = new HashSet<Grab> {
//     Grab.Black,
//     Grab.Black,
//     Grab.White,
//     Grab.Gray
// };

// foreach (var item in grabs)
// {
//     Console.WriteLine($"{item}");
// }

HashSet<int> numbers = new HashSet<int>();

for (int i = 0; i < 20; i++)
{
    numbers.Add(i);
}

Console.WriteLine($"number contains {numbers.Count} numbers");
DisplaySet(numbers);
numbers.RemoveWhere(IsOdd);
DisplaySet(numbers);




static bool IsOdd(int i)
{
    return i % 2 == 1;
}

static void DisplaySet(HashSet<int> set)
{
    Console.Write("{");
    foreach (var item in set)
        Console.Write($" {item}");

    Console.WriteLine(" }");
}

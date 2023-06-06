using J_Actions;

Console.WriteLine("*** Action Demo ***");
Console.WriteLine();

// Action 1
Action<int, int> action1 = MainApp.Move;
// Action 2
Action<int, int> action2 = MainApp.Resize;

// Combine Action 1 += Action 2
action1 += action2;
action1(200, 300);

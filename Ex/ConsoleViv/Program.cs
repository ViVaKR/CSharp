using System.Reflection.Metadata.Ecma335;
using ConsoleViv;

Task t1 = Utility.GetExternalIp();
Task t2 = Utility.Sum();
Task t3 = Utility.Multiply();
Task t4 = Utility.Subtract();
Task t5 = Task.Run(() => Console.WriteLine("Task 5 ============================"));

// await Task.WhenAll(t1, t2, t3, t4);

await Task.WhenAll(t1, t2, t3, t4, t5).ContinueWith(x => Console.WriteLine("All Tasks Completed!"));

// await Task.Run(() => t6);

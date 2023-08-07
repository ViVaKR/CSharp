using Tutor.AsyncAwait;

/* Order 

    (1) Pour Coffee
    (2) Heat Pan
    (3) Fry Eggs
    (4) Fry Bacon
    (5) Toast Bread
    (6) Jam on Bread
    (7) Pour Juice
    ! 30 Minutes Elapsed Time
*/

Coffee cup = PourCoffee();
Console.WriteLine($"{cup.GetType().Name} Coffee is ready");

var eggsTask = FryEggsAsync(2);
var baconTask = FryBaconAsync(3);
var toastTask = MakeToastWithButterAndJamAsync(2);

var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

while (breakfastTasks.Count > 0)
{
    Task finishedTask = await Task.WhenAny(breakfastTasks);
    if (finishedTask == eggsTask)
    {
        Console.WriteLine("eggs are ready");
    }
    else if (finishedTask == baconTask)
    {
        Console.WriteLine("Bacon is Ready");
    }
    else if (finishedTask == toastTask)
    {
        Console.WriteLine("Toast is ready");
    }

    await finishedTask;
    breakfastTasks.Remove(finishedTask);

}

Juice oj = PourOJ();
Console.WriteLine($"{oj.GetType().Name} is Read");
Console.WriteLine("Breakfast is ready");

static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
{
    var toast = await ToastBreadAsync(number);
    ApplyButter(toast);
    ApplyJam(toast);
    return toast;
}
static Juice PourOJ()
{

    Console.WriteLine("Pouring Orange Juice");
    return new Juice();
}

static void ApplyJam(Toast toast)
{
    Console.WriteLine($"Putting jam on the {nameof(Toast)}");
}

static void ApplyButter(Toast toast)
{
    Console.WriteLine($"Putting butter on the {nameof(Toast)}");
}

static async Task<Toast> ToastBreadAsync(int slices)
{
    for (int slice = 0; slice < slices; slice++)
    {
        Console.WriteLine("Putting a slice of bread in the toaster : " + slice);
    }

    Console.WriteLine("Start toasting...");
    await Task.Delay(3000);
    Console.WriteLine("Remove toast from toaster");
    return new Toast();
}

static async Task<Bacon> FryBaconAsync(int slices)
{
    Console.WriteLine($"Putting {slices} slices of bacon in the pan");
    Console.WriteLine("Cooking first side of bacon...");
    Task.Delay(3000).Wait();
    for (int slice = 0; slice < slices; slice++)
    {
        Console.WriteLine("flipping a slice of bacon");
    }
    Console.WriteLine("Cooking the second side of bacon...");
    await Task.Delay(3000);
    Console.WriteLine("Put bacon on plate");

    return new Bacon();
}

static async Task<Egg> FryEggsAsync(int howMany)
{
    Console.WriteLine("Warming the egg pan...");
    Task.Delay(3000).Wait();
    Console.WriteLine($"Cracking {howMany} eggs");
    await Task.Delay(3000);
    Console.WriteLine("Put eggs on plate");

    return new Egg();
}

static Coffee PourCoffee()
{
    Console.WriteLine("Pouring Conffee");
    return new Coffee();
}



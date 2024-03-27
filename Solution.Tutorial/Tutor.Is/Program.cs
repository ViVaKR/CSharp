
static bool CheckDateTime(DateTime date) =>
date is { Month: 8, Day: 7 };

static bool CheckCustomer(Customer customer)
=> customer is { Id: 1, Name: "HelloWorld", Age: 45 };

Console.WriteLine($"Result = {CheckDateTime(DateTime.Now)}");

var cs = new Customer { Id = 1, Name = "HelloWorld", Age = 45 };

var rs = CheckCustomer(cs) ? "일치" : "다름";
Console.WriteLine($"Result = {rs}");

//
static int GetSourceLable<T>(IEnumerable<T> source)
=> source switch
{
    Array => 1,
    ICollection<T> => 2,
    _ => 3
};

var number = new int[] { 10, 20, 30 };
Console.WriteLine($"Check is = {GetSourceLable(number)}");

var letters = new List<char> { 'a', 'b', 'c',};
Console.WriteLine($"Check is = {GetSourceLable(letters)}");

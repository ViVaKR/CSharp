namespace Demo_Properties;
class Program
{
    static void Main(string[] args)
    {
        var customer = new Customer();
        customer.Id = "Viv";
        customer.Password = 123;
        customer.Password = 1234;
        customer.Password = 999;
        customer.Password = 4567;
        
        Console.WriteLine(customer.ToString());
    }
}

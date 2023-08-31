public class Person
{
    public string Name { get; set; }
    public Person()
    {
        Name = "unknown";
    }

    public override string ToString()
    {
        return Name;
    }
}

namespace BootCamp.Attrs;

public enum Animal
{
    Dog = 1,
    Cat,
    Bird
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]

/// <summary>
/// A custom attribute to allow a target to have a pet.
/// </summary>
public class AnimalTypeAttribute : Attribute
{
    /// <summary>
    /// Keep a variable internally ...
    /// </summary>
    protected Animal thePet;

    /// <summary>
    /// .. and show a copy to the outside world.
    /// </summary>
    /// <value></value>
    public Animal Pet { get; set; }

    /// <summary>
    /// The constructor is called when the attribute is set
    /// </summary>
    /// <param name="pet"></param>
    public AnimalTypeAttribute(Animal pet)
    {
        Pet = pet;
    }
}

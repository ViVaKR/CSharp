namespace BootCamp.Attrs;

/// <summary>
/// Define a custom parameter attribute that takes a single message argument.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class ArgumentUsageAttribute : Attribute
{
    /// <summary>
    /// Message is storage for the attribute message.
    /// </summary>
    /// <value></value>
    public string Message { get; set; }

    /// <summary>
    /// This is the attribute constructor.
    /// </summary>
    /// <param name="message"></param>
    public ArgumentUsageAttribute (string message)
    {
        Message = message;
    }

    /// <summary>
    /// Override ToString() to append the message to what the base generates.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{base.ToString()}: {Message}";
    }
}

/// <summary>
/// Define a custom parameter attribute that generates a GUID 
/// for each instance.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public class ArgumentIDAttribute : Attribute
{
    public Guid InstanceGuid { get; set; }
    
    public ArgumentIDAttribute ()
    {
        InstanceGuid = Guid.NewGuid();
    }

    public override string ToString()
    {
        return $"{base.ToString()}.{InstanceGuid}";
    }
}

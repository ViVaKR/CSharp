namespace BootCamp;

/// <summary>
/// AppSettings Meta Class
/// </summary>
public class Settings
{
    public required int KeyOne { get; set; }
    public required bool KeyTwo { get; set; }
    public required NestedSettings? KeyThree { get; set; }
}

public class NestedSettings
{
    public required string? Message { get; set; }
}

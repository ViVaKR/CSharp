namespace PwshModuleInCSharp;

public class NetAdpt
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DeviceId { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public string NetConnectionId { get; set; } = string.Empty;
    public bool PhysicalAdapter { get; set; }
}

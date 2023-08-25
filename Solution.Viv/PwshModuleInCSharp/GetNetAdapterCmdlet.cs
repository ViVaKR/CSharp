using System.Management;
using System.Management.Automation;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;

namespace PwshModuleInCSharp;
/// <summary>
/// Refs : `Using C# to Create PowerShell Cmdlets: The Basics` 
/// https://www.red-gate.com/simple-talk/development/dotnet-development/using-c-to-create-powershell-cmdlets-the-basics/#:~:text=Step%201%3A%20Create%20a%20Visual%20Studio%20project%20Step,container%20Step%207%3A%20Decorate%20your%20class%20with%20OutputTypeAttribute
/// </summary>
[SupportedOSPlatform("windows")]
[Cmdlet(VerbsCommon.Get, "NetAdpt")]
[OutputType(typeof(NetAdpt))]
public class GetNetAdptCmdlet : Cmdlet
{
    [Parameter(
        Position = 1, 
        ValueFromPipelineByPropertyName = true)]
    public string Name { get; set; } = string.Empty;

    [Parameter(
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true)]
    [Alias("mfg", "vendor")]
    public string[]? Manufacturer { get; set; }

    [Parameter(
        Position = 2, 
        ValueFromPipelineByPropertyName = true)]
    public bool? PhysicalAdapter { get; set; }

    [Parameter(Position = 3)]
    public int MaxEntries { get; set; } = 100;

    private IEnumerable<NetAdpt>? _wmiResults;

    private static IEnumerable<NetAdpt>? GetWmiResults()
    {
        const string wmiQuery = "Select * From Win32_NetworkAdapter";

        var result = new ManagementObjectSearcher(wmiQuery).Get()
        .Cast<ManagementObject>()
        .Select(BuildOutputObject);

        return result;
    }

    private static NetAdpt BuildOutputObject(ManagementBaseObject item)
    {
        return new NetAdpt
        {
            Name = (string)item[nameof(NetAdpt.Name)],
            Description = (string)item[nameof(NetAdpt.Description)],
            DeviceId = int.Parse((string)item[nameof(NetAdpt.DeviceId)]),
            Manufacturer = (string)item[nameof(NetAdpt.Manufacturer)],
            NetConnectionId = (string)item[nameof(NetAdpt.NetConnectionId)],
            PhysicalAdapter = (bool)item[nameof(NetAdpt.PhysicalAdapter)]
        };
    }
    protected override void BeginProcessing()
    {
        base.BeginProcessing();
        _wmiResults = GetWmiResults();
    }

    protected override void ProcessRecord()
    {
        var query = _wmiResults;
        if (query == null) return;
        if (Name != null)
        {
            query = query.Where(adapter =>
                adapter.Name != null && adapter.Name.StartsWith(Name));
        }
        // Just like "Name" above, this checks for prefix matches
        // but on multiple values instead of just a single value.
        if (Manufacturer != null)
        {
            query = query.Where(
                adapter =>
                    adapter.Manufacturer != null &&
                    Regex.IsMatch(adapter.Manufacturer,
                        string.Format("^(?:{0})", string.Join("|", Manufacturer))));
        }
        // Being a Boolean, an exact match is used here.
        if (PhysicalAdapter != null)
        {
            query = query.Where(adapter =>
                adapter.PhysicalAdapter == PhysicalAdapter);
        }
        
        query.Take(MaxEntries).ToList().ForEach(WriteObject);
    }
}

// (1) Import Module -> `Import-Module '.\bin\Debug\net7.0\PwshModuleInCSharp.dll' -Force`
// (2) Exec Pwsh -> `Get-NetAdpt -Manufacturer Microsoft`, `Get-Help Get-NetAdpt -Full`
// (3) Remove Module -> `Remove-Module PwshModuleInCSharp -Force`

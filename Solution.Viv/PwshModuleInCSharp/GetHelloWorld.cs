using System.Management.Automation;

namespace PwshModuleInCSharp;

[Cmdlet(VerbsCommon.Get, "HelloWorld")]
[OutputType(typeof(List<HelloWorld>))]
public class GetHelloWorld : Cmdlet
{
    protected override void ProcessRecord()
    {
        base.ProcessRecord();

        var result = new List<HelloWorld>
        {
            new HelloWorld { Name = "장길산", Description = "의적 1"},
            new HelloWorld { Name = "임꺽정", Description = "의적 2"},
            new HelloWorld { Name = "홍깍순", Description = "의적 3"}
        };

        WriteObject(result, true);
    }
}

public class HelloWorld
{
    [Parameter(
        Position = 0,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        ValueFromPipeline = true
    )]

    public string Name { get; set; } = string.Empty;

    [Parameter(
        Position = 1,
        Mandatory = true,
        ValueFromPipelineByPropertyName = true,
        ValueFromPipeline = true
    )]
    public string Description { get; set; } = string.Empty;
}

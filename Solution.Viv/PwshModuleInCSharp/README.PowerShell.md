# PowerShell Module

## Cmdlet Class Namming : `<verb><noun>Cmdlet.cs`

- `GetNetAdapterCmdlet.cs`

```cs
    [Cmdlet(VerbsCommon.Get, "NetAdapter")]
    public class GetNetAdapterCmdlet : Cmdlet
    {

    }

```

```bash
    Import-Module '.\bin\Debug\net7.0\PwshModuleInCSharp.dll' -Force

    Remove-Module PwshModuleInCSharp -Force
    
    Get-Command -Module PwshModuleInCSharp

    Get-Help Get-NetAdpt -Full
```

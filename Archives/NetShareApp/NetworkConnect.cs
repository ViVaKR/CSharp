
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;

namespace NetShareApp;

/// <summary>
/// 네트워크 공유폴더 연결 클래스
/// </summary>
public partial class NetworkConnect : IDisposable
{
	public event EventHandler<EventArgs>? Disposed;

	private readonly string _networkName = string.Empty;
	private readonly NetworkCredential _credentials;
	private readonly string _localName = string.Empty;

	public NetworkConnect(string networkName, NetworkCredential credentials, string localName)
	{
		_networkName = networkName;
		_credentials = credentials;
		_localName = localName;

		NetResource netResource = new()
		{
			Scope = ResourceScope.GlobalNetwork,
			Resourcetype = ResourceType.Disk,
			DisplayType = ResourceDisplaytype.Share,
			RemoteName = _networkName,
			LocalName = $"{_localName}:"
		};

		string userName = string.IsNullOrEmpty(_credentials.Domain) // 도메인 컨트롤러 체크
			? _credentials.UserName //  Not AD (일반)
			: $"{credentials.Domain}\\{_credentials.UserName}"; // AD (Active Directory)

		int result = WNetAddConnection2(netResource, _credentials.Password, userName, 0);

		if (result != 0)
			throw new Win32Exception(result, $"({result}) 공유폴더 연결오류");
	}

	public static bool IsDriveMapped(string driveLetter)
	{
		string[] DriveList = Environment.GetLogicalDrives();
		return DriveList.Any(t => t.Contains($"{driveLetter}:"));
	}

	public static int DisconnectNetworkDrive(string driveLetter, bool disconnect)
	{
		return WNetCancelConnection2($"{driveLetter}:", 0, disconnect);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			EventHandler<EventArgs>? handler = Disposed;
			handler?.Invoke(this, EventArgs.Empty);
		}

		DisconnectNetworkDrive(_networkName, true);
	}

	~NetworkConnect() => Dispose(false);

	/// <summary>
	/// DeskTop `API` 
	/// </summary>
	/// <param name="netResource"></param>
	/// <param name="password"></param>
	/// <param name="username"></param>
	/// <param name="flags"></param>
	/// <returns></returns>
	[DllImport("mpr.dll")]
	private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

	[DllImport("mpr.dll")]
	private static extern int WNetCancelConnection2(string name, int flags, [MarshalAs(UnmanagedType.Bool)] bool force);
}

[StructLayout(LayoutKind.Sequential)]
public class NetResource
{
	public ResourceScope Scope;
	public ResourceType Resourcetype;
	public ResourceDisplaytype DisplayType;
	public int Usage;
	public string LocalName = string.Empty;
	public string RemoteName = string.Empty;
	public string Comment = string.Empty;
	public string Provider = string.Empty;
}

public enum ResourceScope
{
	Connected = 1,
	GlobalNetwork,
	Remembered,
	Recent,
	Context
};

public enum ResourceType
{
	Any = 0,
	Disk = 1,
	Print = 2,
	Reserved = 8,
}

public enum ResourceDisplaytype
{
	Generic = 0x0,
	Domain = 0x01,
	Server = 0x02,
	Share = 0x03,
	File = 0x04,
	Group = 0x05,
	Network = 0x06,
	Root = 0x07,
	Shareadmin = 0x08,
	Directory = 0x09,
	Tree = 0x0a,
	Ndscontainer = 0x0b
}

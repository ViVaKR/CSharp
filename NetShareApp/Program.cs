using System.Net;
using System.Security.Principal;
using NetShareApp;
using System.Management.Automation;
using System.Collections.ObjectModel;

internal class Program
{
	private static readonly string _networkPath = @"\\192.168.219.105\1_WorkSpace";
	private static readonly string _driveLetter = "K";

	private static void Main()
	{

		if (NetworkConnect.IsDriveMapped(_driveLetter))
		{
			NetworkConnect.DisconnectNetworkDrive(_driveLetter, true);
		}

		AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
		Thread.Sleep(10);
		NetworkCredential credentials = new("Administrator", "B9037!m8947#");

		NetworkConnect? connection = default;
		try
		{
			using (connection = new NetworkConnect(_networkPath, credentials, _driveLetter))
			{
				string[] directories = Directory.GetDirectories(_networkPath, "*", SearchOption.TopDirectoryOnly);

				foreach (var item in directories)
				{
					Console.WriteLine(item);
				}
				NetworkConnect.DisconnectNetworkDrive(_driveLetter, true);
				connection?.Dispose();
			}
		}
		catch (Exception ex)
		{
			connection?.Dispose();
			Console.WriteLine($"{ex.Message}");
		}
	}
}


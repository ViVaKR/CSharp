using Microsoft.Win32;
using System.Runtime.Versioning;
using System.Security.Permissions;

namespace RWReg;

public class RegistryHelper
{
	// [SupportedOSPlatform("windows")]
	public static void Write(string key)
	{
		// Create a subkey named Viv under
		// Under HKEY_CURRENT_USER
		RegistryKey Viv = Registry.CurrentUser.CreateSubKey(key);


		using RegistryKey vivName = Viv.CreateSubKey("Name"),
		vivSettings = Viv.CreateSubKey("VivSettings");
		vivSettings.SetValue("Language", "Korean");
		vivSettings.SetValue("Level", "Intermediate");
		vivSettings.SetValue("ID", 903789);
	}

	/// <summary>
	/// Print Registry Keys
	/// </summary>
	public static void Read(RegistryKey registryKey)
	{
		// RegistryKey? regKey = Registry.CurrentUser.OpenSubKey(key);
		RegistryKey? regKey = registryKey;

		if(regKey == null) return;

		foreach (string valueName in regKey.GetSubKeyNames())
		{
			using var tempKey = regKey.OpenSubKey(valueName);
			if (tempKey == null) continue;
			Console.WriteLine($"{valueName, -20} :\t{tempKey.ValueCount}");
			foreach (string item in tempKey.GetValueNames())
			{
				Console.WriteLine($"{item,-20}: {tempKey.GetValue(item)}");
			}
		}
	}

	/// <summary>
	/// Delete Registry Key 
	/// </summary>
	/// <param name="key">SubKey Name String</param>
	public static void Delete(string key)
	{
		RegistryKey regKey = Registry.CurrentUser;

		string? result = regKey.GetSubKeyNames().Where(x => x.ToUpper().Equals(key.ToUpper())).FirstOrDefault();


		Console.WriteLine($"{result}");

		if (string.IsNullOrEmpty(result))
		{
			Console.WriteLine($"Registry Key : `{result}` 는 존재하지 않습니다. 삭제 작업을 취소합니다.");
			return;
		}
		Console.Write($"Delete Registry Key? `{result}` (Y/N) ");
		if (char.ToUpper(Convert.ToChar(Console.Read())) == 'Y')
		{
			Registry.CurrentUser.DeleteSubKeyTree(result);
			Console.WriteLine($"Registry Key `{result}` Deleted.");
		}
		else
		{
			Console.WriteLine($"Registry Key {result} Closed.");
			regKey.Close();
		}
	}

	public static void LocalMachine()
	{
		RegistryKey machine = Registry.LocalMachine;

		var keys = machine.GetSubKeyNames();

		foreach (var item in keys)
		{
			Console.WriteLine($"Local Machine Key : {item}");
		}
	}
}

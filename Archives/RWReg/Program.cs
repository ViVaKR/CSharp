// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using RWReg;


Dictionary<int, string> menu = new()
{
	{ 1, $"{KEYS.HKEY_CURRENT_USER} (Write)"},
	{ 2, $"{KEYS.HKEY_CURRENT_USER} (Read)"},
	{ 3, $"{KEYS.HKEY_CURRENT_USER} (Delete)"},

	{ 4, $"{KEYS.HKEY_LOCAL_MACHINE} (Write)"},
	{ 5, $"{KEYS.HKEY_LOCAL_MACHINE} (Read)"},
	{ 6, $"{KEYS.HKEY_LOCAL_MACHINE} (Delete)"},

	{ 7, $"{KEYS.HKEY_USERS} (Write)"},
	{ 8, $"{KEYS.HKEY_USERS} (Read)"},
	{ 9, $"{KEYS.HKEY_USERS} (Delete)"},

	{ 10, $"{KEYS.HKEY_CLASS_ROOT} (Write)"},
	{ 11, $"{KEYS.HKEY_CLASS_ROOT} (Read)"},
	{ 12, $"{KEYS.HKEY_CLASS_ROOT} (Delete)"},

	{ 13, $"{KEYS.HKEY_CURRENT_CONFIG} (Write)"},
	{ 14, $"{KEYS.HKEY_CURRENT_CONFIG} (Read)"},
	{ 15, $"{KEYS.HKEY_CURRENT_CONFIG} (Delete)"},
};

foreach (var item in menu)
{
	Console.WriteLine($"{item.Key}. {item.Value}");
}
Console.WriteLine();

Console.Write("실행할 메뉴를 선택하세요 (번호) >> ");
var luKey = "Viv";
var lmKey = "BCD00000000";

switch (Convert.ToInt32(Console.ReadLine()))
{
	case 1: RegistryHelper.Write(luKey); break;
	case 2:
		{
			var currentKey = Registry.CurrentUser.OpenSubKey(luKey);
			if (currentKey == null)
			{
				Console.WriteLine($"Registry Key : `{luKey}` 가 존재하지 않습니다. 확인 후 다시 시도하여 주세요!");
				return;
			}
			RegistryHelper.Read(currentKey);
		}; break;
	case 3: RegistryHelper.Delete(luKey); break;
	case 4:; break;
	case 5:
		{
			var localMashineKey = Registry.LocalMachine.OpenSubKey(lmKey);

			if (localMashineKey == null)
			{
				Console.WriteLine($"Registry Key : `{lmKey}` 가 존재하지 않습니다. 확인 후 다시 시도하여 주세요!");
				return;
			}
			RegistryHelper.Read(localMashineKey);
		}; break;
	case 6:; break;
	case 7:; break;
	case 8:; break;
	case 9:
		{
			RegistryKey? root = Registry.CurrentUser;
			RegistryHelper.GetSubKeys(root);
		}; break;
	case 10:; break;
	case 11:; break;
	case 12:; break;
	case 13:; break;
	case 14:; break;
	case 15:; break;
	default:; break;
}

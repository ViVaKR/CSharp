// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using RWReg;


Dictionary<int, string> menu = new()
{
	{ 1, "CurrentUser (Write)"},
	{ 2, "CurrentUser (Read)"},
	{ 3, "CurrentUser (Delete)"},
	{ 4, "LocalMashine (Write)"},
	{ 5, "LocalMashine (Read)"},
	{ 6, "LocalMashine (Delete)"}
};
foreach (var item in menu)
{
	Console.WriteLine($"{item.Key}. {item.Value}");
}
Console.WriteLine();

Console.Write("실행할 메뉴를 선택하세요 (번호) >> ");
var key = "Viv";

switch (Convert.ToInt32(Console.ReadLine()))
{
	case 1: RegistryHelper.Write(key); break;
	case 2:
		{
			var currentKey = Registry.CurrentUser.OpenSubKey(key);
			if (currentKey == null)
			{
				Console.WriteLine($"Registry Key : `{key}` 가 존재하지 않습니다. 확인 후 다시 시도하여 주세요!");
				return;
			}
			RegistryHelper.Read(currentKey);
		}; break;
	case 3: RegistryHelper.Delete(key); break;
	case 4:; break;
	case 5: RegistryHelper.LocalMachine(); break;
	case 6:; break;
	default:; break;
}

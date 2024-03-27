using System.Net;
using System.Security.Principal;
using NetShareApp;

internal class Program
{
	// 공유폴더 (1)
	private static readonly List<string> NetPaths = new()
	{
		@"\\192.168.219.104\1_WorkSpace",
		@"\\192.168.219.104\2_WorkSpace",
		@"\\192.168.219.104\3_WorkSpace"
	};

	// 공유폴더 드라이브 명
	private static readonly string driveLetter = "K";

	// 다운로드할 파일목록
	private static readonly List<string> _downloads = new() { "111.zip", "222.zip", "333.zip" };

	private static void Main()
	{
		FileCopyFromSharedFolder(NetPaths[0], driveLetter);
	}

	/// <summary>
	/// (트리거 메서드) 
	/// </summary>
	/// <param name="_networkPath">공유폴더</param>
	/// <param name="_driveLetter">공유폴더 드라이브 명</param>
	private static void FileCopyFromSharedFolder(string _networkPath, string _driveLetter)
	{
		if (NetworkConnect.IsDriveMapped(_driveLetter))
		{
			NetworkConnect.DisconnectNetworkDrive(_driveLetter, true);
		}

		AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
		Thread.Sleep(10); // 느낌적 스카카토 (즉, 없어도 됨)

		// 공유폴더 연결 자격증명 (아이디, 비밀번호)
		NetworkCredential credentials = new("Administrator", "B9037!m8947#"); // 아이디, 비밀번호

		NetworkConnect? connection = default;

		try
		{
			// 연결
			using (connection = new NetworkConnect(_networkPath, credentials, _driveLetter))
			{
				// 연결후 zip 파일 목록 작성
				var files = Directory.GetFiles(_driveLetter + @":\", "*.zip", SearchOption.TopDirectoryOnly).ToList();
				
				// 다운로드할 파일 목록과 연결된 공유 폴더 파일명 비교 후 해당 파일 목록 작성
				var result = files.Where(x => _downloads.Any(y => x.Contains(y))).ToList();

				foreach (var item in result)
				{
					var fi = new FileInfo(item);
					Console.WriteLine($"{item}"); // 다운로드 하는 파일 명 출력

					// 문의에 대한 답변 (파일 카피, 대상 폴더 지정)
					File.Copy(fi.FullName, $@"D:\Temp\{fi.Name}"); 
				}

				// 네크워크 드라이브 해제
				NetworkConnect.DisconnectNetworkDrive(_driveLetter, true);

				// 연결 자원 해제
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


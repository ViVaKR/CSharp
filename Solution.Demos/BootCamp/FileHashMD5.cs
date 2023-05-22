using System.Security.Cryptography;

namespace BootCamp;
public class FileHashMD5
{
    public void Run()
    {
        CreateFileDB();
        CompareFiles();
    }

    // 최초 파일 해쉬정보구성하기
    public readonly Dictionary<string, byte[]> dic = new Dictionary<string, byte[]>();
    private const string directory = @"./files";
    public void CreateFileDB()
    {
        // 원본 파일 위치 파일들

        var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                {
                    var hash = md5.ComputeHash(stream);
                    dic.Add(file, hash);
                }
            }
        }
    }

    // 비교하기, 비교 후 데이터베이스 목록 갱신 파트는 생략되어 있음.. 
    public void CompareFiles()
    {
        // 비교 대상 파일들
        var files = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

        foreach (string file in files)
        {
            FileInfo fi = new FileInfo(file);
            byte[] value = dic.FirstOrDefault(x => new FileInfo(x.Key).Name.Equals(fi.Name)).Value;

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fi.FullName))
                {
                    var hash = md5.ComputeHash(stream);
                    bool tf = hash.SequenceEqual(value);

                    string message = tf ? "동일" : "다름 " + fi.LastWriteTime.ToString("U");
                    Console.WriteLine($@"{fi.Name} => {message}");
                }
            }
        }
    }
}


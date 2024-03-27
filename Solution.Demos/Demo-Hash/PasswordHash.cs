using System.Security.Cryptography;
using System.Text;

namespace Demo_Hash
{
    public class PasswordHash
    {
        public void Start()
        {
            CreatePasswordHash("G8934$s8049@", out byte[] passwordHash, out byte[] passwordSalt);

            string salt = BitConverter.ToString(passwordSalt);
            string hash = BitConverter.ToString(passwordHash);
            Console.WriteLine();
            Console.WriteLine("(hash)");
            Console.WriteLine(hash);
            Console.WriteLine();
            Console.WriteLine("(salt)");
            Console.WriteLine(salt);
            
            bool check = VerifyPasswordHash("G8934$s8049@", passwordHash, passwordSalt);
            Console.WriteLine($"\n비밀번호의 일치 여부 : {check}");
        }

        // 비밀번호 암호화 처리
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hamc = new HMACSHA512();
            passwordSalt = hamc.Key;
            passwordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        // 암호 해독하여 비밀번호 일치 확인하기
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            Console.Write("\n(compute)\n");
            Console.WriteLine(BitConverter.ToString(computedHash));
            
            Console.Write("\n(pasword)\n");
            Console.WriteLine(BitConverter.ToString(passwordHash));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}

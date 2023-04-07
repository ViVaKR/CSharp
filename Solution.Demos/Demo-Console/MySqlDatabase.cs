
using MySqlConnector;

namespace Demo_Console
{
    public class MySqlHelper
    {
        public void Start()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "172.30.1.10",
                Port = 33060,
                Database = "데이터베이스",
                UserID = "아이디",
                Password = "비밀번호"
            };

            using var conn = new MySqlConnection(builder.ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Member";

            using var reader = cmd.ExecuteReader();
            var members = new List<Member>();

            while (reader.Read())
            {
                var member = new Member
                {
                    Id = reader.GetInt32(nameof(Member.Id)),
                    UserName = reader.GetString(nameof(Member.UserName)),
                    Addr = reader.GetString(nameof(Member.Addr))
                };

                members.Add(member);
            }

            Console.WriteLine("== Print ==");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Id} {member.UserName} {member.Addr}");
            }
        }
    }

    public class Member
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Addr { get; set; }
    }
}


// dotnet add package MySqlConnector

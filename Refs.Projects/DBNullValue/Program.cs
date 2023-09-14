using Microsoft.Data.SqlClient;

var conStr = "Server=172.30.1.10,59273;Initial Catalog=Demo;Integrated Security=false;User ID=아이디;Password=비밀번호;TrustServerCertificate=True;";

using (var conn = new SqlConnection(conStr))
{
    conn.Open();
    var sql = "insert into Test values(12, 100, @Addr)";
    var cmd = new SqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Addr", DBNull.Value);
    cmd.ExecuteNonQuery();

    Console.WriteLine("완료");
}

string script = File.ReadAllText(@"E:\someSqlScript.sql");

// split script on GO command
IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

Connection.Open();

foreach (string commandString in commandStrings)
{
    if (commandString.Trim() != "")
    {
        using (var command = new SqlCommand(commandString, Connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
Connection.Close();


public partial class ExcuteScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";

        string script = File.ReadAllText(@"E:\Project Docs\MX462-PD\MX756_ModMappings1.sql");

        SqlConnection conn = new SqlConnection(sqlConnectionString);

        Server server = new Server(new ServerConnection(conn));

        server.ConnectionContext.ExecuteNonQuery(script);
    }
}

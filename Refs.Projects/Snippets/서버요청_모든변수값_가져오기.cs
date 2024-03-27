// 서버요청 모든 변수값 가져오기
int i, j;
NameValueCollection coll = Request.ServerVariables;
string[] keys = coll.AllKeys;
for (i = 0; i < keys.Length; i++)
{
    Response.Write("Key: " + keys[i] + "<br>");
    string[] values = coll.GetValues(keys[i]);
    for (j = 0; j < values.Length; j++)
    {
        Response.Write("Value " + j + ": " + Server.HtmlEncode(values[j]) + "<br>");
    }
}

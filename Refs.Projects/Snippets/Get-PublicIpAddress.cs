바_폰트.EditValue = WindowsFormsSettings.DefaultFont.Name;

// API IP Address response
https://api.ipify.org					            text	98.207.254.136
https://api.ipify.org?format=json			        json	{"ip":"98.207.254.136"}
https://api.ipify.org?format=jsonp			        jsonp	callback({"ip":"98.207.254.136"});
https://api.ipify.org?format=jsonp&callback=getip	jsonp	getip({"ip":"98.207.254.136"});

// Get Public IP Address Code Snippet
var httpClient = new HttpClient();
var ip = await httpClient.GetStringAsync("https://api.ipify.org");
Console.WriteLine($"My public IP address is: {ip}");

// Get User Public IP Address
protected void GetUser_IP()
{
    string VisitorsIPAddr = string.Empty;
    if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
    {
        VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
    }
    else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
    {
        VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
    }
    uip.Text = "Your IP is: " + VisitorsIPAddr;
}

using System.Text;

using System.Net;

namespace Libs;

public static class Utility
{
    /// <summary>
    /// 인터넷 연결여부 체크
    /// </summary>
    /// <returns></returns>
    public static bool IsInternetConnected()
    {
        const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
        const string NCSI_TEST_RESULT = "Microsoft NCSI";
        const string NCSI_DNS = "dns.msftncsi.com";
        const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

        try
        {
            var client = new HttpClient();
            var result = client.GetStringAsync(NCSI_TEST_URL);

            if (!result.Result.Equals(NCSI_TEST_RESULT)) return false;

            Console.WriteLine(result.Result);

            var dnsHost = Dns.GetHostEntry(NCSI_DNS);

            int count = dnsHost.AddressList.Count();
            if (count < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 날짜 포맷
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public static string TimeFormat(this TimeSpan timeSpan)
    {
        string format;

        if (timeSpan.TotalHours >= 1)
        {
            format = @"hh\:mm\:ss\:fff";
        }
        else if (timeSpan.TotalMinutes >= 1)
        {
            format = @"mm\:ss\:fff";
        }
        else
        {
            format = @"ss\:fff";
        }

        return timeSpan.ToString(format);
    }

    /// <summary>
    /// 웹 페이지 내용 가져오기
    /// </summary>
    /// <param name="url">대상 URL</param>
    /// <returns></returns>
    public static string GetWebPage(string url) {

        try
        {
            var client = new HttpClient();
            string html = string.Empty;
            var stream = client.GetStreamAsync(url);  //(HttpWebRequest)HttpClient.Create(url);
            using (var reader = new StreamReader(stream.Result, Encoding.UTF8))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }
        catch
        {
            return "null";
        }
    }
}

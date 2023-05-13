
using System.Net.NetworkInformation;

namespace Helper;

public static class PingTest
{
    //확장메서트 : ipAddress.Ping();
    public static void Ping(this string url)
    {
        try
        {
            var myPing = new Ping();
            var buffer = new byte[32];
            var timeout = 120;
            var options = new PingOptions { DontFragment = true, Ttl = 128 };
            var reply = myPing.Send(url, timeout, buffer, options);
            var result = reply?.Status == IPStatus.Success
                ? $"\t핑테스트 성공!\tTTL {reply?.Options?.Ttl}\ttime: {reply?.RoundtripTime}ms"
                : "\t- ";

            Console.WriteLine($"{url.PadLeft(15)} -> {result}");
        }
        catch
        {
            Console.WriteLine($"{url.PadLeft(15)} ->\t핑테스트 실패!");
        }
    }
}

/* 


            use the default Ttl value which is 128,
            but change the fragmentation behavior.
            options.DontFragment = true;

            Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = pingSender.Send (args[0], timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine ("Address: {0}", reply.Address.ToString ());
                Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
            } */

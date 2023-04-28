using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Helper;

public class Nets
{

    // Create UDP Server (포트넘버(임의 2001 ~ 60000 사이 권장): 12345, AddressFamily 생략가능)
    private UdpClient udpServer = new UdpClient(12345, AddressFamily.InterNetwork);
    
    // Create UDP Client
    private UdpClient client = new UdpClient();

    /// <summary>
    /// UDP Server
    /// </summary>
    public void StartUDPServer()
    {
        // Loop For Receive Client Data and Reply Success Received Info
        while (true)
        {
            // 서버 접속자를 위한 수신 대기 듕 ...
            // 서버의 모든 아이피와 포트번호 = 12345 번에서 수신대기)
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 12345);

            // 클라이언트 수신 발생 시 처리하는 작업 (바이트 형식 데이터 저장, 및 회신을 위하여 클라이언트 엔드 포인트 저장)
            byte[] data = udpServer.Receive(ref remoteEP);

            // 수신된 바이트를 string 으로 변환
            string recData = Encoding.UTF8.GetString(data);

            // 종료 메시지 설정 : 메시지 중 "Quit" 란 메시지 수신시에 서버 종료 하고 서버 대기 루프 벗어남 
            if (recData.Equals("Quit"))
            {
                udpServer.Close();
                break;
            }
            // 친절한게 응답하기: 궁디 팡팡 포상성 회신 메시지 작성
            byte[] replyData = Encoding.UTF8.GetBytes("Connection Success! : Received Data = " + recData);

            // 클라이언트에게 메시지 전송하기
            udpServer.Send(replyData, replyData.Length, remoteEP);
        }
    }

    public void StopAll()
    {
        udpServer.Close();
        udpServer.Dispose();

        client.Close();
        client.Dispose();
    }

    /// <summary>
    /// UDP Client
    /// </summary>
    public void UdpClient()
    {
        try
        {


            // Create Server EndPoint for UDP Server Connection  
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);

            // Connection using UDP Client
            client.Connect(ep);

            // Create Test message  (텍스트 박스에 글을 쓴 후 전송을 위해 엔터 치는 그림과 동일함, )
            string sendMessage = "Hi! Fine Thanks And You!";

            // Convert to string to bytes for send
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendMessage);

            // Send Message (bytes)
            client.Send(sendBytes, sendBytes.Length);

            // Then receive data (bytes) : 위에서 메시지 전송후 서버로 부터 회신 메시지를 수신 하기위한 재빠른 태세 전환 모드 (실제론 이렇게 하지 않고 비동기 처리를 하는 부분)
            byte[] receivedData = client.Receive(ref ep);

            // Then bytes convert to string
            string receivedString = Encoding.UTF8.GetString(receivedData);

            // 폼 컨트롤 중 리치텍스트 박스에 메시지 표현하기
            Console.WriteLine($"# 수신된 시간 => {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("# 발신자 EndPoint => " + ep);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("# 수신 메시지 => " + receivedString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

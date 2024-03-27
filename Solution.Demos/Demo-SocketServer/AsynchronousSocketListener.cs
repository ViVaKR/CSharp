using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Demo_SocketServer
{
    public class AsynchronousSocketListener
    {
        public Socket listener;
        public IPAddress ipAddress;
        public IPEndPoint localEndPoint;

        private Dictionary<string, Socket> clients;

        public ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
            ipAddress = IPAddress.Parse("172.30.1.10");
            localEndPoint = new IPEndPoint(ipAddress, 50005);
            clients = new Dictionary<string, Socket>();
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    allDone.Reset();
                    Console.WriteLine($"{localEndPoint}  Waiting for a connection... ({clients.Count})");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            if (ar.AsyncState == null) return;

            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            clients?.Add(Guid.NewGuid().GetHashCode().ToString(), handler);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            if (ar.AsyncState == null) return;
            String content = String.Empty;

            StateObject state = (StateObject)ar.AsyncState;
            if (state.workSocket == null) return;
            Socket handler = state.workSocket;

            // Read data from the client socket.
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));

                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                    Send(handler, content);
                }
                else
                {
                    handler.BeginReceive(state.buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state);
                }
            }
        }

        private void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                if (ar.AsyncState == null) return;
                Socket handler = (Socket)ar.AsyncState;

                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

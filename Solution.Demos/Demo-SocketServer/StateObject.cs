using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Demo_SocketServer
{
    public class StateObject
    {
        // Size of receive buffer.  
        public readonly int BufferSize;

        // Receive buffer.  
        public byte[] buffer;

        // Received data string.
        public StringBuilder sb;

        public Socket? workSocket;

        public StateObject()
        {
            BufferSize = 1024;
            buffer = new byte[BufferSize];
            sb = new StringBuilder();
        }
    }
}

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GasStation.Application.Server
{
    public class TcpServer
    {
        public TcpServer(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        public async Task Start(Delegate method)
        {
            var listener = new TcpListener(_ip, _port);
            listener.Start();

            while (true)
            {
                var socket = await listener.AcceptSocketAsync();

                socket.Receive(buffer);

                string data = Encoding.UTF8.GetString(buffer);

                method.DynamicInvoke(data);
            }
        }

        private readonly IPAddress _ip;

        private readonly int _port;

        private byte[] buffer = new byte[1024];
    }
}

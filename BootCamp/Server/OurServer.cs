using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Server
{

    class OurServer
    {
        TcpListener _server;

        public OurServer(string ipAddress,int portNum)
        {
            _server = new TcpListener(IPAddress.Parse(ipAddress),portNum);
            _server.Start();

            LoopClients();
        }

        void LoopClients()
        {
            while(true)
            {
                TcpClient _client = _server.AcceptTcpClient();

                Thread _thread = new Thread(() => HandleClient(_client));
                _thread.Start();
            }
        }

        void HandleClient(TcpClient _client)
        {
            StreamReader _sReader = new StreamReader(_client.GetStream(),Encoding.UTF8);
            StreamWriter _sWriter = new StreamWriter(_client.GetStream(),Encoding.UTF8);

            while (true)
            {
                string message = _sReader.ReadLine();
                Console.WriteLine($"Recieved: {message}");
                Console.Write("> ");
                string answer = Console.ReadLine();
                _sWriter.WriteLine($"Message Recieved: {message}; Answer: {answer};");
//                _sWriter.Write("> ");
                _sWriter.Flush();

            }
        }

    }

}
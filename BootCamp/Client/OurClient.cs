using System.Net.Sockets;
using System.Text;
using System.Net;

namespace Client
{
    class OurClient
    {
        private TcpClient _client;
        StreamWriter _sWriter;
        StreamReader _sReader;

        public OurClient(string ipAddress, int portNum)
        {
            _client = new TcpClient(ipAddress,portNum);
            _sWriter = new StreamWriter(_client.GetStream(),Encoding.UTF8);
            _sReader = new StreamReader(_client.GetStream(),Encoding.UTF8);

            HandleCommunication();
        }

        void HandleCommunication()
        {
            while(true)
            {
                Console.Write("> ");
                string? message = Console.ReadLine();
                _sWriter.WriteLine(message);
                _sWriter.Flush();
                string? answer = _sReader.ReadLine();
                Console.WriteLine($"from Server: {answer}");
 
            }
        }
    }
}
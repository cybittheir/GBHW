namespace Server
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Сервер включён");
            OurServer _server = new OurServer("127.0.0.1",5555);
        }
    }
}
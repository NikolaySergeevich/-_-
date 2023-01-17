namespace Server
{
    class Program// этот класс будет работать с клиентом
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Это наш сервер");
            OurServer server = new OurServer();
        }
    }
}
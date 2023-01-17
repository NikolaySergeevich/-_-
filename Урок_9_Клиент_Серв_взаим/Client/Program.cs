namespace Client
{
    class Program// этот класс будет работать с клиентом
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Это наш клиент");
            OurClient co_worcker = new OurClient();// ссылаемся на класс OurClient, называем co_worcker и создаём нового клиента вызовом метода new OurClient
                                                    //создали клиент при помощи конструктора new (мутот в файле OurClient.cs) => 
                                                    // и в этом методе мы дали ему ip, порт. А с помощью строки № 16 сделали поток,
                                                    // работает с клиентом. С помощтю client.GetStream() мы вытащили поток из client и 
                                                    // засунули в переменную sReader. через эту переменную, а тоесть поток мы можем
                                                    // записать/передать данные на сервер.
         
        }
    }
}
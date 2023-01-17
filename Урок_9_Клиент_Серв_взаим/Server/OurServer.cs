using System.Net.Sockets;
using System.Net;
using System.Text;
namespace Server
{
    class OurServer
    {
        TcpListener server; //TcpListener это слушатель подключений. Он ждёт пока на сервер что-то придёт. 

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);// создаём сервер и нашему слушателю(TcpListener) даём адрес и порт по которому он будет сидеть и ждать
                                                                         // пока ему что-нибудь не пришлют
            server.Start(); //сразу запускаем сервер.

            LookClients();
        }
        // теперь нужно создать метод, который как и в клиенте, который постоянно держит связь с сервером, будет постоянно ждать от 
        // клиента данные
        void LookClients() //функцияЮ которая постоянно будет ловить клиентов
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); //как только на сервер прилетает какой-то клиент (AcceptTcpClient). Т.е. подключается.
                                                             //то создаётся клиент на сервере, который будем обрабатывать
                // теперь каждого отдельно клиента нужно положить в отдельный поток
                Thread thread = new Thread(() => HandleClient(client)); //создаётся отдельный поток для клиента
                thread.Start();
            }
        }
        void HandleClient(TcpClient client) //метод, который будет держать соединение от сервера с клиентом. Принимает клиента, к которору
                                            //будет создаваться свой поток внутри метода
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);// от конкретного соединения мы получаем поток и создаём обратный к клиенту конкретному

            while (true) // бесконечно  будем работат с одним клиентом, как только он подсоеденился к серверу
            {
                string massag = sReader.ReadLine();
                Console.WriteLine($"клиент написал - {massag}");
            }
        }
    }
}
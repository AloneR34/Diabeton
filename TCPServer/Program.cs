using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;
using System.Data;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;





namespace SocketTcpServer
{
    class Program
    {
        static int port = 8005; // порт для приема входящих запросов
        public static void Main(string[] args)
        {
            DB db = new DB();//Экземпляр класса Базы Данных
            //db.openConnection();//Устанавливаем подключение
            Broker broker = new Broker();
            broker.Setup();
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                Console.WriteLine(DateTime.Now.ToShortTimeString() + " КУИ добавлен");
                string[] words = { "s1", "s2", "s3", "s4" };
                string s1;
                string s2;
                string s3;
                string s4;
                string s5;
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // получаем сообщение

                    StringBuilder builder1 = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] data = new byte[256]; // буфер для получаемых данных


                    do
                    {
                        bytes = handler.Receive(data);
                        builder1.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        if (builder1.ToString().Contains(' '))
                        {
                            words = builder1.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        }
                        else words[0] = builder1.ToString();
                    }

                    while (handler.Available > 0);
                    s1 = words[0];
                    s2 = words[1];
                    s3 = words[2];
                    s4 = words[3];
                    s5 = words[4];
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + s1);

                    if (s1 != "Авторизация" & s1 != "Регистрация")
                    {
                        string message = builder1.ToString();
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                        // закрываем сокет
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }

                    if (s1 == "Авторизация")
                    {
                        string mess = db.avtorizasia(words[1], words[2]);
                        data = Encoding.Unicode.GetBytes(mess);
                        handler.Send(data);
                        // закрываем сокет
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        // handler.Send(data);
                    }

                    if (s1 == "Регистрация")
                    {
                        string mess = db.registrasia(words[1], words[2], words[3], words[4]);
                        data = Encoding.Unicode.GetBytes(mess);
                        handler.Send(data);
                        // закрываем сокет
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();

                    }

                     if ( s1 == "Запрос_к_MQTT") //broker.getMessage
                    {
                        string mess = db.search_ucol();
                        data = Encoding.Unicode.GetBytes(mess);
                        handler.Send(data);
                        // закрываем сокет
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    class DB
    {

        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=LordLedi@T140;database=diabeton2");


        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        //public MySqlConnection getConnection()
        //{
        //return conn;
        //}
        public string avtorizasia(string login, string password)
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();

            MySqlCommand comand = new MySqlCommand("SELECT * FROM `person` where `login` = @Login AND `password` = @Password", getConnection());

            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = login;
            comand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;

            openConnection();
            adapter.SelectCommand = comand;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                message = "Пользователь найден";
                Console.WriteLine(message);
            }
            else message = " ";
            closeConnection();
            return message;
        }

        public string registrasia(string login, string password, string toggle, string key)
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();


            MySqlCommand comand = new MySqlCommand("INSERT INTO `person` (`id_person`,`login`,`password`,`status`,`key`) VALUES ('1',@Login,@Password,@toggle,@key)", getConnection());

            comand.Parameters.Add("@Login", MySqlDbType.VarChar).Value = login;
            comand.Parameters.Add("@Password", MySqlDbType.VarChar).Value = password;
            comand.Parameters.Add("@toggle", MySqlDbType.VarChar).Value = toggle;
            comand.Parameters.Add("@key", MySqlDbType.VarChar).Value = key;
            message = "Пользователь добавлен";

            openConnection();

            if (comand.ExecuteNonQuery() == 1)
                message = "Пользователь добавлен";
            else
                message = "Данные уже существуют";

            closeConnection();

            Console.WriteLine(message);
            return message;
        }

        public string ukol_new ()
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();


            //Broker broker = new Broker();
            //string str=broker.getMessage();

            MySqlCommand comand = new MySqlCommand("INSERT INTO `ukol` (`id_ukol`,`datatime`) VALUES ('1','2022-05-30 13:41:10')", getConnection()); //@str

            //comand.Parameters.Add("@str", MySqlDbType.VarChar).Value = str;
            openConnection();

            if (comand.ExecuteNonQuery() == 1)
                message = "Укол добавлен";
            else
                message = "Данные не добавились";

            closeConnection();
            
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = 8005; // порт для приема входящих запросов
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listenSocket.Bind(ipPoint);
            Socket handler = listenSocket.Accept();
            StringBuilder builder1 = new StringBuilder();
            byte[] data = new byte[256]; // буфер для получаемых данных
            message = builder1.ToString();
            data = Encoding.Unicode.GetBytes(message);
            handler.Send(data);
            // закрываем сокет
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            return message;
        }
        public string search_ucol()
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();
           

            MySqlCommand comand = new MySqlCommand("SELECT `datatime` FROM `ukol` where `id_ukol` like @id", getConnection());

            comand.Parameters.Add("@id", MySqlDbType.VarChar).Value = 1;


            openConnection();
            adapter.SelectCommand = comand;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                message = dt.Rows[1][2].ToString();
                Console.WriteLine(message);
            }

            else message = " ";
            closeConnection();
            return message;
        }

        public string date_medicine(string date, int id)
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();


            MySqlCommand comand = new MySqlCommand("UPDATE `child` SET `date_of_prescription`= @date WHERE `id_child`=@id", getConnection());
            comand.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            comand.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;

            openConnection();

            if (comand.ExecuteNonQuery() == 1)
                message = "Дата была добавлена";
            else
                message = "Дата не была добавлена";

            closeConnection();

            Console.WriteLine(message);
            return message;
        }
        public string KUI(double KUI, int id)
        {
            string message;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            DB db = new DB();


            MySqlCommand comand = new MySqlCommand("UPDATE `child` SET `KUI`= @KUI WHERE `id_child`=@id", getConnection());

            comand.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            comand.Parameters.Add("@KUI", MySqlDbType.VarChar).Value = KUI;


            openConnection();

            if (comand.ExecuteNonQuery() == 1)
                message = "КУИ добавлен";
            else
                message = "КУИ не добавлен";

            closeConnection();

            Console.WriteLine(message);
            return message;
        }

    }

    class Broker
    {
        DB db = new DB();
        MqttClient mqttClient;
        string str1;
        public void Setup()
        {
            Task.Run(() =>
            {
                mqttClient = new MqttClient("broker.hivemq.com");
                mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                mqttClient.Subscribe(new string[] { "Application1/Message" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                mqttClient.Connect("Application1");
            });
        }


        private void MqttClient_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
        var message = Encoding.UTF8.GetString(e.Message);
            str1 = message;
            Console.WriteLine(message + " " + DateTime.Now);
        }

        public string getMessage()
        {
            db.ukol_new();
            return str1;
        }
    }
}

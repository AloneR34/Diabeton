using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class ServerConn : MonoBehaviour
{
    // адрес и порт сервера, к которому будем подключаться
    static int port = 8005; // порт сервера
    static string address = "127.0.0.1"; // адрес сервера
    
    public string Message(string message_to_server, string text1, string text2, string text3 )
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);
            string message = message_to_server + " " + text1 + " " + text2 + " " + text3;
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);

            // получаем ответ
            data = new byte[256]; // буфер для ответа
            //StringBuilder builder = new StringBuilder();
            int bytes = 0; // количество полученных байт

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

            }
            while (socket.Available > 0);
            Console.WriteLine("ответ сервера: " + builder.ToString());



            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();

        return builder.ToString();
    }

}


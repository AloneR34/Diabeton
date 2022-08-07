using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


public class AvtoToggleChild : MonoBehaviour
{
    public string mess;
    public Toggle child_Toggle;
    public Toggle parent_Toggle;
    public InputField login;
    public InputField password;
    public string toggle;
    static int port = 8005; // порт сервера
    static string address = "127.0.0.1"; // адрес сервера

    public void between_scenes()
    {

        //Устанавливаем подключение
        
        if (child_Toggle.isOn == true)
        {
            //SceneManager.LoadScene(1);
            toggle = "child";
        }
        if (parent_Toggle.isOn == true)
        {
            //SceneManager.LoadScene(2);
            toggle = "parent";
        }


        message("Авторизация");
       if (message("Авторизация") == "Пользователь найден")
        {
            if (child_Toggle.isOn == true)
            {
                SceneManager.LoadScene(1);
            }
            if (parent_Toggle.isOn == true)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public string message(string message_to_server)
    {
        StringBuilder builder = new StringBuilder();
        try
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);
            string message = message_to_server + " " + login.text + " " + password.text + " " + toggle;
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
            mess = builder.ToString();


            // закрываем сокет
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();
        return mess;
    }
}
    



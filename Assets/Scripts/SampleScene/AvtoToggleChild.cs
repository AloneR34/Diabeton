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
    static int port = 8005; // ���� �������
    static string address = "127.0.0.1"; // ����� �������

    public void between_scenes()
    {

        //������������� �����������
        
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


        message("�����������");
       if (message("�����������") == "������������ ������")
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
            // ������������ � ���������� �����
            socket.Connect(ipPoint);
            string message = message_to_server + " " + login.text + " " + password.text + " " + toggle;
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);

            // �������� �����
            data = new byte[256]; // ����� ��� ������
            //StringBuilder builder = new StringBuilder();
            int bytes = 0; // ���������� ���������� ����

            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            Console.WriteLine("����� �������: " + builder.ToString());
            mess = builder.ToString();


            // ��������� �����
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
    



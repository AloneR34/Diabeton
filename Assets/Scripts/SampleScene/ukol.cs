using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class ukol : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PanelProfil;
    public Text Text;
    public string mess;
    static int port = 8005; // ���� �������
    static string address = "127.0.0.1"; // ����� �������

    public void ButtonClick()
    {
            Text.text = message("������_�_MQTT");
                if (PanelProfil != null)
                {
                    bool isActive = PanelProfil.activeSelf;
                    PanelProfil.SetActive(!isActive);
                }

                if (Panel != null)
                {
                    bool isActive = Panel.activeSelf;
                    Panel.SetActive(!isActive);
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
            string message = message_to_server;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class Enter_from_Reg : MonoBehaviour
{
    public GameObject PanelRegistrasia;
    public GameObject PanelProfile;
    public string mess;
    public Toggle child_Toggle;
    public Toggle parent_Toggle;
    public InputField login;
    public InputField Key;
    public InputField password;
    public GameObject PanelError;
    public Text TextError;
    public Text TextDebug;
    public int toggle;
    static int port = 8005; // ���� �������
    static string address = "127.0.0.1"; // ����� �������

    public void ButtonRegToProfClick()//������ ����� � ������ �����������
    {

        if (child_Toggle.isOn == true)
        {
            //SceneManager.LoadScene(1);
            toggle = 1;
        }
        if (parent_Toggle.isOn == true)
        {
            //SceneManager.LoadScene(2);
            toggle = 0;
        }
        //TextDebug.text = message("�����������");
       if (message("�����������") == "������������ ��������")
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

        else
        {
            TextError.text = "������� ������ ������";
            if (PanelError != null)
            {
                bool isActive = PanelError.activeSelf;
                PanelError.SetActive(!isActive);
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
            string message = message_to_server + " " + login.text + " " + password.text + " " + toggle.ToString() + " " + Key.text;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class KlientToServer : MonoBehaviour
{
        // ����� � ���� �������, � �������� ����� ������������
        static int port = 8005; // ���� �������
        static string address = "127.0.0.1"; // ����� �������


        public void Main()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // ������������ � ���������� �����
                socket.Connect(ipPoint);
                //Console.Write("������� ���������:" );
                string message = DateTime.Now.ToString() + " ������� �������";
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // �������� �����
                data = new byte[256]; // ����� ��� ������
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // ���������� ���������� ����

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                Console.WriteLine("����� �������: " + builder.ToString());

                // ��������� �����
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }

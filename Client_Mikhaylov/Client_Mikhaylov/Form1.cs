using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
namespace Client_Mikhaylov
{
  
    public partial class Form1 : Form
    {
        int status = 0;
        int port;
        static SocketClient client;        //содержит ip и port клиента
        public Form1()
        {

            InitializeComponent();
        }
        private void connection()             //подключение к серверу
        {

            client = new SocketClient("127.0.0.1", this.port);  //создаем сокет под нашего клиента
            bool smt = client.Connect();                        //подключаемся к серверу

            if (smt)                                           //если подключились
            {
                if (port == 9000)                               //порт первого сервера
                    list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add("Сервер 1 - подключен"); }));
                else
                    list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add("Сервер 2 - подключен"); }));
                Status();
            }
            else
            {
                if (port == 9000)
                    list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add("Ошибка подключения - Сервер 1"); }));
                else
                    list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add("Ошибка подключения - Сервер 2"); }));
            }
        }
        private void Status()
        {
            for (; ; )                                                          //бесконечный цикл
            {
                client.Receive();                                               //выводим информацию из сокета
                try
                {
                    if (client.ReceiveMessage[client.ReceiveMessage.Count - 1] == "[end]") break; //закончился ли поток данных
                }
                catch
                { }
            }


            for (int i = 0; i < client.ReceiveMessage.Count-2;)
            {
                if (client.ReceiveMessage[i] != "[end]")
                    list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add(client.ReceiveMessage[i]); })); //выводит в лист бокс
                client.ReceiveMessage.RemoveAt(i);                                                              //удаляем сообщение которое вывели
            }

        }

        private void button1_Click(object sender, EventArgs e)                   //кнопка подключения к серверу 1
        {
            port = 9000;                                                       //определяем порт для подключения
            Thread connect = new Thread(connection);                           //создаем поток для void connection
            connect.Start();                                                   //запуск потока
            connect.IsBackground = true;                                       //переводим поток в фоновый режим
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port = 10000;
            Thread connect = new Thread(connection);
            connect.Start();
            connect.IsBackground = true;
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
            String str = textBox1.Text;
            if (str == "байты")
            {
                String temp = client.ReceiveMessage[0];
                long bytes = Int64.Parse(temp);
                list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add(bytes); }));
            } 
            if (str == "мегабайты")
            {
                String temp = client.ReceiveMessage[0];
                long bytes = Int64.Parse(temp);
                list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add(bytes/1024); }));
            }
            if (str == "гигабайты")
            {
                String temp = client.ReceiveMessage[0];
                long bytes = Int64.Parse(temp);
                list_box.Invoke(new MethodInvoker(delegate { list_box.Items.Add((bytes / 1024)/1024); }));
            }
        }
    }
    class SocketClient
    {

        public Socket client;
        private IPEndPoint ip;
        public List<string> SendMessage = new List<string>();
        public List<string> ReceiveMessage = new List<string>();
        public SocketClient(string ip, Int32 port)
        {
            this.ip = new IPEndPoint(IPAddress.Parse(ip), port);                                    //используется для связывания сокета и локального адреса
            this.client = new Socket(this.ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool Connect()
        {
            try
            {
                this.client.Connect(this.ip);               //проверяем соединение
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Receive()
        {
            string message = String.Empty;
            byte[] GetBytes = new byte[1024];        //создаем буфер
            try
            {
                int b = client.Receive(GetBytes);    //записывает данные из сокета в буфер
                message = Encoding.UTF8.GetString(GetBytes, 0, b);  //форматируем в стринг
                if (message != "")
                    this.ReceiveMessage.Add(message);               //добавление в лист строк из сокета
            }
            catch
            { }
        }
        public void Send(string message, Socket handler)
        {
            byte[] tosend = Encoding.UTF8.GetBytes(message);
            try
            {
                handler.Send(tosend, 0, tosend.Length, SocketFlags.None);  //отправляем сообщение на сервер
            }
            catch
            {
            }
        }
        public void Disconnect()                    //отключаем сокет 
        {
            this.client.Disconnect(false);
        }
    }
}

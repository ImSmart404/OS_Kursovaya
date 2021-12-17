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
namespace server2
{
    public partial class Form2 : Form
    {
        SocketServer server;                            //сокет нашего сервера

        public Form2()
        {
            InitializeComponent();
            server = new SocketServer("127.0.0.1", 10000);
            server.Start();
            Thread list = new Thread(List);
            list.IsBackground = true;
            list.Start();
        }

        private void List()
        {
            for (; ; Thread.Sleep(200))
                if (server.ClientList.Count != List_box.Items.Count)
                {
                    List_box.Invoke(new MethodInvoker(delegate { List_box.Items.Clear(); }));
                    for (int i = 0; i < server.ClientList.Count; i++)
                        List_box.Invoke(new MethodInvoker(delegate { List_box.Items.Add(server.ClientList[i]); }));
                }
        }
        private void Form2_Closed(object sender, System.EventArgs e)
        {
            server.Dispose();
            this.Dispose();
            Application.Exit();
        }


    }
    class SocketServer
    {
        bool open = true;
        public Socket server;
        private IPEndPoint ip;
        private List<Thread> thread_list;
        private int max_conn;
        public List<string> messageSend = new List<string>();
        public List<string> ClientList = new List<string>();
        public SocketServer(string ip, Int32 port)
        {
            this.max_conn = 2;
            this.thread_list = new List<Thread>();
            this.ip = new IPEndPoint(IPAddress.Parse(ip), port);
            this.server = new Socket(this.ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.server.Bind(this.ip);
            this.server.Listen(this.max_conn);
        }
        public void Start()
        {
            for (int i = 0; i < this.max_conn; i++)                 //создает кол-во потоков для указанного кол-ва пользователей
            {
                Thread th = new Thread(Listening);                 //создается поток для метода listening
                th.Start();
                thread_list.Add(th);                               //добавляет потоки в list
            }
        }

        public void Dispose()                                      //нужен для завершения потоков из list
        {
            foreach (Thread th in thread_list)
            {
                th.Interrupt();
            }
            open = false;
            server.Close();
        }

        private void Listening()
        {
            while (open)                                        //пока сокет открыт
            {

                try
                {
                    using (Socket client = this.server.Accept())   //новый сокет для клиента
                    {
                   
                        client.Blocking = true;                                                                    //блокирует сокет
                        if (client.Connected)                                                                      //подключились ли мы к сокету?
                        {
                            this.ClientList.Add("Клиент " + client.RemoteEndPoint.ToString() + " получил информацию");    //записываем пользователя для которого создался сокет
                            List<string> message = new List<string>();
                            Process proc = Process.GetProcessesByName("ServerGUI")[0];
                            ProcessModuleCollection modules = proc.Modules; //Получаем коллекция модулей использующие нашу программу
                            message.Add("Имя модуля текущего процесса: " + modules[0].ModuleName);
                            long peakWorkingSet = 0;
                            
                            Process proc1 = Process.GetProcessesByName("Client_Mikhaylov")[0];
                            peakWorkingSet = proc1.PeakWorkingSet64;
                            string str = peakWorkingSet.ToString();
                            message.Add(str);
                            message.Add("[end]");
                            SendAll(client, message);                                                              //выгружаем его в сокет
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public void SendAll(Socket handler, List<string> message)                                                   //метод для отправки данных в сокет из листа
        {
            for (int i = 0; i < message.Count;)
            {
                Send(message[i], handler);                                                                         //применяем send, который отправляет наши данные в сокет                                
                message.RemoveAt(i);
                Thread.Sleep(5);
            }
        }
        public void Send(string message, Socket handler)
        {
            byte[] tosend = Encoding.UTF8.GetBytes(message);
            try
            {
                handler.Send(tosend, 0, tosend.Length, SocketFlags.None);
            }
            catch
            {
            }
        }
    }
}
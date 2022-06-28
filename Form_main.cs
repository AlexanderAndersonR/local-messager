using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local_messager
{
    public partial class LocalMessager_form : Form
    {
        tcp.server Server = new tcp.server();
        tcp.client Client = new tcp.client();
        bool debugging;
        object setting = null;
        public LocalMessager_form()
        {
            InitializeComponent();
            Server.debugging = true;
            Client.debugging = true;
            debugging = true;
            ToolStripMenuItem_disconnect.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void toolStripMenuItem_CreateLocalServer_Click(object sender, EventArgs e)
        {
            Form_CreateLocalServer form_CreateLocalServer = new Form_CreateLocalServer(Server);
            form_CreateLocalServer.Owner = this;
            form_CreateLocalServer.ShowDialog();
        }

        private void toolStripMenuItem_ConnecttoLocalServer_Click(object sender, EventArgs e)
        {
            Form_ConnectLocalServer form_ConnectLocalServer = new Form_ConnectLocalServer(Server,Client);
            form_ConnectLocalServer.Owner = this;
            form_ConnectLocalServer.ShowDialog();
        }
        public void StartSetting(object _setting)
        {
            if (_setting is tcp.server)
            {
                setting = _setting;
                textBox1.Text += "Server started\r\n";
                ToolStripMenuItem_disconnect.Visible = true;
                toolStripMenuItem_CreateLocalServer.Enabled = false;
                Thread listenThread = new Thread(new ThreadStart(() => waiting_for_the_client()));
                listenThread.Start();
                //BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { Server.history });
            }
            if (_setting is tcp.client)
            {
                setting = _setting;
                textBox1.Text += "Connecting server...\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = false;
                ToolStripMenuItem_disconnect.Visible = true;
                BeginInvoke(new SetTextDeleg_client(si_DataReceived), new object[] { Client.read() });
            }
        }

        private void ToolStripMenuItem_disconnect_Click(object sender, EventArgs e)
        {
            if (setting is tcp.server)
            {
                Server.stop();
                textBox1.Text += "Server stoped\r\n";
                ToolStripMenuItem_disconnect.Visible = false;
                toolStripMenuItem_CreateLocalServer.Enabled = true;
            }
            if (setting is tcp.client)
            {
                Client.close();
                Client.Disconnect();
                textBox1.Text += "Discinnecting\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = true;
                ToolStripMenuItem_disconnect.Visible = false;
            }
        }
        private delegate void SetTextDeleg(List<String> text);
        private delegate void SetTextDeleg_client(string text);
        public void si_DataReceived(List<String> text)
        {
            textBox1.Text += String.Join("\n\r",text.ToArray());
        }
        public void si_DataReceived(string text)
        {
            textBox1.Text += text + "\n\r";
        }

        private void button_send_message_Click(object sender, EventArgs e)
        {
            if (setting is tcp.client)
            {
                Client.Send(textBox_message_text.Text);
            }
            if (setting is tcp.server)
            {
                Server.Send(textBox_message_text.Text);
            }
        }

        private void LocalMessager_form_Load(object sender, EventArgs e)
        {

        }
        public void waiting_for_the_client()
        {
            try
            {
                while (true)
                {
                    TcpClient tcpClient = Server.tcpListener.AcceptTcpClient();
                    //ClientObject clientObject = new ClientObject(tcpClient, this);
                    //Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    Server.clients.Add(tcpClient);
                    //clients.Add(tcpClient);
                    Thread clientThread = new Thread(new ThreadStart(() => ClientConnect(tcpClient)));
                    clientThread.Start();
                }

            }
            catch (Exception e)
            {
                if (debugging) MessageBox.Show(e.Message);
            }
        }
        private delegate void textBoxAdd_del(string message);
        void textBoxAdd(string message)
        {
            textBox1.Text += message+ "\n\r";
        }
        public void ClientConnect(TcpClient tcpClient)
        {
            Invoke(new textBoxAdd_del(textBoxAdd), new object[] { "client connecting" });
            while (true)
            {
                try
                {
                    NetworkStream stream = tcpClient.GetStream();
                    // сообщение для отправки клиенту
                    string response = "Привет мир";
                    // преобразуем сообщение в массив байтов
                    byte[] data = Encoding.UTF8.GetBytes(response);

                    // отправка сообщения
                    stream.Write(data, 0, data.Length);
                    //Console.WriteLine("Отправлено сообщение: {0}", response);
                    //// закрываем поток
                    //stream.Close();
                    //// закрываем подключение
                    //tcpClient.Close();
                    // создаем новый поток для обслуживания нового клиента
                    //Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    //clientThread.Start();
                }
                catch (Exception e)
                {
                    if (debugging) MessageBox.Show(e.Message);
                    break;
                }
            }
        }
    }
}

//BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { client.read() });
//private delegate void SetTextDeleg(string text);
//private void si_DataReceived(string data)
//{
//    save_log_file(data.Trim());
//    DataReceived.Add(data.Trim());
//    if (checked_message)
//    {
//        checked_message_List.Add(data.Trim());
//    }
//    for (int i = 0; i < DataReceived.Count; i++)
//    {
//        if (i == 100)
//        {
//            DataReceived.RemoveAt(0);
//        }
//    }
//    Form_LogDialog.getTextBox().Lines = DataReceived.ToArray();
//}
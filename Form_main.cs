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
        public string NickName { get; set; }
        bool debugging;
        object setting = null;
        List<Thread> threads = new List<Thread>();
        public LocalMessager_form()
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.NickName))
                NickName = Properties.Settings.Default.NickName;
            Server.debugging_message = true;
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
        public async void StartSetting(object _setting)
        {
            if (_setting is tcp.server)
            {
                setting = _setting;
                textBox1.Text += "Server started\r\n";
                ToolStripMenuItem_disconnect.Visible = true;
                toolStripMenuItem_CreateLocalServer.Enabled = false;
                Thread listenThread = new Thread(new ThreadStart(() => waiting_for_the_client()));
                listenThread.Start();
                threads.Add(listenThread);
            }
            if (_setting is tcp.client)
            {
                setting = _setting;
                textBox1.Text += "Connecting server...\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = false;
                ToolStripMenuItem_disconnect.Visible = true;
                if(Client.con_status()) Client.Send(NickName);
                await Task.Run(() => 
                {
                    while (Client.con_status()) {Invoke(new SetTextDeleg_client(si_DataReceived), new object[] { Client.read() }); }
                });
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
                Client.Disconnect();
                textBox1.Text += "Discinnecting\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = true;
                ToolStripMenuItem_disconnect.Visible = false;
            }
            foreach (Thread item in threads)
            {
                item.Interrupt();
            }
            threads.Clear();
        }
        private delegate void SetTextDeleg_client(string text);
        public void si_DataReceived(string text)
        {
            textBox1.Text += text + "\n\r";
        }

        private async void button_send_message_Click(object sender, EventArgs e)
        {
            if (setting is tcp.client)
            {
                await Task.Run(() => { Client.Send(textBox_message_text.Text); });
            }
            if (setting is tcp.server)
            {
                await Task.Run(() => { Server.Send(textBox_message_text.Text); });
            }
        }
        public void waiting_for_the_client()
        {
            try
            {
                while (true)
                {
                    TcpClient tcpClient = Server.tcpListener.AcceptTcpClient();
                    Server.clients.Add(tcpClient);
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
            if (!String.IsNullOrEmpty(message))
                textBox1.Text += message+ "\n\r";
        }
        public /*async*/ void ClientConnect(TcpClient tcpClient)
        {
            string client_name = Server.read(tcpClient);
            Invoke(new textBoxAdd_del(textBoxAdd), client_name + " connected\n\r");
            //await Task.Run(() =>
            //{
                Server.Send(client_name + " connected\n\r");
                while (tcpClient.Connected)
                {
                    Invoke(new textBoxAdd_del(textBoxAdd), new object[] { Server.read(tcpClient) });
                }
                Invoke(new textBoxAdd_del(textBoxAdd), client_name +" disconnect\n\r");
            //});
            Environment.Exit(0); //завершение процесса
        }
        private void LocalMessager_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);  //close all thread
            try
            {
                if (setting is tcp.server)
                {
                    Server.stop();
                }
                if (setting is tcp.client)
                {
                    Client.Disconnect();
                }
            }
            catch (Exception ex)
            {
                if (debugging) MessageBox.Show(ex.Message);
            }
        }
    }
}
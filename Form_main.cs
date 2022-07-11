using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace local_messager
{
    public partial class LocalMessager_form : Form
    {
        List<string> Client_NickName= new List<string>();
        tcp.server Server = new tcp.server();
        tcp.client Client = new tcp.client();
        string form_name { get; set; }
        
        public string NickName { get; set; }
        public bool debugging;
        public bool thow_exeption;
        public bool clear_textBox;
        object setting = null;
        List<Thread> threads = new List<Thread>();
        public LocalMessager_form()
        {
            InitializeComponent();
            form_name = this.Text;
            this.Text = form_name + " " + GetVersion();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.NickName))
                NickName = Properties.Settings.Default.NickName;
            start_setting();
            ToolStripMenuItem_disconnect.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Setting form_Setting = new Form_Setting(Server,Client);
            form_Setting.Owner = this;
            form_Setting.ShowDialog();
        }
        public async void StartSetting(object _setting)
        {
            if (_setting is tcp.server)
            {
                this.Text = form_name + " " + GetVersion() + " (Server)";
                ToolStripMenuItem_disconnect.Text = "Stop Server";
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
                this.Text = form_name+" " + GetVersion() + " (Client)";
                ToolStripMenuItem_disconnect.Text = "Disconnect";
                setting = _setting;
                textBox1.Text += "Connecting server...\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = false;
                ToolStripMenuItem_disconnect.Visible = true;
                if(Client.con_status()) Client.Send(NickName);
                await Task.Run(() => 
                {
                    while (Client.con_status()) {Invoke(new SetTextDeleg_client(textBoxAdd), new object[] { Client.read() }); }
                    MessageBox.Show("Server Disconnected");
                    ClientDisconnect();
                });
            }
        }

        private void ToolStripMenuItem_disconnect_Click(object sender, EventArgs e)
        {
            if (setting is tcp.server)
            {
                this.Text = form_name + " " + GetVersion();
                Server.stop();
                textBox1.Text += "Server stoped\r\n";
                ToolStripMenuItem_disconnect.Visible = false;
                toolStripMenuItem_CreateLocalServer.Enabled = true;
            }
            if (setting is tcp.client)
                ClientDisconnect();
        }
        private void ClientDisconnect()
        {
            this.Text = form_name + " " + GetVersion();
            Client.Disconnect();
            textBox1.Text += "Discinnected\r\n";
            toolStripMenuItem_ConnecttoLocalServer.Enabled = true;
            ToolStripMenuItem_disconnect.Visible = false;
        }
        private delegate void SetTextDeleg_client(string text);
        private async void button_send_message_Click(object sender, EventArgs e)
        {
            if (setting is tcp.client)
                await Task.Run(() => { Client.Send(textBox_message_text.Text); });
            if (setting is tcp.server)
                await Task.Run(() => {
                    if (String.IsNullOrEmpty(Properties.Settings.Default.ServerNickName))
                        Server.Send("Server: " + textBox_message_text.Text);
                    else
                        Server.Send(Properties.Settings.Default.ServerNickName + " (Server): " + textBox_message_text.Text);
                    ; 
                });
            if (clear_textBox) 
                textBox_message_text.Clear();
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
                textBox1.Text += message+ "\r\n";
        }
        public void ClientConnect(TcpClient tcpClient)
        {
            string client_name = Server.read(tcpClient);
            Client_NickName.Add(client_name);
            Invoke(new textBoxAdd_del(textBoxAdd), client_name + " connected\n\r");
                Server.Send(client_name + " connected\n\r");
                while (Client.con_status(tcpClient))
                {
                    string message = Server.read(tcpClient, thow_exeption);
                    if (!String.IsNullOrEmpty(message))
                    {
                        Invoke(new textBoxAdd_del(textBoxAdd), new object[] { client_name + ": " + message });
                        Server.Send(client_name + ": " + message, tcpClient);
                    }
                }
                Invoke(new textBoxAdd_del(textBoxAdd), client_name + " disconnect");
            Client_NickName.Remove(client_name);
            Server.clients.Remove(tcpClient);
            Server.Send(client_name + ": " + " disconnect");
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
        void start_setting()
        {
            debugging = Properties.Settings.Default.debug_message;
            thow_exeption = Properties.Settings.Default.thow_exeption;
            Server.debugging_message = debugging;
            Client.debugging = debugging;
            clear_textBox = Properties.Settings.Default.clear_textBox;
        }
    }
}
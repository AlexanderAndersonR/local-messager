using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local_messager
{
    public partial class LocalMessager_form : Form
    {
        tcp.server Server = new tcp.server();
        tcp.client Client = new tcp.client();
        object setting = null;
        public LocalMessager_form()
        {
            InitializeComponent();
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
        public delegate void SetTextDeleg(string text);
        public void si_DataReceived(string data)
        {
            textBox1.Text += data +"\n\r";
        }
        public void startReadMessageServer()
        {
           //BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { Server.re });
        }
        //public void setTextTextBox(string message)
        //{
        //    textBox1.Text += message + "\n\r"; 
        //}
        public void StartSetting(object _setting)
        {
            if (_setting is tcp.server)
            {
                setting = _setting;
                textBox1.Text += "Server started\r\n";
                ToolStripMenuItem_disconnect.Visible = true;
                toolStripMenuItem_CreateLocalServer.Enabled = false;
            }
            if (_setting is tcp.client)
            {
                setting = _setting;
                textBox1.Text += "Connecting server...\r\n";
                toolStripMenuItem_ConnecttoLocalServer.Enabled = false;
                ToolStripMenuItem_disconnect.Visible = true;
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
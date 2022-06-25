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

        public LocalMessager_form()
        {
            InitializeComponent();
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
           BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { Server.re });
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
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
        tcp.server server = new tcp.server();
        public LocalMessager_form()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem_CreateLocalServer_Click(object sender, EventArgs e)
        {
            Form_CreateLocalServer form_CreateLocalServer = new Form_CreateLocalServer(server);
            form_CreateLocalServer.ShowDialog();
        }

        private void toolStripMenuItem_ConnecttoLocalServer_Click(object sender, EventArgs e)
        {
            Form_ConnectLocalServer form_ConnectLocalServer = new Form_ConnectLocalServer(server);
            form_ConnectLocalServer.ShowDialog();
        }
    }
}

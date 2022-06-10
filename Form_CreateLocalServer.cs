using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace local_messager
{
    public partial class Form_CreateLocalServer : Form
    {
        tcp.server Server {get;set;}
        public Form_CreateLocalServer(tcp.server server)
        {
            InitializeComponent();
            Server = server;
            if (Properties.Settings.Default.CodeCreate!= null && Properties.Settings.Default.CodeCreate != "")
            {
                comboBox1.SelectedItem = Properties.Settings.Default.CodeCreate;
            }
            if (Properties.Settings.Default.ipCreate != null && Properties.Settings.Default.ipCreate != "")
            {
                textBox_IP.Text = Properties.Settings.Default.ipCreate;
            }
            textBox_Port.Text = Properties.Settings.Default.portCreate.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString()!=null && comboBox1.SelectedItem.ToString() != "")
            {
                Properties.Settings.Default.CodeCreate = comboBox1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }
        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

            if (textBox_IP.Text != null && textBox_IP.Text != "")
            {
                if (Regex.IsMatch(textBox_IP.Text,pattern))
                {
                    Properties.Settings.Default.ipCreate = textBox_IP.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void textBox_Port_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\d{4}";
            if (textBox_Port.Text != null && textBox_Port.Text != "")
            {
                if (Regex.IsMatch(textBox_Port.Text, pattern))
                {
                    Properties.Settings.Default.portCreate = Convert.ToInt16(textBox_Port.Text);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Form_CreateLocalServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start_server();
            }
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            start_server();
        }
        private void start_server()
        {
            Server.start(Properties.Settings.Default.ipCreate, Properties.Settings.Default.portCreate);
            this.Close();
        }
    }
}

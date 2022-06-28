using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace local_messager
{
    public partial class Form_ConnectLocalServer: Form
    {
        tcp.client Client { get; set; }
        tcp.server Server { get; set; }
        public Form_ConnectLocalServer(tcp.server server, tcp.client client)
        {
            Server = server;
            Client = client;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox_NickName.Text = !String.IsNullOrEmpty(Properties.Settings.Default.NickName) ? textBox_NickName.Text = Properties.Settings.Default.NickName : "Enter your nickname";
            if (!String.IsNullOrEmpty(Properties.Settings.Default.CodeConnect))
            {
                comboBox1.SelectedItem = Properties.Settings.Default.CodeConnect;
                Client.code = Properties.Settings.Default.CodeConnect;
            }
            textBox_IP.Text = Properties.Settings.Default.ipConnect = !String.IsNullOrEmpty(Properties.Settings.Default.ipConnect) ? Properties.Settings.Default.ipConnect : "Enter server ip";
            textBox_Port.Text = Properties.Settings.Default.portConnect.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
            {
                Properties.Settings.Default.CodeConnect = comboBox1.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void textBox_NickName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_NickName.Text) && textBox_NickName.Text != "Enter your nickname")
            {
                Properties.Settings.Default.NickName = textBox_NickName.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";

            if (!String.IsNullOrEmpty(textBox_IP.Text))
            {
                if (Regex.IsMatch(textBox_IP.Text, pattern))
                {
                    Properties.Settings.Default.ipConnect = textBox_IP.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void textBox_Port_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"\d{4}";
            if (!String.IsNullOrEmpty(textBox_Port.Text))
            {
                if (Regex.IsMatch(textBox_Port.Text, pattern))
                {
                    Properties.Settings.Default.portConnect = Convert.ToInt16(textBox_Port.Text);
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (Client.connect(Properties.Settings.Default.ipConnect, Properties.Settings.Default.portConnect))
            {
                LocalMessager_form main_form = this.Owner as LocalMessager_form;
                if (main_form != null)
                {
                    main_form.StartSetting(Client);
                    //Server.getMessage(main_form.textBox);
                    // BeginInvoke();
                    //Thread clientThread = new Thread(()=>Server.getMessage(main_form.textBox));
                    //clientThread.Start();
                }
                this.Close();
            }
            //Thread listenThread = new Thread(new ThreadStart(() => Server.waiting_for_the_client()));
            //listenThread.Start();
        }
    }
    }

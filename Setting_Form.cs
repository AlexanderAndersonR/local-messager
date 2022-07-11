using System;
using System.Windows.Forms;
using setting = local_messager.Properties.Settings;

namespace local_messager
{
    public partial class Form_Setting : Form
    {
        tcp.server Server { get; set; }
        tcp.client Client { get; set; }
        public Form_Setting(tcp.server server, tcp.client client)
        {
            Server = server;
            Client = client;
            InitializeComponent();
            startSetting();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void startSetting()
        {
            checkBox_debug_message.Checked = setting.Default.debug_message;
            checkBox_thow_exeption.Checked = setting.Default.thow_exeption;
            checkBox_clear_textBox.Checked = setting.Default.clear_textBox;
        }

        private void button_SaveSetting_Click(object sender, EventArgs e)
        {
            setting.Default.debug_message = checkBox_debug_message.Checked;
            Server.debugging_message = setting.Default.debug_message;
            Client.debugging = setting.Default.debug_message;
            setting.Default.thow_exeption = checkBox_thow_exeption.Checked;
            setting.Default.clear_textBox = checkBox_clear_textBox.Checked;
            setting.Default.Save();
            LocalMessager_form main_form = this.Owner as LocalMessager_form;
            if (main_form != null)
            {
                main_form.clear_textBox = setting.Default.clear_textBox;
                main_form.debugging = setting.Default.debug_message;
                main_form.thow_exeption = setting.Default.thow_exeption;
            }
            this.Close();
        }
    }
}

namespace local_messager
{
    partial class Form_ConnectLocalServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ConnectLocalServer));
            this.button_Connect = new System.Windows.Forms.Button();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.label_Coding = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_Nickname = new System.Windows.Forms.Label();
            this.textBox_NickName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(15, 159);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 16;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(12, 111);
            this.textBox_Port.MaxLength = 4;
            this.textBox_Port.Multiline = true;
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(142, 20);
            this.textBox_Port.TabIndex = 15;
            this.textBox_Port.TextChanged += new System.EventHandler(this.textBox_Port_TextChanged);
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(12, 95);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 14;
            this.label_port.Text = "Port";
            // 
            // label_Coding
            // 
            this.label_Coding.AutoSize = true;
            this.label_Coding.Location = new System.Drawing.Point(236, 40);
            this.label_Coding.Name = "label_Coding";
            this.label_Coding.Size = new System.Drawing.Size(40, 13);
            this.label_Coding.TabIndex = 13;
            this.label_Coding.Text = "Coding";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "UTF8",
            "ASCII",
            "Unicode",
            "UTF7"});
            this.comboBox1.Location = new System.Drawing.Point(202, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(12, 40);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(51, 13);
            this.label_ip.TabIndex = 11;
            this.label_ip.Text = "Server IP";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(12, 57);
            this.textBox_IP.MaxLength = 17;
            this.textBox_IP.Multiline = true;
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(142, 20);
            this.textBox_IP.TabIndex = 10;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // label_Nickname
            // 
            this.label_Nickname.AutoSize = true;
            this.label_Nickname.Location = new System.Drawing.Point(12, 14);
            this.label_Nickname.Name = "label_Nickname";
            this.label_Nickname.Size = new System.Drawing.Size(64, 13);
            this.label_Nickname.TabIndex = 17;
            this.label_Nickname.Text = "Nickname - ";
            // 
            // textBox_NickName
            // 
            this.textBox_NickName.Location = new System.Drawing.Point(82, 11);
            this.textBox_NickName.Multiline = true;
            this.textBox_NickName.Name = "textBox_NickName";
            this.textBox_NickName.Size = new System.Drawing.Size(241, 20);
            this.textBox_NickName.TabIndex = 18;
            this.textBox_NickName.TextChanged += new System.EventHandler(this.textBox_NickName_TextChanged);
            // 
            // Form_ConnectLocalServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 269);
            this.Controls.Add(this.textBox_NickName);
            this.Controls.Add(this.label_Nickname);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_Coding);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.textBox_IP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(424, 308);
            this.MinimumSize = new System.Drawing.Size(424, 308);
            this.Name = "Form_ConnectLocalServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Local Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_Coding;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_Nickname;
        private System.Windows.Forms.TextBox textBox_NickName;
    }
}
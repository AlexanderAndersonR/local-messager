namespace local_messager
{
    partial class Form_CreateLocalServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CreateLocalServer));
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label_ip = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_Coding = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.button_Create = new System.Windows.Forms.Button();
            this.label_HostName = new System.Windows.Forms.Label();
            this.label_ipAdress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(12, 82);
            this.textBox_IP.MaxLength = 17;
            this.textBox_IP.Multiline = true;
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(142, 20);
            this.textBox_IP.TabIndex = 0;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(12, 65);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(51, 13);
            this.label_ip.TabIndex = 1;
            this.label_ip.Text = "Server IP";
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
            this.comboBox1.Location = new System.Drawing.Point(202, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_Coding
            // 
            this.label_Coding.AutoSize = true;
            this.label_Coding.Location = new System.Drawing.Point(236, 65);
            this.label_Coding.Name = "label_Coding";
            this.label_Coding.Size = new System.Drawing.Size(40, 13);
            this.label_Coding.TabIndex = 3;
            this.label_Coding.Text = "Coding";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(12, 136);
            this.textBox_Port.MaxLength = 4;
            this.textBox_Port.Multiline = true;
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(142, 20);
            this.textBox_Port.TabIndex = 5;
            this.textBox_Port.TextChanged += new System.EventHandler(this.textBox_Port_TextChanged);
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(15, 184);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 6;
            this.button_Create.Text = "Create";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // label_HostName
            // 
            this.label_HostName.AutoSize = true;
            this.label_HostName.Location = new System.Drawing.Point(12, 9);
            this.label_HostName.Name = "label_HostName";
            this.label_HostName.Size = new System.Drawing.Size(154, 13);
            this.label_HostName.TabIndex = 7;
            this.label_HostName.Text = "Computer Name (Host Name) - ";
            // 
            // label_ipAdress
            // 
            this.label_ipAdress.AutoSize = true;
            this.label_ipAdress.Location = new System.Drawing.Point(12, 36);
            this.label_ipAdress.Name = "label_ipAdress";
            this.label_ipAdress.Size = new System.Drawing.Size(61, 13);
            this.label_ipAdress.TabIndex = 8;
            this.label_ipAdress.Text = "IP Adress - ";
            // 
            // Form_CreateLocalServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 269);
            this.Controls.Add(this.label_ipAdress);
            this.Controls.Add(this.label_HostName);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Coding);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.textBox_IP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CreateLocalServer";
            this.Text = "Create Local Server";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_CreateLocalServer_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label_Coding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.Label label_HostName;
        private System.Windows.Forms.Label label_ipAdress;
    }
}
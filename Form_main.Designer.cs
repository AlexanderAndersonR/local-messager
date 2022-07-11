namespace local_messager
{
    partial class LocalMessager_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalMessager_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_CreateLocalServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ConnecttoLocalServer = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_message_text = new System.Windows.Forms.TextBox();
            this.button_send_message = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_CreateLocalServer,
            this.toolStripMenuItem_ConnecttoLocalServer,
            this.settingToolStripMenuItem,
            this.ToolStripMenuItem_disconnect});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_CreateLocalServer
            // 
            this.toolStripMenuItem_CreateLocalServer.Name = "toolStripMenuItem_CreateLocalServer";
            this.toolStripMenuItem_CreateLocalServer.Size = new System.Drawing.Size(119, 20);
            this.toolStripMenuItem_CreateLocalServer.Text = "Create Local Server";
            this.toolStripMenuItem_CreateLocalServer.Click += new System.EventHandler(this.toolStripMenuItem_CreateLocalServer_Click);
            // 
            // toolStripMenuItem_ConnecttoLocalServer
            // 
            this.toolStripMenuItem_ConnecttoLocalServer.Name = "toolStripMenuItem_ConnecttoLocalServer";
            this.toolStripMenuItem_ConnecttoLocalServer.Size = new System.Drawing.Size(144, 20);
            this.toolStripMenuItem_ConnecttoLocalServer.Text = "Connect to Local Server";
            this.toolStripMenuItem_ConnecttoLocalServer.Click += new System.EventHandler(this.toolStripMenuItem_ConnecttoLocalServer_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_disconnect
            // 
            this.ToolStripMenuItem_disconnect.Name = "ToolStripMenuItem_disconnect";
            this.ToolStripMenuItem_disconnect.Size = new System.Drawing.Size(78, 20);
            this.ToolStripMenuItem_disconnect.Text = "Disconnect";
            this.ToolStripMenuItem_disconnect.Click += new System.EventHandler(this.ToolStripMenuItem_disconnect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(515, 320);
            this.textBox1.TabIndex = 1;
            // 
            // textBox_message_text
            // 
            this.textBox_message_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_message_text.Location = new System.Drawing.Point(12, 354);
            this.textBox_message_text.Multiline = true;
            this.textBox_message_text.Name = "textBox_message_text";
            this.textBox_message_text.Size = new System.Drawing.Size(515, 92);
            this.textBox_message_text.TabIndex = 2;
            // 
            // button_send_message
            // 
            this.button_send_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send_message.Location = new System.Drawing.Point(557, 354);
            this.button_send_message.Name = "button_send_message";
            this.button_send_message.Size = new System.Drawing.Size(75, 23);
            this.button_send_message.TabIndex = 3;
            this.button_send_message.Text = "Send";
            this.button_send_message.UseVisualStyleBackColor = true;
            this.button_send_message.Click += new System.EventHandler(this.button_send_message_Click);
            // 
            // LocalMessager_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 458);
            this.Controls.Add(this.button_send_message);
            this.Controls.Add(this.textBox_message_text);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(452, 293);
            this.Name = "LocalMessager_form";
            this.Text = "LocalMessager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocalMessager_form_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_CreateLocalServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ConnecttoLocalServer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_disconnect;
        private System.Windows.Forms.TextBox textBox_message_text;
        private System.Windows.Forms.Button button_send_message;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
    }
}


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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ToolStripMenuItem_disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_CreateLocalServer,
            this.toolStripMenuItem_ConnecttoLocalServer,
            this.ToolStripMenuItem_disconnect});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 374);
            this.textBox1.TabIndex = 1;
            // 
            // ToolStripMenuItem_disconnect
            // 
            this.ToolStripMenuItem_disconnect.Name = "ToolStripMenuItem_disconnect";
            this.ToolStripMenuItem_disconnect.Size = new System.Drawing.Size(78, 20);
            this.ToolStripMenuItem_disconnect.Text = "Disconnect";
            this.ToolStripMenuItem_disconnect.Click += new System.EventHandler(this.ToolStripMenuItem_disconnect_Click);
            // 
            // LocalMessager_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocalMessager_form";
            this.Text = "LocalMessager";
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
    }
}


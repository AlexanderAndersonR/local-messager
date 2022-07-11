namespace local_messager
{
    partial class Form_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Setting));
            this.checkBox_thow_exeption = new System.Windows.Forms.CheckBox();
            this.checkBox_debug_message = new System.Windows.Forms.CheckBox();
            this.button_SaveSetting = new System.Windows.Forms.Button();
            this.checkBox_clear_textBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_thow_exeption
            // 
            this.checkBox_thow_exeption.AutoSize = true;
            this.checkBox_thow_exeption.Location = new System.Drawing.Point(12, 36);
            this.checkBox_thow_exeption.Name = "checkBox_thow_exeption";
            this.checkBox_thow_exeption.Size = new System.Drawing.Size(92, 17);
            this.checkBox_thow_exeption.TabIndex = 7;
            this.checkBox_thow_exeption.Text = "thow exeption";
            this.checkBox_thow_exeption.UseVisualStyleBackColor = true;
            // 
            // checkBox_debug_message
            // 
            this.checkBox_debug_message.AutoSize = true;
            this.checkBox_debug_message.Location = new System.Drawing.Point(12, 12);
            this.checkBox_debug_message.Name = "checkBox_debug_message";
            this.checkBox_debug_message.Size = new System.Drawing.Size(115, 17);
            this.checkBox_debug_message.TabIndex = 6;
            this.checkBox_debug_message.Text = "debuging message";
            this.checkBox_debug_message.UseVisualStyleBackColor = true;
            // 
            // button_SaveSetting
            // 
            this.button_SaveSetting.Location = new System.Drawing.Point(257, 186);
            this.button_SaveSetting.Name = "button_SaveSetting";
            this.button_SaveSetting.Size = new System.Drawing.Size(101, 23);
            this.button_SaveSetting.TabIndex = 8;
            this.button_SaveSetting.Text = "Save Setting";
            this.button_SaveSetting.UseVisualStyleBackColor = true;
            this.button_SaveSetting.Click += new System.EventHandler(this.button_SaveSetting_Click);
            // 
            // checkBox_clear_textBox
            // 
            this.checkBox_clear_textBox.AutoSize = true;
            this.checkBox_clear_textBox.Location = new System.Drawing.Point(12, 60);
            this.checkBox_clear_textBox.Name = "checkBox_clear_textBox";
            this.checkBox_clear_textBox.Size = new System.Drawing.Size(210, 17);
            this.checkBox_clear_textBox.TabIndex = 9;
            this.checkBox_clear_textBox.Text = "Clear TextBox after sending a message";
            this.checkBox_clear_textBox.UseVisualStyleBackColor = true;
            // 
            // Form_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 221);
            this.Controls.Add(this.checkBox_clear_textBox);
            this.Controls.Add(this.button_SaveSetting);
            this.Controls.Add(this.checkBox_thow_exeption);
            this.Controls.Add(this.checkBox_debug_message);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(386, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(386, 260);
            this.Name = "Form_Setting";
            this.Text = "LocalMessager Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_thow_exeption;
        private System.Windows.Forms.CheckBox checkBox_debug_message;
        private System.Windows.Forms.Button button_SaveSetting;
        private System.Windows.Forms.CheckBox checkBox_clear_textBox;
    }
}
﻿namespace ACMReport3
{
    partial class Form_Connection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Connection));
            this.gb_ACM = new System.Windows.Forms.GroupBox();
            this.button_Hide = new System.Windows.Forms.Button();
            this.tb_ACMPassword = new System.Windows.Forms.TextBox();
            this.tb_ACMUsername = new System.Windows.Forms.TextBox();
            this.tb_ACMServerPort = new System.Windows.Forms.TextBox();
            this.tb_ACMServerIP = new System.Windows.Forms.TextBox();
            this.label_ACMPAssword = new System.Windows.Forms.Label();
            this.label_ACMUsername = new System.Windows.Forms.Label();
            this.label_ACMServerPort = new System.Windows.Forms.Label();
            this.label_ACMServerIP = new System.Windows.Forms.Label();
            this.button_Test = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.gb_Timers = new System.Windows.Forms.GroupBox();
            this.tb_Timeout = new System.Windows.Forms.TextBox();
            this.label_Timeout = new System.Windows.Forms.Label();
            this.tb_CommandTimeout = new System.Windows.Forms.TextBox();
            this.label_CommandTimeout = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.cb_Cache = new System.Windows.Forms.CheckBox();
            this.gb_ACM.SuspendLayout();
            this.gb_Timers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ACM
            // 
            this.gb_ACM.Controls.Add(this.button_Hide);
            this.gb_ACM.Controls.Add(this.tb_ACMPassword);
            this.gb_ACM.Controls.Add(this.tb_ACMUsername);
            this.gb_ACM.Controls.Add(this.tb_ACMServerPort);
            this.gb_ACM.Controls.Add(this.tb_ACMServerIP);
            this.gb_ACM.Controls.Add(this.label_ACMPAssword);
            this.gb_ACM.Controls.Add(this.label_ACMUsername);
            this.gb_ACM.Controls.Add(this.label_ACMServerPort);
            this.gb_ACM.Controls.Add(this.label_ACMServerIP);
            this.gb_ACM.Location = new System.Drawing.Point(12, 12);
            this.gb_ACM.Name = "gb_ACM";
            this.gb_ACM.Size = new System.Drawing.Size(373, 172);
            this.gb_ACM.TabIndex = 0;
            this.gb_ACM.TabStop = false;
            this.gb_ACM.Text = "Connection to ACM server";
            // 
            // button_Hide
            // 
            this.button_Hide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Hide.BackgroundImage")));
            this.button_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Hide.Location = new System.Drawing.Point(336, 129);
            this.button_Hide.Name = "button_Hide";
            this.button_Hide.Size = new System.Drawing.Size(23, 23);
            this.button_Hide.TabIndex = 50;
            this.button_Hide.Text = "...";
            this.button_Hide.UseVisualStyleBackColor = true;
            this.button_Hide.Click += new System.EventHandler(this.Button_Hide_Click);
            // 
            // tb_ACMPassword
            // 
            this.tb_ACMPassword.Location = new System.Drawing.Point(166, 130);
            this.tb_ACMPassword.Name = "tb_ACMPassword";
            this.tb_ACMPassword.Size = new System.Drawing.Size(164, 22);
            this.tb_ACMPassword.TabIndex = 40;
            this.tb_ACMPassword.UseSystemPasswordChar = true;
            // 
            // tb_ACMUsername
            // 
            this.tb_ACMUsername.Location = new System.Drawing.Point(166, 97);
            this.tb_ACMUsername.Name = "tb_ACMUsername";
            this.tb_ACMUsername.Size = new System.Drawing.Size(193, 22);
            this.tb_ACMUsername.TabIndex = 30;
            // 
            // tb_ACMServerPort
            // 
            this.tb_ACMServerPort.Location = new System.Drawing.Point(166, 65);
            this.tb_ACMServerPort.Name = "tb_ACMServerPort";
            this.tb_ACMServerPort.Size = new System.Drawing.Size(193, 22);
            this.tb_ACMServerPort.TabIndex = 20;
            // 
            // tb_ACMServerIP
            // 
            this.tb_ACMServerIP.Location = new System.Drawing.Point(166, 32);
            this.tb_ACMServerIP.Name = "tb_ACMServerIP";
            this.tb_ACMServerIP.Size = new System.Drawing.Size(193, 22);
            this.tb_ACMServerIP.TabIndex = 10;
            // 
            // label_ACMPAssword
            // 
            this.label_ACMPAssword.AutoSize = true;
            this.label_ACMPAssword.Location = new System.Drawing.Point(7, 135);
            this.label_ACMPAssword.Name = "label_ACMPAssword";
            this.label_ACMPAssword.Size = new System.Drawing.Size(69, 17);
            this.label_ACMPAssword.TabIndex = 3;
            this.label_ACMPAssword.Text = "Password";
            // 
            // label_ACMUsername
            // 
            this.label_ACMUsername.AutoSize = true;
            this.label_ACMUsername.Location = new System.Drawing.Point(7, 102);
            this.label_ACMUsername.Name = "label_ACMUsername";
            this.label_ACMUsername.Size = new System.Drawing.Size(43, 17);
            this.label_ACMUsername.TabIndex = 2;
            this.label_ACMUsername.Text = "Login";
            // 
            // label_ACMServerPort
            // 
            this.label_ACMServerPort.AutoSize = true;
            this.label_ACMServerPort.Location = new System.Drawing.Point(6, 70);
            this.label_ACMServerPort.Name = "label_ACMServerPort";
            this.label_ACMServerPort.Size = new System.Drawing.Size(86, 17);
            this.label_ACMServerPort.TabIndex = 1;
            this.label_ACMServerPort.Text = "Port number";
            // 
            // label_ACMServerIP
            // 
            this.label_ACMServerIP.AutoSize = true;
            this.label_ACMServerIP.Location = new System.Drawing.Point(7, 37);
            this.label_ACMServerIP.Name = "label_ACMServerIP";
            this.label_ACMServerIP.Size = new System.Drawing.Size(75, 17);
            this.label_ACMServerIP.TabIndex = 0;
            this.label_ACMServerIP.Text = "IP address";
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(12, 334);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(160, 30);
            this.button_Test.TabIndex = 90;
            this.button_Test.Text = "Test Connection";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.Button_Test_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(285, 334);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(100, 30);
            this.button_Save.TabIndex = 80;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // gb_Timers
            // 
            this.gb_Timers.Controls.Add(this.cb_Cache);
            this.gb_Timers.Controls.Add(this.tb_Timeout);
            this.gb_Timers.Controls.Add(this.label_Timeout);
            this.gb_Timers.Controls.Add(this.tb_CommandTimeout);
            this.gb_Timers.Controls.Add(this.label_CommandTimeout);
            this.gb_Timers.Location = new System.Drawing.Point(13, 191);
            this.gb_Timers.Name = "gb_Timers";
            this.gb_Timers.Size = new System.Drawing.Size(372, 125);
            this.gb_Timers.TabIndex = 4;
            this.gb_Timers.TabStop = false;
            this.gb_Timers.Text = "Advanced settings";
            // 
            // tb_Timeout
            // 
            this.tb_Timeout.Location = new System.Drawing.Point(165, 63);
            this.tb_Timeout.Name = "tb_Timeout";
            this.tb_Timeout.Size = new System.Drawing.Size(193, 22);
            this.tb_Timeout.TabIndex = 70;
            // 
            // label_Timeout
            // 
            this.label_Timeout.AutoSize = true;
            this.label_Timeout.Location = new System.Drawing.Point(6, 66);
            this.label_Timeout.Name = "label_Timeout";
            this.label_Timeout.Size = new System.Drawing.Size(129, 17);
            this.label_Timeout.TabIndex = 10;
            this.label_Timeout.Text = "Connection timeout";
            // 
            // tb_CommandTimeout
            // 
            this.tb_CommandTimeout.Location = new System.Drawing.Point(165, 29);
            this.tb_CommandTimeout.Name = "tb_CommandTimeout";
            this.tb_CommandTimeout.Size = new System.Drawing.Size(193, 22);
            this.tb_CommandTimeout.TabIndex = 60;
            // 
            // label_CommandTimeout
            // 
            this.label_CommandTimeout.AutoSize = true;
            this.label_CommandTimeout.Location = new System.Drawing.Point(6, 32);
            this.label_CommandTimeout.Name = "label_CommandTimeout";
            this.label_CommandTimeout.Size = new System.Drawing.Size(121, 17);
            this.label_CommandTimeout.TabIndex = 9;
            this.label_CommandTimeout.Text = "Command timeout";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(178, 334);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(100, 30);
            this.button_Close.TabIndex = 91;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // cb_Cache
            // 
            this.cb_Cache.AutoSize = true;
            this.cb_Cache.Location = new System.Drawing.Point(165, 98);
            this.cb_Cache.Name = "cb_Cache";
            this.cb_Cache.Size = new System.Drawing.Size(130, 21);
            this.cb_Cache.TabIndex = 71;
            this.cb_Cache.Text = "Use local cache";
            this.cb_Cache.UseVisualStyleBackColor = true;
            // 
            // Form_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 376);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.gb_Timers);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.gb_ACM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Connection";
            this.ShowIcon = false;
            this.Text = "Network connection";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Connection_FormClosed);
            this.Load += new System.EventHandler(this.Form_Connection_Load);
            this.gb_ACM.ResumeLayout(false);
            this.gb_ACM.PerformLayout();
            this.gb_Timers.ResumeLayout(false);
            this.gb_Timers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ACM;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.TextBox tb_ACMPassword;
        private System.Windows.Forms.TextBox tb_ACMUsername;
        private System.Windows.Forms.TextBox tb_ACMServerPort;
        private System.Windows.Forms.TextBox tb_ACMServerIP;
        private System.Windows.Forms.Label label_ACMPAssword;
        private System.Windows.Forms.Label label_ACMUsername;
        private System.Windows.Forms.Label label_ACMServerPort;
        private System.Windows.Forms.Label label_ACMServerIP;
        private System.Windows.Forms.Button button_Hide;
        private System.Windows.Forms.GroupBox gb_Timers;
        private System.Windows.Forms.TextBox tb_CommandTimeout;
        private System.Windows.Forms.Label label_CommandTimeout;
        private System.Windows.Forms.TextBox tb_Timeout;
        private System.Windows.Forms.Label label_Timeout;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.CheckBox cb_Cache;
    }
}
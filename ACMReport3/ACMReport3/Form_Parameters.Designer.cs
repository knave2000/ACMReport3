namespace ACMReport3
{
    partial class Form_Parameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Parameters));
            this.button_Browse = new System.Windows.Forms.Button();
            this.tb_CommandTimeout = new System.Windows.Forms.TextBox();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_CommandTimeout = new System.Windows.Forms.Label();
            this.gb_Settings = new System.Windows.Forms.GroupBox();
            this.gb_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Browse
            // 
            this.button_Browse.BackgroundImage = global::ACMReport3.Properties.Resources.openToolStripButton_Image;
            this.button_Browse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Browse.Location = new System.Drawing.Point(433, 22);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(23, 23);
            this.button_Browse.TabIndex = 20;
            this.button_Browse.UseMnemonic = false;
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // tb_CommandTimeout
            // 
            this.tb_CommandTimeout.Location = new System.Drawing.Point(161, 23);
            this.tb_CommandTimeout.Name = "tb_CommandTimeout";
            this.tb_CommandTimeout.Size = new System.Drawing.Size(265, 22);
            this.tb_CommandTimeout.TabIndex = 10;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(371, 171);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(110, 30);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Сохранить";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // label_CommandTimeout
            // 
            this.label_CommandTimeout.AutoSize = true;
            this.label_CommandTimeout.Location = new System.Drawing.Point(7, 26);
            this.label_CommandTimeout.Name = "label_CommandTimeout";
            this.label_CommandTimeout.Size = new System.Drawing.Size(112, 17);
            this.label_CommandTimeout.TabIndex = 1;
            this.label_CommandTimeout.Text = "Путь к каталогу";
            // 
            // gb_Settings
            // 
            this.gb_Settings.Controls.Add(this.button_Browse);
            this.gb_Settings.Controls.Add(this.label_CommandTimeout);
            this.gb_Settings.Controls.Add(this.tb_CommandTimeout);
            this.gb_Settings.Location = new System.Drawing.Point(13, 13);
            this.gb_Settings.Name = "gb_Settings";
            this.gb_Settings.Size = new System.Drawing.Size(468, 152);
            this.gb_Settings.TabIndex = 0;
            this.gb_Settings.TabStop = false;
            this.gb_Settings.Text = "Модули";
            // 
            // Form_Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 210);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.gb_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Parameters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Parameters_FormClosed);
            this.gb_Settings.ResumeLayout(false);
            this.gb_Settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.TextBox tb_CommandTimeout;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Label label_CommandTimeout;
        private System.Windows.Forms.GroupBox gb_Settings;
    }
}
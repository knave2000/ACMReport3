namespace ACMReport3
{
    partial class Form_Data
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_BeginDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Load = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_EndTime);
            this.groupBox1.Controls.Add(this.dateTimePicker_BeginTime);
            this.groupBox1.Controls.Add(this.dateTimePicker_EndDate);
            this.groupBox1.Controls.Add(this.dateTimePicker_BeginDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // dateTimePicker_EndTime
            // 
            this.dateTimePicker_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_EndTime.Location = new System.Drawing.Point(296, 48);
            this.dateTimePicker_EndTime.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_EndTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_EndTime.Name = "dateTimePicker_EndTime";
            this.dateTimePicker_EndTime.ShowUpDown = true;
            this.dateTimePicker_EndTime.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker_EndTime.TabIndex = 6;
            this.dateTimePicker_EndTime.Value = new System.DateTime(2018, 6, 10, 23, 59, 59, 0);
            // 
            // dateTimePicker_BeginTime
            // 
            this.dateTimePicker_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_BeginTime.Location = new System.Drawing.Point(296, 20);
            this.dateTimePicker_BeginTime.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_BeginTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_BeginTime.Name = "dateTimePicker_BeginTime";
            this.dateTimePicker_BeginTime.ShowUpDown = true;
            this.dateTimePicker_BeginTime.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker_BeginTime.TabIndex = 5;
            this.dateTimePicker_BeginTime.Value = new System.DateTime(2018, 6, 10, 0, 0, 0, 0);
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(120, 48);
            this.dateTimePicker_EndDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_EndDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(170, 22);
            this.dateTimePicker_EndDate.TabIndex = 4;
            // 
            // dateTimePicker_BeginDate
            // 
            this.dateTimePicker_BeginDate.Location = new System.Drawing.Point(120, 20);
            this.dateTimePicker_BeginDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_BeginDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_BeginDate.Name = "dateTimePicker_BeginDate";
            this.dateTimePicker_BeginDate.Size = new System.Drawing.Size(170, 22);
            this.dateTimePicker_BeginDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Окончание";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало";
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(308, 105);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(110, 30);
            this.button_Load.TabIndex = 1;
            this.button_Load.Text = "Загрузить";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Form_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 142);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Data";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Загрузка данных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_BeginDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_EndTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_BeginTime;
    }
}
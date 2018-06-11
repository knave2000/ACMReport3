namespace ACMReport3
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сетевоеПодключениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнительныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataView1 = new System.Data.DataView();
            this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem,
            this.выходToolStripMenuItem1,
            this.выходToolStripMenuItem2});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.выходToolStripMenuItem.Text = "О программе";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem1
            // 
            this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            this.выходToolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // выходToolStripMenuItem2
            // 
            this.выходToolStripMenuItem2.Name = "выходToolStripMenuItem2";
            this.выходToolStripMenuItem2.Size = new System.Drawing.Size(216, 26);
            this.выходToolStripMenuItem2.Text = "Выход";
            this.выходToolStripMenuItem2.Click += new System.EventHandler(this.выходToolStripMenuItem2_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сетевоеПодключениеToolStripMenuItem,
            this.дополнительныеToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // сетевоеПодключениеToolStripMenuItem
            // 
            this.сетевоеПодключениеToolStripMenuItem.Name = "сетевоеПодключениеToolStripMenuItem";
            this.сетевоеПодключениеToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.сетевоеПодключениеToolStripMenuItem.Text = "Сетевое подключение";
            this.сетевоеПодключениеToolStripMenuItem.Click += new System.EventHandler(this.сетевоеПодключениеToolStripMenuItem_Click);
            // 
            // дополнительныеToolStripMenuItem
            // 
            this.дополнительныеToolStripMenuItem.Name = "дополнительныеToolStripMenuItem";
            this.дополнительныеToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.дополнительныеToolStripMenuItem.Text = "Дополнительные";
            this.дополнительныеToolStripMenuItem.Click += new System.EventHandler(this.дополнительныеToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьДанныеToolStripMenuItem,
            this.toolStripSeparator1,
            this.сформироватьОтчетToolStripMenuItem,
            this.создатьОтчетToolStripMenuItem,
            this.редактироватьОтчетToolStripMenuItem,
            this.удалитьОтчетToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // загрузитьДанныеToolStripMenuItem
            // 
            this.загрузитьДанныеToolStripMenuItem.Name = "загрузитьДанныеToolStripMenuItem";
            this.загрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить данные";
            // 
            // сформироватьОтчетToolStripMenuItem
            // 
            this.сформироватьОтчетToolStripMenuItem.Name = "сформироватьОтчетToolStripMenuItem";
            this.сформироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.сформироватьОтчетToolStripMenuItem.Text = "Сформировать отчет";
            // 
            // создатьОтчетToolStripMenuItem
            // 
            this.создатьОтчетToolStripMenuItem.Name = "создатьОтчетToolStripMenuItem";
            this.создатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.создатьОтчетToolStripMenuItem.Text = "Создать отчет";
            // 
            // редактироватьОтчетToolStripMenuItem
            // 
            this.редактироватьОтчетToolStripMenuItem.Name = "редактироватьОтчетToolStripMenuItem";
            this.редактироватьОтчетToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.редактироватьОтчетToolStripMenuItem.Text = "Редактировать отчет";
            // 
            // удалитьОтчетToolStripMenuItem
            // 
            this.удалитьОтчетToolStripMenuItem.Name = "удалитьОтчетToolStripMenuItem";
            this.удалитьОтчетToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.удалитьОтчетToolStripMenuItem.Text = "Удалить отчет";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "ACM Report";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сетевоеПодключениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator выходToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem2;
        private System.Data.DataView dataView1;
        private System.Windows.Forms.ToolStripMenuItem дополнительныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}


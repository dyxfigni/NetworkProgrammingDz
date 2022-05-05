namespace WeatheFilmInfo
{
    partial class Form1
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
            this.edDol = new System.Windows.Forms.TextBox();
            this.edCity = new System.Windows.Forms.TextBox();
            this.edShyr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbWeather = new System.Windows.Forms.ListBox();
            this.lbAnalys = new System.Windows.Forms.ListBox();
            this.lbCoord = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.edCountry = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edDol
            // 
            this.edDol.Location = new System.Drawing.Point(12, 55);
            this.edDol.Name = "edDol";
            this.edDol.Size = new System.Drawing.Size(100, 20);
            this.edDol.TabIndex = 0;
            // 
            // edCity
            // 
            this.edCity.Location = new System.Drawing.Point(12, 188);
            this.edCity.Name = "edCity";
            this.edCity.Size = new System.Drawing.Size(100, 20);
            this.edCity.TabIndex = 1;
            // 
            // edShyr
            // 
            this.edShyr.Location = new System.Drawing.Point(12, 94);
            this.edShyr.Name = "edShyr";
            this.edShyr.Size = new System.Drawing.Size(100, 20);
            this.edShyr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите Долготу и Ширину";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Долгота:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "пустым и введите город";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Или оставьте поле";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Имя города";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 258);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 23);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Пуск";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbWeather
            // 
            this.lbWeather.FormattingEnabled = true;
            this.lbWeather.Location = new System.Drawing.Point(159, 38);
            this.lbWeather.Name = "lbWeather";
            this.lbWeather.Size = new System.Drawing.Size(456, 199);
            this.lbWeather.TabIndex = 9;
            // 
            // lbAnalys
            // 
            this.lbAnalys.FormattingEnabled = true;
            this.lbAnalys.Location = new System.Drawing.Point(12, 300);
            this.lbAnalys.Name = "lbAnalys";
            this.lbAnalys.Size = new System.Drawing.Size(294, 199);
            this.lbAnalys.TabIndex = 10;
            // 
            // lbCoord
            // 
            this.lbCoord.FormattingEnabled = true;
            this.lbCoord.Location = new System.Drawing.Point(312, 300);
            this.lbCoord.Name = "lbCoord";
            this.lbCoord.Size = new System.Drawing.Size(303, 199);
            this.lbCoord.TabIndex = 11;
            this.lbCoord.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Прогноз погоды";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Код из документа погоды";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Код из документа координат ";
            // 
            // edCountry
            // 
            this.edCountry.Location = new System.Drawing.Point(12, 232);
            this.edCountry.Name = "edCountry";
            this.edCountry.Size = new System.Drawing.Size(100, 20);
            this.edCountry.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Страна";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 511);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.edCountry);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbCoord);
            this.Controls.Add(this.lbAnalys);
            this.Controls.Add(this.lbWeather);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edShyr);
            this.Controls.Add(this.edCity);
            this.Controls.Add(this.edDol);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edDol;
        private System.Windows.Forms.TextBox edCity;
        private System.Windows.Forms.TextBox edShyr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox lbWeather;
        private System.Windows.Forms.ListBox lbAnalys;
        private System.Windows.Forms.ListBox lbCoord;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox edCountry;
        private System.Windows.Forms.Label label10;
    }
}


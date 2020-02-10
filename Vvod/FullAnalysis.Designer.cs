namespace Vvod
{
    partial class FullAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullAnalysis));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox_1 = new System.Windows.Forms.ListBox();
            this.button_1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CountWords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StatusL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(171, 66);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(487, 274);
            this.textBox1.TabIndex = 5;
            // 
            // listBox_1
            // 
            this.listBox_1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_1.FormattingEnabled = true;
            this.listBox_1.ItemHeight = 15;
            this.listBox_1.Location = new System.Drawing.Point(12, 66);
            this.listBox_1.Name = "listBox_1";
            this.listBox_1.Size = new System.Drawing.Size(153, 274);
            this.listBox_1.TabIndex = 4;
            this.listBox_1.SelectedIndexChanged += new System.EventHandler(this.listBox_1_SelectedIndexChanged_1);
            // 
            // button_1
            // 
            this.button_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_1.Location = new System.Drawing.Point(171, 22);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(153, 41);
            this.button_1.TabIndex = 3;
            this.button_1.Text = "Полный анализ текста";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Прилагательные",
            "Числительные",
            "Существительные",
            "Местоимения",
            "Глаголы",
            "Наречия",
            "Предлоги",
            "Союзы",
            "Частицы",
            "Причастия",
            "Деепричастия",
            "Не определённые"});
            this.comboBox1.Location = new System.Drawing.Point(12, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CountWords
            // 
            this.CountWords.AutoSize = true;
            this.CountWords.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountWords.Location = new System.Drawing.Point(344, 33);
            this.CountWords.Name = "CountWords";
            this.CountWords.Size = new System.Drawing.Size(0, 15);
            this.CountWords.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Выберите часть речи:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 41);
            this.button1.TabIndex = 28;
            this.button1.Text = "Сохранить результаты в файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_2_Click);
            // 
            // StatusL
            // 
            this.StatusL.AutoSize = true;
            this.StatusL.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusL.Location = new System.Drawing.Point(182, 360);
            this.StatusL.Name = "StatusL";
            this.StatusL.Size = new System.Drawing.Size(0, 15);
            this.StatusL.TabIndex = 29;
            // 
            // FullAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(678, 401);
            this.Controls.Add(this.StatusL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox_1);
            this.Controls.Add(this.button_1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FullAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты анализа";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FullAnalysis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox_1;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label CountWords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label StatusL;
    }
}
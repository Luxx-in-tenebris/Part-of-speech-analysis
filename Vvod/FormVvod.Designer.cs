namespace Vvod
{
    partial class FormVvod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVvod));
            this.TextBoxSentence = new System.Windows.Forms.TextBox();
            this.ButtonControl = new System.Windows.Forms.Button();
            this.ButtonReadFile = new System.Windows.Forms.Button();
            this.LFileName = new System.Windows.Forms.Label();
            this.LFileNameF = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // TextBoxSentence
            // 
            this.TextBoxSentence.BackColor = System.Drawing.Color.White;
            this.TextBoxSentence.Location = new System.Drawing.Point(12, 30);
            this.TextBoxSentence.Multiline = true;
            this.TextBoxSentence.Name = "TextBoxSentence";
            this.TextBoxSentence.Size = new System.Drawing.Size(571, 407);
            this.TextBoxSentence.TabIndex = 0;
            // 
            // ButtonControl
            // 
            this.ButtonControl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonControl.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonControl.Location = new System.Drawing.Point(12, 443);
            this.ButtonControl.Name = "ButtonControl";
            this.ButtonControl.Size = new System.Drawing.Size(203, 52);
            this.ButtonControl.TabIndex = 3;
            this.ButtonControl.Text = "Анализ введенного текста";
            this.ButtonControl.UseVisualStyleBackColor = true;
            this.ButtonControl.Click += new System.EventHandler(this.ButtonControl_Click);
            // 
            // ButtonReadFile
            // 
            this.ButtonReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonReadFile.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonReadFile.Location = new System.Drawing.Point(380, 442);
            this.ButtonReadFile.Name = "ButtonReadFile";
            this.ButtonReadFile.Size = new System.Drawing.Size(203, 53);
            this.ButtonReadFile.TabIndex = 5;
            this.ButtonReadFile.Text = "Анализ текста из файла";
            this.ButtonReadFile.UseVisualStyleBackColor = true;
            this.ButtonReadFile.Click += new System.EventHandler(this.ButtonReadFile_Click);
            // 
            // LFileName
            // 
            this.LFileName.AutoSize = true;
            this.LFileName.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LFileName.Location = new System.Drawing.Point(25, 532);
            this.LFileName.Name = "LFileName";
            this.LFileName.Size = new System.Drawing.Size(0, 15);
            this.LFileName.TabIndex = 6;
            // 
            // LFileNameF
            // 
            this.LFileNameF.AutoSize = true;
            this.LFileNameF.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LFileNameF.Location = new System.Drawing.Point(25, 513);
            this.LFileNameF.Name = "LFileNameF";
            this.LFileNameF.Size = new System.Drawing.Size(0, 15);
            this.LFileNameF.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ввод текста с клавиатуры:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormVvod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(622, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LFileNameF);
            this.Controls.Add(this.LFileName);
            this.Controls.Add(this.ButtonReadFile);
            this.Controls.Add(this.ButtonControl);
            this.Controls.Add(this.TextBoxSentence);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormVvod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ текста";
            this.Load += new System.EventHandler(this.FormVvod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxSentence;
        private System.Windows.Forms.Button ButtonControl;
        private System.Windows.Forms.Button ButtonReadFile;
        private System.Windows.Forms.Label LFileName;
        private System.Windows.Forms.Label LFileNameF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


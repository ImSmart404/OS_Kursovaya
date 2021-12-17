
namespace Client_Mikhaylov
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
            this.list_box = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.send_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // list_box
            // 
            this.list_box.FormattingEnabled = true;
            this.list_box.Location = new System.Drawing.Point(90, 63);
            this.list_box.Name = "list_box";
            this.list_box.Size = new System.Drawing.Size(366, 238);
            this.list_box.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "Подключение к серверу 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(477, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 90);
            this.button2.TabIndex = 2;
            this.button2.Text = "Подключение к серверу 2\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(477, 337);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите байты, мегабайты или гигабайты:\r\n";
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(653, 334);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 5;
            this.send_btn.Text = "Отправить";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 915);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox list_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button send_btn;
    }
}


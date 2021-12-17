namespace server1
{
    partial class Form1
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
            this.btn_ClearInformation = new System.Windows.Forms.Button();
            this.List_box = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_ClearInformation
            // 
            this.btn_ClearInformation.Location = new System.Drawing.Point(0, 0);
            this.btn_ClearInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ClearInformation.Name = "btn_ClearInformation";
            this.btn_ClearInformation.Size = new System.Drawing.Size(87, 20);
            this.btn_ClearInformation.TabIndex = 4;
            // 
            // List_box
            // 
            this.List_box.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.List_box.FormattingEnabled = true;
            this.List_box.Location = new System.Drawing.Point(0, 0);
            this.List_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.List_box.Name = "List_box";
            this.List_box.Size = new System.Drawing.Size(382, 225);
            this.List_box.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 240);
            this.Controls.Add(this.List_box);
            this.Controls.Add(this.btn_ClearInformation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(931, 344);
            this.MinimumSize = new System.Drawing.Size(231, 175);
            this.Name = "Form1";
            this.Text = "Server №1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ClearInformation;
        private System.Windows.Forms.ListBox List_box;
    }
}


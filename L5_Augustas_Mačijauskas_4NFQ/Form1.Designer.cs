﻿namespace L1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.skaiciuoti = new System.Windows.Forms.Button();
            this.baigti = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.read = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBox1.Location = new System.Drawing.Point(23, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(756, 487);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // skaiciuoti
            // 
            this.skaiciuoti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skaiciuoti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaiciuoti.Location = new System.Drawing.Point(798, 174);
            this.skaiciuoti.Name = "skaiciuoti";
            this.skaiciuoti.Size = new System.Drawing.Size(105, 53);
            this.skaiciuoti.TabIndex = 1;
            this.skaiciuoti.Text = "Skaičiuoti";
            this.skaiciuoti.UseVisualStyleBackColor = true;
            this.skaiciuoti.Click += new System.EventHandler(this.skaiciuoti_Click);
            // 
            // baigti
            // 
            this.baigti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.baigti.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.baigti.Location = new System.Drawing.Point(947, 459);
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(105, 53);
            this.baigti.TabIndex = 2;
            this.baigti.Text = "Baigti";
            this.baigti.UseVisualStyleBackColor = true;
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // print
            // 
            this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.print.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.print.Location = new System.Drawing.Point(798, 303);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(105, 53);
            this.print.TabIndex = 3;
            this.print.Text = "Spaudinti";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // read
            // 
            this.read.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.read.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.read.Location = new System.Drawing.Point(798, 26);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(105, 53);
            this.read.TabIndex = 4;
            this.read.Text = "Skaityti";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.textBox1.Location = new System.Drawing.Point(798, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 26);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Įveskite norimą amžių";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 524);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.read);
            this.Controls.Add(this.print);
            this.Controls.Add(this.baigti);
            this.Controls.Add(this.skaiciuoti);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(1086, 563);
            this.Name = "Form1";
            this.Text = "Krepšininkai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button skaiciuoti;
        private System.Windows.Forms.Button baigti;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.TextBox textBox1;
    }
}


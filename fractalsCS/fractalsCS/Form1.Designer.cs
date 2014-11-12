namespace fractalsCS
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFrac1 = new System.Windows.Forms.Button();
            this.btnFrac2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFrac3 = new System.Windows.Forms.Button();
            this.btnFrac4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnFrac1
            // 
            this.btnFrac1.Location = new System.Drawing.Point(9, 253);
            this.btnFrac1.Name = "btnFrac1";
            this.btnFrac1.Size = new System.Drawing.Size(61, 23);
            this.btnFrac1.TabIndex = 1;
            this.btnFrac1.Text = "Fractal 1";
            this.btnFrac1.UseVisualStyleBackColor = true;
            this.btnFrac1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFrac2
            // 
            this.btnFrac2.Location = new System.Drawing.Point(81, 253);
            this.btnFrac2.Name = "btnFrac2";
            this.btnFrac2.Size = new System.Drawing.Size(61, 23);
            this.btnFrac2.TabIndex = 2;
            this.btnFrac2.Text = "Fractal 2";
            this.btnFrac2.UseVisualStyleBackColor = true;
            this.btnFrac2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 226);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ratio Rects.:";
            // 
            // btnFrac3
            // 
            this.btnFrac3.Location = new System.Drawing.Point(148, 253);
            this.btnFrac3.Name = "btnFrac3";
            this.btnFrac3.Size = new System.Drawing.Size(61, 23);
            this.btnFrac3.TabIndex = 7;
            this.btnFrac3.Text = "Fractal 3";
            this.btnFrac3.UseVisualStyleBackColor = true;
            this.btnFrac3.Click += new System.EventHandler(this.btnFrac3_Click);
            // 
            // btnFrac4
            // 
            this.btnFrac4.Location = new System.Drawing.Point(148, 221);
            this.btnFrac4.Name = "btnFrac4";
            this.btnFrac4.Size = new System.Drawing.Size(61, 23);
            this.btnFrac4.TabIndex = 8;
            this.btnFrac4.Text = "Fractal 4";
            this.btnFrac4.UseVisualStyleBackColor = true;
            this.btnFrac4.Click += new System.EventHandler(this.btnFrac4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 285);
            this.Controls.Add(this.btnFrac4);
            this.Controls.Add(this.btnFrac3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnFrac2);
            this.Controls.Add(this.btnFrac1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Fractals";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFrac1;
        private System.Windows.Forms.Button btnFrac2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFrac3;
        private System.Windows.Forms.Button btnFrac4;
    }
}


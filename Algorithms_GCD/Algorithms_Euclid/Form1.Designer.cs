namespace Algorithms_Euclid
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
            this.textNumberA = new System.Windows.Forms.TextBox();
            this.textNumberB = new System.Windows.Forms.TextBox();
            this.btnCalculateEuclid = new System.Windows.Forms.Button();
            this.lbResult = new System.Windows.Forms.Label();
            this.radioSubtraction = new System.Windows.Forms.RadioButton();
            this.radioModulo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radRecursive = new System.Windows.Forms.RadioButton();
            this.textAnalysis = new System.Windows.Forms.RichTextBox();
            this.radPrimeFactorization = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textNumberA
            // 
            this.textNumberA.Location = new System.Drawing.Point(29, 81);
            this.textNumberA.Name = "textNumberA";
            this.textNumberA.Size = new System.Drawing.Size(132, 20);
            this.textNumberA.TabIndex = 0;
            this.textNumberA.TextChanged += new System.EventHandler(this.textNumberA_TextChanged);
            // 
            // textNumberB
            // 
            this.textNumberB.Location = new System.Drawing.Point(29, 131);
            this.textNumberB.Name = "textNumberB";
            this.textNumberB.Size = new System.Drawing.Size(132, 20);
            this.textNumberB.TabIndex = 1;
            // 
            // btnCalculateEuclid
            // 
            this.btnCalculateEuclid.Location = new System.Drawing.Point(212, 101);
            this.btnCalculateEuclid.Name = "btnCalculateEuclid";
            this.btnCalculateEuclid.Size = new System.Drawing.Size(92, 23);
            this.btnCalculateEuclid.TabIndex = 2;
            this.btnCalculateEuclid.Text = "Calculate GCD";
            this.btnCalculateEuclid.UseVisualStyleBackColor = true;
            this.btnCalculateEuclid.Click += new System.EventHandler(this.btnCalculateEuclid_Click);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(215, 136);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(0, 13);
            this.lbResult.TabIndex = 3;
            // 
            // radioSubtraction
            // 
            this.radioSubtraction.AutoSize = true;
            this.radioSubtraction.Location = new System.Drawing.Point(31, 48);
            this.radioSubtraction.Name = "radioSubtraction";
            this.radioSubtraction.Size = new System.Drawing.Size(79, 17);
            this.radioSubtraction.TabIndex = 4;
            this.radioSubtraction.TabStop = true;
            this.radioSubtraction.Text = "Subtraction";
            this.radioSubtraction.UseVisualStyleBackColor = true;
            // 
            // radioModulo
            // 
            this.radioModulo.AutoSize = true;
            this.radioModulo.Location = new System.Drawing.Point(139, 48);
            this.radioModulo.Name = "radioModulo";
            this.radioModulo.Size = new System.Drawing.Size(60, 17);
            this.radioModulo.TabIndex = 5;
            this.radioModulo.TabStop = true;
            this.radioModulo.Text = "Modulo";
            this.radioModulo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "_____________________";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radRecursive
            // 
            this.radRecursive.AutoSize = true;
            this.radRecursive.Location = new System.Drawing.Point(229, 48);
            this.radRecursive.Name = "radRecursive";
            this.radRecursive.Size = new System.Drawing.Size(73, 17);
            this.radRecursive.TabIndex = 7;
            this.radRecursive.TabStop = true;
            this.radRecursive.Text = "Recursive";
            this.radRecursive.UseVisualStyleBackColor = true;
            // 
            // textAnalysis
            // 
            this.textAnalysis.Location = new System.Drawing.Point(29, 169);
            this.textAnalysis.Name = "textAnalysis";
            this.textAnalysis.Size = new System.Drawing.Size(275, 136);
            this.textAnalysis.TabIndex = 8;
            this.textAnalysis.Text = "";
            // 
            // radPrimeFactorization
            // 
            this.radPrimeFactorization.AutoSize = true;
            this.radPrimeFactorization.Location = new System.Drawing.Point(328, 47);
            this.radPrimeFactorization.Name = "radPrimeFactorization";
            this.radPrimeFactorization.Size = new System.Drawing.Size(114, 17);
            this.radPrimeFactorization.TabIndex = 9;
            this.radPrimeFactorization.TabStop = true;
            this.radPrimeFactorization.Text = "Prime Factorization";
            this.radPrimeFactorization.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(578, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluationToolStripMenuItem,
            this.calculatorToolStripMenuItem});
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.modesToolStripMenuItem.Text = "Modes";
            // 
            // evaluationToolStripMenuItem
            // 
            this.evaluationToolStripMenuItem.Name = "evaluationToolStripMenuItem";
            this.evaluationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.evaluationToolStripMenuItem.Text = "Evaluation";
            this.evaluationToolStripMenuItem.Click += new System.EventHandler(this.evaluationToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 313);
            this.Controls.Add(this.radPrimeFactorization);
            this.Controls.Add(this.textAnalysis);
            this.Controls.Add(this.radRecursive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioModulo);
            this.Controls.Add(this.radioSubtraction);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.btnCalculateEuclid);
            this.Controls.Add(this.textNumberB);
            this.Controls.Add(this.textNumberA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Greatest Common Divisor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNumberA;
        private System.Windows.Forms.TextBox textNumberB;
        public System.Windows.Forms.Button btnCalculateEuclid;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.RadioButton radioSubtraction;
        private System.Windows.Forms.RadioButton radioModulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radRecursive;
        private System.Windows.Forms.RichTextBox textAnalysis;
        private System.Windows.Forms.RadioButton radPrimeFactorization;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaluationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
    }
}


namespace Homework2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.btnGenerateNGrams = new System.Windows.Forms.Button();
            this.btnTriggerPreprocesses = new System.Windows.Forms.Button();
            this.btnLoadCorpus = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchTermResults = new System.Windows.Forms.RichTextBox();
            this.btnSearchTerm = new System.Windows.Forms.Button();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchSentences = new System.Windows.Forms.TextBox();
            this.btnSimilarSentences = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxDistance = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.btnGenerateNGrams);
            this.panel1.Controls.Add(this.btnTriggerPreprocesses);
            this.panel1.Controls.Add(this.btnLoadCorpus);
            this.panel1.Location = new System.Drawing.Point(13, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 186);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Extraction and Preprocesses";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(249, 60);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(385, 105);
            this.txtInfo.TabIndex = 3;
            this.txtInfo.Text = "";
            // 
            // btnGenerateNGrams
            // 
            this.btnGenerateNGrams.Location = new System.Drawing.Point(38, 142);
            this.btnGenerateNGrams.Name = "btnGenerateNGrams";
            this.btnGenerateNGrams.Size = new System.Drawing.Size(134, 23);
            this.btnGenerateNGrams.TabIndex = 2;
            this.btnGenerateNGrams.Text = "Generate N-Grams";
            this.btnGenerateNGrams.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateNGrams.UseVisualStyleBackColor = true;
            this.btnGenerateNGrams.Click += new System.EventHandler(this.btnGenerateNGrams_Click);
            // 
            // btnTriggerPreprocesses
            // 
            this.btnTriggerPreprocesses.Location = new System.Drawing.Point(38, 100);
            this.btnTriggerPreprocesses.Name = "btnTriggerPreprocesses";
            this.btnTriggerPreprocesses.Size = new System.Drawing.Size(134, 23);
            this.btnTriggerPreprocesses.TabIndex = 1;
            this.btnTriggerPreprocesses.Text = "Trigger preprocessing";
            this.btnTriggerPreprocesses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTriggerPreprocesses.UseVisualStyleBackColor = true;
            this.btnTriggerPreprocesses.Click += new System.EventHandler(this.btnTriggerPreprocesses_Click);
            // 
            // btnLoadCorpus
            // 
            this.btnLoadCorpus.Location = new System.Drawing.Point(38, 60);
            this.btnLoadCorpus.Name = "btnLoadCorpus";
            this.btnLoadCorpus.Size = new System.Drawing.Size(134, 23);
            this.btnLoadCorpus.TabIndex = 0;
            this.btnLoadCorpus.Text = "Add document";
            this.btnLoadCorpus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoadCorpus.UseVisualStyleBackColor = true;
            this.btnLoadCorpus.Click += new System.EventHandler(this.btnLoadCorpus_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtSearchTermResults);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 283);
            this.panel2.TabIndex = 1;
            // 
            // txtSearchTermResults
            // 
            this.txtSearchTermResults.Location = new System.Drawing.Point(249, 43);
            this.txtSearchTermResults.Name = "txtSearchTermResults";
            this.txtSearchTermResults.Size = new System.Drawing.Size(385, 230);
            this.txtSearchTermResults.TabIndex = 6;
            this.txtSearchTermResults.Text = "";
            // 
            // btnSearchTerm
            // 
            this.btnSearchTerm.Location = new System.Drawing.Point(24, 72);
            this.btnSearchTerm.Name = "btnSearchTerm";
            this.btnSearchTerm.Size = new System.Drawing.Size(134, 23);
            this.btnSearchTerm.TabIndex = 8;
            this.btnSearchTerm.Text = "Search term";
            this.btnSearchTerm.UseVisualStyleBackColor = true;
            this.btnSearchTerm.Click += new System.EventHandler(this.btnSearchTerm_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(12, 22);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(183, 20);
            this.txtSearchTerm.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search";
            // 
            // txtSearchSentences
            // 
            this.txtSearchSentences.Location = new System.Drawing.Point(12, 7);
            this.txtSearchSentences.Name = "txtSearchSentences";
            this.txtSearchSentences.Size = new System.Drawing.Size(183, 20);
            this.txtSearchSentences.TabIndex = 9;
            // 
            // btnSimilarSentences
            // 
            this.btnSimilarSentences.Location = new System.Drawing.Point(24, 69);
            this.btnSimilarSentences.Name = "btnSimilarSentences";
            this.btnSimilarSentences.Size = new System.Drawing.Size(134, 23);
            this.btnSimilarSentences.TabIndex = 10;
            this.btnSimilarSentences.Text = "Similar sentences";
            this.btnSimilarSentences.UseVisualStyleBackColor = true;
            this.btnSimilarSentences.Click += new System.EventHandler(this.btnSimilarSentences_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Distance:";
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(118, 43);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(77, 20);
            this.txtMaxDistance.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSearchTerm);
            this.panel3.Controls.Add(this.txtSearchTerm);
            this.panel3.Location = new System.Drawing.Point(13, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 105);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSimilarSentences);
            this.panel4.Controls.Add(this.txtMaxDistance);
            this.panel4.Controls.Add(this.txtSearchSentences);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(13, 166);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 107);
            this.panel4.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "A&O - Homework2 - NGram Search - (c) Sascha Feldmann ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Button btnGenerateNGrams;
        private System.Windows.Forms.Button btnTriggerPreprocesses;
        private System.Windows.Forms.Button btnLoadCorpus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearchTerm;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtSearchTermResults;
        private System.Windows.Forms.Button btnSimilarSentences;
        private System.Windows.Forms.TextBox txtSearchSentences;
        private System.Windows.Forms.TextBox txtMaxDistance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}


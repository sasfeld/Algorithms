namespace Homework1
{
    partial class EvaluationForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartEvaluation = new System.Windows.Forms.Button();
            this.textN3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textN2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textN1 = new System.Windows.Forms.TextBox();
            this.textAnalysis = new System.Windows.Forms.RichTextBox();
            this.evaluationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNumberOfSteps = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboDiagramMethods = new System.Windows.Forms.ComboBox();
            this.btnComputingTimesTicks = new System.Windows.Forms.Button();
            this.btnHistogramTicks = new System.Windows.Forms.Button();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.textX3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCalculateX1N1 = new System.Windows.Forms.Button();
            this.btnCalculateX2N2 = new System.Windows.Forms.Button();
            this.btnCalculateX3N3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnCalculateX3N3);
            this.panel1.Controls.Add(this.btnCalculateX2N2);
            this.panel1.Controls.Add(this.btnCalculateX1N1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textX3);
            this.panel1.Controls.Add(this.textX2);
            this.panel1.Controls.Add(this.textX1);
            this.panel1.Controls.Add(this.btnStartEvaluation);
            this.panel1.Controls.Add(this.textN3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textN2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textN1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 182);
            this.panel1.TabIndex = 0;
            // 
            // btnStartEvaluation
            // 
            this.btnStartEvaluation.Location = new System.Drawing.Point(12, 134);
            this.btnStartEvaluation.Name = "btnStartEvaluation";
            this.btnStartEvaluation.Size = new System.Drawing.Size(109, 23);
            this.btnStartEvaluation.TabIndex = 6;
            this.btnStartEvaluation.Text = "Start Evaluation";
            this.btnStartEvaluation.UseVisualStyleBackColor = true;
            this.btnStartEvaluation.Click += new System.EventHandler(this.btnStartEvaluation_Click);
            // 
            // textN3
            // 
            this.textN3.Location = new System.Drawing.Point(37, 100);
            this.textN3.Name = "textN3";
            this.textN3.Size = new System.Drawing.Size(24, 20);
            this.textN3.TabIndex = 5;
            this.textN3.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "3:";
            // 
            // textN2
            // 
            this.textN2.Location = new System.Drawing.Point(37, 67);
            this.textN2.Name = "textN2";
            this.textN2.Size = new System.Drawing.Size(24, 20);
            this.textN2.TabIndex = 3;
            this.textN2.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "2:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textN1
            // 
            this.textN1.Location = new System.Drawing.Point(37, 34);
            this.textN1.Name = "textN1";
            this.textN1.Size = new System.Drawing.Size(24, 20);
            this.textN1.TabIndex = 0;
            this.textN1.Text = "3";
            // 
            // textAnalysis
            // 
            this.textAnalysis.Location = new System.Drawing.Point(282, 12);
            this.textAnalysis.Name = "textAnalysis";
            this.textAnalysis.Size = new System.Drawing.Size(568, 165);
            this.textAnalysis.TabIndex = 9;
            this.textAnalysis.Text = "";
            // 
            // evaluationChart
            // 
            chartArea10.Name = "ChartArea1";
            this.evaluationChart.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.evaluationChart.Legends.Add(legend10);
            this.evaluationChart.Location = new System.Drawing.Point(12, 301);
            this.evaluationChart.Name = "evaluationChart";
            series10.ChartArea = "ChartArea1";
            series10.Legend = "Legend1";
            series10.Name = "Series1";
            this.evaluationChart.Series.Add(series10);
            this.evaluationChart.Size = new System.Drawing.Size(1001, 548);
            this.evaluationChart.TabIndex = 10;
            this.evaluationChart.Text = "chartNumberOfSteps";
            // 
            // btnNumberOfSteps
            // 
            this.btnNumberOfSteps.Location = new System.Drawing.Point(12, 254);
            this.btnNumberOfSteps.Name = "btnNumberOfSteps";
            this.btnNumberOfSteps.Size = new System.Drawing.Size(109, 23);
            this.btnNumberOfSteps.TabIndex = 11;
            this.btnNumberOfSteps.Text = "Number of Steps";
            this.btnNumberOfSteps.UseVisualStyleBackColor = true;
            this.btnNumberOfSteps.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Steps Histogram";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Computing Times (ms)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(149, 283);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Times Histogram (ms)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboDiagramMethods
            // 
            this.comboDiagramMethods.FormattingEnabled = true;
            this.comboDiagramMethods.Location = new System.Drawing.Point(139, 211);
            this.comboDiagramMethods.Name = "comboDiagramMethods";
            this.comboDiagramMethods.Size = new System.Drawing.Size(121, 21);
            this.comboDiagramMethods.TabIndex = 15;
            // 
            // btnComputingTimesTicks
            // 
            this.btnComputingTimesTicks.Location = new System.Drawing.Point(311, 254);
            this.btnComputingTimesTicks.Name = "btnComputingTimesTicks";
            this.btnComputingTimesTicks.Size = new System.Drawing.Size(129, 23);
            this.btnComputingTimesTicks.TabIndex = 16;
            this.btnComputingTimesTicks.Text = "Computing Times (ticks)";
            this.btnComputingTimesTicks.UseVisualStyleBackColor = true;
            this.btnComputingTimesTicks.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnHistogramTicks
            // 
            this.btnHistogramTicks.Location = new System.Drawing.Point(311, 283);
            this.btnHistogramTicks.Name = "btnHistogramTicks";
            this.btnHistogramTicks.Size = new System.Drawing.Size(129, 23);
            this.btnHistogramTicks.TabIndex = 17;
            this.btnHistogramTicks.Text = "Times Histogram (ticks)";
            this.btnHistogramTicks.UseVisualStyleBackColor = true;
            this.btnHistogramTicks.Click += new System.EventHandler(this.button5_Click);
            // 
            // textX1
            // 
            this.textX1.Location = new System.Drawing.Point(85, 34);
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(24, 20);
            this.textX1.TabIndex = 7;
            this.textX1.Text = "3";
            // 
            // textX2
            // 
            this.textX2.Location = new System.Drawing.Point(85, 67);
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(24, 20);
            this.textX2.TabIndex = 8;
            this.textX2.Text = "3";
            // 
            // textX3
            // 
            this.textX3.Location = new System.Drawing.Point(85, 100);
            this.textX3.Name = "textX3";
            this.textX3.Size = new System.Drawing.Size(24, 20);
            this.textX3.TabIndex = 9;
            this.textX3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Location = new System.Drawing.Point(87, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Location = new System.Drawing.Point(40, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "n";
            // 
            // btnCalculateX1N1
            // 
            this.btnCalculateX1N1.Location = new System.Drawing.Point(127, 32);
            this.btnCalculateX1N1.Name = "btnCalculateX1N1";
            this.btnCalculateX1N1.Size = new System.Drawing.Size(109, 23);
            this.btnCalculateX1N1.TabIndex = 12;
            this.btnCalculateX1N1.Text = "Calculate";
            this.btnCalculateX1N1.UseVisualStyleBackColor = true;
            this.btnCalculateX1N1.Click += new System.EventHandler(this.btnCalculateX1N1_Click);
            // 
            // btnCalculateX2N2
            // 
            this.btnCalculateX2N2.Location = new System.Drawing.Point(127, 65);
            this.btnCalculateX2N2.Name = "btnCalculateX2N2";
            this.btnCalculateX2N2.Size = new System.Drawing.Size(109, 23);
            this.btnCalculateX2N2.TabIndex = 13;
            this.btnCalculateX2N2.Text = "Calculate";
            this.btnCalculateX2N2.UseVisualStyleBackColor = true;
            this.btnCalculateX2N2.Click += new System.EventHandler(this.btnCalculateX2N2_Click);
            // 
            // btnCalculateX3N3
            // 
            this.btnCalculateX3N3.Location = new System.Drawing.Point(127, 99);
            this.btnCalculateX3N3.Name = "btnCalculateX3N3";
            this.btnCalculateX3N3.Size = new System.Drawing.Size(109, 23);
            this.btnCalculateX3N3.TabIndex = 14;
            this.btnCalculateX3N3.Text = "Calculate";
            this.btnCalculateX3N3.UseVisualStyleBackColor = true;
            this.btnCalculateX3N3.Click += new System.EventHandler(this.btnCalculateX3N3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Select Algorithm:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(169, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "x ^ n";
            // 
            // EvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 934);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnHistogramTicks);
            this.Controls.Add(this.btnComputingTimesTicks);
            this.Controls.Add(this.comboDiagramMethods);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNumberOfSteps);
            this.Controls.Add(this.evaluationChart);
            this.Controls.Add(this.textAnalysis);
            this.Controls.Add(this.panel1);
            this.Name = "EvaluationForm";
            this.Text = "Exponential EvaluationForm (c) Sascha Feldmann";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textN1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textN3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textN2;
        private System.Windows.Forms.Button btnStartEvaluation;
        private System.Windows.Forms.RichTextBox textAnalysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart evaluationChart;
        private System.Windows.Forms.Button btnNumberOfSteps;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboDiagramMethods;
        private System.Windows.Forms.Button btnComputingTimesTicks;
        private System.Windows.Forms.Button btnHistogramTicks;
        private System.Windows.Forms.TextBox textX3;
        private System.Windows.Forms.TextBox textX2;
        private System.Windows.Forms.TextBox textX1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalculateX3N3;
        private System.Windows.Forms.Button btnCalculateX2N2;
        private System.Windows.Forms.Button btnCalculateX1N1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
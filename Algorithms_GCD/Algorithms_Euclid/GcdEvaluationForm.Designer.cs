namespace Algorithms_Euclid
{
    partial class GcdEvaluationForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textNumberLoops = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartEvaluation = new System.Windows.Forms.Button();
            this.textMaximumRandomNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textMinimumRandomNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textNumberRandomPairs = new System.Windows.Forms.TextBox();
            this.textAnalysis = new System.Windows.Forms.RichTextBox();
            this.evaluationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNumberOfSteps = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboDiagramMethods = new System.Windows.Forms.ComboBox();
            this.btnComputingTimesTicks = new System.Windows.Forms.Button();
            this.btnHistogramTicks = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textNumberLoops);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnStartEvaluation);
            this.panel1.Controls.Add(this.textMaximumRandomNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textMinimumRandomNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textNumberRandomPairs);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 165);
            this.panel1.TabIndex = 0;
            // 
            // textNumberLoops
            // 
            this.textNumberLoops.Enabled = false;
            this.textNumberLoops.Location = new System.Drawing.Point(176, 105);
            this.textNumberLoops.Name = "textNumberLoops";
            this.textNumberLoops.Size = new System.Drawing.Size(51, 20);
            this.textNumberLoops.TabIndex = 8;
            this.textNumberLoops.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of loops:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnStartEvaluation
            // 
            this.btnStartEvaluation.Location = new System.Drawing.Point(12, 134);
            this.btnStartEvaluation.Name = "btnStartEvaluation";
            this.btnStartEvaluation.Size = new System.Drawing.Size(109, 23);
            this.btnStartEvaluation.TabIndex = 6;
            this.btnStartEvaluation.Text = "Start Evaluation";
            this.btnStartEvaluation.UseVisualStyleBackColor = true;
            this.btnStartEvaluation.Click += new System.EventHandler(this.btnStartEvaluation_Click_1);
            // 
            // textMaximumRandomNumber
            // 
            this.textMaximumRandomNumber.Location = new System.Drawing.Point(176, 76);
            this.textMaximumRandomNumber.Name = "textMaximumRandomNumber";
            this.textMaximumRandomNumber.Size = new System.Drawing.Size(51, 20);
            this.textMaximumRandomNumber.TabIndex = 5;
            this.textMaximumRandomNumber.Text = "100000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Maximum random number: ";
            // 
            // textMinimumRandomNumber
            // 
            this.textMinimumRandomNumber.Location = new System.Drawing.Point(176, 44);
            this.textMinimumRandomNumber.Name = "textMinimumRandomNumber";
            this.textMinimumRandomNumber.Size = new System.Drawing.Size(38, 20);
            this.textMinimumRandomNumber.TabIndex = 3;
            this.textMinimumRandomNumber.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minimum random number: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of random pairs: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textNumberRandomPairs
            // 
            this.textNumberRandomPairs.Location = new System.Drawing.Point(176, 11);
            this.textNumberRandomPairs.Name = "textNumberRandomPairs";
            this.textNumberRandomPairs.Size = new System.Drawing.Size(38, 20);
            this.textNumberRandomPairs.TabIndex = 0;
            this.textNumberRandomPairs.Text = "1000";
            // 
            // textAnalysis
            // 
            this.textAnalysis.Location = new System.Drawing.Point(282, 12);
            this.textAnalysis.Name = "textAnalysis";
            this.textAnalysis.Size = new System.Drawing.Size(370, 165);
            this.textAnalysis.TabIndex = 9;
            this.textAnalysis.Text = "";
            // 
            // evaluationChart
            // 
            chartArea1.Name = "ChartArea1";
            this.evaluationChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.evaluationChart.Legends.Add(legend1);
            this.evaluationChart.Location = new System.Drawing.Point(12, 262);
            this.evaluationChart.Name = "evaluationChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.evaluationChart.Series.Add(series1);
            this.evaluationChart.Size = new System.Drawing.Size(1001, 548);
            this.evaluationChart.TabIndex = 10;
            this.evaluationChart.Text = "chartNumberOfSteps";
            // 
            // btnNumberOfSteps
            // 
            this.btnNumberOfSteps.Location = new System.Drawing.Point(12, 200);
            this.btnNumberOfSteps.Name = "btnNumberOfSteps";
            this.btnNumberOfSteps.Size = new System.Drawing.Size(109, 23);
            this.btnNumberOfSteps.TabIndex = 11;
            this.btnNumberOfSteps.Text = "Number of Steps";
            this.btnNumberOfSteps.UseVisualStyleBackColor = true;
            this.btnNumberOfSteps.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Steps Histogram";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(149, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Computing Times (ms)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(149, 229);
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
            this.comboDiagramMethods.Location = new System.Drawing.Point(531, 200);
            this.comboDiagramMethods.Name = "comboDiagramMethods";
            this.comboDiagramMethods.Size = new System.Drawing.Size(121, 21);
            this.comboDiagramMethods.TabIndex = 15;
            // 
            // btnComputingTimesTicks
            // 
            this.btnComputingTimesTicks.Location = new System.Drawing.Point(311, 200);
            this.btnComputingTimesTicks.Name = "btnComputingTimesTicks";
            this.btnComputingTimesTicks.Size = new System.Drawing.Size(129, 23);
            this.btnComputingTimesTicks.TabIndex = 16;
            this.btnComputingTimesTicks.Text = "Computing Times (ticks)";
            this.btnComputingTimesTicks.UseVisualStyleBackColor = true;
            this.btnComputingTimesTicks.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnHistogramTicks
            // 
            this.btnHistogramTicks.Location = new System.Drawing.Point(311, 229);
            this.btnHistogramTicks.Name = "btnHistogramTicks";
            this.btnHistogramTicks.Size = new System.Drawing.Size(129, 23);
            this.btnHistogramTicks.TabIndex = 17;
            this.btnHistogramTicks.Text = "Times Histogram (ticks)";
            this.btnHistogramTicks.UseVisualStyleBackColor = true;
            this.btnHistogramTicks.Click += new System.EventHandler(this.button5_Click);
            // 
            // GcdEvaluationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 811);
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
            this.Name = "GcdEvaluationForm";
            this.Text = "GcdEvaluationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.evaluationChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNumberRandomPairs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMaximumRandomNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMinimumRandomNumber;
        private System.Windows.Forms.Button btnStartEvaluation;
        private System.Windows.Forms.RichTextBox textAnalysis;
        private System.Windows.Forms.DataVisualization.Charting.Chart evaluationChart;
        private System.Windows.Forms.Button btnNumberOfSteps;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboDiagramMethods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNumberLoops;
        private System.Windows.Forms.Button btnComputingTimesTicks;
        private System.Windows.Forms.Button btnHistogramTicks;
    }
}
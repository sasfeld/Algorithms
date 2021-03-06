﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Homework1
{
    public partial class EvaluationForm : Form
    {
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        protected Dictionary<ExponentialAlgorithm, Evaluation.MethodEvaluationData> evaluationData;
        protected Exponential exponential;
        protected Dictionary<ExponentialAlgorithm, double[]> savedMeans;
        protected Dictionary<ExponentialAlgorithm, double> overallMeans;
        protected Dictionary<ExponentialAlgorithm, double[]> savedVariances;
        protected Boolean getRidOfOutsiders = true;



        public EvaluationForm()
        {
            InitializeComponent();

            this.addComboBoxItems();
        }

        protected void addComboBoxItems()
        {
            ComboboxItem itemAll = new ComboboxItem();
            itemAll.Text = "All methods";
            itemAll.Value = null;

            this.comboDiagramMethods.Items.Add(itemAll);

            foreach (ExponentialAlgorithm method in getEvaluationModel().getMethodsForEvaluation())
            {
                ComboboxItem newItem = new ComboboxItem();
                newItem.Text = "" + method;
                newItem.Value = method;

                this.comboDiagramMethods.Items.Add(newItem);
            }
        }

        protected HashSet<ExponentialAlgorithm> getSelectedAlgorithms()
        {
            ComboboxItem selectedItem = (ComboboxItem)comboDiagramMethods.SelectedItem;

            HashSet<ExponentialAlgorithm> selectedMethods = new HashSet<ExponentialAlgorithm>();

            // if 'All methods' was selected, return all evaluated methods
            if (null == selectedItem || null == selectedItem.Value)
            {
                foreach (ExponentialAlgorithm method in getEvaluationModel().getMethodsForEvaluation())
                {
                    selectedMethods.Add(method);
                }
            }
            else
            {
                selectedMethods.Add((ExponentialAlgorithm)selectedItem.Value);
            }

            return selectedMethods;
        }

        protected Evaluation getEvaluationModel()
        {
            return new Evaluation();
        }

        protected Evaluation getFreshEvaluationModel()
        {
            Evaluation model = this.getEvaluationModel();
            model.setInfoTextBox(textAnalysis);
            model.resetPairs();

            return model;
        }

        protected Exponential getExponentialModel()
        {
            if (null == this.exponential)
            {
                this.exponential = new Exponential();
            }

            return this.exponential;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStartEvaluation_Click(object sender, EventArgs e)
        {
            this.addInfo("Starting evaluation\n");

            Evaluation evaluation = this.getFreshEvaluationModel();
            this.addInputPairs(evaluation);
            evaluation.runEvaluation(convertToInt(textLoops.Text));

            this.evaluationData = evaluation.getEvaluationData();

            this.savedMeans = new Dictionary<ExponentialAlgorithm, double[]>();
            this.overallMeans = new Dictionary<ExponentialAlgorithm, double>();
            this.savedVariances = new Dictionary<ExponentialAlgorithm, double[]>();
             
            foreach (ExponentialAlgorithm algo in evaluation.getMethodsForEvaluation())
            {
                this.showAndSaveMeansAndVariances(algo);
            }
        }

        /// <summary>
        /// Show the means and variances of each algorithm per problem size N.
        /// </summary>
        protected void showAndSaveMeansAndVariances(ExponentialAlgorithm algorithm)
        {
            int numberExperiments = 3;
            double[] means = new double[numberExperiments];
            double[] variances = new double[numberExperiments];

            this.evaluationData[algorithm].setGetRidofOutsiders(true);
            for (int i = 1; i <= numberExperiments; i++)
            {
                int numberOfLoops = convertToInt(this.textLoops.Text);

                double meanInputSize = this.evaluationData[algorithm].calculateMean(i, numberOfLoops);
                double varianceInputSize = this.evaluationData[algorithm].calculateVariance(i, numberOfLoops);

                // print in textfield
                this.addInfo("Mean for " + algorithm + " and N" + i + ": " + meanInputSize);
                this.addInfo("Variance for " + algorithm + " and N" + i + ": " + varianceInputSize);

                means[i-1] = meanInputSize;
                variances[i-1] = varianceInputSize;
            }

            this.savedMeans.Add(algorithm, means);
            this.savedVariances.Add(algorithm, variances);

            double overallMean = ExtendedMath.calculateMean(means);
            this.overallMeans.Add(algorithm, overallMean);

            this.addInfo("Overall mean: " + overallMean);
            this.addInfo("Overall variance: " + ExtendedMath.calculateStandardDeviation(means));
        }

        protected void addInputPairs(Evaluation evaluation)
        {           
            evaluation.addPair(convertToInt(textX1.Text), convertToInt(textN1.Text));
            evaluation.addPair(convertToInt(textX2.Text), convertToInt(textN2.Text));
            evaluation.addPair(convertToInt(textX3.Text), convertToInt(textN3.Text));
        }

        protected void addInfo(String info)
        {
            this.textAnalysis.AppendText(info + "\n");
        }

        protected int convertToInt(String input)
        {
            try
            {
                int outputInt = Convert.ToInt32(input);
                return outputInt;
            }
            catch (FormatException e)
            {
                addInfo("Please type in an valid integer!");
            }
            catch (OverflowException e)
            {
                addInfo("Please type in an valid integer!");
            }

            return 0;
        }

        protected long convertToLong(String input)
        {
            try
            {
                long outputInt = Convert.ToInt64(input);
                return outputInt;
            }
            catch (FormatException e)
            {
                addInfo("Please type in an valid integer!");
            }
            catch (OverflowException e)
            {
                addInfo("Please type in an valid integer!");
            }

            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            } 

            if (getSelectedAlgorithms().Count > 1)
            {
                this.addInfo("Please select an algorithm in the dropdown.");
                return;
            }


            foreach (ExponentialAlgorithm method in getSelectedAlgorithms())
            {
                evaluationChart.Series.Clear();

                evaluationChart.Titles.Clear();
                evaluationChart.Titles.Add("Algorithm " + method);

                this.addTicksHistogram(evaluationChart, method);
            }
        }
        protected void addTicksHistogram(Chart chart, ExponentialAlgorithm method)
        {
            for (int i = 1; i <= 3; i++)
            {
                String seriesName = "N" + i + " = " + this.getNValue(i);

                // prepare legend and type of chart
                chart.Series.Add(seriesName);
                chart.ChartAreas[0].AxisX.Minimum = convertToInt(this.txtMinValue.Text);
                chart.ChartAreas[0].AxisX.Maximum = convertToInt(this.txtMaxValue.Text);
                chart.ChartAreas[0].AxisX.Title = "CPU Time (ticks)";
                chart.ChartAreas[0].AxisY.Title = "Prohability (%)";
                
                chart.Series[seriesName].ChartType = SeriesChartType.Column;
                

                Evaluation.MethodEvaluationData methodData = evaluationData[method];

                SortedDictionary<long, double> ticksHistogram = methodData.getTicksHistogram(i, methodData.getNumberLoops(), true);
                // fill chart with data
                foreach (long ticks in ticksHistogram.Keys)
                {
                    double ticksCount = ticksHistogram[ticks];

                    long enterTicks = ticks;
                    chart.Series[seriesName].Points.AddXY(enterTicks, ticksCount);
                }
            }
        }

        protected String getNValue(int i)
        {
            switch(i) {
                case 1:
                    return this.textN1.Text;
                case 2:
                    return this.textN2.Text;
                case 3: 
                    return this.textN3.Text;
                default:
                    throw new Exception("Unknown n value " + i);
            }
        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            evaluationChart.Series.Clear();

            evaluationChart.Titles.Clear();
            evaluationChart.Titles.Add("Algorithm Growth");

            evaluationChart.ChartAreas[0].AxisX.Minimum = convertToInt(this.txtMinValue.Text);
            evaluationChart.ChartAreas[0].AxisX.Maximum = convertToInt(this.txtMaxValue.Text);
            evaluationChart.ChartAreas[0].AxisX.Title = "Problem Size (N)";
            evaluationChart.ChartAreas[0].AxisY.Title = "CPU Time (ticks)";

            foreach (ExponentialAlgorithm method in getSelectedAlgorithms())
            {

                this.addGrowthDiagram(evaluationChart, method);
            }
        }

        protected void addGrowthDiagram(Chart chart, ExponentialAlgorithm method)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Line;

            for (int i = 1; i <= 3; i++)
            {
                int nValue = convertToInt(this.getNValue(i));

                chart.Series[seriesName].Points.AddXY(nValue, this.savedMeans[method][i-1]);
            }   
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculateX1N1_Click(object sender, EventArgs e)
        {
            long x1 = convertToLong(textX1.Text);
            long n1 = convertToLong(textN1.Text);

            this.calculateExponentialsAndShowResult(x1, n1);
        }      

        private void btnCalculateX2N2_Click(object sender, EventArgs e)
        {
            long x2 = convertToLong(textX2.Text);
            long n2 = convertToLong(textN2.Text);

            this.calculateExponentialsAndShowResult(x2, n2);
        }

        private void btnCalculateX3N3_Click(object sender, EventArgs e)
        {
            long x3 = convertToLong(textX3.Text);
            long n3 = convertToLong(textN3.Text);

            this.calculateExponentialsAndShowResult(x3, n3);
        }

        protected void calculateExponentialsAndShowResult(long x, long n)
        {
            Exponential exponentialModel = this.getExponentialModel();

            foreach (ExponentialAlgorithm method in getSelectedAlgorithms())
            {
                exponentialModel.setAlgorithmToUse(method);
                double exponentialResult = exponentialModel.runAlgorithm(x, n);

                this.addInfo("Calculate exponential using " + method);
                this.addInfo("Result of " + x + "^" + n + " = " + exponentialResult);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);
                        
            this.executeTTest(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);
        }   
  
        protected void executeTTest(ExponentialAlgorithm algorithm1, ExponentialAlgorithm algorithm2)
        {
            TTestResult result = evaluationChart.DataManipulator.Statistics.TTestPaired(0, 0.05, algorithm1.ToString(), algorithm2.ToString());

            this.addInfo("");
            this.addInfo("TTest result for " + algorithm1 + " and " + algorithm2 + ":");
            this.addInfo("TValue: " + result.TValue);
            this.addInfo("P(T<=t) one: " + result.ProbabilityTOneTail);
            this.addInfo("t critical one tail: " + result.TCriticalValueOneTail);
            this.addInfo("P(T<=t) two: " + result.ProbabilityTTwoTail);
            this.addInfo("t critical two tail: " + result.TCriticalValueTwoTail);
            this.addInfo("Mean 1: " + result.FirstSeriesMean);
            this.addInfo("Mean 2: " + result.SecondSeriesMean);
            this.addInfo("");
        }

        protected void executeFTest(ExponentialAlgorithm algorithm1, ExponentialAlgorithm algorithm2)
        {
            FTestResult result = evaluationChart.DataManipulator.Statistics.FTest(0.05, algorithm1.ToString(), algorithm2.ToString());

            this.addInfo("");
            this.addInfo("FTest result for " + algorithm1 + " and " + algorithm2 + ":");
            this.addInfo("FValue: " + result.FValue);
            this.addInfo("P(F<=f) one: " + result.ProbabilityFOneTail);
            this.addInfo("F critical one tail: " + result.FCriticalValueOneTail);
            this.addInfo("Mean 1: " + result.FirstSeriesMean);
            this.addInfo("Mean 2: " + result.SecondSeriesMean);
            this.addInfo("");

        }

        private void drawTTestDiagram(ExponentialAlgorithm algorithm1, ExponentialAlgorithm algorithm2)
        {
            // set diagram title
            evaluationChart.Series.Clear();
            evaluationChart.Titles.Clear();
            evaluationChart.Titles.Add("TTest " + algorithm1 + " and " + algorithm2);

            // draw diagram
            this.addTTestDiagram(evaluationChart, algorithm1);
            this.addTTestDiagram(evaluationChart, algorithm2);
        }

        protected void addTTestDiagram(Chart chart, ExponentialAlgorithm method)
        {
            String seriesName = method.ToString();

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.ChartAreas[0].AxisX.Minimum = convertToInt(this.txtMinValue.Text);
            chart.ChartAreas[0].AxisX.Maximum = convertToInt(this.txtMaxValue.Text);
            chart.ChartAreas[0].AxisX.Title = "Problem Size";
            chart.ChartAreas[0].AxisY.Title = "Mean (CPU ticks)";

            chart.Series[seriesName].ChartType = SeriesChartType.Column;

            foreach (int numberOfExperiment in this.evaluationData[method].getTicks().Keys)
            {
                long measuredCpuTime = this.evaluationData[method].getTicks()[numberOfExperiment];

                // add x: problem size: y: mean for the problem size in current algorithm's series
                chart.Series[seriesName].Points.AddXY(numberOfExperiment, measuredCpuTime);
            }
        }

        private void btnTTestAlg1_Alg3_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);

            this.executeTTest(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);
        }

        private void btnTTest_Alg2_Alg3_Click(object sender, EventArgs e)
        {

            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);

            this.executeTTest(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);
        }

        private void btnFTestAlg1_2_Click(object sender, EventArgs e)
        {
            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);

            this.executeFTest(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION);
        
        }

        private void btnFTest_Alg1_3_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);

            this.executeFTest(ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);
        }

        private void btnFTest_Alg2_3_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            this.drawTTestDiagram(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);

            this.executeFTest(ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTIATION, ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION);
        }
    }
}

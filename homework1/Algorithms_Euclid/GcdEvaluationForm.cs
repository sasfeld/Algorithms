using System;
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
            Evaluation evaluation = new Evaluation();
            evaluation.setInfoTextBox(textAnalysis);

            evaluation.generateRandomPairs(
                convertToInt(textN1.Text),
                convertToInt(textN2.Text), 
                convertToInt(textN3.Text));


            evaluation.runEvaluation();

            this.evaluationData = evaluation.getEvaluationData();

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

            evaluationChart.Series.Clear();

            int n = 0;
            foreach (ExponentialAlgorithm method in getSelectedAlgorithms())
            {
                this.addTicksHistogram(evaluationChart, method, n);

                n++;
            }
        }
        protected void addTicksHistogram(Chart chart, ExponentialAlgorithm method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Column;

            Evaluation.MethodEvaluationData methodData = evaluationData[method];

            SortedDictionary<long, int> ticksHistogram = methodData.getTicksHistogram();
            // fill chart with data
            foreach (long ticks in ticksHistogram.Keys)
            {
                int ticksCount = ticksHistogram[ticks];

                chart.Series[seriesName].Points.AddXY(ticks, ticksCount);
            }
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
           
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
    }
}

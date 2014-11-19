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

        private void EvaluationForm_Load(object sender, EventArgs e)
        {

        }       
    }
}

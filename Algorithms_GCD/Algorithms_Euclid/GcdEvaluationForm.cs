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

namespace Algorithms_Euclid
{
    public partial class GcdEvaluationForm : Form
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

        protected Dictionary<EuclidMethod, EuclidEvaluation.MethodEvaluationData> evaluationData;
        protected EuclidEvaluation evaluationModel;

        public GcdEvaluationForm()
        {
            InitializeComponent();

            this.addComboBoxItems();
        }

        protected EuclidEvaluation getEuclidEvaluationModel()
        {
            return new EuclidEvaluation();
        }

        protected HashSet<EuclidMethod> getSelectedEuclidMethodsForDiagram()
        {
            ComboboxItem selectedItem = (ComboboxItem) comboDiagramMethods.SelectedItem;

            HashSet<EuclidMethod> selectedMethods = new HashSet<EuclidMethod>();

            // if 'All methods' was selected, return all evaluated methods
            if (null == selectedItem || null == selectedItem.Value)
            {
                foreach (EuclidMethod method in getEuclidEvaluationModel().getMethodsForEvaluation())  {
                    selectedMethods.Add(method);
                }
            }
            else
            {
                selectedMethods.Add((EuclidMethod) selectedItem.Value);
            }

            return selectedMethods;
        }

        protected void addComboBoxItems()
        {
            ComboboxItem itemAll = new ComboboxItem();
            itemAll.Text = "All methods";
            itemAll.Value = null;

            this.comboDiagramMethods.Items.Add(itemAll);
            
            foreach (EuclidMethod method in getEuclidEvaluationModel().getMethodsForEvaluation())
            {
                ComboboxItem newItem = new ComboboxItem();
                newItem.Text = "" + method;
                newItem.Value = method;

                this.comboDiagramMethods.Items.Add(newItem);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnStartEvaluation_Click(object sender, EventArgs e)
        {
           

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

        private void btnStartEvaluation_Click_1(object sender, EventArgs e)
        {
            // read and convert input field texts
            int numberPairs = convertToInt(this.textNumberRandomPairs.Text);
            int minimumRandomValue = convertToInt(this.textMinimumRandomNumber.Text);
            int maximumRandomValue = convertToInt(this.textMaximumRandomNumber.Text);
            int numberLoops = convertToInt(this.textNumberLoops.Text);

            this.addInfo("Starting evaluation with " + numberPairs + " number of integer pairs.");

            // start and run evaluation
            this.evaluationModel = new EuclidEvaluation();
            evaluationModel.setInfoTextBox(this.textAnalysis);
            this.evaluationData = evaluationModel.runEvaluation(numberPairs, minimumRandomValue, maximumRandomValue, numberLoops);

            // compute evaluation data
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            Chart numberStepsChart = this.evaluationChart;
            numberStepsChart.Series.Clear();

            int n = 0;
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addNumberStepsForMethod(numberStepsChart, method, n);

                n++;
            }
        }

        protected void addNumberStepsForMethod(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Point;
            chart.Series[seriesName].XValueMember = "(a + b) / 2";
            chart.Series[seriesName].YValueMembers = "number steps";

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];

            // fill chart with data
            foreach (int evaluationNumber in methodData.getNumbersOfSteps().Keys)
            {
                int numberSteps = methodData.getNumbersOfSteps()[evaluationNumber];

                chart.Series[seriesName].Points.AddXY(evaluationNumber, numberSteps);                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            evaluationChart.Series.Clear();

            int n = 0;
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addComputingTimeForMethod(evaluationChart, method, n);

                n++;
            }
        }

        protected void addComputingTimeForMethod(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Point;

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];

            // fill chart with data
            foreach (int evaluationNumber in methodData.getTimesInMilliseconds().Keys)
            {
                long timesInMillseconds = methodData.getTimesInMilliseconds()[evaluationNumber];

                chart.Series[seriesName].Points.AddXY(evaluationNumber, timesInMillseconds);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            evaluationChart.Series.Clear();

            int n = 0;
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addNumberofStepsHistogramForMethod(evaluationChart, method, n);

                n++;
            }
        }

        protected void addNumberofStepsHistogramForMethod(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Column;

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];
            SortedDictionary<int, int> stepsHistogram = methodData.getNumberOfStepsHistogram();
            // fill chart with data
            foreach (int numberSteps in stepsHistogram.Keys)
            {
                int numberStepsCount = stepsHistogram[numberSteps];

                chart.Series[seriesName].Points.AddXY(numberSteps, numberStepsCount);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            evaluationChart.Series.Clear();

            int n = 0;
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addComputingTimeHistogram(evaluationChart, method, n);

                n++;
            }
        }

        protected void addComputingTimeHistogram(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Column;

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];

            SortedDictionary<long, int> timeHistogram = methodData.getComputingTimeHistogram();
            // fill chart with data
            foreach (long computingTime in timeHistogram.Keys)
            {
                int computingTimeCount = timeHistogram[computingTime];

                chart.Series[seriesName].Points.AddXY(computingTime, computingTimeCount);
            }
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
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addTicksHistogram(evaluationChart, method, n);

                n++;
            }
        }

        protected void addTicksHistogram(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Column;

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];

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
            if (null == this.evaluationData)
            {
                this.addInfo("Please start the evaluation first.");
                return;
            }

            evaluationChart.Series.Clear();

            int n = 0;
            foreach (EuclidMethod method in getSelectedEuclidMethodsForDiagram())
            {
                this.addComputingTicksForMethod(evaluationChart, method, n);

                n++;
            }
        }

        protected void addComputingTicksForMethod(Chart chart, EuclidMethod method, int seriesNumber)
        {
            String seriesName = "" + method;

            // prepare legend and type of chart
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = SeriesChartType.Point;

            // draw deviation
            String seriesNameDeviation = "" + method + "deviation";
            chart.Series.Add(seriesNameDeviation);
            chart.Series[seriesNameDeviation].ChartType = SeriesChartType.ErrorBar;

            EuclidEvaluation.MethodEvaluationData methodData = evaluationData[method];

            double deviationDifference = evaluationModel.overallStandardDeviation / 2;
            // fill chart with data
            foreach (int evaluationNumber in methodData.getTicks().Keys)
            {
                long ticks = methodData.getTicks()[evaluationNumber];

                chart.Series[seriesName].Points.AddXY(evaluationNumber, ticks);

                // automatic way
                chart.Series[seriesNameDeviation]["ErrorBarSeries"] = seriesName + ":Y1";
                chart.Series[seriesNameDeviation]["ErrorBarType"] = "StandardDeviation()";

                // manual way
                //double lowestValue = ticks - deviationDifference;
                //double highestValue = ticks + deviationDifference;
                //chart.Series[seriesNameDeviation].Points.AddY(ticks, lowestValue, highestValue);

                // deviation
                //chart.Series[seriesNameDeviation].Points.AddXY(evaluationNumber, ticks);
            }
        }
    }
}

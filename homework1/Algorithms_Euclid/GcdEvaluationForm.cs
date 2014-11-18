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

        public EvaluationForm()
        {
            InitializeComponent();

        }

        protected Evaluation getEuclidEvaluationModel()
        {
            return new Evaluation();
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
           
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

       
    }
}

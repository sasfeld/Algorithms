using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithms_Euclid
{
    public partial class Form1 : Form
    {
        protected GcdEvaluationForm evaluationForm;

        public Form1()
        {
            InitializeComponent();

            evaluationForm = new GcdEvaluationForm();
        }

        private Gcd getEuclid()
        {
            Gcd euclid = new Gcd(getEuclidMethod());
            return euclid;
        }

        private EuclidMethod getEuclidMethod()
        {
            EuclidMethod method = EuclidMethod.MODULO;
            
            if (radioModulo.Checked)
            {
                method = EuclidMethod.MODULO;
            }

            if (radioSubtraction.Checked)
            {
                method = EuclidMethod.SUBTRACTION;
            }

            if (radRecursive.Checked)
            {
                method = EuclidMethod.RECURSIVE;
            }

            if (radPrimeFactorization.Checked)
            {
                method = EuclidMethod.PRIME_FACTORIZATION;
            }

            return method;
        }

        private void btnCalculateEuclid_Click(object sender, EventArgs e)
        {
            String inputNumberA = this.textNumberA.Text;
            String inputNumberB = this.textNumberB.Text;

            long numberA = convertToInt(inputNumberA);
            long numberB = convertToInt(inputNumberB);

            // run euclid
            Gcd euclid = getEuclid();
            long gcd = euclid.gcd(numberA, numberB);
            printResult("GCD is: " + Convert.ToString(gcd) + "\nUsed method: " + getEuclidMethod());
            addInfo("[" + getEuclidMethod() + "] Number of steps: " + euclid.getCount());
            addInfo("[" + getEuclidMethod() + "] Required time in ms: " + euclid.getTime());
        }   

        protected void addInfo(String info)
        {
            this.textAnalysis.AppendText(info + "\n");
        }
        protected long convertToInt(String input)
        {
            try
            {
                long outputInt = Convert.ToInt64(input);
                return outputInt;
            }
            catch (FormatException e)
            {
                printResult("Please type in an valid integer!");
            }
            catch (OverflowException e)
            {
                printResult("Please type in an valid integer!");
            }

            return 0;
        }

        protected void printResult(String errorMessage)
        {
            this.lbResult.Text = errorMessage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textNumberA_TextChanged(object sender, EventArgs e)
        {

        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evaluationForm.Show();
        }
    }
}

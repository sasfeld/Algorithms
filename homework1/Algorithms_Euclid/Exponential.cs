using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Homework1
{
    public enum ExponentialAlgorithm
    {
         SIMPLE_ITERATIVE_EXPONENTITATION,
         SIMPLE_RECURSIVE_EXPONENTITATION,
         IMPROVED_RECURSIVE_EXPONTENTIATION
    }

    /// <summary>
    /// This class offers different algorithms of x ^ n calculation.
    /// 
    /// To use it, set an ExponentialAlgorithm.
    /// </summary>
    public class Exponential
    {
        protected ExponentialAlgorithm algorithmToUse;
        protected long cpuTime;

        public void setAlgorithmToUse(ExponentialAlgorithm toUse)
        {
            this.algorithmToUse = toUse;
        }

        public long getLastMeasuredCpuTime()
        {
            return this.cpuTime;
        }

        public ExponentialAlgorithm getUsedAlgorithm()
        {
            return this.algorithmToUse;
        }

        public double runAlgorithm(long x, long n)
        {
            this.checkIfAlgorithmIsSet();

            double calculatedValue = 0;

            // measure CPU ticks
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            switch (this.algorithmToUse)
            {
                case ExponentialAlgorithm.SIMPLE_ITERATIVE_EXPONENTITATION:
                    calculatedValue = this.func1(x, n);
                    break;
                case ExponentialAlgorithm.SIMPLE_RECURSIVE_EXPONENTITATION:
                    calculatedValue = this.func2(x, n);
                    break;
                case ExponentialAlgorithm.IMPROVED_RECURSIVE_EXPONTENTIATION:
                    calculatedValue = this.func3(x, n);
                    break;
                default:
                    throw new ArgumentException("The given exponential algorithm is not supported yet");
            }
            stopWatch.Stop();
            this.cpuTime = stopWatch.ElapsedTicks;

            return calculatedValue;
        }


        /// <summary>
        /// Calculate the exponential x ^ n by using a simple while loop.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        protected double func1(long x, long n)
        {
            double result = 1;

            while (n > 0)
            {
                result *= x;
                n -= 1;
            }

            return result;
        }

        /// <summary>
        /// Calculate the exponential x ^ n by using a simple recursion that terminates at n = 1.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        protected double func2(long x, long n)
        {
            if (n == 1)
            {
                return x;
            }
            else
            {
                return x * func2(x, n - 1);
            }
        }

        /// <summary>
        /// This own implementation makes usage of the exponential law x ^ (m * n) = (x ^ m) ^ n.
        /// 
        /// Therefore, we try to express x ^ n by x ^ (2 * n/2) = (x ^ 2) ^ n/2.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        protected double func3(long x, long n)
        {
            if (n == 1)
            {
                return x;
            }
            else
            {
                if (n % 2 == 0)
                {
                    return func3( x * x, n / 2);
                }
                else
                {
                    return x * func3(x, n - 1);
                }
            }
        }

        protected void checkIfAlgorithmIsSet()
        {
            if (null == this.algorithmToUse)
            {
                throw new ArgumentNullException("Please set the algorithm to use before running.");
            }
        }

    }
}
